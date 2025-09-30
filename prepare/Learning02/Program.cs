using System;

class Program
{
    static void Main(string[] args)
    {
        // Job job1 = new Job("Goat Milker", "Deluna Acres", 2024, 2025);
        // Job job2 = new Job("Sandwich Artist", "Subway", 2025, 2025);

        Job job1 = new Job();
        job1._jobTitle = "Goat Milker";
        job1._company = "Deluna Acres";
        job1._startYear = 2024;
        job1._endYear = 2025;

        Job job2 = new Job();
        job2._jobTitle = "Sandwich Artist";
        job2._company = "Subway";
        job2._startYear = 2025;
        job2._endYear = 2025;

        // Resume resume1 = new Resume("Caden", new List<Job> { job1, job2 });

        Resume resume1 = new Resume();
        resume1._name = "Caden";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.DisplayResume();
    }
}