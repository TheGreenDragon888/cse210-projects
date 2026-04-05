class Item
{
    public string _name { get; }
    public int _quantity { get; set; }

    public Item(string name, int quantity)
    {
        _name = name;
        _quantity = quantity;
    }
}