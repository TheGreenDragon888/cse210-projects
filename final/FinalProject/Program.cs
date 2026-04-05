using System;

/*
My final project is a rudamentary economy simulator. I have
chosen to make the project "industry-based" instead of "agent-based"
(like I had set up previously in my design plan).

Within the simulation settings menu you will be able to create and
modify the industries that will be participating within the economy.

The simulation is extremely rudamentarily simple. It generates a price
based on the quantity of demand over the quantity of supply. There is a
base price floor of $1 within the simulation.

Feel free to experiment with my project!

Disclaimer:
This project was assisted by AI. Mostly with accelerating development
by helping me write the user interface. The base class system, and
underlying functions were designed by me. I can also explain what
everything does within this project. And I plan on doing so for my
final project evaluation.
*/

class Program
{
    static void Main(string[] args)
    {
        Simulation simulation = new Simulation();

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine();
            Console.WriteLine("=== Economy Simulator Main Menu ===");
            Console.WriteLine("1. Add Industry");
            Console.WriteLine("2. Remove Industry");
            Console.WriteLine("3. Update Industry Settings");
            Console.WriteLine("4. List Industries");
            Console.WriteLine("5. Run Simulation");
            Console.WriteLine("6. Exit");
            Console.Write("Select option: ");

            string option = Console.ReadLine()?.Trim() ?? "";
            switch (option)
            {
                case "1":
                    simulation.AddIndustry();
                    break;
                case "2":
                    simulation.RemoveIndustry();
                    break;
                case "3":
                    simulation.UpdateIndustrySettings();
                    break;
                case "4":
                    simulation.ListIndustries();
                    break;
                case "5":
                    try
                    {
                        Market market = simulation.CompileMarket();
                        market.Run();
                        Console.WriteLine("Simulation completed.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error running simulation: " + ex.Message);
                    }
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose 1-6.");
                    break;
            }
        }

        Console.WriteLine("Exiting simulator.");
    }
}