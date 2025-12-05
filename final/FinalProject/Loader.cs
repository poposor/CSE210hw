using System;
using System.IO;

class Loader
{
    private string _fileName;

    public List<CalendarItem> load(string url)

    {
        _fileName = url;
        try
        {
            string fileContents = File.ReadAllText(_fileName);

            List<CalendarItem> items = new List<CalendarItem>();
            string[] events = fileContents.Split("\n");
            foreach (string e in events)
            {
                string[] parts = e.Split("|");
                if (parts[0] == "A")
                {
                    items.Add(new AllDay(parts[1], parts[2], DateOnly.Parse(parts[3])));
                }
                else if(parts[0] == "R"){
                    items.Add(new Reminder(parts[1], parts[2], DateTime.Parse(parts[3])));
                }
                else if(parts[0] == "E")
                {
                    items.Add(new Event(parts[1], parts[2], DateTime.Parse(parts[3]), DateTime.Parse(parts[4])));
                }
                else if(parts[0] == "G")
                {
                    items.Add(new Goal(parts[1], parts[2], bool.Parse(parts[3])));
                }
            }
            return items;
            // Console.WriteLine(fileContents);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{_fileName}' was not found.");
            return new List<CalendarItem>();
        }
    }
    public void save(string url, List<CalendarItem> items)
    {
        _fileName = url;
        List<string> lines = new List<string>();
        foreach (CalendarItem item in items)
        {
            lines.Add(item.getSaveable());
        }
        File.WriteAllLines(_fileName, lines);
    }
}