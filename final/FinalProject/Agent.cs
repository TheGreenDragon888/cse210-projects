public class Agent
{
    public string Name;
    public double Money;
    public List<Item> Inventory = new List<Item>();

    public Agent(string name, double initialMoney)
    {
        Name = name;
        Money = initialMoney;
    }

    public void Buy(Item item, double price)
    {
        if (Money >= price)
        {
            Money -= price;
            Inventory.Add(item);
        }
    }

    public void Sell(Item item, double price)
    {
        if (Inventory.Contains(item))
        {
            Money += price;
            Inventory.Remove(item);
        }
    }
}