using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Goat Milker", "Deluna Acres", 2024, 2025);
        Job job2 = new Job("Sandwich Artist", "Subway", 2025, 2025);

        Resume resume1 = new Resume("Caden", new List<Job> { job1, job2 });

        resume1.DisplayResume();
    }
}