// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;
    private int _budget;
    public int Budget
    {
        get {return _budget;}
        set
        {
            if (value <= 0 || value > 10000)
            {
                throw new ArgumentOutOfRangeException(nameof(Budget), "Value can not be negative, zero or above 10 000");
            }
            _budget = value;
        }
    }

    public ShoppingList(string path, int budget)
    {
        this.path = path;
        this.Budget = budget;
    }

    public bool Add(Item item)  //If item and total price would be more than buget, the item is not added to the list. Otherwise it gets added.
    {
        if (Total() + item.Price > Budget)
        {
            return false;
        }
        items.Add(item);  
        return true;   
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

        for (int i = 0; i < items.Count; i++)
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
            Console.WriteLine("Listan är sparad.");
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine($"No access: {e.Message}");
            
        }
        catch (IOException e)
        {
            Console.WriteLine($"Något gick fel: {e.Message}");
        }  
    }
    // Reads the file back into the list.
    
    public void Load()
    {
        if (!File.Exists(path))     //Checks if the file of the path(items.txt) exits. If not the program continues to run. (Save creates the missing file)
        {
            return;
        }
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
    public int Count()  //Returns the ammount of items in the list. 
    {
        return items.Count;
    }
}