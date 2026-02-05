namespace Assngiment4_2
{
    partial class TeacherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblStudentName = new Label();
            txtStudentName = new TextBox();
            lblGPA = new Label();
            txtGPA = new TextBox();
            btnAddStudent = new Button();
            lstStudents = new ListBox();
            btnDeleteStudent = new Button();
            btnSaveHighestGPA = new Button();
            lblStudentsList = new Label();
            SuspendLayout();
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(30, 30);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(82, 20);
            lblStudentId.TabIndex = 0;
            lblStudentId.Text = "Student ID:";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(150, 27);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(200, 27);
            txtStudentId.TabIndex = 1;
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.Location = new Point(30, 70);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(107, 20);
            lblStudentName.TabIndex = 2;
            lblStudentName.Text = "Student Name:";
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(150, 67);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(200, 27);
            txtStudentName.TabIndex = 3;
            // 
            // lblGPA
            // 
            lblGPA.AutoSize = true;
            lblGPA.Location = new Point(30, 110);
            lblGPA.Name = "lblGPA";
            lblGPA.Size = new Size(39, 20);
            lblGPA.TabIndex = 4;
            lblGPA.Text = "GPA:";
            // 
            // txtGPA
            // 
            txtGPA.Location = new Point(150, 107);
            txtGPA.Name = "txtGPA";
            txtGPA.Size = new Size(200, 27);
            txtGPA.TabIndex = 5;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(150, 150);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(130, 35);
            btnAddStudent.TabIndex = 6;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = true;
            // 
            // lstStudents
            // 
            lstStudents.FormattingEnabled = true;
            lstStudents.Location = new Point(30, 240);
            lstStudents.Name = "lstStudents";
            lstStudents.Size = new Size(740, 144);
            lstStudents.TabIndex = 8;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new Point(30, 400);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(180, 35);
            btnDeleteStudent.TabIndex = 9;
            btnDeleteStudent.Text = "Delete Selected Student";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            // 
            // btnSaveHighestGPA
            // 
            btnSaveHighestGPA.Location = new Point(230, 400);
            btnSaveHighestGPA.Name = "btnSaveHighestGPA";
            btnSaveHighestGPA.Size = new Size(180, 35);
            btnSaveHighestGPA.TabIndex = 10;
            btnSaveHighestGPA.Text = "Save Highest GPA";
            btnSaveHighestGPA.UseVisualStyleBackColor = true;
            btnSaveHighestGPA.Click += btnSaveHighestGPA_Click;
            // 
            // lblStudentsList
            // 
            lblStudentsList.AutoSize = true;
            lblStudentsList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStudentsList.Location = new Point(30, 210);
            lblStudentsList.Name = "lblStudentsList";
            lblStudentsList.Size = new Size(114, 23);
            lblStudentsList.TabIndex = 7;
            lblStudentsList.Text = "Students List";
            // 
            // TeacherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 460);
            Controls.Add(btnSaveHighestGPA);
            Controls.Add(btnDeleteStudent);
            Controls.Add(lstStudents);
            Controls.Add(lblStudentsList);
            Controls.Add(btnAddStudent);
            Controls.Add(txtGPA);
            Controls.Add(lblGPA);
            Controls.Add(txtStudentName);
            Controls.Add(lblStudentName);
            Controls.Add(txtStudentId);
            Controls.Add(lblStudentId);
            Name = "TeacherForm";
            Text = "Teacher Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblStudentName;
        private TextBox txtStudentName;
        private Label lblGPA;
        private TextBox txtGPA;
        private Button btnAddStudent;
        private ListBox lstStudents;
        private Button btnDeleteStudent;
        private Button btnSaveHighestGPA;
        private Label lblStudentsList;
    }
}