namespace Assignment3_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewCoffees = new DataGridView();
            groupBoxAddCoffee = new GroupBox();
            btnAdd = new Button();
            cboSize = new ComboBox();
            lblSize = new Label();
            numPrice = new NumericUpDown();
            lblPrice = new Label();
            txtName = new TextBox();
            lblName = new Label();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCoffees).BeginInit();
            groupBoxAddCoffee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCoffees
            // 
            dataGridViewCoffees.AllowUserToAddRows = false;
            dataGridViewCoffees.AllowUserToDeleteRows = false;
            dataGridViewCoffees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCoffees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCoffees.Location = new Point(12, 12);
            dataGridViewCoffees.MultiSelect = false;
            dataGridViewCoffees.Name = "dataGridViewCoffees";
            dataGridViewCoffees.ReadOnly = true;
            dataGridViewCoffees.RowHeadersWidth = 51;
            dataGridViewCoffees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCoffees.Size = new Size(500, 250);
            dataGridViewCoffees.TabIndex = 0;
            // 
            // groupBoxAddCoffee
            // 
            groupBoxAddCoffee.Controls.Add(btnAdd);
            groupBoxAddCoffee.Controls.Add(cboSize);
            groupBoxAddCoffee.Controls.Add(lblSize);
            groupBoxAddCoffee.Controls.Add(numPrice);
            groupBoxAddCoffee.Controls.Add(lblPrice);
            groupBoxAddCoffee.Controls.Add(txtName);
            groupBoxAddCoffee.Controls.Add(lblName);
            groupBoxAddCoffee.Location = new Point(12, 270);
            groupBoxAddCoffee.Name = "groupBoxAddCoffee";
            groupBoxAddCoffee.Size = new Size(500, 140);
            groupBoxAddCoffee.TabIndex = 1;
            groupBoxAddCoffee.TabStop = false;
            groupBoxAddCoffee.Text = "Add New Coffee";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(370, 100);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 30);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add Coffee";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboSize
            // 
            cboSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSize.FormattingEnabled = true;
            cboSize.Items.AddRange(new object[] { "Small", "Medium", "Large" });
            cboSize.Location = new Point(120, 100);
            cboSize.Name = "cboSize";
            cboSize.Size = new Size(130, 28);
            cboSize.TabIndex = 5;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(20, 103);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(39, 20);
            lblSize.TabIndex = 4;
            lblSize.Text = "Size:";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(120, 70);
            numPrice.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(130, 27);
            numPrice.TabIndex = 3;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 72);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(44, 20);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Price:";
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 40);
            txtName.Name = "txtName";
            txtName.Size = new Size(130, 27);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 43);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 420);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 30);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Selected";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 486);
            Controls.Add(btnDelete);
            Controls.Add(groupBoxAddCoffee);
            Controls.Add(dataGridViewCoffees);
            Name = "Form1";
            Text = "Coffee Management System";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCoffees).EndInit();
            groupBoxAddCoffee.ResumeLayout(false);
            groupBoxAddCoffee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewCoffees;
        private GroupBox groupBoxAddCoffee;
        private TextBox txtName;
        private Label lblName;
        private NumericUpDown numPrice;
        private Label lblPrice;
        private ComboBox cboSize;
        private Label lblSize;
        private Button btnAdd;
        private Button btnDelete;
    }
}
