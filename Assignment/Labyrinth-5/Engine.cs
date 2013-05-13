using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class Engine
    {
        private Labyrinth labyrinth;
        private Player player;
        private char[,] field;

        public void StartGame()
        {

        }

        public void Initialize()
        {
            // labyrinth.matrix = field;
            // this.AddObject(player);
            this.Render();
        }

        public void AddPlayer()
        {
            // this.AddObject();
        }

        public void AddObject()
        {

            //this.field[object.x, object.y] = object.symbol;
        }

        public void Render()
        {
        }

        private void ExecuteCommand(string command, ref int movesCounter)
        {
            switch (command.ToUpper())
            {
                case "L":
                    {
                        movesCounter++;
                        Move(-1, 0);
                        break;
                    }
                case "R":
                    {
                        movesCounter++;
                        Move(1, 0);
                        break;
                    }
                case "U":
                    {
                        movesCounter++;
                        Move(0, -1);
                        break;
                    }
                case "D":
                    {
                        movesCounter++;
                        Move(0, 1);
                        break;
                    }
                case "RESTART":
                    {
                        this.player.X = px;
                        this.player.Y = py;
                        this.StartGame();

                        break;
                    }
                case "TOP":
                    {
                        this.PrintScore();
                        break;
                    }
                case "EXIT":
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine("**Press a key to continue**");
                        Console.ReadKey();
                        break;
                    }
            }
        }

        private void Move(int dirX, int dirY)
        {

            if (this.IsMoveValid(this.player.X + dirX, this.player.Y + dirY) == false)
            {
                return;
            }

            if (this.field[this.player.Y + dirY, this.player.X + dirX] == typeof(BlockedCell))
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                return;
            }
            else
            {
                // Player left cell
                // AddObject(player.x, player.y, freecell)
                this.field[this.player.X, this.player.Y] = FreeCell;

                // Player's new cell
                this.field[this.player.Y + dirY, this.player.X + dirX] = PlayerSign;

                this.player.Y += dirY;
                this.player.X += dirX;
                return;
            }
        }

        private bool IsMoveValid(int x, int y)
        {
            if (x < 0 || x > this.labyrinth.Size - 1 || y < 0 || y > this.labyrinth.Size - 1)
            {
                return false;
            }

            return true;
        }

        
    }
}
