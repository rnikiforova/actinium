using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace LabirynthGame
{
    public class ScoreBoard
    {

        public List<Player> Players = new List<Player>();
        //public List<Player> Players { get; set; }
        
        public void Add(Player player)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            player.Name = name;
            this.Players.Add(player);
        }

        private List<Player> Sort()
        {
            var sortedPlayers =
                from player in this.Players
                orderby player.Points
                select player;

            List<Player> result = sortedPlayers.ToList();

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.Players = this.Sort();

            for (int player = 0; player < this.Players.Count; player++)
            {
                // 1. Bay Ivan --> 5 
                sb.AppendLine(string.Format("{0} {1} --> {2}", player + 1, this.Players[player].Name, this.Players[player].Points));
            }

            return sb.ToString();
        }

    }
}
