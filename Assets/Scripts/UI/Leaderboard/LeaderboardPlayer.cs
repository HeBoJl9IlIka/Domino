public class LeaderboardPlayer
{
    public int Rank { get; private set; }
    public string Name { get; private set; }
    public int Score { get; private set; }

    public void SetRank(int rank)
    {
        Rank = rank;
    }
    
    public void SetName(string name)
    {
        Name = name;
    }
    
    public void SetScore(int score)
    {
        Score = score;
    }
}
