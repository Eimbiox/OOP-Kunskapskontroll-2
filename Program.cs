ShoppingList list = new ShoppingList("items.txt");
list.Load();
string ReadString(string promt)     //Prints promt and reads a string that is not empty
{
    Console.WriteLine(promt);
    string temp = Console.ReadLine();
    while (string.IsNullOrEmpty(temp))
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
    while(!int.TryParse(Console.ReadLine(), out num) || num < 0)
    {
        Console.WriteLine("Skriv ett heltal som inte är negativt");
    }
    return num;
}
void AddItem()  //Uses the helpers and adds the item to the shopping list.

{
    string name = ReadString("Skriv namnet på varan");
    int price = ReadNotNegativeInt("Skriv priset på varan");
    list.Add(new Item(name, price));
}
void RemoveItem()   //Removes an item from the list.
{
    int number = ReadNotNegativeInt("Nummer: ");
    if(number > list.Count() || number == 0)
    {
        Console.WriteLine($"Det finns ingen vara på plats {number}");
        Console.ReadKey();
    }
    else
    {
        list.RemoveAt(number);
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
    if(choice > 5)
    {
        Console.WriteLine("Välj en av meny valen");
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
        }
        else if (choice == 4)
        {
            Console.Write("Namn att söka efter: ");
            string wanted = Console.ReadLine();
            Item found = list.Find(wanted);

        if (found == null)
        {
            Console.WriteLine("Varan finns inte i listan.");
        }
        else
        {
            Console.WriteLine($"Hittade: {found}");
        }
        }
        else if (choice == 5)
        {
            break;
        }
    }
    
    
}
