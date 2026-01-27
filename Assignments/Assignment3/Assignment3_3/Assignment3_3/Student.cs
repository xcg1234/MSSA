namespace Assignment3_3
{
    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December

    }
    internal class Student
    {
        public int StudId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Month MonthOfAdmission { get; set; }
        public char Grade { get; set; }
    }
}
