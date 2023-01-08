namespace CollectionOfTestingApp
{
    partial class UserGroup7
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Reset_But = new System.Windows.Forms.Button();
            this.Pause_But = new System.Windows.Forms.Button();
            this.Record_But = new System.Windows.Forms.Button();
            this.Start_But = new System.Windows.Forms.Button();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.Percentage = new System.Windows.Forms.Label();
            this.PercentageBar = new System.Windows.Forms.ProgressBar();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.write_data = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.Remaining_Timer = new System.Windows.Forms.Timer(this.components);
            this.Stopwatch_Timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Reset_But);
            this.panel1.Controls.Add(this.Pause_But);
            this.panel1.Controls.Add(this.Record_But);
            this.panel1.Controls.Add(this.Start_But);
            this.panel1.Controls.Add(this.lbl_Time);
            this.panel1.Controls.Add(this.Percentage);
            this.panel1.Controls.Add(this.PercentageBar);
            this.panel1.Controls.Add(this.TimeLabel);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.write_data);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Location = new System.Drawing.Point(-7, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1777, 1051);
            this.panel1.TabIndex = 0;
            // 
            // Reset_But
            // 
            this.Reset_But.Enabled = false;
            this.Reset_But.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_But.Location = new System.Drawing.Point(590, 150);
            this.Reset_But.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reset_But.Name = "Reset_But";
            this.Reset_But.Size = new System.Drawing.Size(145, 34);
            this.Reset_But.TabIndex = 22;
            this.Reset_But.Text = "Reset";
            this.Reset_But.UseVisualStyleBackColor = true;
            this.Reset_But.Click += new System.EventHandler(this.Reset_But_Click);
            // 
            // Pause_But
            // 
            this.Pause_But.Enabled = false;
            this.Pause_But.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pause_But.Location = new System.Drawing.Point(256, 150);
            this.Pause_But.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pause_But.Name = "Pause_But";
            this.Pause_But.Size = new System.Drawing.Size(145, 34);
            this.Pause_But.TabIndex = 21;
            this.Pause_But.Text = "Pause";
            this.Pause_But.UseVisualStyleBackColor = true;
            this.Pause_But.Click += new System.EventHandler(this.Pause_But_Click);
            // 
            // Record_But
            // 
            this.Record_But.Enabled = false;
            this.Record_But.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record_But.Location = new System.Drawing.Point(423, 150);
            this.Record_But.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Record_But.Name = "Record_But";
            this.Record_But.Size = new System.Drawing.Size(145, 34);
            this.Record_But.TabIndex = 20;
            this.Record_But.Text = "Record";
            this.Record_But.UseVisualStyleBackColor = true;
            this.Record_But.Click += new System.EventHandler(this.Record_But_Click);
            // 
            // Start_But
            // 
            this.Start_But.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_But.Location = new System.Drawing.Point(90, 150);
            this.Start_But.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start_But.Name = "Start_But";
            this.Start_But.Size = new System.Drawing.Size(145, 34);
            this.Start_But.TabIndex = 19;
            this.Start_But.Text = "Start";
            this.Start_But.UseVisualStyleBackColor = true;
            this.Start_But.Click += new System.EventHandler(this.Start_But_Click);
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Time.Location = new System.Drawing.Point(366, 100);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(291, 41);
            this.lbl_Time.TabIndex = 18;
            this.lbl_Time.Text = "00 : 00 : 00 : 000";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Percentage
            // 
            this.Percentage.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Percentage.Location = new System.Drawing.Point(838, 66);
            this.Percentage.Name = "Percentage";
            this.Percentage.Size = new System.Drawing.Size(89, 31);
            this.Percentage.TabIndex = 17;
            this.Percentage.Text = "0 %";
            this.Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PercentageBar
            // 
            this.PercentageBar.Location = new System.Drawing.Point(36, 66);
            this.PercentageBar.Margin = new System.Windows.Forms.Padding(4);
            this.PercentageBar.Name = "PercentageBar";
            this.PercentageBar.Size = new System.Drawing.Size(873, 31);
            this.PercentageBar.TabIndex = 16;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(31, 38);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(308, 25);
            this.TimeLabel.TabIndex = 15;
            this.TimeLabel.Text = "Remaining Time = 00 : 00 : 00";
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(935, 38);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.LabelBorderWidth = 5;
            series1.Legend = "Legend1";
            series1.MarkerSize = 1;
            series1.Name = "Battery";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(634, 930);
            this.chart1.TabIndex = 23;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Battery Chart";
            this.chart1.Titles.Add(title1);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 50;
            this.listBox1.Location = new System.Drawing.Point(36, 311);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(873, 702);
            this.listBox1.TabIndex = 28;
            // 
            // write_data
            // 
            this.write_data.Enabled = false;
            this.write_data.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.write_data.Location = new System.Drawing.Point(748, 150);
            this.write_data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.write_data.Name = "write_data";
            this.write_data.Size = new System.Drawing.Size(177, 34);
            this.write_data.TabIndex = 27;
            this.write_data.Text = "Download Record";
            this.write_data.UseVisualStyleBackColor = true;
            this.write_data.Click += new System.EventHandler(this.write_data_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label2.Location = new System.Drawing.Point(31, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 32);
            this.label2.TabIndex = 26;
            this.label2.Text = "Record Results :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 28);
            this.label1.TabIndex = 25;
            this.label1.Text = "Start Record : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBox2
            // 
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 46;
            this.listBox2.Location = new System.Drawing.Point(270, 223);
            this.listBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(473, 48);
            this.listBox2.TabIndex = 24;
            // 
            // Remaining_Timer
            // 
            this.Remaining_Timer.Enabled = true;
            this.Remaining_Timer.Interval = 1000;
            this.Remaining_Timer.Tick += new System.EventHandler(this.Remaining_Timer_Tick);
            // 
            // Stopwatch_Timer
            // 
            this.Stopwatch_Timer.Tick += new System.EventHandler(this.Stopwatch_Timer_Tick);
            // 
            // UserGroup7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserGroup7";
            this.Size = new System.Drawing.Size(1577, 1051);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Reset_But;
        private System.Windows.Forms.Button Pause_But;
        private System.Windows.Forms.Button Record_But;
        private System.Windows.Forms.Button Start_But;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label Percentage;
        private System.Windows.Forms.ProgressBar PercentageBar;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button write_data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Timer Remaining_Timer;
        private System.Windows.Forms.Timer Stopwatch_Timer;
    }
}
