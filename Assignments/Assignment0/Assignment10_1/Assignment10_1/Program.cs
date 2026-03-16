namespace Assignment10_1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            //hardcode mulitple student class objects and add them to a list
            List<Student> students = new List<Student>
            {
                new Student(1, 3.0m, "John Doe", "CS")
                , new Student(2, 3.5m, "Jane Doe", "Math")
                , new Student(3, 2.5m, "Jim Doe", "CS")
                ,  new Student(4, 3.8m, "Jill Doe", "Math")

            };
            string jsonPath = Path.Combine(Environment.CurrentDirectory, "students.json");
            string xmlPath = Path.Combine(Environment.CurrentDirectory, "students.xml");
            string binaryPath = Path.Combine(Environment.CurrentDirectory, "students.bin");

            string json = System.Text.Json.JsonSerializer.Serialize(students, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(jsonPath, json);

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Student>));
            using (var xmlStream = File.Create(xmlPath))
            {
                xmlSerializer.Serialize(xmlStream, students);
            }

            using (var binaryStream = File.Create(binaryPath))
            using (var writer = new BinaryWriter(binaryStream))
            {
                writer.Write(students.Count);
                foreach (var student in students)
                {
                    writer.Write(student.Id);
                    writer.Write(student.GPA);
                    writer.Write(student.Name);
                    writer.Write(student.Major);
                }
            }

            Console.WriteLine("JSON content:");
            Console.WriteLine(File.ReadAllText(jsonPath));
            Console.WriteLine();

            Console.WriteLine("XML content:");
            Console.WriteLine(File.ReadAllText(xmlPath));
            Console.WriteLine();

            Console.WriteLine("Binary content:");
            using (var binaryStream = File.OpenRead(binaryPath))
            using (var reader = new BinaryReader(binaryStream))
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    int id = reader.ReadInt32();
                    decimal gpa = reader.ReadDecimal();
                    string name = reader.ReadString();
                    string major = reader.ReadString();

                    Console.WriteLine($"Id: {id}, GPA: {gpa}, Name: {name}, Major: {major}");
                }
            }
        }
    }
}