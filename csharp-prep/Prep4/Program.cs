using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> yourList = new List<int>();
        int last = -1;
        do
        {
            Console.Write("Enter number: ");
            last = int.Parse(Console.ReadLine());
            if (last != 0)
            {
                yourList.Add(last);
            }
        } while (last != 0);
        int sum = 0;
        int largest = 0;
        foreach (int i in yourList)
        {
            sum += i;
            largest = Math.Max(largest, i);
        }
        Console.WriteLine("sum: " + sum);
        Console.WriteLine("average: " + ((float)sum / yourList.Count));
        Console.WriteLine("largest: " + largest);

    }
}