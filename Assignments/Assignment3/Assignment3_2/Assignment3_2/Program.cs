namespace Assignment3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating and printing a 2D array:");
            CreatingArray();
            Console.WriteLine();
            Console.WriteLine("Adding two 2D arrays:");
            AddingArrays();
            Console.WriteLine();
            Circle circle1 = new Circle(3);
            Circle circle2 = new Circle(4);
            double areaSum = circle1 + circle2;
            double areaDifference = circle1 - circle2;
            Console.WriteLine($"Area of Circle 1: {circle1.Area():F2}");
            Console.WriteLine($"Area of Circle 2: {circle2.Area():F2}");
            Console.WriteLine();
            Console.WriteLine($"Sum of areas: {areaSum:F2}");
            Console.WriteLine($"Difference of areas: {areaDifference:F2}");
            Console.WriteLine();

            int[] sampleArray = { 10, 20, 30, 40, 50 };
            FindElementIndex(sampleArray, 30); // Element present

        }

        //Create 2D array to store integers and print them in matrix format, with | between each element and as
        //well at the start and end of each row.
        public static void CreatingArray()
        {
            int[,] newArray = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < newArray.GetLength(1); j++)
                {
                    Console.Write(newArray[i, j] + "|");
                }
                Console.WriteLine();
            }

        }

        // create 2 2D array, with first (1,2),(3,4), and second (5,6),(7,8). then add them together and print the result


        public static void AddingArrays()
        {
            int[,] array1 = { { 1, 2 }, { 3, 4 } };
            int[,] array2 = { { 5, 6 }, { 7, 8 } };
            int[,] resultArray = new int[2, 2];
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    resultArray[i, j] = array1[i, j] + array2[i, j];
                }
            }
            for (int i = 0; i < resultArray.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < resultArray.GetLength(1); j++)
                {
                    Console.Write(resultArray[i, j] + "|");
                }
                Console.WriteLine();
            }

        }

        //Create a console application to overload “+” and “-“ operator for adding the areas of 2 circles and getting their area difference respectively.
        class Circle
        {
            public double Radius { get; set; }
            public Circle(double radius)
            {
                Radius = radius;
            }
            public double Area()
            {
                return Math.PI * Radius * Radius;
            }
            public static double operator +(Circle c1, Circle c2)
            {
                return c1.Area() + c2.Area();
            }
            public static double operator -(Circle c1, Circle c2)
            {
                return Math.Abs(c1.Area() - c2.Area());
            }
        }


        //Creating a function returns the index of the element in an array, if not found return -1

        public static int FindElementIndex(int[] array, int element)
        {
            int index = Array.IndexOf(array, element);
            if (index >= 0)
            {
                Console.WriteLine($"Element {element} found at index: {index}");
                return index;
            }
            else
            {
                Console.WriteLine($"Element {element} not found in the array.");
                return -1;
            }
        }
    }
}
