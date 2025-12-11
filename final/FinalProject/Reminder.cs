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
    public override List<string> GetDetails()
    {
        List<string> details = new List<string>();
        details.Add(GetName());
        details.Add(GetDescription());
        details.Add(_time.ToString());
        return details;
    }
    public override DateOnly GetDate()
    {
        return DateOnly.FromDateTime(_time);
    }
    public override string GetSaveable()
    {
        return $"R|{GetName()}|{GetDescription()}|{_time}";
    }
}