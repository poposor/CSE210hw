using System;
using System.Collections.Generic;

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
    public bool IsComplete()
    {
        return _complete;
    }
    public void CompleteGoal()
    {
        _complete = true;
    }
    public override List<string> GetDetails()
    {
        List<string> details = new List<string>();
        details.Add(GetName());
        details.Add(GetDescription());
        details.Add(_complete.ToString());
        return details;
    }
    public override DateOnly GetDate()
    {
        return new DateOnly(1932, 11, 2);
    }
    public override string GetSaveable()
    {
        return $"G|{GetName()}|{GetDescription()}|{_complete}";
    }
}