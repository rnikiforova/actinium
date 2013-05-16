using System;
using Wintellect.PowerCollections;

namespace LabirynthGame
{
    public class Labyrinth : IField
    {

        private const int MinimumBlockedCellsCount = 30;
        private const int MaximumBlockedCellsCount = 50;
        const char BlockedCellSymbol = 'X';
        const char FreeCellSymbol = '-';

        public Labyrinth(int size)
        {
            this.Size = size;
            this.matrix = this.GenerateMatrix();
        }

        public int Size { get; private set; }

        private char[,] matrix;       

        private static Random randomGenerator = new Random();
        private char[,] GenerateMatrix()
        {
            char[,] labyrinthMatrix = new char[this.Size, this.Size];
            
            int labyrinthBlockedCellsCount = randomGenerator.Next(MinimumBlockedCellsCount, MaximumBlockedCellsCount);

            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    int cellNumber = randomGenerator.Next(0, 100);
                    if (cellNumber < labyrinthBlockedCellsCount)
                    {
                        labyrinthMatrix[row, col] = BlockedCellSymbol;
                    }
                    else
                    {
                        labyrinthMatrix[row, col] = FreeCellSymbol;
                    }
                }
            }
                       
          

            char[,] copyMatrix = (char[,])labyrinthMatrix.Clone();

            char[,] testMatrix = new char[,] {
                 {'-', 'X', '-', '-', 'X', 'X', '-'},
                 {'-', '-', '-', '-', '-', '-', 'X'},
                 {'-', '-', '-', '-', '-', '-', 'X'},
                 {'X', '-', '-', 'X', '-', '-', '-'},
                 {'-', '-', '-', '-', '-', '-', '-'},
                 {'-', '-', '-', 'X', '-', '-', '-'},
                 {'-', '-', '-', 'X', '-', 'X', 'X'}
            };

            bool exit = this.AssureReachableExit(copyMatrix, 3, 3);

            if (exit == false)
            {
                GenerateMatrix();
            }

            if (labyrinthMatrix[3, 3] != FreeCellSymbol)
            {
                labyrinthMatrix[3, 3] = FreeCellSymbol;    
            }            

            return labyrinthMatrix;
        }

        public void AddObject(GameObject gameObject)
        {
            if (this.matrix[gameObject.Row, gameObject.Col] != BlockedCellSymbol)
            {               
                this.matrix[gameObject.Row, gameObject.Col] = gameObject.Symbol;                
            }
            else
            {
                // Exception
                Console.WriteLine("Invalid move");
            }                
           
        }

        public bool IsPositionAvailable(Coords coords)
        {
            if (this[coords.Row, coords.Col] == BlockedCellSymbol)
            {
                return false;
            }

            return true;
        }

        private bool AssureReachableExit(char[,] generatedMatrix, int row, int col)
        {
            if (row > generatedMatrix.GetLength(0) || row < 0 || col > generatedMatrix.GetLength(1) || col < 0)
            {
                // We are out
                return false;
            }

            if (row == generatedMatrix.GetLength(0) - 1 || col == generatedMatrix.GetLength(1) - 1)
            {
                // Corner
                return true;
            }

            if (generatedMatrix[row, col] == BlockedCellSymbol)
            {
                return false;
            }

            // Mark visited
            generatedMatrix[row, col] = BlockedCellSymbol;

            // Invoke recursion to explore all possible directions
              AssureReachableExit(generatedMatrix, row, col - 1); // left
              AssureReachableExit(generatedMatrix, row - 1, col); // up
              AssureReachableExit(generatedMatrix, row, col + 1); // right
              AssureReachableExit(generatedMatrix, row + 1, col); // down

              return true;
        }

        public void RemoveObject(Coords coords)
        {
            this.matrix[coords.Row, coords.Col] = '-';
        }

        public char this[int row, int col]
        {
            // TODO: VALIDATION
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                this.matrix[row, col] = value;
            }
        }

    }
}