using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    class NQueenGA: GeneticAlgorithm<int []>
    {
        NQueenFitnessFunction fitnessFunction;
        int crossOverLimit;
        int mostFitTargetScore;
        Random random;
        float mutationChance = 0.0f;
        Board board;

        public NQueenGA(Board board, float mutationChance, int crossOverLimit, int mostFitTargetScore) {
            random = new Random();
            this.mutationChance = mutationChance;
            this.crossOverLimit = crossOverLimit;
            this.mostFitTargetScore = mostFitTargetScore;
            this.board = board;
            fitnessFunction = new NQueenFitnessFunction(board);
        }

        public override int[][] Crossover(int[][] population)
        {
            List<int[]> newPopulation = new List<int[]>();
            for (int i = 0; i < population.Length; i++)
            {
                int[] firstParent = population[random.Next(population.Length)];
                int[] secondParent = population[random.Next(population.Length)];
                int crossoverPoint = random.Next(crossOverLimit);
                Array.Copy(firstParent, 0, firstParent, 0, population[i].Length); // Arrays.copyOfRange(firstParent, 0, crossoverPoint);
                Array.Copy(secondParent, crossoverPoint, firstParent, crossoverPoint, population[i].Length - crossoverPoint);
                int[] result = new int[population[i].Length];
                Array.Copy(firstParent, result, firstParent.Length);
                result = Mutate(result);
                newPopulation.Add(result);
            }
            return newPopulation.ToArray<int[]>();
        }

        public override int Fitness(int[] chromosome)
        {
            return fitnessFunction.Fitness(chromosome);
        }

        public override int[] GetFittestPopulation(int[][] population)
        {
            List<IntArrayComparableContainer<int[]>> fitness = new List<IntArrayComparableContainer<int[]>>();
            foreach (int[] chromosome in population)
            {
                IntArrayComparableContainer<int[]> container = new IntArrayComparableContainer<int[]>();
                container.Object = chromosome;
                container.Value = this.Fitness(chromosome);
                fitness.Add(container);
            }
            fitness.Sort();
            return fitness.First().Object;
        }

        public override int[] Mutate(int[] param)
        {
            if (mutationChance > random.NextDouble())
            {
                param[random.Next(param.Length)] = random.Next(board.Columns);
            }
            return param;
        }

        public override int[][] Search(int[][] population)
        {
            return SearchHelper(1000000, population);
        }
        int[][] halfMostFit = null;
        private int[][] SearchHelper(int mostFit, int[][] population)
        {
            if (mostFit <= mostFitTargetScore)
                return population;
            else
            {
                List<IntArrayComparableContainer<int[]>> fitness = new List<IntArrayComparableContainer<int[]>>();
                foreach (int[] chromosome in population)
                {
                    IntArrayComparableContainer<int[]> container = new IntArrayComparableContainer<int[]>();
                    container.Object = chromosome;
                    container.Value = this.Fitness(chromosome);
                    fitness.Add(container);
                }
                fitness.Sort();
                if (halfMostFit == null)
                    halfMostFit = new int[fitness.Count / 2][];
                for (int i = 0, count = fitness.Count / 2; i < count; i++)
                {
                    halfMostFit[i] = new int[fitness[i].Object.Length];
                    halfMostFit[i] = fitness[i].Object;
                }
                int[][] newPopulation = this.Crossover(halfMostFit);
                Array.Copy(newPopulation, 0, population, 0, population.Length / 2);                
                int[] mostFitChromosome = GetFittestPopulation(population);
                int mostFitChromosomeScore = Fitness(mostFitChromosome);
                return SearchHelper(mostFitChromosomeScore, population);
            }
        }

        class NQueenFitnessFunction : IFitnessFunction<int []>
        {
            public Board Board { get; set; }
            public NQueenFitnessFunction(Board board)
            {
                this.Board = board;
            }

            public int Fitness(int[] chromosome)
            {
                int row = 0, col = 0;
                for (int i = 0; i < chromosome.Length; i++)
                {
                    row = chromosome[i];
                    col = i;
                    Board.PlaceQueen(row, col);
                }

                int score = Board.GetPenalties();
                Board.Clear();
                return score;
                
            }
        }

        class IntArrayComparableContainer<T> : IComparable
        {
            public T Object { get; set; }
            public int Value { get; set; }
            public IntArrayComparableContainer()
            {

            }
            public int CompareTo(object obj)
            {
                if (this.Value == ((IntArrayComparableContainer<T>)obj).Value)
                { 
                    return 0;
                }
                else if ((this.Value) > ((IntArrayComparableContainer<T>)obj).Value)
                { 
                    return 1;
                }
                else
                { 
                    return -1;
                }
            }
        }
    }
}
