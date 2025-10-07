public class Journal
{
    public List<Entry> _entries = [];
    public List<string> _prompts = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I want to improve about myself?",
        "What was my biggest success today?",
        "Who am I most grateful for today?",
        "What did I learn today?",
        "What was the best food I ate today?"
    ];

    public void NewEntry()
    {
        string selectedPrompt = _prompts[new Random().Next(0, _prompts.Count)];
        Console.WriteLine(selectedPrompt);
        Console.Write(">");
        string response = Console.ReadLine();
        Console.WriteLine("How would you rate today (1-10)?");
        string rating = Console.ReadLine();

        Entry entry = new Entry();
        entry._content = response;
        entry._rating = rating;
        entry._date = DateTime.Now.ToString();
        entry._prompt = selectedPrompt;

        _entries.Add(entry);
        Console.WriteLine(entry._date);
    }
    public void EditEntry()
    {
        Console.WriteLine("Which entry would you like to edit? (Enter the index)");
        int index = int.Parse(Console.ReadLine());
        if (index >= 0 && index < _entries.Count)
        {
            Console.WriteLine("Enter new content:");
            string response = Console.ReadLine();
            _entries[index]._content = response;
            Console.WriteLine("What is your new rating for that day (1-10)?");
            string rating = Console.ReadLine();
            _entries[index]._rating = rating;

        }
    }
    public void Display()
    {
        Console.WriteLine("Journal Entries:");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"{entry._date} - {entry._prompt}\n{entry._content}\n{entry._rating}/10 for the day\n" );
        }
    }
    public void Load()
    {
        _entries = [];
        string filename = "journal.txt";
        Console.WriteLine("what is the journal file called?");
        filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 4)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._prompt = parts[1];
                entry._content = parts[2];
                entry._rating = parts[3];
                _entries.Add(entry);
            }
        }
    }
    public void Save()
    {
        string filename = "journal.txt";
        Console.WriteLine("what should the journal file be called?");
        filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Date|Prompt|Entry|Rating");
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._content}|{entry._rating}");
            }
            Console.WriteLine($"Journal saved to {filename}");
        }
    }
}