using System;

class Program
{
    static void Main(string[] args)
    {
        string lastName;
        string firstName;

        Console.Write("What is your first name?");
        firstName = Console.ReadLine();

        Console.Write("What is your last name?");
        lastName = Console.ReadLine();

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}