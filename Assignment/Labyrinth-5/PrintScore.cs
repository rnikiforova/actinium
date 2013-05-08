 private void PrintScore()
 {
     int counter = 1;

     if (this.scoreBoard.Count == 0)
     {
         Console.WriteLine("The scoreboard is empty.");
     }
   
     else
     {
         foreach (var score in this.scoreBoard)
         {
             var foundScore = this.scoreBoard[score.Key];

             foreach (var equalScore in foundScore)
             {
                 Console.WriteLine("{0}. {1} --> {2}", counter, equalScore, score.Key);

             }
             counter++;
         }
     }
}
