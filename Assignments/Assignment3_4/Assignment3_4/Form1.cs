namespace Assignment3_4
{
    public partial class Form1 : Form
    {
        private List<Coffee> coffeeList;
        private BindingSource bindingSource;
        private int nextId = 1;

        public Form1()
        {
            InitializeComponent();
            InitializeCoffeeList();
        }

        private void InitializeCoffeeList()
        {
            coffeeList = new List<Coffee>
            {
                new Coffee(nextId++, "Espresso", 3.50m, "Small"),
                new Coffee(nextId++, "Cappuccino", 4.50m, "Medium"),
                new Coffee(nextId++, "Latte", 4.75m, "Large"),
                new Coffee(nextId++, "Americano", 3.75m, "Medium")
            };

            bindingSource = new BindingSource();
            bindingSource.DataSource = coffeeList;
            dataGridViewCoffees.DataSource = bindingSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                Coffee newCoffee = new Coffee(
                    nextId++,
                    txtName.Text,
                    numPrice.Value,
                    cboSize.SelectedItem?.ToString() ?? "Medium"
                );

                coffeeList.Add(newCoffee);
                bindingSource.ResetBindings(false);
                ClearInputs();
                MessageBox.Show("Coffee added successfully!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCoffees.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected coffee?",
                                            "Confirm Delete",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int selectedIndex = dataGridViewCoffees.SelectedRows[0].Index;
                    coffeeList.RemoveAt(selectedIndex);
                    bindingSource.ResetBindings(false);
                    MessageBox.Show("Coffee deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Please select a coffee to delete.");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a coffee name.", "Validation Error");
                return false;
            }

            if (cboSize.SelectedItem == null)
            {
                MessageBox.Show("Please select a size.", "Validation Error");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtName.Clear();
            numPrice.Value = 0;
            cboSize.SelectedIndex = 1; // Medium
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
