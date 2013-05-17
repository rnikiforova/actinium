using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    /// <summary>
    /// The class of Engine makes all the mechanics of the entire game.
    /// </summary>
    public class Engine
    {       
        public Player Player { get;  set; }
        public IRenderer Renderer { get;  set; }
        public IController Controller { get;  set; }
        public ScoreBoard ScoreBoard { get; set; }
        private IField Labyrinth;
        private static bool isGameOn = true;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player">Player instance</param>
        /// <param name="renderer">IRender instance</param>
        /// <param name="controller">IControler instance</param>
        /// <param name="scoreBoard">Scoreboard instance</param>
        public Engine(Player player, IRenderer renderer, IController controller, ScoreBoard scoreBoard)
        {
            this.Player = player;
            this.Renderer = renderer;
            this.Controller = controller;
            this.ScoreBoard = scoreBoard;
        }

        /// <summary>
        /// Starts the game execution
        /// </summary>
        public void StartGame()
        {
            this.Labyrinth = new Labyrinth(7);

            while (isGameOn == true)
            {
                this.Labyrinth.AddObject(this.Player);
                Console.WriteLine(this.Renderer.Render(this.Labyrinth));

                if (IsGameOver(new Coords(this.Player.Row, this.Player.Col)) == true)
                {
                    this.ScoreBoard.Add(this.Player);
                    Console.WriteLine(this.ScoreBoard);
                    this.Player = new Player('*', 3, 3);
                    Console.WriteLine("Game over!");
                    this.StartGame();
                }
                Console.Write("Enter your move (L=left, R=right, U=up, D=down):");
                string currentLine = Console.ReadLine();
                this.ExecuteCommand(currentLine);
            }
        }

        /// <summary>
        /// The method checks the if the coordinates are out of the labyrinth
        /// </summary>
        /// <param name="coords">Coord instance</param>
        /// <returns>Returns true or false</returns>
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

        /// <summary>
        /// The method reads and executes the commands from the user
        /// </summary>
        /// <param name="cmd">input string</param>
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
                        //exit still not implemented corectly
                        isGameOn = false;
                        Console.WriteLine("Good Bye");
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
