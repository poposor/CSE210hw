class ReflectionActivity : Activity
{
    // int _timeSpent;
    int _totalTime = 0;
    public ReflectionActivity(string startMsg, string endMsg, string type)
    : base(startMsg, endMsg, type)
    { }
    public void StartActivity(int length)
    {
        StartMessage();

        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("");

        int t = 0;
        while (t < length*1000)
        {
            Console.WriteLine("Breathe in");
            Spinner(4000);
            t += 2000;
            Console.WriteLine("");

            if (t < length * 1000)
            {
                Console.WriteLine("Breathe out");
                Spinner(4000);
                t += 2000;
                Console.WriteLine("");
            }
        }

        EndMessage();
        _totalTime += t/1000;
        Console.WriteLine($"You spent {t / 1000} seconds on this activity");
        Console.WriteLine($"You have spent {_totalTime} seconds total on this activity");
    }
}