using System;
using System.Collections.Generic;

public class Reminder : CalendarItem
{
    private DateTime _time;
    public Reminder(string name, string desc, DateTime time) : base(name, desc)
    {
        _time = time;
    }
    public DateTime getTime()
    {
        return _time;
    }
    public override List<string> getDetails()
    {
        List<string> details = new List<string>();
        details.Add(getName());
        details.Add(getDescription());
        details.Add(_time.ToString());
        return details;
    }
    public override DateOnly getDate()
    {
        return DateOnly.FromDateTime(_time);
    }
    public override string getSaveable()
    {
        return $"R|{getName()}|{getDescription()}|{_time}";
    }
}