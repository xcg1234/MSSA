using System.IO;

// 1. Setup path and dummy data
string filePath = "UserDetails.txt";
string name = "John Doe";
int age = 30;
string address = "123 Main St, Anytown, USA";

// 2. Prepare the data array
string[] details = {
    $"Name: {name}",
    $"Age: {age}",
    $"Address: {address}"
};

// 3. Write all lines at once (automatically handles opening/closing)
File.WriteAllLines(filePath, details);
Console.WriteLine("File written successfully.\n");

// 4. Read and print
if (File.Exists(filePath))
{
    string[] readDetails = File.ReadAllLines(filePath);
    foreach (string line in readDetails)
    {
        Console.WriteLine(line);
    }
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();