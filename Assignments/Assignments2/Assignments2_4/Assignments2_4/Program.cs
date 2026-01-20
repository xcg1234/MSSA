//find the sum of the elements in array
int[] newArr = new int[3];
newArr[0] = 2;
newArr[1] = 5;
newArr[2] = 8;
int sum = 0;
for (int i = 0; i < newArr.Length; i++)
{
    sum += newArr[i];
}
Console.WriteLine("The sum of the elements in the array is: " + sum);
//or use the built-in method
int total = newArr.Sum();
Console.WriteLine("The sum of the elements in the array using built-in method is: " + total);

//find the largest element in array
int [] arr2 = new int[] { 25, 63, 10 };
int largest = arr2[0];
for (int i = 1; i < arr2.Length; i++)
{
    if( arr2[i] > largest)
    {
        largest = arr2[i];
    }
}
Console.WriteLine("The largest element in the array is: " + largest);
//or use the built-in method
int max = arr2.Max();
Console.WriteLine("The largest element in the array using built-in method is: " + max);


//take user input of x and y coordinates
Console.WriteLine("Enter x coordinate:");
string ? xInput = Console.ReadLine();
if (int.TryParse(xInput, out int x))
{
    Console.WriteLine("Enter y coordinate:");
    string ? yInput = Console.ReadLine();
    if (int.TryParse(yInput, out int y))
    {
        //tell the user which quadrant the point (x, y) lies in
        switch ((x, y))
        {
            case (> 0, > 0):
                Console.WriteLine($"The point ({x}, {y}) lies in Quadrant 1.");
                break;
            case (< 0, > 0):
                Console.WriteLine($"The point ({x}, {y}) lies in Quadrant 2.");
                break;
            case (< 0, < 0):
                Console.WriteLine($"The point ({x}, {y}) lies in Quadrant 3.");
                break;
            case (> 0, < 0):
                Console.WriteLine($"The point ({x}, {y}) lies in Quadrant 4.");
                break;
            case (0, 0):
                Console.WriteLine("The point is at the Origin.");
                break;
            case (0, _):
                Console.WriteLine($"The point ({x}, {y}) lies on the Y-axis.");
                break;
            case (_, 0):
                Console.WriteLine($"The point ({x}, {y}) lies on the X-axis.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input for y coordinate.");
    }
}
else
{
    Console.WriteLine("Invalid input for x coordinate.");
}