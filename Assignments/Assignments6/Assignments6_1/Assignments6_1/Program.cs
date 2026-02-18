namespace Assignments6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We're moving zeroes to the end");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine($"Current array is [{string.Join(", ", nums)}]");
            int[] result = MoveZeroes.MoveZeroesToEnd(nums);
            Console.WriteLine($"Array after moving is [{string.Join(", ", result)}]");



            //Implement a single linked list with each node representing a house. You may add data in it like house number, brief address, type of house ( like Ranch, Colonial) . each house (node) will be linked to next .Give facility to the user to search a house by its number and then display the details. 
            LinkedList<House> houses = new LinkedList<House>();
            House house1 = new House(1, "123 Main St", "Ranch");
            House house2 = new House(2, "456 Elm St", "Colonial");
            House house3 = new House(3, "789 Oak St", "Victorian");
            houses.AddLast(house1);
            houses.AddLast(house2);
            houses.AddLast(house3);

            Console.WriteLine("Enter the house number to search:");
            int houseNumber = int.TryParse(Console.ReadLine(), out int results) ? results : 0;
            //if find the house in the list then display the details otherwise display not found
            House foundHouse = houses.FirstOrDefault(h => h.HouseNumber == houseNumber);
            if (foundHouse != null)
            {
                Console.WriteLine($"House Number: {foundHouse.HouseNumber}");
                Console.WriteLine($"Address: {foundHouse.Address}");
                Console.WriteLine($"Type: {foundHouse.Type}");
            }
            else
            {
                Console.WriteLine("House not found.");

            }
        }
    }
}
