 private void UpdateScoreBoard(int currentNumberOfMoves)
{
    string userName = string.Empty;

    if (this.scoreBoard.Count < 5)
    {
        while (userName == string.Empty)
        {
            Console.WriteLine("**Please put down your name:**");
            userName = Console.ReadLine();
        }
        this.scoreBoard.Add(currentNumberOfMoves, userName);
    }
    else
    {
        int worstScore = this.GetWorstScore();
        if (currentNumberOfMoves <= worstScore)
        {
            if (this.scoreBoard.ContainsKey(currentNumberOfMoves) == false)
            {
                this.scoreBoard.Remove(worstScore);
            }
            while (userName == string.Empty)
            {
                Console.WriteLine("**Please put down your name:**");
                userName = Console.ReadLine();
            }
            this.scoreBoard.Add(currentNumberOfMoves, userName);
        }
    }
}
