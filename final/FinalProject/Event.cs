using System;
using System.Collections.Generic;

class Event : CalendarItem
{
    private DateTime _startTime;
    private DateTime _endTime;

    public Event(string name, string desc, DateTime start, DateTime end) : base(name, desc)
    {
        _startTime = start;
        _endTime = end;
    }
    public DateTime getStartTime()
    {
        return _startTime;
    }
    public DateTime getEndTime()
    {
        return _endTime;
    }
    public override List<string> getDetails()
    {
        List<string> details = new List<string>();
        details.Add(getName());
        details.Add(getDescription());
        details.Add(_startTime.ToString());
        details.Add(_endTime.ToString());
        return details;
    }
    public override DateOnly getDate()
    {
        return DateOnly.FromDateTime(_startTime);
    }
    public override string getSaveable()
    {
        return $"E|{getName()}|{getDescription()}|{_startTime}|{_endTime}";
    }
}