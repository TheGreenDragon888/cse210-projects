class Till
{
    // bin identifier indexes for convenience
    private enum BinIndex
    {
        Pennies = 0,
        Nickels = 1,
        Dimes = 2,
        Quarters = 3,
        OneDollarBills = 4,
        FiveDollarBills = 5,
        TenDollarBills = 6,
        TwentyDollarBills = 7,
        BinCount
    }

    // fields (attributes)
    private List<Bin> _bins;

    // methods (behaviors)
    public Till()
    {
        // constructor method
        // initialize the till to a standard starting currency/coin count
        _bins = new List<Bin>();
        _bins.Add(new Bin( 0.01, 50, "pennies"));
        _bins.Add(new Bin( 0.05, 40, "nickels"));
        _bins.Add(new Bin( 0.10, 50, "dimes"));
        _bins.Add(new Bin( 0.25, 40, "quarters"));
        _bins.Add(new Bin( 1.00, 25, "one-dollar bills"));
        _bins.Add(new Bin( 5.00,  5, "five-dollar bills"));
        _bins.Add(new Bin(10.00,  2, "ten-dollar bills"));
        _bins.Add(new Bin(20.00,  0, "twenty-dollar bills"));
    }

    public double TotalCash()  // "getter" method
    {
        double total = 0.0;
        foreach (Bin b in _bins)
        {
            total += b.TotalBinCash();
        }
        return total;
    }

    public void ExchangeCash(int count, double value)  // "setter" method
    {
        switch (value)
        {
            case 0.01:
                _bins[(int)BinIndex.Pennies].Exchange(count);
                break;
            case 0.05:
                _bins[(int)BinIndex.Nickels].Exchange(count);
                break;
            case 0.10:
                _bins[(int)BinIndex.Dimes].Exchange(count);
                break;
            case 0.25:
                _bins[(int)BinIndex.Quarters].Exchange(count);
                break;
            case 1.00:
                _bins[(int)BinIndex.OneDollarBills].Exchange(count);
                break;
            case 5.00:
                _bins[(int)BinIndex.FiveDollarBills].Exchange(count);
                break;
            case 10.00:
                _bins[(int)BinIndex.TenDollarBills].Exchange(count);
                break;
            case 20.00:
                _bins[(int)BinIndex.TwentyDollarBills].Exchange(count);
                break;
            default:
                string error = $"Invalid cash value {value}.";
                throw new Exception(error);
        }
    }
}