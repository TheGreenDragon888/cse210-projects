using System;

class Program
{
    static void Main(string[] args)
    {
        Resume resume1 = new Resume("Jon Doe", [
            new Job("Microsoft", "Software Engineer", 2019, 2022),
            new Job("Apple", "Manager", 2022, 2023)
        ]);

        resume1.Display();
    }
}