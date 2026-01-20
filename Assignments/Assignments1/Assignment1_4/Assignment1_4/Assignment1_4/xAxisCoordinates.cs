namespace Assignment1_4
{
    struct xAxisCoordinates
    {
        public int x;
        public int y;
    }

    internal class CoordinateHelper
    {
        public static void CompareCoordinates()
        {
            Console.WriteLine("Enter the x coordinates of point P1:");
            xAxisCoordinates P1;
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int x1))
            {
                P1.x = x1;
            }
            else
            {
                Console.WriteLine("Invalid input for x coordinate of P1.");
                return;
            }

            Console.WriteLine("Enter the y coordinates of point P1:");
            string? input2 = Console.ReadLine();
            if (int.TryParse(input2, out int y1))
            {
                P1.y = y1;
            }
            else
            {
                Console.WriteLine("Invalid input for y coordinate of P1.");
                return;
            }


            Console.WriteLine("Enter the x coordinates of point P2:");
            xAxisCoordinates P2;
            string? input3 = Console.ReadLine();
            if (int.TryParse(input3, out int x2))
            {
                P2.x = x2;
            }
            else
            {
                Console.WriteLine("Invalid input for x coordinate of P2.");
                return;
            }

            Console.WriteLine("Enter the y coordinates of point P2:");
            string? input4 = Console.ReadLine();
            if (int.TryParse(input4, out int y2))
            {
                P2.y = y2;
            }
            else
            {
                Console.WriteLine("Invalid input for y coordinate of P2.");
                return;
            }

            if (P1.x > P2.x)
            {
                Console.WriteLine("P2 is to the left of P1.");
            }
            else if (P1.x < P2.x)
            {
                Console.WriteLine("P2 is to the right of P1.");
            }
            else
            {
                Console.WriteLine("P2 is on the same axis as P1.");


            }

        }
    }
}
