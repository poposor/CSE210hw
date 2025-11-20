class User
{
    private int _points;
    private List<string> _ranks;

    public User()
    {
        _points = 0;
        _ranks = new List<string> { "Beginner", "Intermediate", "Advanced", "Expert" };
    }
    public int GetPoints()
    {
        return _points;
    }
    public void AddPoints(int points)
    {
        _points += points;
    }
    public string GetRank()
    {
        int rankIndex = _points / 100;
        if (rankIndex >= _ranks.Count)
        {
            rankIndex = _ranks.Count - 1;
        }
        return _ranks[rankIndex];
    }
}