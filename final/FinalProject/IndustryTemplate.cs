class IndustryTemplate
{
    public string _name  { get; set; }
    public float _money { get; set; }
    public List<ItemTemplate> _produceItems { get; set; }
    public List<ItemTemplate> _consumeItems { get; set; }

    public IndustryTemplate(string name)
    {
        _name = name;
        _money = 1000f; // Default starting cash is $1000
        _produceItems = new List<ItemTemplate>();
        _consumeItems = new List<ItemTemplate>();
    }

    public IndustryTemplate(string name, float money, List<ItemTemplate> produceItems, List<ItemTemplate> consumeItems)
    {
        _name = name;
        _money = money;
        _produceItems = produceItems;
        _consumeItems = consumeItems;
    }
}