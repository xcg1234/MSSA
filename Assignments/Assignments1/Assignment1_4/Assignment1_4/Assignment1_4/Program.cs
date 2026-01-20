using System.Security.Cryptography;

namespace Assignment1_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ask user to pick a task
            Console.WriteLine("Choose a task:");
            Console.WriteLine("1. Compare two points on the x-axis");
            Console.WriteLine("2. Student Information");
            string? choice = Console.ReadLine();
            if(int.TryParse(choice, out int taskChoice))
            {
                switch (taskChoice)
                {
                    case 1:
                        CoordinateHelper.CompareCoordinates();
                        break;
                    case 2:
                        Student student1 = new Student();
                        student1.CollectStudentInfo();
                        student1.DisplayInfo();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid task number.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number corresponding to the task.");
            }

        }

       
    }
}
