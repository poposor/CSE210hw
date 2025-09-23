using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("What is your name?: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number?: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int number)
    {
        return number * number;
    }
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("What is your birth year?: ");
        birthYear = int.Parse(Console.ReadLine());
    }
    static void DisplayResult(string name, int squared, int birthYear)
    {
        Console.WriteLine(name + ", your number squared is " + squared);
        Console.WriteLine(name + ", your will turn " + (2025-birthYear) + " this year");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int birthYear;
        PromptUserBirthYear(out birthYear);
        int squareResult = SquareNumber(userNumber);
        DisplayResult(userName, squareResult, birthYear);

    }
}