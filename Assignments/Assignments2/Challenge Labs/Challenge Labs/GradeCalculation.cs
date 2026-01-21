using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_Labs
{
    class Student { 
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public int MathScore { get; set; }
        public int ScienceScore { get; set; }
        public int EnglishScore { get; set; }

        public int TotalScore => MathScore + ScienceScore + EnglishScore;
        public double AverageScore => TotalScore / 3.0;

        public string Division
        {
            get
            {
                return AverageScore switch
                {
                    >= 80 => "First Division",
                    >= 60 => "Second Division",
                    >= 40 => "Third Division",
                    _ => "Fail"

                };
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Roll Number: {RollNumber}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Math Score: {MathScore}");
            Console.WriteLine($"Science Score: {ScienceScore}");
            Console.WriteLine($"English Score: {EnglishScore}");
            Console.WriteLine($"Total Score: {TotalScore}");
            Console.WriteLine($"Average Score: {AverageScore:F2}");
            Console.WriteLine($"Division: {Division}");
        }
    }

    class CalculateGrade {
        public static void Calculate() {
            var sampleStudent = new Student();
            Console.WriteLine("Enter Roll Number:");
            sampleStudent.RollNumber = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Enter Name:");
            sampleStudent.Name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter Math Score:");
            sampleStudent.MathScore = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Enter Science Score:");
            sampleStudent.ScienceScore = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Enter English Score:");
            sampleStudent.EnglishScore = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("\nStudent Details:");
            sampleStudent.DisplayDetails();

        }
    }
}
