namespace Assignment4_1
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
            dataGridView = new DataGridView();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblWorkPhone = new Label();
            lblCellPhone = new Label();
            lblAddress = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtWorkPhone = new TextBox();
            txtCellPhone = new TextBox();
            txtAddress = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(30, 266);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(907, 314);
            dataGridView.TabIndex = 0;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(30, 30);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(83, 20);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(30, 70);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(82, 20);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name:";
            // 
            // lblWorkPhone
            // 
            lblWorkPhone.AutoSize = true;
            lblWorkPhone.Location = new Point(30, 110);
            lblWorkPhone.Name = "lblWorkPhone";
            lblWorkPhone.Size = new Size(91, 20);
            lblWorkPhone.TabIndex = 3;
            lblWorkPhone.Text = "Work Phone:";
            // 
            // lblCellPhone
            // 
            lblCellPhone.AutoSize = true;
            lblCellPhone.Location = new Point(30, 150);
            lblCellPhone.Name = "lblCellPhone";
            lblCellPhone.Size = new Size(82, 20);
            lblCellPhone.TabIndex = 4;
            lblCellPhone.Text = "Cell Phone:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(30, 190);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(65, 20);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Address:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(140, 27);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(160, 27);
            txtFirstName.TabIndex = 6;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(140, 67);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(160, 27);
            txtLastName.TabIndex = 7;
            // 
            // txtWorkPhone
            // 
            txtWorkPhone.Location = new Point(140, 107);
            txtWorkPhone.Name = "txtWorkPhone";
            txtWorkPhone.Size = new Size(160, 27);
            txtWorkPhone.TabIndex = 8;
            // 
            // txtCellPhone
            // 
            txtCellPhone.Location = new Point(140, 147);
            txtCellPhone.Name = "txtCellPhone";
            txtCellPhone.Size = new Size(160, 27);
            txtCellPhone.TabIndex = 9;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(140, 187);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(160, 27);
            txtAddress.TabIndex = 10;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(30, 230);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 35);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add Contact";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(180, 230);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 35);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete Contact";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(343, 34);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 13;
            lblSearch.Text = "Search:";
            lblSearch.Click += lblSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(405, 31);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 27);
            txtSearch.TabIndex = 14;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(405, 70);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(133, 67);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(544, 70);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(139, 67);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 600);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtAddress);
            Controls.Add(txtCellPhone);
            Controls.Add(txtWorkPhone);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblAddress);
            Controls.Add(lblCellPhone);
            Controls.Add(lblWorkPhone);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(dataGridView);
            Name = "Form1";
            Text = "PhoneBook Application";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private DataGridView dataGridView;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblWorkPhone;
        private Label lblCellPhone;
        private Label lblAddress;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtWorkPhone;
        private TextBox txtCellPhone;
        private TextBox txtAddress;
        private Button btnAdd;
        private Button btnDelete;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClear;
    }
}
