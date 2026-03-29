public class TransactionData
{
    public Agent Buyer;
    public Agent Seller;
    public Item Item;
    public double Price;
    public DateTime Timestamp;

    public TransactionData(Agent buyer, Agent seller, Item item, double price)
    {
        Buyer = buyer;
        Seller = seller;
        Item = item;
        Price = price;
        Timestamp = DateTime.Now;
    }
}