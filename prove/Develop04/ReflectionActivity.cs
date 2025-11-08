class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    public ReflectionActivity(string startMsg, string endMsg, string type)
    : base(startMsg, endMsg, type)
    { }
    public void StartActivity(int time)
    {
        length = time;
        StartMessage();

        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("");

        Console.WriteLine("Get ready...");
        Spinner(3000);

        Random rand = new Random();
        int i = rand.Next(_prompts.Count);

        Console.WriteLine(_prompts[i]);
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.WriteLine("You may begin in: ");
        Countdown(5);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(length);

        while (DateTime.Now < endTime)
        {
            i = rand.Next(_questions.Count);
            Console.WriteLine("> "+_questions[i]);
            Spinner(5000);
        }

        _totalTime += length;
        EndMessage();
        Spinner(5000);
    }
}