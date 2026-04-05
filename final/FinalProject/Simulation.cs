/*
Simulation is the class in charge of preparing the simulation.
It compiles the simulation settings into parameters for the
Market class, and initializes all of the Industry classes from
the simulation settings as well.
*/

using System;
using System.Collections.Generic;

class Simulation
{
    public List<IndustryTemplate> _industryTemplates { get; set; }

    public Simulation() 
    { 
        _industryTemplates = new List<IndustryTemplate>();
        AddDefaultIndustries();
    }

    private void AddDefaultIndustries()
    {
        // Baker Industry
        List<ItemTemplate> bakerProduce = new List<ItemTemplate> { new ItemTemplate("Bread", 3) };
        List<ItemTemplate> bakerConsume = new List<ItemTemplate> { new ItemTemplate("Flour", 2), new ItemTemplate("Bread", 1) };
        _industryTemplates.Add(new IndustryTemplate("Baker Industry", 1000f, bakerProduce, bakerConsume));

        // Milling Industry
        List<ItemTemplate> millingProduce = new List<ItemTemplate> { new ItemTemplate("Flour", 2) };
        List<ItemTemplate> millingConsume = new List<ItemTemplate> { new ItemTemplate("Wheat", 3), new ItemTemplate("Bread", 1) };
        _industryTemplates.Add(new IndustryTemplate("Milling Industry", 1000f, millingProduce, millingConsume));

        // Farming Industry
        List<ItemTemplate> farmingProduce = new List<ItemTemplate> { new ItemTemplate("Wheat", 4) };
        List<ItemTemplate> farmingConsume = new List<ItemTemplate> { new ItemTemplate("Bread", 1) };
        _industryTemplates.Add(new IndustryTemplate("Farming Industry", 1000f, farmingProduce, farmingConsume));
    }

    public void AddIndustry()
    {
        EnsureTemplateList();

        Console.Write("Industry name: ");
        string name = Console.ReadLine()?.Trim() ?? "Unnamed Industry";

        float money = ReadFloat("Starting money (default 1000): ", 1000f);
        IndustryTemplate template = new IndustryTemplate(name, money, new List<ItemTemplate>(), new List<ItemTemplate>());

        Console.WriteLine("Add production items (press ENTER when done):");
        while (true)
        {
            Console.Write("  Item name (or blank to stop): ");
            string itemName = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(itemName)) break;

            int quantity = ReadInt($"  Quantity for '{itemName}' (default 1): ", 1);
            template._produceItems.Add(new ItemTemplate(itemName, quantity));
        }

        Console.WriteLine("Add consumption items (press ENTER when done):");
        while (true)
        {
            Console.Write("  Item name (or blank to stop): ");
            string itemName = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(itemName)) break;

