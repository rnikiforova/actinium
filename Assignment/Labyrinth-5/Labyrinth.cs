using System;
using Wintellect.PowerCollections;

namespace LabirynthGame
{
    /// <summary>
    /// The Labyrinth class which generates the playfield-labyrinth and assuring the correct state of the labyrint
    /// </summary>
    public class Labyrinth : IField
    {
        private const int MinimumBlockedCellsCount = 30;
        private const int MaximumBlockedCellsCount = 50;
        const char BlockedCellSymbol = 'X';
        const char FreeCellSymbol = '-';
        private int size;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">size</param>
        public Labyrinth(int size)
        {
            this.Size = size;
            this.matrix = this.GenerateMatrix();
        }

        public int Size {
            get
            {
                return this.size;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("The size of the labyrinth cannot be negative or zero.");
                }
                this.size = value;
            }
        }

        private char[,] matrix;       

        /// <summary>
        /// Generates randum elements for the labyrinth matrix
        /// </summary>
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

        /// <summary>
        /// Move object Player in to tha labyrinth
        /// </summary>
        /// <param name="gameObject">Player instance</param>
        public void AddObject(GameObject gameObject)
        {
            if (this.matrix[gameObject.Row, gameObject.Col] != BlockedCellSymbol)
            {               
                this.matrix[gameObject.Row, gameObject.Col] = gameObject.Symbol;                
            }
            else
            {
                Console.WriteLine("Invalid move");
            }
        }

        /// <summary>
        /// The method checks the availability of the next cell 
        /// </summary>
        /// <param name="coords">Coordinates</param>
        /// <returns>Returns true or false</returns>
        public bool IsPositionAvailable(Coords coords)
        {
            if (this[coords.Row, coords.Col] == BlockedCellSymbol)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The methods checks there is at least one exit from the labyrinth with recursion
        /// </summary>
        /// <param name="generatedMatrix">matrix labyrinth</param>
        /// <param name="row">row</param>
        /// <param name="col">cal</param>
        /// <returns></returns>
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

        /// <summary>
        /// The method removes the last position of the player
        /// </summary>
        /// <param name="coords">Coordinates</param>
        public void RemoveObject(Coords coords)
        {
            this.matrix[coords.Row, coords.Col] = '-';
        }

        /// <summary>
        /// The methods sets custom matrix indeces to the class
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="col">col</param>
        /// <returns>char</returns>
        public char this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The index cannot be negative.");
                }
                this.matrix[row, col] = value;
            }
        }

        public void TestMatrix(char[,] testMatrix)
        {
            this.matrix = testMatrix;
        }

    }
}