class Wait
{
    public static void WaitingUI(double seconds = 10, int decimalPlaces = 0)
    {
        int totalSteps = 100;
        DateTime startTime = DateTime.Now;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        void GenerateBar(double progress)
        {
            i = (int)Math.Round(progress * totalSteps);

            // Update progress bar
            // string bar = new string('█', i * 50 / totalSteps) + new string('▒', 50 - i * 50 / totalSteps);
            string bar = new string('█', i * 50 / totalSteps) + new string('═', 50 - i * 50 / totalSteps);
            string status = $"╞{bar}╡ {progress.ToString($"P{decimalPlaces}")}";

            // Overwrite the current line
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(status);
        }
        
        Console.CursorVisible = false;
        while (DateTime.Now < endTime)
        {
            double progress = (DateTime.Now - startTime).TotalSeconds / (endTime - startTime).TotalSeconds;
            GenerateBar(progress);

            // Simulate work
            System.Threading.Thread.Sleep(10);
        }
        GenerateBar(1);

        Console.WriteLine(); // Final newline
        Console.CursorVisible = true;
    }
}