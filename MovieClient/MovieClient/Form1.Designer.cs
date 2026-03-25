namespace MovieClient
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
            lblId = new Label();
            txtId = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblDirector = new Label();
            txtDirector = new TextBox();
            lblReleaseYear = new Label();
            txtReleaseYear = new TextBox();
            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            moviesGrid = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)moviesGrid).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(12, 18);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Id";
            // 
            // txtId
            // 
            txtId.Location = new Point(39, 15);
            txtId.Name = "txtId";
            txtId.Size = new Size(90, 27);
            txtId.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(150, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(38, 20);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(194, 15);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(220, 27);
            txtTitle.TabIndex = 3;
            // 
            // lblDirector
            // 
            lblDirector.AutoSize = true;
            lblDirector.Location = new Point(430, 18);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(63, 20);
            lblDirector.TabIndex = 4;
            lblDirector.Text = "Director";
            // 
            // txtDirector
            // 
            txtDirector.Location = new Point(499, 15);
            txtDirector.Name = "txtDirector";
            txtDirector.Size = new Size(220, 27);
            txtDirector.TabIndex = 5;
            // 
            // lblReleaseYear
            // 
            lblReleaseYear.AutoSize = true;
            lblReleaseYear.Location = new Point(735, 18);
            lblReleaseYear.Name = "lblReleaseYear";
            lblReleaseYear.Size = new Size(88, 20);
            lblReleaseYear.TabIndex = 6;
            lblReleaseYear.Text = "ReleaseYear";
            // 
            // txtReleaseYear
            // 
            txtReleaseYear.Location = new Point(830, 15);
            txtReleaseYear.Name = "txtReleaseYear";
            txtReleaseYear.Size = new Size(95, 27);
            txtReleaseYear.TabIndex = 7;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(12, 55);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 35);
            btnLoad.TabIndex = 8;
            btnLoad.Text = "Load Movies";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(150, 55);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 35);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(288, 55);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 35);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(426, 55);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 35);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // moviesGrid
            // 
            moviesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            moviesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            moviesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            moviesGrid.Location = new Point(12, 106);
            moviesGrid.Name = "moviesGrid";
            moviesGrid.RowHeadersWidth = 51;
            moviesGrid.Size = new Size(1154, 482);
            moviesGrid.TabIndex = 12;
            moviesGrid.SelectionChanged += moviesGrid_SelectionChanged;
            // 
            // button1
            // 
            button1.Location = new Point(552, 55);
            button1.Name = "button1";
            button1.Size = new Size(120, 35);
            button1.TabIndex = 13;
            button1.Text = "GetWeather";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btn_GetWeather;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 600);
            Controls.Add(button1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtReleaseYear);
            Controls.Add(lblReleaseYear);
            Controls.Add(txtDirector);
            Controls.Add(lblDirector);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(moviesGrid);
            Controls.Add(btnLoad);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)moviesGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private TextBox txtId;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblDirector;
        private TextBox txtDirector;
        private Label lblReleaseYear;
        private TextBox txtReleaseYear;
        private Button btnLoad;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView moviesGrid;
        private Button button1;
    }
}
