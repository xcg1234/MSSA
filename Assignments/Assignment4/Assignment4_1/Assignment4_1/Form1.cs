namespace Assignment4_1
{
    public partial class Form1 : Form
    {
        private PhoneBook phoneBook;

        public Form1()
        {
            InitializeComponent();
            phoneBook = new PhoneBook();
            SetupDataGridView();
            LoadDummyData();
            RefreshDataGridView();
        }

        private void SetupDataGridView()
        {
            
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "First Name",
                DataPropertyName = "FirstName",
                Width = 150
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Last Name",
                DataPropertyName = "LastName",
                Width = 150
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Work Phone",
                DataPropertyName = "WorkPhoneNumber",
                Width = 150
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cell Phone",
                DataPropertyName = "CellPhoneNumber",
                Width = 150
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Address",
                DataPropertyName = "Address",
                Width = 200
            });
        }

        private void RefreshDataGridView()
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = phoneBook.Contacts.Values.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("First Name and Last Name are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string key = txtFirstName.Text.Trim() + txtLastName.Text.Trim();

            if (phoneBook.Contacts.ContainsKey(key))
            {
                MessageBox.Show("A contact with this First Name and Last Name already exists!", "Duplicate Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Person newPerson = new Person
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                WorkPhoneNumber = txtWorkPhone.Text.Trim(),
                CellPhoneNumber = txtCellPhone.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            phoneBook.Contacts.Add(key, newPerson);
            RefreshDataGridView();
            ClearInputFields();
            MessageBox.Show("Contact added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a contact to delete!", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Person selectedPerson = (Person)dataGridView.SelectedRows[0].DataBoundItem;
            string key = selectedPerson.FirstName + selectedPerson.LastName;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {selectedPerson.FirstName} {selectedPerson.LastName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                phoneBook.Contacts.Remove(key);
                RefreshDataGridView();
                MessageBox.Show("Contact deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a search term!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var searchResults = phoneBook.Contacts.Values
                .Where(p =>
                    p.FirstName.ToLower().Contains(searchText) ||
                    p.LastName.ToLower().Contains(searchText) ||
                    p.WorkPhoneNumber.Contains(searchText) ||
                    p.CellPhoneNumber.Contains(searchText) ||
                    p.Address.ToLower().Contains(searchText))
                .ToList();

            if (searchResults.Count == 0)
            {
                MessageBox.Show("No contacts found matching your search!", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridView.DataSource = null;
            dataGridView.DataSource = searchResults;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            RefreshDataGridView();
        }

        private void ClearInputFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtWorkPhone.Clear();
            txtCellPhone.Clear();
            txtAddress.Clear();
            txtFirstName.Focus();
        }

        private void LoadDummyData()
        {
            var dummyContacts = new[]
            {
                new Person { FirstName = "John", LastName = "Smith", WorkPhoneNumber = "555-0101", CellPhoneNumber = "555-0102", Address = "123 Main St, Seattle, WA" },
                new Person { FirstName = "Sarah", LastName = "Johnson", WorkPhoneNumber = "555-0201", CellPhoneNumber = "555-0202", Address = "456 Oak Ave, Portland, OR" },
                new Person { FirstName = "Michael", LastName = "Williams", WorkPhoneNumber = "555-0301", CellPhoneNumber = "555-0302", Address = "789 Pine Rd, San Francisco, CA" },
                new Person { FirstName = "Emily", LastName = "Brown", WorkPhoneNumber = "555-0401", CellPhoneNumber = "555-0402", Address = "321 Elm St, Los Angeles, CA" },
                new Person { FirstName = "David", LastName = "Martinez", WorkPhoneNumber = "555-0501", CellPhoneNumber = "555-0502", Address = "654 Maple Dr, San Diego, CA" }
            };

            foreach (var person in dummyContacts)
            {
                string key = person.FirstName + person.LastName;
                phoneBook.Contacts.Add(key, person);
            }
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
