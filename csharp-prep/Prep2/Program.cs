using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        int grade = int.Parse(Console.ReadLine());

        string letter;

        if (grade >= 90)
        {
            letter = "A";
            if (grade >= 3)
            {
                grade = 95;
            }
        }
            else if (grade >= 80)
            {
                letter = "B";
            }
            else if (grade >= 70)
            {
                letter = "C";
            }
            else if (grade >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
                // Terrible edge case prevention
                grade = 15;
            }
        string gradeSign = "";
        if (grade % 10 >= 7)
        {
            gradeSign = "+";
        }
        else if (grade % 10 < 3)
        {
            gradeSign = "-";
        }
        Console.WriteLine(letter+gradeSign);

        if (grade >= 70)
        {
            Console.WriteLine("You passed the course!");
        }
        else
        {
            Console.WriteLine("You failed the course. Better luck next time.");
        }
    }
}