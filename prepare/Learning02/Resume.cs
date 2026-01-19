public class Resume
{
    public string _name = "";
    public List<Job> _jobs = [];

    public Resume(string name, List<Job> jobList)
    {
        _name = name;
        _jobs = jobList;
    }
    
    public void Display()
    {
        Console.WriteLine($"{_name}:");
        // Iterate through the joblist and call the display function for each job
        foreach (Job job in _jobs)
        {
            job.Display();
        } 
    }
}