using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        int[][] matrixTable = null;
        int penalties = 0;

        public Board(int rows, int cols)
        {
            Rows = rows;
            Columns = cols;
            Clear();
        }

        public bool PlaceQueen(int row, int col)
        {
            if (matrixTable.Length < row || matrixTable.Length <= 0)
                return false;
            if (matrixTable[0].Length < col || matrixTable[0].Length <= 0)
                return false;
            if (!CanPlaceQueen(row, col))
                penalties++;
            matrixTable[row][col] = 1;
            return true;
        }

        public int GetPenalties()
        {
            return penalties;
        }

        public bool CanPlaceQueen(int row, int col)
        {
            for (int i = 0; i < col; i++)
            {
                if (matrixTable[row][i] == 1)
                {
                    return false;
                }
            }

            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (matrixTable[i][j] == 1)
                {
                    return false;
                }
            }

            for (int i = row, j = col; i < matrixTable.Length && j >= 0; i++, j--)
            {
                if (matrixTable[i][j] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public void Clear()
        {
            if(matrixTable == null)
                matrixTable = new int[Rows][];
            for(int i = 0; i < Rows; i++)
            {
                if (matrixTable[i] == null)
                    matrixTable[i] = new int[Columns];
                else
                    for (int j = 0; j < matrixTable[i].Length; j++)
                    {
                        matrixTable[i][j] = 0;
                    }
            }
            penalties = 0;
        }
    }
}
