class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Cash Register Simulator!");

        Till myTill = new Till();
        Console.Write("Fresh cash drawer cash on hand: ");
        Console.WriteLine($"{myTill.TotalCash():C}");
            // "C" for "currency" in that .NET format string

        Console.WriteLine("Accepting $40.00 payment...");
        myTill.ExchangeCash(2, 20.00);
        Console.WriteLine("Sale was $23.06, disbursing 16.94 in change...");
        myTill.ExchangeCash(-4, 0.01);
        myTill.ExchangeCash(-1, 0.05);
        myTill.ExchangeCash(-1, 0.10);
        myTill.ExchangeCash(-3, 0.25);
        myTill.ExchangeCash(-1, 1.00);
        myTill.ExchangeCash(-1, 5.00);
        myTill.ExchangeCash(-1, 10.00);
        Console.Write("Cash on hand after transaction: ");
        Console.WriteLine($"{myTill.TotalCash():C}");
    }
}
