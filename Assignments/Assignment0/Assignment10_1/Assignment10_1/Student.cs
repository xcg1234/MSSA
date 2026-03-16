using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment10_1
{
    public class Student
    {
        public int Id { get; set; } = 0;
        public decimal GPA { get; set; } = 0.0m;

        public string Name { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;

        public Student()
        {
        }

        public Student(int id, decimal gpa, string name, string major)
        {
            Id = id;
            GPA = gpa;
            Name = name;
            Major = major;
        }
    }
}
