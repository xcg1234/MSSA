namespace Challenge_Labs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculateGrade.Calculate();

            TemperatureReader.ReadTemperature();

            UserValidation userValidation = new UserValidation();
            userValidation.ValidateUser();

            TriangleDisplay.DisplayTriangle(5, 5);

        }
    }
}
