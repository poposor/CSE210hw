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
    public override List<string> GetDetails()
    {
        List<string> details = new List<string>();
        details.Add(GetName());
        details.Add(GetDescription());
        details.Add(_startTime.ToString());
        details.Add(_endTime.ToString());
        return details;
    }
    public override DateOnly GetDate()
    {
        return DateOnly.FromDateTime(_startTime);
    }
    public override string GetSaveable()
    {
        return $"E|{GetName()}|{GetDescription()}|{_startTime}|{_endTime}";
    }
}