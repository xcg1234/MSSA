using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace Assngiment4_2
{
    public partial class TeacherForm : Form
    {
        private List<Student> students = new List<Student>();
        public TeacherForm()
        {
            InitializeComponent();
            
            // Wire up event handlers
            btnAddStudent.Click += AddStudent;
            btnDeleteStudent.Click += DeleteStudent;
            btnSaveHighestGPA.Click += btnSaveHighestGPA_Click;
        }


        private void AddStudent(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentName.Text) || string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Please enter both Student Name and Student ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtStudentId.Text, out int studentId))
            {
                MessageBox.Show("Student ID must be a valid number!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(txtGPA.Text, out double gpa) || gpa < 0 || gpa > 4.0)
            {
                MessageBox.Show("GPA must be a valid number between 0 and 4.0!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (students.Any(s => s.StudentId == studentId))
            {
                MessageBox.Show("A student with this ID already exists!", "Duplicate Entry",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //after all the checks, now we can create a new student
            Student newStudent = new Student
            {
                StudentId = studentId,
                StudentName = txtStudentName.Text.Trim(),
                GPA = gpa
            };
            students.Add(newStudent);
            RefreshList();
            ClearInputFields();

        }

        private void DeleteStudent(object sender, EventArgs s)
        {
            if (lstStudents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a student to delete!", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this student?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Remove from list
                students.RemoveAt(lstStudents.SelectedIndex);

                // Refresh display
                RefreshList();

                MessageBox.Show("Student deleted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        //helper function refresh list and clear input field
        private void RefreshList()
        {

            lstStudents.Items.Clear();
            foreach (var student in students)
            {
                lstStudents.Items.Add($"ID: {student.StudentId} | Name: {student.StudentName} | GPA: {student.GPA:F2}");
            }
        }

        // Helper method to clear input fields
        private void ClearInputFields()
        {
            txtStudentId.Clear();
            txtStudentName.Clear();
            txtGPA.Clear();
            txtStudentId.Focus();
        }

        private void btnSaveHighestGPA_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No students available to save!", "No Data", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Find student with highest GPA using LINQ
            Student topStudent = students.OrderByDescending(s => s.GPA).First();

            try
            {
                // Save to text file
                string filePath = "HighestGPA.txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("=== Student with Highest GPA ===");
                    writer.WriteLine($"Student ID: {topStudent.StudentId}");
                    writer.WriteLine($"Student Name: {topStudent.StudentName}");
                    writer.WriteLine($"GPA: {topStudent.GPA:F2}");
                    writer.WriteLine($"Saved on: {DateTime.Now}");
                }

                MessageBox.Show($"Highest GPA student saved to {filePath}\n\n" +
                    $"Name: {topStudent.StudentName}\n" +
                    $"GPA: {topStudent.GPA:F2}", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "File Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