            int quantity = ReadInt($"  Quantity for '{itemName}' (default 1): ", 1);
            template._consumeItems.Add(new ItemTemplate(itemName, quantity));
        }

        _industryTemplates.Add(template);
        Console.WriteLine($"Industry '{name}' added.");
    }

    public void RemoveIndustry()
    {
        if (_industryTemplates == null || _industryTemplates.Count == 0)
        {
            Console.WriteLine("No industries to remove.");
            return;
        }

        ListIndustries();
        int index = ReadInt("Enter industry index to remove: ", -1);
        if (index >= 0 && index < _industryTemplates.Count)
        {
            string removedName = _industryTemplates[index]._name;
            _industryTemplates.RemoveAt(index);
            Console.WriteLine($"Removed industry '{removedName}'.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    public void UpdateIndustrySettings()
    {
        if (_industryTemplates == null || _industryTemplates.Count == 0)
        {
            Console.WriteLine("No industries available to update.");
            return;
        }

        ListIndustries();
        int index = ReadInt("Enter industry index to update: ", -1);
        if (index < 0 || index >= _industryTemplates.Count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }

        IndustryTemplate industry = _industryTemplates[index];
        bool back = false;

        while (!back)
        {
            Console.WriteLine();
            Console.WriteLine($"=== Update Industry: {industry._name} ===");
            Console.WriteLine("1. Rename");
            Console.WriteLine("2. Change starting money");
            Console.WriteLine("3. Add production item");
            Console.WriteLine("4. Remove production item");
            Console.WriteLine("5. Add consumption item");
            Console.WriteLine("6. Remove consumption item");
            Console.WriteLine("7. Back");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine()?.Trim() ?? "";
            switch (choice)
            {
                case "1":
                    Console.Write("New name: ");
                    industry._name = Console.ReadLine()?.Trim() ?? industry._name;
                    break;
                case "2":
                    industry._money = ReadFloat("New starting money: ", industry._money);
                    break;
                case "3":
                    AddItemToList(industry._produceItems, "production");
                    break;
                case "4":
                    RemoveItemFromList(industry._produceItems, "production");
                    break;
                case "5":
                    AddItemToList(industry._consumeItems, "consumption");
                    break;
                case "6":
                    RemoveItemFromList(industry._consumeItems, "consumption");
                    break;
                case "7":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    public void ListIndustries()
    {
        if (_industryTemplates == null || _industryTemplates.Count == 0)
        {
            Console.WriteLine("No industries created yet.");
            return;
        }

        Console.WriteLine("=== Industries ===");
        for (int i = 0; i < _industryTemplates.Count; i++)
        {
            IndustryTemplate industry = _industryTemplates[i];
            string produce = industry._produceItems.Count > 0
                ? string.Join(", ", industry._produceItems.ConvertAll(x => x._name + "(" + x._quantity + ")"))
                : "(none)";
            string consume = industry._consumeItems.Count > 0
                ? string.Join(", ", industry._consumeItems.ConvertAll(x => x._name + "(" + x._quantity + ")"))
                : "(none)";

            Console.WriteLine($"[{i}] {industry._name} | Money: {industry._money} | Produce: {produce} | Consume: {consume}");
        }
    }

    public Market CompileMarket()
    {
        EnsureTemplateList();

        List<Industry> industries = new List<Industry>();
        List<string> assetNames = new List<string>();

        foreach (IndustryTemplate template in _industryTemplates)
        {
            foreach (ItemTemplate item in template._produceItems)
            {
                if (!assetNames.Contains(item._name)) assetNames.Add(item._name);
            }
            foreach (ItemTemplate item in template._consumeItems)
            {
                if (!assetNames.Contains(item._name)) assetNames.Add(item._name);
            }
        }

        foreach (IndustryTemplate template in _industryTemplates)
        {
            Item[] assets = new Item[assetNames.Count];
            for (int i = 0; i < assetNames.Count; i++)
                assets[i] = new Item(assetNames[i], 0);

            int[] production = new int[assetNames.Count];
            foreach (ItemTemplate item in template._produceItems)
            {
                int assetId = assetNames.IndexOf(item._name);
                if (assetId >= 0)
                    production[assetId] += item._quantity;
            }

            int[] consumption = new int[assetNames.Count];
            foreach (ItemTemplate item in template._consumeItems)
            {
                int assetId = assetNames.IndexOf(item._name);
                if (assetId >= 0)
                    consumption[assetId] += item._quantity;
            }

            Industry industry = new Industry(template._name, template._money, assets, production, consumption);
            industries.Add(industry);
        }

        return new Market(industries.ToArray(), assetNames.ToArray());
    }

    void EnsureTemplateList()
    {
        if (_industryTemplates == null)
            _industryTemplates = new List<IndustryTemplate>();
    }

    float ReadFloat(string prompt, float defaultValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string raw = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(raw))
                return defaultValue;

            if (float.TryParse(raw.Trim(), out float value))
                return value;

            Console.WriteLine("Invalid number. Please try again.");
        }
    }

    int ReadInt(string prompt, int defaultValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string raw = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(raw))
                return defaultValue;

            if (int.TryParse(raw.Trim(), out int value))
                return value;

            Console.WriteLine("Invalid integer. Please try again.");
        }
    }

    void AddItemToList(List<ItemTemplate> list, string type)
    {
        Console.Write($"{type} item name: ");
        string itemName = Console.ReadLine()?.Trim() ?? "";
        if (string.IsNullOrEmpty(itemName))
        {
            Console.WriteLine("Item name cannot be empty.");
            return;
        }

        int quantity = ReadInt($"Quantity for '{itemName}' (default 1): ", 1);
        list.Add(new ItemTemplate(itemName, quantity));
        Console.WriteLine($"Added {type} item '{itemName}' ({quantity}).");
    }

    void RemoveItemFromList(List<ItemTemplate> list, string type)
    {
        if (list.Count == 0)
        {
            Console.WriteLine($"No {type} items to remove.");
            return;
        }

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"[{i}] {list[i]._name} ({list[i]._quantity})");
        }

        int index = ReadInt($"Select {type} item index to remove: ", -1);
        if (index >= 0 && index < list.Count)
        {
            Console.WriteLine($"Removed {type} item '{list[index]._name}'.");
            list.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
}