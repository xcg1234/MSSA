namespace Assignment3_4
{
    /// <summary>
    /// Coffee class that inherits from Beverage
    /// </summary>
    public class Coffee : Beverage
    {
        public Coffee()
        {
        }

        public Coffee(int id, string name, decimal price, string size)
        {
            Id = id;
            Name = name;
            Price = price;
            Size = size;
        }

        public override string GetDescription()
        {
            return $"{Size} {Name} - ${Price:F2}";
        }
    }
}
