abstract class Goal
{
    protected int _pointValue;
    protected string _name;
    protected string _description;

    public Goal(string name, string description, int pointValue)
    {
        _name = name;
        _description = description;
        _pointValue = pointValue;
    }
    abstract public int Complete();
    abstract public string GetStatus();
    abstract public string PrintGoal();
    abstract public string Serialize();
}