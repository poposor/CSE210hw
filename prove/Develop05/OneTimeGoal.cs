class OneTimeGoal : Goal
{
    private bool _status;
    public OneTimeGoal(string name, string description, int pointValue, bool status = false) : base(name, description, pointValue)
    {
        _status = status;
    }
    public override int Complete()
    {
        if (_status)
        {
            return 0;
        }
        _status = true;
        return _pointValue;
    }
    public override string GetStatus()
    {
        if (!_status)
        {
            return "[ ]";
        }
        return "[X]";
    }
    public override string PrintGoal()
    {
        return $"{GetStatus()} {_name}: {_description} {_pointValue} points";
    }
    public override string Serialize()
    {
        return $"OneTimeGoal:{_name},{_description},{_pointValue},{_status}";
    }
}