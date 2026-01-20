public abstract class Pet{
    public abstract void Speak();
}

class Dog : Pet{
    public override void Speak() => Console.WriteLine("Woof!");
}

class Hound : Dog{
    public override void Speak() => Console.WriteLine("Woof! Woof!");
}

class Terrier : Dog{
    public override void Speak() => Console.WriteLine("Yap! Yap!");
}

class Working : Pet{
    public override void Speak() => Console.WriteLine("Grrr!");
}

class Beagle : Hound{
    public override void Speak() => Console.WriteLine("Aroo! Aroo!");
}

class WelshTerrier : Terrier{
    public override void Speak() => Console.WriteLine("Yip! Yip!");
}

class Boxer: Working{
    public override void Speak() => Console.WriteLine("Woof! Grrr!");
}
class Program{
    static void Main(string[] args){
        Console.WriteLine("=== Pet Demo ===");
        Pet myPet1 = new Beagle();
        Pet myPet2 = new WelshTerrier();
        Pet myPet3 = new Boxer();

        myPet1.Speak(); // Output: Aroo! Aroo!
        myPet2.Speak(); // Output: Yip! Yip!
        myPet3.Speak(); // Output: Woof! Grrr!

        Console.WriteLine("\n=== Math Operations Demo ===");
        // Demo Math class methods
        int sum1 = Maths.Add(5, 3);
        Console.WriteLine($"Add(5, 3) = {sum1}");
        
        decimal sum2 = Maths.Add(2.5m, 3.7m, 1.8m);
        Console.WriteLine($"Add(2.5, 3.7, 1.8) = {sum2}");
        
        float product1 = Maths.Multiply(4.2f, 3.1f);
        Console.WriteLine($"Multiply(4.2, 3.1) = {product1}");
        
        float product2 = Maths.Multiply(2.0f, 3.0f, 4.0f);
        Console.WriteLine($"Multiply(2.0, 3.0, 4.0) = {product2}");

        Console.WriteLine("\n=== Shape Calculator ===");
        //take user input to generate a circle and calculate the area
        Console.WriteLine("Choose an operation: 1 for Circle Area, 2 for Square Area");
        string ?choice = Console.ReadLine();
        // validate user input
        if (choice == "1" || choice == "2")
        {
            if (choice == "1")
            {
                Console.WriteLine("Enter radius of the circle:");
                try
                {
                    double radius = Convert.ToDouble(Console.ReadLine());
                    Circle circle = new Circle(1, "MyCircle", "Red", radius);
                    Console.WriteLine($"Area of the circle: {circle.CalculateArea()}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too large or too small.");
                }   
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter side length of the square:");
                try
                {
                    double sideLength = Convert.ToDouble(Console.ReadLine());
                    Square square = new Square(2, "MySquare", "Blue", sideLength);
                    Console.WriteLine($"Area of the square: {square.CalculateArea()}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too large or too small.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select 1 or 2.");
        }
    }


}