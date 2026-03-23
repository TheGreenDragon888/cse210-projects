class Points
{
    private int DAY_IN_SECONDS = 60 * 60 * 24;
    private int POINT_LOSS_PER_DAY = 50;

    private string _pointsFile = "Points.txt";

    private long _lastTimestamp; // last incrementation of point values

    public int current; // current point total
    public int total; // all time total points
    public int highscore; // all-time highest "current" point total

    public Points()
    {
        // Initialize the points variable with the value from the file (if it exists) or 0 (if it doesn't)
        if (File.Exists(_pointsFile))
        {
            string[] pointFileData = File.ReadAllText(_pointsFile).Trim().Split(',');

            current = int.Parse(pointFileData[0]);
            total = int.Parse(pointFileData[1]);
            highscore = int.Parse(pointFileData[2]);
            _lastTimestamp = long.Parse(pointFileData[3]);

            // Now that we've loaded all necessary data from file,
            // let's find out how many points we've lost from atrophy!
            long currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            float pointLoss = (currentTimestamp - _lastTimestamp) / DAY_IN_SECONDS * POINT_LOSS_PER_DAY;
            current -= (int)pointLoss; // trunicates and doesnt round (effectively rounds down)
            current = current > 0 ? current : 0; // prevents the user from going below 0 current points
        }
        else
        {
            current = 0;
            total = 0;
            highscore = 0;
            // Set this just to prevent errors
            _lastTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }

    public void IncreaseAndSave(int amount)
    {
        // Adds a value to the total and saves the new amount to file
        current = current + amount > 0 ? current + amount : 0; // prevents the user from going below 0 current points
        total = amount > 0 ? total + amount : total;
        highscore = Math.Max(current, highscore); // Returns the higher value of the two

        // Uses DateTimeOffset so timezones and other time artifacts don't affect the calculation
        _lastTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        // Saves all this point data to file
        File.WriteAllText(_pointsFile, $"{current},{total},{highscore},{_lastTimestamp}");
    }
}