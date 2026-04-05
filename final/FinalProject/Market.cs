using System;

/*
The market class is the mediator that allows the Industry
classes to talk each other.
*/

class Market
{
    protected Industry[] _industries;
    protected string[] _assetNames;

    public Market(Industry[] industries, string[] assetNames)
    {
        _industries = industries;
        _assetNames = assetNames;
    }

    public void Run()
    {
        Console.WriteLine("Starting simulation...");

        int assetCount = _assetNames.Length;
        int[] totalSupply = new int[assetCount];
        int[] totalDemand = new int[assetCount];
        float[] assetPrice = new float[assetCount];

        for (int i = 0; i < _industries.Length; i++)
        {
            for (int assetID = 0; assetID < assetCount; assetID++)
            {
                totalSupply[assetID] += _industries[i].GetProduction(assetID);
                totalDemand[assetID] += _industries[i].GetConsumption(assetID);
            }
        }

        Console.WriteLine("=== Asset price evaluation ===");
        for (int assetID = 0; assetID < assetCount; assetID++)
        {
            int supply = totalSupply[assetID];
            int demand = totalDemand[assetID];
            float scarcity = supply == 0 ? demand : (float)demand / supply;
            assetPrice[assetID] = Math.Max(1f, 1f + demand * 0.5f + scarcity * 0.75f);
            Console.WriteLine($"{_assetNames[assetID]}: ${assetPrice[assetID]:0.00} (Supply: {supply}, Demand: {demand})");
        }

        // Set initial inventory equal to planned production
        for (int i = 0; i < _industries.Length; i++)
        {
            for (int assetID = 0; assetID < assetCount; assetID++)
            {
                _industries[i]._assets[assetID]._quantity = _industries[i].GetProduction(assetID);
            }
        }

        Console.WriteLine("=== Trading phase ===");
        for (int buyerIndex = 0; buyerIndex < _industries.Length; buyerIndex++)
        {
            Industry buyer = _industries[buyerIndex];
            for (int assetID = 0; assetID < assetCount; assetID++)
            {
                int need = buyer.GetConsumption(assetID);
                if (need <= 0)
                    continue;

                float price = assetPrice[assetID];
                int affordable = (int)Math.Floor(buyer._money / price);
                int remainingNeed = Math.Min(need, affordable);
                if (remainingNeed <= 0)
                    continue;

                int originalNeed = remainingNeed;
                for (int sellerIndex = 0; sellerIndex < _industries.Length && remainingNeed > 0; sellerIndex++)
                {
                    if (sellerIndex == buyerIndex)
                        continue;

                    Industry seller = _industries[sellerIndex];
                    int available = seller._assets[assetID]._quantity;
                    if (available <= 0)
                        continue;

                    int transfer = Math.Min(available, remainingNeed);
                    float payment = transfer * price;

                    buyer.Transaction(assetID, transfer, -payment);
                    seller.Transaction(assetID, -transfer, payment);

                    remainingNeed -= transfer;
                }

                int purchased = originalNeed - remainingNeed;
                if (purchased > 0)
                {
                    Console.WriteLine($"{buyer._name} bought {purchased} {_assetNames[assetID]} for ${((float)purchased * price):0.00}.");
                }
            }
        }

        Console.WriteLine("=== End of round money and assets ===");
        for (int i = 0; i < _industries.Length; i++)
        {
            Industry industry = _industries[i];
            Console.Write($"{industry._name}: ${industry._money:0.00}, Assets: ");
            for (int assetID = 0; assetID < assetCount; assetID++)
            {
                Console.Write($"{_assetNames[assetID]}({industry._assets[assetID]._quantity}) ");
            }
            Console.WriteLine();
        }
    }
}