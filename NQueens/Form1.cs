using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NQueens
{
    public partial class Form1 : Form
    {
        List<int> queenLocations;
        List<int[]> population;
        const int POPULATION_MAXSIZE = 500;
        public Form1()
        {
            InitializeComponent();
        }

        private void SizeNumeric_ValueChanged(object sender, EventArgs e)
        {
            
            
        }


        public void UpdateMapGrid(int row, int col, int mapWidth, int mapHeight, Graphics g)
        {
            if (g == null) return;
            Point start = new Point();
            Point end = new Point();
            Size cellSize = new Size(mapWidth / col, mapHeight / row);
            Pen pen = new Pen(Color.White, 1);
            for (int i = 0; i < row; i++)
            {
                start.X = 0;
                start.Y = i * cellSize.Height;
                end.X = mapWidth;
                end.Y = i * cellSize.Height;
                g.DrawLine(pen, start, end);
            }
            for (int i = 0; i < col; i++)
            {
                start.X = i * cellSize.Width;
                start.Y = 0;
                end.X = i * cellSize.Width;
                end.Y = mapHeight;
                g.DrawLine(pen, start, end);
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            SizeNumeric_ValueChanged(null, null);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.Clear(pictureBox1.BackColor);
            UpdateMapGrid((int)sizeNumeric.Value, (int)sizeNumeric.Value, pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());
            queenLocations = new List<int>();
            Random random = new Random();
            for (int i = 0; i < sizeNumeric.Value; i++)
            { 
                queenLocations.Add(random.Next((int)sizeNumeric.Value));
            }
            DrawQueenLocations(queenLocations, (int)sizeNumeric.Value, (int)sizeNumeric.Value, pictureBox1.Width, pictureBox1.Height, graphics);
        }

        private void DrawQueenLocations(List<int> locations, int row, int col, int mapWidth, int mapHeight, Graphics g)
        {
            if (g == null) return;
            int x = 0, y = 0;
            Size cellSize = new Size(mapWidth / col, mapHeight / row);
            SolidBrush brush = new SolidBrush(Color.Red);
            for(int i = 0; i <locations.Count; i++)
            {
                x = i * cellSize.Width;
                y = locations[i] * cellSize.Height;
                g.FillEllipse(brush, x, y, cellSize.Width, cellSize.Height);
            }
        }
        
        private void SolveButton_Click(object sender, EventArgs e)
        {

            Random random = new Random();
            if (population == null)
                population = new List<int[]>();
            else
                population.Clear();
            for (int i = 0; i < POPULATION_MAXSIZE; i++)
            {
                int[] set = new int[(int)sizeNumeric.Value];
                for (int j = 0; j < sizeNumeric.Value; j++)
                {
                    set[j] = random.Next((int)sizeNumeric.Value);
                }
                population.Add(set);
            }

            int[][] array_population = population.ToArray();
            Board board = new Board((int)sizeNumeric.Value, (int)sizeNumeric.Value);
            NQueenGA nQueenGA = new NQueenGA(board, 0.1f, (int)sizeNumeric.Value, 0);
            int [][] optimized = nQueenGA.Search(array_population);
            int[] solution = nQueenGA.GetFittestPopulation(optimized);

            List<int> newQueen = new List<int>(solution);
            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.Clear(pictureBox1.BackColor);
            UpdateMapGrid((int)sizeNumeric.Value, (int)sizeNumeric.Value, pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());            
            DrawQueenLocations(newQueen, (int)sizeNumeric.Value, (int)sizeNumeric.Value, pictureBox1.Width, pictureBox1.Height, graphics);
        }

    }
}
