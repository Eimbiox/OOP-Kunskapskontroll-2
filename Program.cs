ShoppingList list = new ShoppingList("items.txt");
list.Load();
string ReadString(string promt)
{
    Console.WriteLine(promt);
    string temp = Console.ReadLine();
    while (string.IsNullOrEmpty(temp))
    {
        Console.Clear();
        Console.WriteLine($"Skriv namnet på varan: ");
        temp = Console.ReadLine();
    }
    return temp;
}
int ReadNotNegativeInt(string promt)
{
    Console.WriteLine(promt);
    int num;
    while(!int.TryParse(Console.ReadLine(), out num) || num < 0)
    {
        Console.Clear();
        Console.WriteLine("Skriv ett heltal som inte är negativt");
    }
    return num;
}
void AddItem()
{
    string name = ReadString("Skriv namnet på varan");
    int price = ReadNotNegativeInt("Skriv priset på varan");
    list.Add(new Item(name, price));
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
    Console.Write("Välj: ");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        AddItem();
    }
    else if (choice == 2)
    {
        Console.Write("Nummer: ");
        int number = int.Parse(Console.ReadLine());
        list.RemoveAt(number);
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
