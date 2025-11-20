class ChecklistGoal : Goal
{
    private int _timesComepleted;
    private int _goalCompletions;
    private int _finalValue;
    public ChecklistGoal(string name, string description, int pointValue, int goalCompletions, int finalValue, int timesCompleted = 0) : base(name, description, pointValue)
    {
        _timesComepleted = timesCompleted;
        _goalCompletions = goalCompletions;
        _finalValue = finalValue;
    }
    public override int Complete()
    {
        if (_timesComepleted >= _goalCompletions)
        {
            return 0;
        }
        _timesComepleted++;
        if (_timesComepleted >= _goalCompletions)
        {
            return _finalValue;
        }
        return _pointValue;
    }
    public override string GetStatus()
    {
        return $"[{_timesComepleted}/{_goalCompletions}]";
    }
    public override string PrintGoal()
    {
        return $"{GetStatus()} {_name}: {_description} {_pointValue} points each time and {_finalValue} points upon completion";
    }
    public override string Serialize()
    {
        return $"ChecklistGoal:{_name},{_description},{_pointValue},{_timesComepleted},{_goalCompletions},{_finalValue}";
    }
}