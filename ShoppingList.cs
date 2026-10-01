// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;

    public ShoppingList(string path)
    {
        this.path = path;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
        items.RemoveAt(number - 1);
    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 1; i < items.Count; i++)
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name == name)
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}"); 
        }

        try
        {
            File.WriteAllText(path, string.Join("\r\n", lines) + "\r\n");
        }
        catch
        {
        }   //catch what?

        Console.WriteLine("Listan är sparad.");
    }
    // Reads the file back into the list.
    
    public void Load()
    {
        string[] lines = File.ReadAllLines(path);   //Reads all lines in path, ReadAllLines fixes the issue where \r is left after the split and it does not create and extra empty line
        foreach (string line in lines)          
        {
            string[] parts = line.Split(';');   //every line is split on ; so you get part[0] and part[1]
            if(string.IsNullOrWhiteSpace(parts[0]))     //Here we have an extra saftey measure that incase there is an empty line in txt file it will ignore them.
            {
                continue;
            }
            items.Add(new Item(parts[1], int.Parse(parts[0])));     //To the items list you add a new object item with part[1](name) and parse the part[0] to an int. 
        }
    }    
}