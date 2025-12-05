class AllDay : CalendarItem
{
    private DateOnly _date;
    public AllDay(string name, string desc, DateOnly date) : base(name, desc)
    {
        _date = date;
    }
    public DateOnly getDate()
    {
        return _date;
    }
    public override List<string> getDetails()
    {
        List<string> details = new List<string>();
        details.Add(getName());
        details.Add(getDescription());
        details.Add(_date.ToString());
        return details;
    }
    public override string getSaveable()
    {
        return $"A|{getName()}|{getDescription()}|{_date}";
    }
}