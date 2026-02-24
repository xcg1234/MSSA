namespace StravaWinForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnConnect;
        private Label lblStatus;
        private TabControl tabControl;
        private TabPage tabActivities;
        private TabPage tabDashboard;
        private TabPage tabPersonalRecords;
        private DataGridView dgvActivities;
        private Button btnRefreshActivities;
        private Label lblRunThisYear;
        private Label lblRunLastYear;
        private Label lblBikeThisYear;
        private Label lblBikeLastYear;
        private Button btnRefreshDashboard;
        private ProgressBar progressBar;
        private Label lblLongestRun;
        private Label lblFastestPace;
        private Label lblLongestRide;
        private Label lblFastestRide;
        private Label lblMostElevation;
        private Button btnRefreshPRs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnConnect = new Button();
            lblStatus = new Label();
            tabControl = new TabControl();
            tabActivities = new TabPage();
            btnRefreshActivities = new Button();
            dgvActivities = new DataGridView();
            tabDashboard = new TabPage();
            btnRefreshDashboard = new Button();
            lblBikeLastYear = new Label();
            lblBikeThisYear = new Label();
            lblRunLastYear = new Label();
            lblRunThisYear = new Label();
            tabPersonalRecords = new TabPage();
            btnRefreshPRs = new Button();
            lblMostElevation = new Label();
            lblFastestRide = new Label();
            lblLongestRide = new Label();
            lblFastestPace = new Label();
            lblLongestRun = new Label();
            progressBar = new ProgressBar();
            tabControl.SuspendLayout();
            tabActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActivities).BeginInit();
            tabDashboard.SuspendLayout();
            tabPersonalRecords.SuspendLayout();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConnect.Location = new Point(12, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(200, 40);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect to Strava";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(218, 22);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(182, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Click Connect to authorize";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabActivities);
            tabControl.Controls.Add(tabDashboard);
            tabControl.Controls.Add(tabPersonalRecords);
            tabControl.Location = new Point(12, 74);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(891, 399);
            tabControl.TabIndex = 3;
            // 
            // tabActivities
            // 
            tabActivities.Controls.Add(btnRefreshActivities);
            tabActivities.Controls.Add(dgvActivities);
            tabActivities.Location = new Point(4, 29);
            tabActivities.Name = "tabActivities";
            tabActivities.Padding = new Padding(3);
            tabActivities.Size = new Size(883, 366);
            tabActivities.TabIndex = 0;
            tabActivities.Text = "Last 5 Activities";
            tabActivities.UseVisualStyleBackColor = true;
            // 
            // btnRefreshActivities
            // 
            btnRefreshActivities.Location = new Point(6, 6);
            btnRefreshActivities.Name = "btnRefreshActivities";
            btnRefreshActivities.Size = new Size(150, 34);
            btnRefreshActivities.TabIndex = 1;
            btnRefreshActivities.Text = "Refresh Activities";
            btnRefreshActivities.UseVisualStyleBackColor = true;
            btnRefreshActivities.Click += btnRefreshActivities_Click;
            // 
            // dgvActivities
            // 
            dgvActivities.AllowUserToAddRows = false;
            dgvActivities.AllowUserToDeleteRows = false;
            dgvActivities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActivities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActivities.Location = new Point(6, 46);
            dgvActivities.Name = "dgvActivities";
            dgvActivities.ReadOnly = true;
            dgvActivities.RowHeadersWidth = 51;
            dgvActivities.Size = new Size(871, 314);
            dgvActivities.TabIndex = 0;
            // 
            // tabDashboard
            // 
            tabDashboard.Controls.Add(btnRefreshDashboard);
            tabDashboard.Controls.Add(lblBikeLastYear);
            tabDashboard.Controls.Add(lblBikeThisYear);
            tabDashboard.Controls.Add(lblRunLastYear);
            tabDashboard.Controls.Add(lblRunThisYear);
            tabDashboard.Location = new Point(4, 29);
            tabDashboard.Name = "tabDashboard";
            tabDashboard.Padding = new Padding(3);
            tabDashboard.Size = new Size(883, 366);
            tabDashboard.TabIndex = 1;
            tabDashboard.Text = "Yearly Comparison";
            tabDashboard.UseVisualStyleBackColor = true;
            // 
            // btnRefreshDashboard
            // 
            btnRefreshDashboard.Location = new Point(6, 6);
            btnRefreshDashboard.Name = "btnRefreshDashboard";
            btnRefreshDashboard.Size = new Size(180, 34);
            btnRefreshDashboard.TabIndex = 4;
            btnRefreshDashboard.Text = "Refresh Dashboard";
            btnRefreshDashboard.UseVisualStyleBackColor = true;
            btnRefreshDashboard.Click += btnRefreshDashboard_Click;
            // 
            // lblBikeLastYear
            // 
            lblBikeLastYear.AutoSize = true;
            lblBikeLastYear.Font = new Font("Segoe UI", 14F);
            lblBikeLastYear.Location = new Point(50, 260);
            lblBikeLastYear.Name = "lblBikeLastYear";
            lblBikeLastYear.Size = new Size(229, 32);
            lblBikeLastYear.TabIndex = 3;
            lblBikeLastYear.Text = "2025 Biking: 0.00 mi";
            // 
            // lblBikeThisYear
            // 
            lblBikeThisYear.AutoSize = true;
            lblBikeThisYear.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBikeThisYear.ForeColor = Color.DarkBlue;
            lblBikeThisYear.Location = new Point(50, 210);
            lblBikeThisYear.Name = "lblBikeThisYear";
            lblBikeThisYear.Size = new Size(278, 37);
            lblBikeThisYear.TabIndex = 2;
            lblBikeThisYear.Text = "2026 Biking: 0.00 mi";
            // 
            // lblRunLastYear
            // 
            lblRunLastYear.AutoSize = true;
            lblRunLastYear.Font = new Font("Segoe UI", 14F);
            lblRunLastYear.Location = new Point(50, 130);
            lblRunLastYear.Name = "lblRunLastYear";
            lblRunLastYear.Size = new Size(293, 32);
            lblRunLastYear.TabIndex = 1;
            lblRunLastYear.Text = "🏃 2025 Running: 0.00 mi";
            // 
            // lblRunThisYear
            // 
            lblRunThisYear.AutoSize = true;
            lblRunThisYear.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblRunThisYear.ForeColor = Color.DarkGreen;
            lblRunThisYear.Location = new Point(50, 80);
            lblRunThisYear.Name = "lblRunThisYear";
            lblRunThisYear.Size = new Size(349, 37);
            lblRunThisYear.TabIndex = 0;
            lblRunThisYear.Text = "🏃 2026 Running: 0.00 mi";
            // 
            // tabPersonalRecords
            // 
            tabPersonalRecords.Controls.Add(btnRefreshPRs);
            tabPersonalRecords.Controls.Add(lblMostElevation);
            tabPersonalRecords.Controls.Add(lblFastestRide);
            tabPersonalRecords.Controls.Add(lblLongestRide);
            tabPersonalRecords.Controls.Add(lblFastestPace);
            tabPersonalRecords.Controls.Add(lblLongestRun);
            tabPersonalRecords.Location = new Point(4, 29);
            tabPersonalRecords.Name = "tabPersonalRecords";
            tabPersonalRecords.Size = new Size(883, 366);
            tabPersonalRecords.TabIndex = 3;
            tabPersonalRecords.Text = "Personal Records";
            tabPersonalRecords.UseVisualStyleBackColor = true;
            // 
            // btnRefreshPRs
            // 
            btnRefreshPRs.Location = new Point(6, 6);
            btnRefreshPRs.Name = "btnRefreshPRs";
            btnRefreshPRs.Size = new Size(180, 34);
            btnRefreshPRs.TabIndex = 5;
            btnRefreshPRs.Text = "Refresh Personal Records";
            btnRefreshPRs.UseVisualStyleBackColor = true;
            btnRefreshPRs.Click += btnRefreshPRs_Click;
            // 
            // lblMostElevation
            // 
            lblMostElevation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMostElevation.ForeColor = Color.DarkOrange;
            lblMostElevation.Location = new Point(30, 260);
            lblMostElevation.Name = "lblMostElevation";
            lblMostElevation.Size = new Size(820, 40);
            lblMostElevation.TabIndex = 4;
            lblMostElevation.Text = "⛰️ Most Elevation Gain: --";
            // 
            // lblFastestRide
            // 
            lblFastestRide.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFastestRide.ForeColor = Color.Blue;
            lblFastestRide.Location = new Point(30, 210);
            lblFastestRide.Name = "lblFastestRide";
            lblFastestRide.Size = new Size(820, 40);
            lblFastestRide.TabIndex = 3;
            lblFastestRide.Text = "⚡ Fastest Ride: --";
            // 
            // lblLongestRide
            // 
            lblLongestRide.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLongestRide.ForeColor = Color.DarkBlue;
            lblLongestRide.Location = new Point(30, 160);
            lblLongestRide.Name = "lblLongestRide";
            lblLongestRide.Size = new Size(820, 40);
            lblLongestRide.TabIndex = 2;
            lblLongestRide.Text = "🏆 Longest Ride: --";
            // 
            // lblFastestPace
            // 
            lblFastestPace.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFastestPace.ForeColor = Color.Green;
            lblFastestPace.Location = new Point(30, 110);
            lblFastestPace.Name = "lblFastestPace";
            lblFastestPace.Size = new Size(820, 40);
            lblFastestPace.TabIndex = 1;
            lblFastestPace.Text = "⚡ Fastest Run Pace: --";
            // 
            // lblLongestRun
            // 
            lblLongestRun.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLongestRun.ForeColor = Color.DarkGreen;
            lblLongestRun.Location = new Point(30, 60);
            lblLongestRun.Name = "lblLongestRun";
            lblLongestRun.Size = new Size(820, 40);
            lblLongestRun.TabIndex = 0;
            lblLongestRun.Text = "🏆 Longest Run: --";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 58);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(891, 10);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 2;
            progressBar.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 514);
            Controls.Add(tabControl);
            Controls.Add(progressBar);
            Controls.Add(lblStatus);
            Controls.Add(btnConnect);
            Name = "Form1";
            Text = "Strava Activity Tracker";
            Load += Form1_Load;
            tabControl.ResumeLayout(false);
            tabActivities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActivities).EndInit();
            tabDashboard.ResumeLayout(false);
            tabDashboard.PerformLayout();
            tabPersonalRecords.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
