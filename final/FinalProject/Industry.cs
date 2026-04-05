class Industry
{
    public string _name { get; }
    public float _money { get; protected set; }
    public Item[] _assets { get; protected set; }

    public int[] _production { get; protected set; }
    public int[] _consumption { get; protected set; }

    public Industry(string name, float money, Item[] assets, int[] production, int[] consumption)
    {
        _name = name;
        _money = money;
        _assets = assets; // Initialize the assets for this industry

        // This industry will only produce product proportional to the amount it has consumed
        _production = production; // Initialize the assetIDs that this industry will produce
        _consumption = consumption; // Initialize the assetIDs that this industry will consume
    }

    public int GetProduction(int assetID)
    {
        // Return 0 if any parameter is invalid to prevent errors
        return assetID >= 0 && assetID < _production.Length ? _production[assetID] : 0;
    }

    public int GetConsumption(int assetID)
    {
        // Return 0 if any parameter is invalid to prevent errors
        return assetID >= 0 && assetID < _consumption.Length ? _consumption[assetID] : 0;
    }

    public void Transaction(int assetID, int quantity, float money)
    {
        _assets[assetID]._quantity += quantity;
        _money += money;
    }
}