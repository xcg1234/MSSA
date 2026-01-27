namespace Mod3Winformapp
{
    public partial class lblheading : Form
    {
        public lblheading()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Mod3 WinForms App!");
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            lblhandling.Text = "You have changed the text!";
        }

        private void lblhandling_Click(object sender, EventArgs e)
        {

        }

        private void lowButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Hi {txtName.Text}");
            txtName.Clear();
        }
    }
}
