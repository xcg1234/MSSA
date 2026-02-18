namespace Assignments6_1
{
    internal class House
    {
        public int HouseNumber { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

        public House(int houseNumber, string address, string type)
        {
            HouseNumber = houseNumber;
            Address = address;
            Type = type;
        }
    }
}
