using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathAct = new BreathingActivity("Welcome to the Breathing Activity", "Well Done!!", "breath");
        ReflectionActivity reflectAct = new ReflectionActivity("Welcome to the Reflecting Activity", "Well Done!!", "reflect");
        // Activity ListAct = new ListingActivity("Welcome to the Listing Activity", "Well Done!!", "list");

        bool quit = false;
        int choice;
        while (!quit)
        {

            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            
            Console.Write("What would you like to do? ");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("How long in seconds? ");
                int len = Convert.ToInt32(Console.ReadLine());
                breathAct.StartActivity(len);
            }
            else if (choice == 2)
            {
                Console.Write("How long in seconds? ");
                int len = Convert.ToInt32(Console.ReadLine());
                reflectAct.StartActivity(len);
            }
            else if (choice == 3)
            {
                Console.Write("How long in seconds? ");
                int len = Convert.ToInt32(Console.ReadLine());
                // listAct.StartActivity(len);
            }
            else
            {
                quit = true;
            }
        }
    }
}