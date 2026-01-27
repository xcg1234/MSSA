namespace Assignment3_3
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
            studentID = new Label();
            firstName = new Label();
            lastName = new Label();
            address = new Label();
            textId = new TextBox();
            txtAddress = new TextBox();
            textLastname = new TextBox();
            txtFirstName = new TextBox();
            cmbMonth = new ComboBox();
            adMonth = new Label();
            txtGrade = new TextBox();
            gradeLabel = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            dgvStudents = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // studentID
            // 
            studentID.AutoSize = true;
            studentID.Location = new Point(98, 22);
            studentID.Name = "studentID";
            studentID.Size = new Size(75, 20);
            studentID.TabIndex = 0;
            studentID.Text = "StudentID";
            // 
            // firstName
            // 
            firstName.AutoSize = true;
            firstName.Location = new Point(98, 56);
            firstName.Name = "firstName";
            firstName.Size = new Size(80, 20);
            firstName.TabIndex = 1;
            firstName.Text = "First Name";
            firstName.Click += label2_Click;
            // 
            // lastName
            // 
            lastName.AutoSize = true;
            lastName.Location = new Point(98, 93);
            lastName.Name = "lastName";
            lastName.Size = new Size(79, 20);
            lastName.TabIndex = 2;
            lastName.Text = "Last Name";
            // 
            // address
            // 
            address.AutoSize = true;
            address.Location = new Point(98, 128);
            address.Name = "address";
            address.Size = new Size(62, 20);
            address.TabIndex = 3;
            address.Text = "Address";
            // 
            // textId
            // 
            textId.Location = new Point(179, 22);
            textId.Name = "textId";
            textId.Size = new Size(125, 27);
            textId.TabIndex = 4;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(179, 119);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 6;
            // 
            // textLastname
            // 
            textLastname.Location = new Point(179, 86);
            textLastname.Name = "textLastname";
            textLastname.Size = new Size(125, 27);
            textLastname.TabIndex = 7;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(179, 53);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 8;
            // 
            // cmbMonth
            // 
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Location = new Point(179, 165);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(151, 28);
            cmbMonth.TabIndex = 9;
            // 
            // adMonth
            // 
            adMonth.AutoSize = true;
            adMonth.Location = new Point(48, 168);
            adMonth.Name = "adMonth";
            adMonth.Size = new Size(125, 20);
            adMonth.TabIndex = 10;
            adMonth.Text = "Admission Month";
            adMonth.Click += label1_Click;
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(179, 210);
            txtGrade.MaxLength = 1;
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(125, 27);
            txtGrade.TabIndex = 11;
            txtGrade.TextChanged += txtGrade_TextChanged;
            // 
            // gradeLabel
            // 
            gradeLabel.AutoSize = true;
            gradeLabel.Location = new Point(111, 213);
            gradeLabel.Name = "gradeLabel";
            gradeLabel.Size = new Size(49, 20);
            gradeLabel.TabIndex = 12;
            gradeLabel.Text = "Grade";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(83, 334);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.DialogResult = DialogResult.OK;
            btnDelete.Location = new Point(210, 334);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(402, 22);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.Size = new Size(659, 392);
            dgvStudents.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 544);
            Controls.Add(dgvStudents);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(gradeLabel);
            Controls.Add(txtGrade);
            Controls.Add(adMonth);
            Controls.Add(cmbMonth);
            Controls.Add(txtFirstName);
            Controls.Add(textLastname);
            Controls.Add(txtAddress);
            Controls.Add(textId);
            Controls.Add(address);
            Controls.Add(lastName);
            Controls.Add(firstName);
            Controls.Add(studentID);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label studentID;
        private Label firstName;
        private Label lastName;
        private Label address;
        private TextBox textId;
        private TextBox txtAddress;
        private TextBox textLastname;
        private TextBox txtFirstName;
        private ComboBox cmbMonth;
        private Label adMonth;
        private TextBox txtGrade;
        private Label gradeLabel;
        private Button btnAdd;
        private Button btnDelete;
        private DataGridView dgvStudents;
    }
}
