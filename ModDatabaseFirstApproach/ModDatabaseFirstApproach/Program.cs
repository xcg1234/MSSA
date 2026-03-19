namespace ModDatabaseFirstApproach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //pacakge needed: Design, SqlServer, Tools
            //Scaffold-DbContext "Server=MSI;Database=CCAD22Books;Trusted_Connection=True;Integrated Security=True;trustservercertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Force

        }
    }
}
