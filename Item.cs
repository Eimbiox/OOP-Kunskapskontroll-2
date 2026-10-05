// One item on the shopping list.
class Item
{
    private string _name;
    public string Name
    {
        get {return _name;}
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value can not be empty");
            }
            _name = value;
        }
    }
    private int _price;
    public int Price
    {
        get {return _price;}
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Value can not be below 0");
            }
            _price = value;
        }
    }

    public Item(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} - {Price} kr";
    }
}
