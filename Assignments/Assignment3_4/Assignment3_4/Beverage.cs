namespace Assignment3_4
{
  
    public abstract class Beverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }

        protected Beverage()
        {
            Name = string.Empty;
            Size = "Medium";
        }

        public abstract string GetDescription();
    }
}
