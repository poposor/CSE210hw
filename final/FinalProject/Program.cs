using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello World2!");
        Calender myCalendar = new Calender();
        myCalendar.load("bigcal.txt");


    }
}