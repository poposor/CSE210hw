abstract class CalendarItem
{
    private string _name;
    private string _description;

    public CalendarItem(string name, string desc)
    {
        _name = name;
        _description = desc;
    }

    public string getName()
    {
        return _name;
    }
    public string getDescription()
    {
        return _description;
    }

    public abstract List<string> getDetails();
    public abstract string getSaveable();
}