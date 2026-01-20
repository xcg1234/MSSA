namespace Assignment1_4
{
    internal class Student
    {


        // public properties for each data member
        public int StudentID { get; set; } = 0;
        public string StudentFName { get; set; } = string.Empty;
        public string StudentLname { get; set; } = string.Empty;
        public char StudentGrade { get; set; } = 'F';


        // Method to collect student information from console input
        public void CollectStudentInfo()
        {
            Console.WriteLine("Enter Student ID:");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                StudentID = id;
            }
            else
            {
                Console.WriteLine("Invalid input for Student ID. Setting to default value 0.");
                StudentID = 0;
            }

            Console.WriteLine("Enter Student First Name:");
            string? fNameInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(fNameInput))
            {
                StudentFName = fNameInput;
            }
            else
            {
                Console.WriteLine("Invalid input for Student First Name.");
            }

            Console.WriteLine("Enter Student Last Name:");
            string? lNameInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(lNameInput))
            {
                StudentLname = lNameInput;
            }
            else
            {
                Console.WriteLine("Invalid input for Student Last Name.");
            }

            Console.WriteLine("Enter Student Grade (A-F):");
            string? gradeInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(gradeInput))
            {
                if (char.TryParse(gradeInput, out char grade))
                {
                    if (grade >= 'A' && grade <= 'F' || grade >= 'a' && grade <= 'f')
                    {
                        StudentGrade = char.ToUpper(grade);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Student Grade. Setting to default value 'F'.");
                        StudentGrade = 'F';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for Student Grade. Setting to default value 'F'.");
                    StudentGrade = 'F';
                }
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("\n--- Student Information ---");
            Console.WriteLine($"Student ID: {StudentID}");
            Console.WriteLine($"First Name: {StudentFName}");
            Console.WriteLine($"Last Name: {StudentLname}");
            Console.WriteLine($"Grade: {StudentGrade}");
        }
    }

   
}
