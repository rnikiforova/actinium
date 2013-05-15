using System;
using Wintellect.PowerCollections;

namespace LabirynthGame
{
    public class Labyrinth
    {
        private int size;
        private const int PositionX = 3;
        private const int PositionY = 3;
        private const int MinimumBlockedCellsCount = 30;
        private const int MaximumBlockedCellsCount = 50;
        const char BlockedCellSymbol = 'X';
        const char FreeCellSymbol = '-';
        const char PlayerSymbol = '*';

        private char[,] matrix;

        // TODO - Connect with the field
        public int Size { get; set; }
        
        public Labyrinth(int size)
        {
            this.Size = size;
            this.matrix = this.GenerateLabyrinthMatrix();
        }

        public void PrintLabyrinth()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0,2}", this.matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private char[,] GenerateLabyrinthMatrix()
        {
            char[,] labyrinthMatrix = new char[size, size];
            Random randomGenerator = new Random();
            int labyrinthBlockedCellsCount = randomGenerator.Next(MinimumBlockedCellsCount, MaximumBlockedCellsCount);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
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

            // TODO - Move logic for the player racket into the Player class or Engine class ?
            labyrinthMatrix[PositionY, PositionX] = PlayerSymbol;
            this.AssureReachableExit(labyrinthMatrix);
            
            // TODO - Messages go to Engine.StartGame()
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top");
            Console.WriteLine("scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            return labyrinthMatrix;
        }

        public bool IsGameOver(int playerPositionX, int playerPositionY)
        {
            if ((playerPositionX > 0 && playerPositionX < size - 1) &&
                (playerPositionY > 0 && playerPositionY < size - 1))
            {
                return false;
            }

            return true;
        }

        private void AssureReachableExit(char[,] generatedMatrix)
        {
            Random randumGenerator = new Random();
            int pathX = PositionX;
            int pathY = PositionY;
            int[] directionX = { 0, 0, 1, -1 };
            int[] directionY = { 1, -1, 0, 0 };
            int basicDirections = 4;
            int maximumTimesToChange = 2;

            while (this.IsGameOver(pathX, pathY) == false)
            {
                int direction = randumGenerator.Next(0, basicDirections);
                int times = randumGenerator.Next(0, maximumTimesToChange);

                for (int i = 0; i < times; i++)
                {
                    if (pathX + directionX[direction] >= 0 && pathX + directionX[direction] < size && pathY + directionY[direction] >= 0 &&
                        pathY + directionY[direction] < size)
                    {
                        pathX += directionX[direction];
                        pathY += directionY[direction];

                        if (generatedMatrix[pathY, pathX] == PlayerSymbol)
                        {
                            continue;
                        }
                        generatedMatrix[pathY, pathX] = FreeCellSymbol;
                    }
                }
            }
        }
    }
}