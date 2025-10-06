public class Journal
{
    public List<Entry> _entries = [];
    public List<string> _prompts = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    ];

    public void NewEntry()
    {
        string selectedPrompt = _prompts[new Random().Next(0, _prompts.Count)];
        Console.WriteLine(selectedPrompt);
        Console.Write(">");
        string response = Console.ReadLine();

        Entry entry = new Entry();
        entry._content = response;
        entry._date = DateTime.Now.ToString();
        entry._prompt = selectedPrompt;

        _entries.Add(entry);
        Console.WriteLine(entry._date);
    }
    public void Display()
    {
        Console.WriteLine("display");
    }
    public void Load()
    {
        Console.WriteLine("Load");
    }
    public void Save()
    {
        Console.WriteLine("save");
    }
}