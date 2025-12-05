class Sync
{
    private string _externalCal;

    public async Task GetExternalCal(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                _externalCal = await client.GetStringAsync(url);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error getting Calender: {e.Message}");
            }
        }
    }
    public List<CalendarItem> AddExternalCal(List<CalendarItem> items)
    {
        string fileContents;
        string _fileName = "externalCal.ics";
        try
        {
            fileContents = File.ReadAllText(_fileName);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{_fileName}' was not found.");
            return new List<CalendarItem>();
        }
        _externalCal = fileContents;
        string[] events = _externalCal.Split("BEGIN:VEVENT");
        foreach (string e in events)
        {
            Console.WriteLine(e + "\n CHANGE IN EVENTS -------------------------------- \n");
            
        }
        return items;
    }
}