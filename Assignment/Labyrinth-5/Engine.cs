using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class Engine
    {       
        public Player Player { get;  set; }
        public IRenderer Renderer { get;  set; }
        public IController Controller { get;  set; }
        public ScoreBoard ScoreBoard { get; set; }

        private IField Labyrinth;        
        
        public Engine(Player player, IRenderer renderer, IController controller, ScoreBoard scoreBoard)
        {
            this.Player = player;
            this.Renderer = renderer;
            this.Controller = controller;
            this.ScoreBoard = scoreBoard;
        }

        public void StartGame()
        {
            bool isGameOn = true;
            this.Labyrinth = new Labyrinth(7);

            while (isGameOn == true)
            {
                this.Labyrinth.AddObject(this.Player);                
                this.Renderer.Render(this.Labyrinth);

                if (IsGameOver(new Coords(this.Player.Row, this.Player.Col)) == true)
                {
                    this.ScoreBoard.Add(this.Player);
                    Console.WriteLine(this.ScoreBoard);
                    Console.WriteLine("Game over!");
                    break;
                }

                //if (IsGameEnded(new Coords(this.Player.Row, this.Player.Col)) == true)
                //{
                //    Console.WriteLine("Ended!");
                //    break;
                //}

                Console.Write("Enter your move (L=left, R=right, U=up, D=down):");
                string currentLine = Console.ReadLine();
                this.ExecuteCommand(currentLine);
            }
        }

        private bool IsGameOver(Coords coords)
        {                        
           if ((coords.Col > 0 && coords.Col < this.Labyrinth.Size - 1) &&
                (coords.Row > 0 && coords.Row < this.Labyrinth.Size - 1))
           {
               return false;
           }
           else if (coords.Row == this.Labyrinth.Size - 1 || coords.Row == 0 || coords.Col == this.Labyrinth.Size - 1 || coords.Col == 0)
           {
               return true;
           }

           return true;
        }

        private bool IsGameEnded(Coords coords)
        {
            if (coords.Row == this.Labyrinth.Size - 1 || coords.Row == 0 || coords.Col == this.Labyrinth.Size - 1 || coords.Col == 0)
            {
                return true;
            }

            return false;
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
                        Coords playerDirection = this.Controller.ProcessInput(cmd);
                        
                        Coords newPlayerPosition = new Coords(this.Player.Row + playerDirection.Row, this.Player.Col + playerDirection.Col);

                        if (!this.Labyrinth.IsPositionAvailable(newPlayerPosition))
                        {
                            Console.WriteLine("Invalid move");
                        }
                        else
                        {
                            this.Player.Update(newPlayerPosition);
                            this.Labyrinth.RemoveObject(oldCoords);
                        }
                        
                        break;
                    }
                case "RESTART":
                    {
                        this.Player.Reset();
                        this.StartGame();                                                

                        break;
                    }
                case "TOP":
                    {
                        Console.WriteLine(this.ScoreBoard);
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

        
    }
}
