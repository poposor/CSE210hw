using System;

class Program
{
    static void Main(string[] args)
    {
        String keepPlaying = "yes";
        while (keepPlaying == "yes")
        {
            Random randomGenerator = new Random();
            int goal = randomGenerator.Next(1, 101);
            int guess = -1;
            int guesses = -1;
            while (guess != goal)
            {
                guesses += 1;
                Console.WriteLine("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (guess < goal)
                {
                    Console.WriteLine("Too low");
                }
                else if (guess > goal)
                {
                    Console.WriteLine("Too high");
                }
                else
                {
                    Console.WriteLine("Correct!");
                }
            }
            Console.WriteLine("It took you " + guesses + " tries. Type 'yes' to play again");
            keepPlaying = Console.ReadLine();
        }
    }
}