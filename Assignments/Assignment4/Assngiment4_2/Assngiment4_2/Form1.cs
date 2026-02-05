namespace Assngiment4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if credentials match
            if (txtUserId.Text == "Teacher" && txtPassword.Text == "Admin")
            {
                // Create and show TeacherForm
                TeacherForm teacherForm = new TeacherForm();
                teacherForm.Show();

                // Hide the login form
                this.Hide();
            }
            else
            {
                // Show error message
                MessageBox.Show("Invalid User ID or Password!", "Login Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Clear the password field
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}
