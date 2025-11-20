class EternalGoal : Goal
{
    private int _timesCompleted;
    public EternalGoal(string name, string description, int pointValue) : base(name, description, pointValue)
    {
        _timesCompleted = 0;
    }
    public override int Complete()
    {
        _timesCompleted++;
        return _pointValue;
    }
    public override string GetStatus()
    {
        return $"[{_timesCompleted}]";
    }
    public override string PrintGoal()
    {
        return $"{GetStatus()} {_name}: {_description} {_pointValue} points";
    }
    public override string Serialize()
    {
        return $"EternalGoal:{_name},{_description},{_pointValue},{_timesCompleted}";
    }
}