class ItemTemplate
{
    public string _name { get; }
    public int _quantity { get; private set; }

    public ItemTemplate(string name, int quantity)
    {
        _name = name;
        _quantity = quantity < 1 ? 1 : quantity;
    }
}