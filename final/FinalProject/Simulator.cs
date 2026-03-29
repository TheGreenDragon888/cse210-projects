public class Simulator
{
    public void RunSimulation()
    {
        // Creates simulation data storage
        var data = new SimulationData();

        // Initialize items (there will be more added for the full project)
        var apple = new Item("Apple", 1.0);
        var book = new Item("Book", 10.0);
        data.Items.Add(apple);
        data.Items.Add(book);

        // Initialize Agents (there will be more added for the full project)
        var alice = new Agent("Alice", 50.0);
        var bob = new Agent("Bob", 20.0);
        bob.Inventory.Add(apple);
        bob.Inventory.Add(book);
        data.Agents.Add(alice);
        data.Agents.Add(bob);

        Market market = new FreeMarket();
        Console.WriteLine("=== Free Market Demo ===");
        ExecuteTrade(data, market, alice, bob, apple);

        market = new RegulatedMarket();
        Console.WriteLine("\n=== Regulated Market Demo ===");
        ExecuteTrade(data, market, alice, bob, book);

        PrintSummary(data);
    }

    private void ExecuteTrade(SimulationData data, Market market, Agent buyer, Agent seller, Item item)
    {
        var price = market.DeterminePrice(item);

        if (buyer.Money < price)
        {
            Console.WriteLine($"{buyer.Name} cannot afford {item.Name} at {price:C}.");
            return;
        }

        market.ConductTransaction(buyer, seller, item, price);
        data.Transactions.Add(new TransactionData(buyer, seller, item, price));

        Console.WriteLine($"{buyer.Name} bought {item.Name} from {seller.Name} for {price:C} (buyer money {buyer.Money:C}, seller money {seller.Money:C})");
    }

    private void PrintSummary(SimulationData data)
    {
        Console.WriteLine("\n=== Simulation Summary ===");
        Console.WriteLine($"Steps: {data.TimeStep}");
        Console.WriteLine($"Agents: {data.Agents.Count}");
        Console.WriteLine($"Items: {data.Items.Count}");
        Console.WriteLine($"Transactions: {data.Transactions.Count}");
        Console.WriteLine();

        foreach (var t in data.Transactions)
        {
            Console.WriteLine($"[{t.Timestamp:HH:mm:ss}] {t.Buyer.Name} bought {t.Item.Name} from {t.Seller.Name} for {t.Price:C}");
        }
    }
}