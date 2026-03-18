using Assignment10_3.Data;
using Assignment10_3.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Assignment10_3
{
    public partial class Form1 : Form
    {
        private CarContext _context;
        private BindingSource _carBindingSource = new BindingSource();

        private DataGridView carsDataGridView = new DataGridView();
        private TextBox vinTextBox = new TextBox();
        private TextBox makeTextBox = new TextBox();
        private TextBox modelTextBox = new TextBox();
        private TextBox yearTextBox = new TextBox();
        private Button addButton = new Button();
        private Button updateButton = new Button();
        private Button deleteButton = new Button();
        private Button clearButton = new Button();

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Setup controls
            this.SuspendLayout();

            // Labels for textboxes
            var vinLabel = new Label { Text = "VIN", Location = new System.Drawing.Point(12, 260), Size = new System.Drawing.Size(75, 23) };
            var makeLabel = new Label { Text = "Make", Location = new System.Drawing.Point(12, 290), Size = new System.Drawing.Size(75, 23) };
            var modelLabel = new Label { Text = "Model", Location = new System.Drawing.Point(12, 320), Size = new System.Drawing.Size(75, 23) };
            var yearLabel = new Label { Text = "Year", Location = new System.Drawing.Point(12, 350), Size = new System.Drawing.Size(75, 23) };

            // DataGridView
            carsDataGridView.Location = new System.Drawing.Point(12, 12);
            carsDataGridView.Size = new System.Drawing.Size(760, 230);
            carsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            carsDataGridView.Name = "carsDataGridView";
            carsDataGridView.RowTemplate.Height = 29;
            carsDataGridView.SelectionChanged += carsDataGridView_SelectionChanged;

            // TextBoxes
            vinTextBox.Location = new System.Drawing.Point(93, 260);
            vinTextBox.Size = new System.Drawing.Size(250, 27);
            makeTextBox.Location = new System.Drawing.Point(93, 290);
            makeTextBox.Size = new System.Drawing.Size(250, 27);
            modelTextBox.Location = new System.Drawing.Point(93, 320);
            modelTextBox.Size = new System.Drawing.Size(250, 27);
            yearTextBox.Location = new System.Drawing.Point(93, 350);
            yearTextBox.Size = new System.Drawing.Size(250, 27);

            // Buttons
            addButton.Text = "Add";
            addButton.Location = new System.Drawing.Point(380, 288);
            addButton.Click += addButton_Click;

            updateButton.Text = "Update";
            updateButton.Location = new System.Drawing.Point(380, 318);
            updateButton.Click += updateButton_Click;

            deleteButton.Text = "Delete";
            deleteButton.Location = new System.Drawing.Point(380, 348);
            deleteButton.Click += deleteButton_Click;
            
            clearButton.Text = "Clear Selection";
            clearButton.Location = new System.Drawing.Point(380, 258);
            clearButton.Width = 100;
            clearButton.Click += clearButton_Click;

            // Add controls to form
            this.Controls.Add(carsDataGridView);
            this.Controls.Add(vinLabel);
            this.Controls.Add(makeLabel);
            this.Controls.Add(modelLabel);
            this.Controls.Add(yearLabel);
            this.Controls.Add(vinTextBox);
            this.Controls.Add(makeTextBox);
            this.Controls.Add(modelTextBox);
            this.Controls.Add(yearTextBox);
            this.Controls.Add(addButton);
            this.Controls.Add(updateButton);
            this.Controls.Add(deleteButton);
            this.Controls.Add(clearButton);

            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Car Management";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _context = new CarContext();

            // Ensure the database is created if it does not exist
            _context.Database.EnsureCreated();

            // Load data from the database into the context
            _context.Cars.Load();

            // Bind the BindingSource to the local, in-memory data
            _carBindingSource.DataSource = _context.Cars.Local.ToBindingList();

            // Bind the DataGridView to the BindingSource
            carsDataGridView.DataSource = _carBindingSource;
            carsDataGridView.Columns["VIN"].Width = 200;
            carsDataGridView.Columns["Make"].Width = 150;
            carsDataGridView.Columns["Model"].Width = 150;

            // Initially clear fields for new entry
            ClearFields();
        }

        private void carsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (carsDataGridView.CurrentRow != null && carsDataGridView.CurrentRow.DataBoundItem is Car car)
            {
                vinTextBox.Text = car.VIN;
                makeTextBox.Text = car.Make;
                modelTextBox.Text = car.Model;
                yearTextBox.Text = car.Year.ToString();
                
                // VIN is the primary key and shouldn't be changed for an existing record
                vinTextBox.ReadOnly = true;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            carsDataGridView.ClearSelection();
            vinTextBox.Clear();
            makeTextBox.Clear();
            modelTextBox.Clear();
            yearTextBox.Clear();
            vinTextBox.ReadOnly = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if VIN already exists
                if (_context.Cars.Local.Any(c => c.VIN == vinTextBox.Text))
                {
                    MessageBox.Show("A car with this VIN already exists.");
                    return;
                }

                var newCar = new Car
                {
                    VIN = vinTextBox.Text,
                    Make = makeTextBox.Text,
                    Model = modelTextBox.Text,
                    Year = int.TryParse(yearTextBox.Text, out int y) ? y : 0
                };
                _context.Cars.Add(newCar);
                _context.SaveChanges();
                
                // Refresh grid and clear fields
                carsDataGridView.Refresh();
                ClearFields();
                MessageBox.Show("Car added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding car: {ex.Message}");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(vinTextBox.Text)) return;
                
                // Find the car in the Local view first to avoid attaching a new object with same key
                var carToUpdate = _context.Cars.Local.FirstOrDefault(c => c.VIN == vinTextBox.Text);

                if (carToUpdate != null)
                {
                    carToUpdate.Make = makeTextBox.Text;
                    carToUpdate.Model = modelTextBox.Text;
                    carToUpdate.Year = int.TryParse(yearTextBox.Text, out int y) ? y : 0;

                    _context.SaveChanges();
                    carsDataGridView.Refresh();
                    MessageBox.Show("Update successful!");
                }
                else
                {
                    MessageBox.Show("Car not found to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating car: {ex.Message}");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (carsDataGridView.CurrentRow?.DataBoundItem is Car currentCar)
            {
                try
                {
                    _context.Cars.Remove(currentCar);
                    _context.SaveChanges();
                    // Grid updates automatically via BindingList but sometimes needs a nudge if using Remove
                    ClearFields();
                    MessageBox.Show("Car deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting car: {ex.Message}");
                }
            }
            else if (!string.IsNullOrEmpty(vinTextBox.Text))
            {
                // Alternative: Delete by VIN in textbox if no row selected
                var car = _context.Cars.Local.FirstOrDefault(c => c.VIN == vinTextBox.Text);
                if (car != null)
                {
                    _context.Cars.Remove(car);
                    _context.SaveChanges();
                    ClearFields();
                    MessageBox.Show("Car deleted successfully!");
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context?.Dispose(); // Dispose the context when the form is closing
        }
    }
}
