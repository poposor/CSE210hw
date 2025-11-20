/*
Extra Features:
Displays user rank based on points
Eternal goals track number of completions
Screen is cleared between menu options for cleaner ui
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        User user = new User();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("You have " + user.GetPoints() + " points.");
            Console.WriteLine("Your rank is: " + user.GetRank());
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            if (choice == "1")            
            {
                Console.WriteLine("What type of goal?");
                Console.WriteLine("1. One time goal");
                Console.WriteLine("2. Eternal goal");
                Console.WriteLine("3. Checklist goal");
                string type = Console.ReadLine();

                Console.WriteLine("What is the name of your goal?");
                string name = Console.ReadLine();
                Console.WriteLine("What is a short description of it?");
                string description = Console.ReadLine();

                Console.WriteLine("How many points for a completion?");
                int value = int.Parse(Console.ReadLine());

                if (type == "3")
                {
                    Console.WriteLine("How many points for the final completion?");
                    int bonus = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many times must this goal be accomplished?");
                    int target = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, description, value, target, bonus));
                }
                else if (type == "1")
                {
                    goals.Add(new OneTimeGoal(name, description, value));
                }
                else if (type == "2")
                {
                    goals.Add(new EternalGoal(name, description, value));
                }

            }
            else if (choice == "2")            
            {
                Console.Clear();
                Console.WriteLine("Your goals are:");
                foreach (Goal goal in goals)
                {
                    Console.WriteLine(goal.PrintGoal());
                }
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            else if (choice == "3")
            {
                Console.Clear();
                int i = 0;
                foreach (Goal goal in goals)
                {
                    i++;
                    Console.WriteLine(i+". "+goal.PrintGoal());
                }
                Console.WriteLine("What goal did you complete?");
                int select = int.Parse(Console.ReadLine());
                int pointsEarned = goals[select - 1].Complete();
                user.AddPoints(pointsEarned);
                Console.WriteLine("You earned " + pointsEarned + " points!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            else if (choice == "4")
            {
                Console.WriteLine("What file name should it be saved as?");
                string filename = Console.ReadLine();

                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    outputFile.WriteLine(user.GetPoints());
                    foreach (Goal goal in goals)
                    {
                        outputFile.WriteLine(goal.Serialize());
                    }

                }

            }
            else if (choice == "5")
            {
                goals = new List<Goal>();
                user = new User();
                Console.WriteLine("What file name is it saved as?");
                string filename = Console.ReadLine();
                string[] lines = System.IO.File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 1)
                    {
                        user.AddPoints(int.Parse(parts[0]));
                    }
                    else
                    {
                        string[] goalParts = parts[1].Split(',');
                        if (parts[0] == "OneTimeGoal")
                        {
                            goals.Add(new OneTimeGoal(goalParts[0],goalParts[1],int.Parse(goalParts[2]),bool.Parse(goalParts[3])));
                        }
                        else if (parts[0] == "EternalGoal")
                        {
                            goals.Add(new EternalGoal(goalParts[0],goalParts[1],int.Parse(goalParts[2])));
                        }
                        else if (parts[0] == "ChecklistGoal")
                        {
                            goals.Add(new ChecklistGoal(goalParts[0],goalParts[1],int.Parse(goalParts[2]),int.Parse(goalParts[4]),int.Parse(goalParts[5]),int.Parse(goalParts[3])));
                        }
                    }
                }
            }
            else if (choice == "6")
            {
                break;
            }
        }
    }       
}