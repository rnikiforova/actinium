using System;
using Wintellect.PowerCollections;

namespace LabirynthGame
{
    public class Labyrinth
    {
        private const int LabyrinthSize = 7;
        private const int PositionX = 3;
        private const int PositionY = 3;
        private const int MinimumBlockedCellsCount = 30;
        private const int MaximumBlockedCellsCount = 50;

        const char BlockedCellSymbol = 'X';
        const char FreeCellSymbol = '-';
        const char PlayerSymbol = '*';

        
        private char[,] labyrinth;
        private OrderedMultiDictionary<int, string> scoreBoard;


        public Labyrinth()
        {
            this.labyrinth = this.GenerateLabyrinthMatrix();
            this.scoreBoard = new OrderedMultiDictionary<int, string>(true);
        }

        public void PrintLabirynth()
        {
            for (int row = 0; row < LabyrinthSize; row++)
            {
                for (int col = 0; col < LabyrinthSize; col++)
                {
                    Console.Write("{0,2}", this.labyrinth[row, col]);
                }
                Console.WriteLine();
            }
        }
        private char[,] GenerateLabyrinthMatrix()
        {
            char[,] labyrinthMatrix = new char[LabyrinthSize, LabyrinthSize];
            Random randumGenerator = new Random();
            int labyrinthBlockedCellsCount = randumGenerator.Next(MinimumBlockedCellsCount, MaximumBlockedCellsCount);

            for (int row = 0; row < LabyrinthSize; row++)
            {
                for (int col = 0; col < LabyrinthSize; col++)
                {
                    int cellNumber = randumGenerator.Next(0, 100);
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

            labyrinthMatrix[PositionY, PositionX] = PlayerSymbol;
            this.AssureReachableExit(labyrinthMatrix);
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top");
            Console.WriteLine("scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            return labyrinthMatrix;
        }

        public bool IsGameOver(int playerPositionX, int playerPositionY)
        {
            if ((playerPositionX > 0 && playerPositionX < LabyrinthSize - 1) &&
                (playerPositionY > 0 && playerPositionY < LabyrinthSize - 1))
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
            int directions = 4;
            int maximumTimesToChange = 2;

            while (this.IsGameOver(pathX, pathY) == false)
            {
                int num = randumGenerator.Next(0, directions);
                int times = randumGenerator.Next(0, maximumTimesToChange);

                for (int d = 0; d < times; d++)
                {
                    if (pathX + directionX[num] >= 0 && pathX + directionX[num] < LabyrinthSize && pathY + directionY[num] >= 0 &&
                        pathY + directionY[num] < LabyrinthSize)
                    {
                        pathX += directionX[num];
                        pathY += directionY[num];

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
