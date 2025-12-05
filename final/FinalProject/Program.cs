using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello World2!");
        Calender myCalendar = new Calender();
        myCalendar.load("mycal.txt");

        await myCalendar.SyncExternalCal("https://byui.instructure.com/feeds/calendars/user_MsN9hQyH8YwVHMQaYZlbkVdNPZbBk7aAjhOKLGjy.ics");

        Console.WriteLine(myCalendar.getItems());
    }
}