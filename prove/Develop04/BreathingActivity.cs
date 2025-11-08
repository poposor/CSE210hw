class BreathingActivity : Activity
{
    public BreathingActivity(string startMsg, string endMsg, string type)
    : base(startMsg, endMsg, type)
    { }
    public void StartActivity(int time)
    {
        length = time;
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

        _totalTime += length;
        EndMessage();
        Spinner(5000);
    }
}