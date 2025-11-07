class ListingActivity : Activity
{
    // int _timeSpent;
    private int _totalTime = 0;
    public ListingActivity(string startMsg, string endMsg, string type)
    : base(startMsg, endMsg, type)
    { }
    public void StartActivity(int length)
    {
        StartMessage();

        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("");

        

        EndMessage();
        _totalTime += length;
        Console.WriteLine($"You spent {length} seconds on this activity");
        Console.WriteLine($"You have spent {_totalTime} seconds total on this activity");
    }
}