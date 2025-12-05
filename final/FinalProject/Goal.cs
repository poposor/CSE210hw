class Goal : CalendarItem
{
    private bool _complete;
    public Goal(string name, string desc) : base(name, desc)
    {
        _complete = false;
    }
    public Goal(string name, string desc, bool complete) : base(name, desc)
    {
        _complete = complete;
    }
    public bool isComplete()
    {
        return _complete;
    }
    public void CompleteGoal()
    {
        _complete = true;
    }
    public override List<string> getDetails()
    {
        List<string> details = new List<string>();
        details.Add(getName());
        details.Add(getDescription());
        details.Add(_complete.ToString());
        return details;
    }
    public override string getSaveable()
    {
        return $"G|{getName()}|{getDescription()}|{_complete}";
    }
}