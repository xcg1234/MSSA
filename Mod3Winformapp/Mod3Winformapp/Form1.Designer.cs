namespace Mod3Winformapp
{
    partial class lblheading
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
            lblhandling = new Label();
            btnChange = new Button();
            txtName = new TextBox();
            lowButton = new Button();
            nameLabel = new Label();
            SuspendLayout();
            // 
            // lblhandling
            // 
            lblhandling.AutoSize = true;
            lblhandling.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblhandling.ForeColor = SystemColors.ActiveCaption;
            lblhandling.Location = new Point(104, 63);
            lblhandling.Name = "lblhandling";
            lblhandling.Size = new Size(372, 46);
            lblhandling.TabIndex = 0;
            lblhandling.Text = "Welcome To C# course!";
            lblhandling.Click += lblhandling_Click;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(228, 138);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(94, 29);
            btnChange.TabIndex = 1;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(227, 308);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 2;
            // 
            // lowButton
            // 
            lowButton.Location = new Point(91, 308);
            lowButton.Name = "lowButton";
            lowButton.Size = new Size(94, 29);
            lowButton.TabIndex = 3;
            lowButton.Text = "SAY HI";
            lowButton.UseVisualStyleBackColor = true;
            lowButton.Click += lowButton_Click;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(264, 285);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(49, 20);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Name";
            // 
            // lblheading
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 544);
            Controls.Add(nameLabel);
            Controls.Add(lowButton);
            Controls.Add(txtName);
            Controls.Add(btnChange);
            Controls.Add(lblhandling);
            Name = "lblheading";
            Text = "Form1";
            Load += Form1_Load;
            DragDrop += Form1_DragDrop;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblhandling;
        private Button btnChange;
        private TextBox txtName;
        private Button lowButton;
        private Label nameLabel;
    }
}
