namespace Assignment4_1_2
{
    public partial class Form1 : Form
    {
        private ICalculator calculator;

        public Form1()
        {
            InitializeComponent();
            calculator = new Math();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PerformCalculation((a, b) => calculator.Add(a, b));
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            PerformCalculation((a, b) => calculator.Subtract(a, b));
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            PerformCalculation((a, b) => calculator.Multiply(a, b));
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            PerformCalculation((a, b) => calculator.Divide(a, b));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumber1.Clear();
            txtNumber2.Clear();
            txtResult.Clear();
            txtNumber1.Focus();
        }

        private void PerformCalculation(Func<double, double, double> operation)
        //using delegate to perform operation
        {
            try
            {
                if (double.TryParse(txtNumber1.Text, out double num1) &&
                    double.TryParse(txtNumber2.Text, out double num2))
                {
                    double result = operation(num1, num2);
                    txtResult.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Please enter valid numbers.", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
