class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public ListingActivity(string startMsg, string endMsg, string type)
    : base(startMsg, endMsg, type)
    { }
    public void StartActivity(int time)
    {
        length = time;
        StartMessage();

        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("");

        Random rand = new Random();
        int i = rand.Next(prompts.Count);
        Console.WriteLine("Get ready...");
        Spinner(3000);

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine(prompts[i]);
        Console.WriteLine("You may begin in: ");
        Countdown(5);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(length);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            count++;
        }

        Console.WriteLine($"You listed {count} items!");

        _totalTime += length;
        EndMessage();
        Spinner(5000);
    }
}