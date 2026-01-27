using System.ComponentModel;

namespace Assignment3_3
{
    public partial class Form1 : Form
    {
        BindingList<Student> studentList = new BindingList<Student>();
        public Form1()
        {
            InitializeComponent();
            dgvStudents.DataSource = studentList;
            //fill the combobox with enum values
            cmbMonth.DataSource = Enum.GetValues(typeof(Month));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtGrade_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbMonth.SelectedItem is Month selectedMonth)
            {
                var newStudent = new Student
                {
                    StudId = int.Parse(textId.Text),
                    FirstName = txtFirstName.Text,
                    LastName = textLastname.Text,
                    Address = txtAddress.Text,
                    MonthOfAdmission = selectedMonth,
                    Grade = char.Parse(txtGrade.Text)
                };
                //continue to add student to the list 
                studentList.Add(newStudent);
                //clear input fields
                clearFields();
            }
            else
            {
                MessageBox.Show("Please select a valid month of admission.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                var studentToDelete = dgvStudents.CurrentRow.DataBoundItem as Student;
                if (studentToDelete != null)
                {
                    studentList.Remove(studentToDelete);
                }
            }
        }

        private void clearFields() { 
            textId.Clear();
            txtFirstName.Clear();
            textLastname.Clear();
            txtAddress.Clear();
            txtGrade.Clear();
        }
    }
}
