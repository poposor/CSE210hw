using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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

        string[] splitLines = _externalCal.Split("\n");
        _externalCal = string.Join("\n", splitLines.Skip(9).ToArray());

        
        string[] events = _externalCal.Split("BEGIN:VEVENT");
        string dateFormat = "yyyyMMddTHHmmssZ";
        foreach (string e in events)
        {
            if (e.Contains("END:VCALENDAR")){}
            else
            {
                string type = "reminder";
                DateTime placeholderTime = DateTime.Now;
                string name = "failed to get name";
                string desc = "failed to get desc";
                DateOnly date = DateOnly.FromDateTime(placeholderTime);
                DateTime start = placeholderTime;
                DateTime end = placeholderTime;
                foreach (string line in e.Split("\n"))
                {
                    
                    if (line.StartsWith("DESCRIPTION:"))
                    {
                        desc = line.Substring("DESCRIPTION:".Length).Trim();
                    }
                    else if (line.StartsWith("DTSTART;VALUE=DATE:"))
                    {
                        type = "AllDay";
                        string dateString = line.Substring("DTSTART;VALUE=DATE:".Length).Trim();
                        date = DateOnly.ParseExact(dateString, "yyyyMMdd", CultureInfo.InvariantCulture);
                    }
                    else if (line.StartsWith("DTSTART:"))
                    {
                        string dateString = line.Substring("DTSTART:".Length).Trim();
                        start = DateTime.ParseExact(dateString, dateFormat, null);
                    }
                    else if (line.StartsWith("DTEND:"))
                    {
                        type = "event";
                        string dateString = line.Substring("DTEND:".Length).Trim();
                        end = DateTime.ParseExact(dateString, dateFormat, null);
                    }
                    else if (line.StartsWith("SUMMARY:"))
                    {
                        name = line.Substring("SUMMARY:".Length).Trim();
                    }
                }
                if (type == "AllDay")
                {
                    items.Add(new AllDay(name, desc, date));
                }
                else if (type == "event")
                {
                    items.Add(new Event(name, desc, start, end));
                }
                else
                {
                    items.Add(new Reminder(name, desc, start));
                }
                
            }
        }
        return items;
    }
}