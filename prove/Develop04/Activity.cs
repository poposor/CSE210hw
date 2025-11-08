using System.ComponentModel.DataAnnotations;

class Activity
{
    private string _startMessage;
    private string _endMessage;
    private string _activityType;

    protected int _totalTime = 0;
    protected int length = 0;

    public Activity(string startMsg, string endMsg, string type)
    {
        _startMessage = startMsg;
        _endMessage = endMsg;
        _activityType = type;
    }
    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine(_startMessage);
    }
    public void EndMessage()
    {
        Console.WriteLine(_endMessage);
        Spinner(3000);
        Console.WriteLine($"You spent {length} seconds on this activity");
        Console.WriteLine($"You have spent {_totalTime} seconds total on this activity");
    }
    string[] spin = [
        "\\",
        "|",
        "/",
        "-",
    ];
    public void Spinner(int time)
    {
        Console.Write("-");
        for (int i = 0; i < time / 500; i++)
        {
            Thread.Sleep(250);

            Console.Write("\b \b");
            Console.Write(spin[i % 4]);
        }
        Console.Write("\b \b");
    }
    public void Countdown(int time)
    {
        for (int i = time; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}