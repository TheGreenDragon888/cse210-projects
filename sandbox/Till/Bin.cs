class Bin
{
    // fields (attributes)
    private double _value;
    private int _count;
    private string _denomination;

    // methods (behaviors)
    public Bin(double value, int count, string denomination)
    {
        // constructor method
        _value = value;
        _count = count;
        _denomination = denomination;
    }

    public double TotalBinCash()  // "getter" method
    {
        return _count * _value;
    }
    public void Exchange(int amount)  // "setter" (modifier) method
    {
        if (_count + amount >= 0)
        {
            _count += amount;
        }
        else
        {
            string error = "Unable to exchange. ";
            error += $"Not enough {_denomination} in its Bin.";
            throw new Exception(error);
        }
    }
}
