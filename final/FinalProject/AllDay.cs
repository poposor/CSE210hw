using System;
using System.Collections.Generic;

class AllDay : CalendarItem
{
    private DateOnly _date;
    public AllDay(string name, string desc, DateOnly date) : base(name, desc)
    {
        _date = date;
    }
    public override DateOnly GetDate()
    {
        return _date;
    }
    public override List<string> GetDetails()
    {
        List<string> details = new List<string>();
        details.Add(GetName());
        details.Add(GetDescription());
        details.Add(_date.ToString());
        return details;
    }
    public override string GetSaveable()
    {
        return $"A|{GetName()}|{GetDescription()}|{_date}";
    }
}