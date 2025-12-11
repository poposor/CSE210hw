using System;
using System.Collections.Generic;
public abstract class CalendarItem
{
    private string _name;
    private string _description;

    public CalendarItem(string name, string desc)
    {
        _name = name;
        _description = desc;
    }

    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }

    public abstract List<string> GetDetails();
    public abstract DateOnly GetDate();
    public abstract string GetSaveable();
}