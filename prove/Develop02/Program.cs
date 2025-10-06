using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        Journal journal = new Journal();

        bool quit = false;
        int choice;
        while (!quit)
        {

            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                journal.NewEntry();
            }
            else if (choice == 2)
            {
                journal.Display();
            }
            else if (choice == 3)
            {
                journal.Load();
            }
            else if (choice == 4)
            {
                journal.Save();
            }
            else
            {
                quit = true;
            }
        }
        
    }
}