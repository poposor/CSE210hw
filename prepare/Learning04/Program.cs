using System;

class Program
{
    static void Main(string[] args)
    {
        WritingAssignment myAssignment = new WritingAssignment("Caden", "CSE210", "Fredd");
        Console.WriteLine(myAssignment.GetSummary());
        Console.WriteLine(myAssignment.GetWritingInformation());
    }
}