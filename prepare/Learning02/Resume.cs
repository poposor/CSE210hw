public class Resume
{
    public string _name;
    public List<Job> _jobs;

    public Resume(string name, List<Job> jobs)
    {
        _name = name;
        _jobs = jobs;
    }
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}