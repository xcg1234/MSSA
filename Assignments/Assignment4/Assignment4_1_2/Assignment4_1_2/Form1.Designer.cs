namespace Assignment4_1_2
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
            txtNumber1 = new TextBox();
            txtNumber2 = new TextBox();
            txtResult = new TextBox();
            btnAdd = new Button();
            btnSubtract = new Button();
            btnMultiply = new Button();
            btnDivide = new Button();
            btnClear = new Button();
            lblNumber1 = new Label();
            lblNumber2 = new Label();
            lblResult = new Label();
            SuspendLayout();
            // 
            // txtNumber1
            // 
            txtNumber1.Font = new Font("Segoe UI", 12F);
            txtNumber1.Location = new Point(150, 30);
            txtNumber1.Name = "txtNumber1";
            txtNumber1.Size = new Size(200, 29);
            txtNumber1.TabIndex = 0;
            // 
            // txtNumber2
            // 
            txtNumber2.Font = new Font("Segoe UI", 12F);
            txtNumber2.Location = new Point(150, 80);
            txtNumber2.Name = "txtNumber2";
            txtNumber2.Size = new Size(200, 29);
            txtNumber2.TabIndex = 1;
            // 
            // txtResult
            // 
            txtResult.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtResult.Location = new Point(150, 130);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(200, 29);
            txtResult.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnAdd.Location = new Point(50, 200);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 60);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSubtract
            // 
            btnSubtract.BackColor = Color.LightBlue;
            btnSubtract.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnSubtract.Location = new Point(150, 200);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new Size(80, 60);
            btnSubtract.TabIndex = 4;
            btnSubtract.Text = "-";
            btnSubtract.UseVisualStyleBackColor = false;
            btnSubtract.Click += btnSubtract_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.BackColor = Color.LightCoral;
            btnMultiply.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnMultiply.Location = new Point(250, 200);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(80, 60);
            btnMultiply.TabIndex = 5;
            btnMultiply.Text = "×";
            btnMultiply.UseVisualStyleBackColor = false;
            btnMultiply.Click += btnMultiply_Click;
            // 
            // btnDivide
            // 
            btnDivide.BackColor = Color.LightGoldenrodYellow;
            btnDivide.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnDivide.Location = new Point(350, 200);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(80, 60);
            btnDivide.TabIndex = 6;
            btnDivide.Text = "÷";
            btnDivide.UseVisualStyleBackColor = false;
            btnDivide.Click += btnDivide_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.LightGray;
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClear.Location = new Point(150, 280);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(180, 40);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblNumber1
            // 
            lblNumber1.AutoSize = true;
            lblNumber1.Font = new Font("Segoe UI", 12F);
            lblNumber1.Location = new Point(30, 33);
            lblNumber1.Name = "lblNumber1";
            lblNumber1.Size = new Size(86, 21);
            lblNumber1.TabIndex = 8;
            lblNumber1.Text = "Number 1:";
            // 
            // lblNumber2
            // 
            lblNumber2.AutoSize = true;
            lblNumber2.Font = new Font("Segoe UI", 12F);
            lblNumber2.Location = new Point(30, 83);
            lblNumber2.Name = "lblNumber2";
            lblNumber2.Size = new Size(86, 21);
            lblNumber2.TabIndex = 9;
            lblNumber2.Text = "Number 2:";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblResult.Location = new Point(30, 133);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(61, 21);
            lblResult.TabIndex = 10;
            lblResult.Text = "Result:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(lblResult);
            Controls.Add(lblNumber2);
            Controls.Add(lblNumber1);
            Controls.Add(btnClear);
            Controls.Add(btnDivide);
            Controls.Add(btnMultiply);
            Controls.Add(btnSubtract);
            Controls.Add(btnAdd);
            Controls.Add(txtResult);
            Controls.Add(txtNumber2);
            Controls.Add(txtNumber1);
            Name = "Form1";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumber1;
        private TextBox txtNumber2;
        private TextBox txtResult;
        private Button btnAdd;
        private Button btnSubtract;
        private Button btnMultiply;
        private Button btnDivide;
        private Button btnClear;
        private Label lblNumber1;
        private Label lblNumber2;
        private Label lblResult;
    }
}
