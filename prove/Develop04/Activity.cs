using System.ComponentModel.DataAnnotations;

class Activity
{
    private string _startMessage;
    private string _endMessage;
    private string _activityType;
    private int _length;

    public Activity(string startMsg, string endMsg, string type)
    {
        _startMessage = startMsg;
        _endMessage = endMsg;
        _activityType = type;
    }
    public void StartMessage()
    {
        Console.WriteLine(_startMessage);
    }
    public void EndMessage()
    {
        Console.WriteLine(_endMessage);
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
            Console.Write(spin[i%4]);
        }
    }
}