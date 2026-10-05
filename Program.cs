ShoppingList list = null;
while (list == null)    //Checks if the object could be created and goes on until it is
{
    int budget = ReadNotNegativeInt("Skriv in ditt buget(Max 10 000kr): ");
    try
    {
        list = new ShoppingList("items.txt", budget);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine($"Ogiltigt bugettak: {e.Message}");
    }
}
list.Load();
if (list.Errors.Count > 0)
{
    Console.WriteLine(string.Join("\n", list.Errors));
    Console.ReadKey();
}

string ReadString(string promt)     //Prints promt and reads a string that is not empty
{
    Console.WriteLine(promt);
    string temp = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(temp))
    {
        Console.WriteLine($"Skriv namnet på varan: ");
        temp = Console.ReadLine();
    }
    return temp;
}

int ReadNotNegativeInt(string promt)    //Prints promt and reads and int thats is not negative.
{
    Console.WriteLine(promt);
    int num;
    while (!int.TryParse(Console.ReadLine(), out num) || num < 0)
    {
        Console.WriteLine("Skriv ett heltal som inte är negativt");
    }
    return num;
}

void AddItem()  //Uses the helpers and adds the item to the shopping list.
{
    string name = ReadString("Skriv namnet på varan");
    int price = ReadNotNegativeInt("Skriv priset på varan");
    try
    {
        bool added = list.Add(new Item(name, price));   //Save the result in a bool. It does not get added to the list. See ShoppingList Add() logic.
        if (!added)
        {
            Console.WriteLine("Varan kunde inte läggas till eftersom det överstiger budgeten");
            Console.ReadKey();
        }
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine("FEL" + e.Message);
        Console.ReadKey();
    }
    catch (ArgumentException e)
    {
        Console.WriteLine("FEL" + e.Message);
        Console.ReadKey();
    }
}

void RemoveItem()   //Removes an item from the list.
{
    int number = ReadNotNegativeInt("Nummer: ");
    if (number > list.Count() || number == 0)
    {
        Console.WriteLine($"Det finns ingen vara på plats {number}");
        Console.ReadKey();
    }
    else
    {
        list.RemoveAt(number);
    }

}

void SearchItem()   //Searches for an item in the list.
{
    string wanted = ReadString("Namn att söka efter: ");
    Item found = list.Find(wanted);

    if (found == null)
    {
        Console.WriteLine("Varan finns inte i listan.");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine($"Hittade: {found}");
        Console.ReadKey();
    }
}


while (true)
{
    Console.Clear();
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara");
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");

    int choice = ReadNotNegativeInt("Välj: ");
    if (choice > 5 || choice == 0)
    {
        Console.WriteLine("Välj en av meny valen");
        Console.ReadKey();
    }
    else
    {
        if (choice == 1)
        {
            AddItem();
        }
        else if (choice == 2)
        {
            RemoveItem();
        }
        else if (choice == 3)
        {
            list.Save();
            Console.ReadKey();
        }
        else if (choice == 4)
        {
            SearchItem();
        }
        else if (choice == 5)
        {
            break;
        }
    }
}
