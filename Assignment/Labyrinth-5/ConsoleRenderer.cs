using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class ConsoleRenderer : IRenderer
    {
        private const int MinimumBlockedCellsCount = 30;
        private const int MaximumBlockedCellsCount = 50;
        const char BlockedCellSymbol = 'X';
        const char FreeCellSymbol = '-';

        public ConsoleRenderer(int size)
        {
            this.Size = size;
            this.matrix = GenerateMatrix();
        }

        public int Size { get; set; }

        private char[,] matrix;

        public void Render()
        {
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    Console.Write("{0,2}", this.matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private char[,] GenerateMatrix()
        {
            char[,] labyrinthMatrix = new char[this.Size, this.Size];
            Random randomGenerator = new Random();
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

            // TODO - Move logic for the player racket into the Player class or Engine class ?
            //labyrinthMatrix[this.player.Y, this.player.X] = PlayerSymbol;
            
            this.AssureReachableExit(labyrinthMatrix);

            // TODO - Messages go to Engine.StartGame()
            //Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top");
            //Console.WriteLine("scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            return labyrinthMatrix;
        }

        public void AddObject(GameObject gameObject)
        {
            if (IsGameOver(gameObject) == false)
            {               
                this.matrix[gameObject.Row, gameObject.Col] = gameObject.Symbol;             
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }           
        }

        // TODO Rename
        public bool IsGameOver(GameObject gameObject)
        {
            if ((gameObject.Col > 0 && gameObject.Col < this.Size - 1) &&
                (gameObject.Row > 0 && gameObject.Row < this.Size - 1) &&
                this.matrix[gameObject.Row, gameObject.Col] != BlockedCellSymbol)
            {
                return false;
            }
       
            return true;
        }


        private void AssureReachableExit(char[,] generatedMatrix)
        {
            Random rand = new Random();

            // Player's position - to be fixed
            int pathX = 3;
            int pathY = 3;
            int[] dirX = { 0, 0, 1, -1 };
            int[] dirY = { 1, -1, 0, 0 };
            int numberOfDirections = 4;
            int maximumTimesToChangeAfter = 2;

            //while (this.IsGameOver(pathX, pathY) == false)
            //{
                int num = rand.Next(0, numberOfDirections);
                int times = rand.Next(0, maximumTimesToChangeAfter);

                for (int d = 0; d < times; d++)
                {
                    if (pathX + dirX[num] >= 0 && pathX + dirX[num] < this.Size && pathY + dirY[num] >= 0 &&
                        pathY + dirY[num] < this.Size)
                    {


                        pathX += dirX[num];



                        pathY += dirY[num];

                        // Refactored: doesn't check player's position
                        if (generatedMatrix[pathY, pathX] != BlockedCellSymbol && generatedMatrix[pathY, pathX] != FreeCellSymbol)
                        {
                            continue;
                        }
                        generatedMatrix[pathY, pathX] = FreeCellSymbol;
                    }
                }
            //}
        }


        public void RemoveObject(Coords coords)
        {
            this.matrix[coords.Row, coords.Col] = '-';
        }
    }
}
