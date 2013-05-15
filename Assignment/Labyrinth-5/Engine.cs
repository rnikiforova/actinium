using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class Engine
    {       
        
        private char[,] field;
        private int movesCounter;

        public Player Player { get;  set; }
        public IRenderer Renderer { get;  set; }
        public IController Controller { get;  set; }

        public Engine(Player player, IRenderer renderer, IController controller)
        {
            this.Player = player;
            this.Renderer = renderer;
            this.Controller = controller;
        }

        public void StartGame()
        {
            bool isGameOn = true;

            while (isGameOn == true)
            {
                this.Renderer.AddObject(this.Player);                
                this.Renderer.Render();

                Console.Write("Enter your move (L=left, R-right, U=up, D=down):");
                string currentLine = Console.ReadLine();
                this.ExecuteCommand(currentLine);
            }
        }       
        

        private void ExecuteCommand(string cmd)
        {
            switch (cmd.ToUpper())
            {
                case "L":
                case "R":
                case "U":
                case "D":
                    {
                        Coords oldCoords = new Coords(this.Player.Row, this.Player.Col);                        
                        Coords newPlayerCoord = this.Controller.ProcessInput(cmd);      
                        this.Player.Update(newPlayerCoord);

                        if (this.Renderer.IsGameOver(this.Player) == false)
                        {
                            this.Renderer.RemoveObject(oldCoords);
                        }                        
                        
                        break;
                    }
                //case "RESTART":
                //    {
                //        this.PlayerPositionX = px;
                //        this.PlayerPositionY = py;
                //        this.matrix = this.GenerateMatrix();

                //        break;
                //    }
                //case "TOP":
                //    {
                //        this.PrintScore();
                //        break;
                //    }
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

        
    }
}
