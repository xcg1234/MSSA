namespace Assngiment4_2
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
            lblUserId = new Label();
            txtUserId = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Font = new Font("Segoe UI", 10F);
            lblUserId.Location = new Point(80, 100);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(70, 23);
            lblUserId.TabIndex = 0;
            lblUserId.Text = "User ID:";
            // 
            // txtUserId
            // 
            txtUserId.Font = new Font("Segoe UI", 10F);
            txtUserId.Location = new Point(165, 97);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(200, 30);
            txtUserId.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(165, 147);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 30);
            txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(80, 150);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(84, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 102, 204);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(165, 210);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(120, 40);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.Location = new Point(60, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(406, 37);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Learning Management System";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(542, 375);
            Controls.Add(lblTitle);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUserId);
            Controls.Add(lblUserId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Teacher Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserId;
        private TextBox txtUserId;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnLogin;
        private Label lblTitle;
    }
}
