using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace LabirynthGame
{
    /// <summary>
    /// ScoreboardClass
    /// </summary>
    public class ScoreBoard
    {
        public const int PlayersCount = 5;
        public List<Player> Players = new List<Player>();
        
        /// <summary>
        /// The method adds the name of the player when the game is over
        /// </summary>
        /// <param name="player">Player</param>
        public void Add(Player player)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            player.Name = name;
            this.Players.Add(player);
        }

        /// <summary>
        /// Sorts the list of results of all player 
        /// </summary>
        /// <returns>list of players</returns>
        private List<Player> Sort()
        {
            var sortedPlayers =
                from player in this.Players
                orderby player.Points
                select player;

            List<Player> result = sortedPlayers.ToList();

            return result;
        }

        /// <summary>
        /// Overrideng to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.Players = this.Sort();

            int playersCount = PlayersCount;

            if (this.Players.Count < PlayersCount)
            {
                playersCount = this.Players.Count;
            }

            for (int player = 0; player < playersCount; player++)
            {
                sb.AppendLine(string.Format("{0} {1} --> {2}", player + 1, this.Players[player].Name, this.Players[player].Points));
            }

            return sb.ToString();
        }
    }
}
