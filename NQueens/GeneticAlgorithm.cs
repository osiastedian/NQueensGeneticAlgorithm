using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    public abstract class GeneticAlgorithm<T>
    {
        public abstract int Fitness(T chromosome);
        public abstract T GetFittestPopulation(T[] population);
        public abstract T[] Search(T[] population);
        public abstract T[] Crossover(T[] population);
        public abstract T Mutate(T param);
    }
   
}
