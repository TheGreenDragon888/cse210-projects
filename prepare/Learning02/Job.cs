public class Job
{
    public string _companyName = "";
    public string _jobName = "";
    public int _startYear = 0;
    public int _endYear = 0;

    public Job(string companyName, string jobName, int startYear, int endYear)
    {
        _companyName = companyName;
        _jobName = jobName;
        _startYear = startYear;
        _endYear = endYear;
    }

    public void Display()
    {
        Console.WriteLine($"{_jobName} ({_companyName}) {_startYear}-{_endYear}");
    }
}