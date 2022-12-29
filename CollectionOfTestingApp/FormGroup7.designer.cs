namespace CollectionOfTestingApp
{
    partial class FormGroup7
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGroup7));
            this.TimeLabel = new System.Windows.Forms.Label();
            this.PercentageBar = new System.Windows.Forms.ProgressBar();
            this.Percentage = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.Start_But = new System.Windows.Forms.Button();
            this.Record_But = new System.Windows.Forms.Button();
            this.Reset_But = new System.Windows.Forms.Button();
            this.Pause_But = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Remaining_Timer = new System.Windows.Forms.Timer(this.components);
            this.Stopwatch_Timer = new System.Windows.Forms.Timer(this.components);
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.write_data = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(6, 5);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(249, 20);
            this.TimeLabel.TabIndex = 0;
            this.TimeLabel.Text = "Remaining Time = 00 : 00 : 00";
            // 
            // PercentageBar
            // 
            this.PercentageBar.Location = new System.Drawing.Point(10, 28);
            this.PercentageBar.Name = "PercentageBar";
            this.PercentageBar.Size = new System.Drawing.Size(655, 25);
            this.PercentageBar.TabIndex = 1;
            // 
            // Percentage
            // 
            this.Percentage.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Percentage.Location = new System.Drawing.Point(670, 28);
            this.Percentage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Percentage.Name = "Percentage";
            this.Percentage.Size = new System.Drawing.Size(67, 25);
            this.Percentage.TabIndex = 2;
            this.Percentage.Text = "0 %";
            this.Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Time.Location = new System.Drawing.Point(264, 55);
            this.lbl_Time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(228, 33);
            this.lbl_Time.TabIndex = 3;
            this.lbl_Time.Text = "00 : 00 : 00 : 000";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Start_But
            // 
            this.Start_But.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_But.Location = new System.Drawing.Point(62, 96);
            this.Start_But.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Start_But.Name = "Start_But";
            this.Start_But.Size = new System.Drawing.Size(109, 28);
            this.Start_But.TabIndex = 4;
            this.Start_But.Text = "Start";
            this.Start_But.UseVisualStyleBackColor = true;
            this.Start_But.Click += new System.EventHandler(this.Start_But_Click);
            // 
            // Record_But
            // 
            this.Record_But.Enabled = false;
            this.Record_But.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record_But.Location = new System.Drawing.Point(308, 96);
            this.Record_But.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Record_But.Name = "Record_But";
            this.Record_But.Size = new System.Drawing.Size(109, 28);
            this.Record_But.TabIndex = 5;
            this.Record_But.Text = "Record";
            this.Record_But.UseVisualStyleBackColor = true;
            this.Record_But.Click += new System.EventHandler(this.Record_But_Click);
            // 
            // Reset_But
            // 
            this.Reset_But.Enabled = false;
            this.Reset_But.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_But.Location = new System.Drawing.Point(431, 96);
            this.Reset_But.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Reset_But.Name = "Reset_But";
            this.Reset_But.Size = new System.Drawing.Size(109, 28);
            this.Reset_But.TabIndex = 7;
            this.Reset_But.Text = "Reset";
            this.Reset_But.UseVisualStyleBackColor = true;
            this.Reset_But.Click += new System.EventHandler(this.Reset_But_Click);
            // 
            // Pause_But
            // 
            this.Pause_But.Enabled = false;
            this.Pause_But.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pause_But.Location = new System.Drawing.Point(185, 96);
            this.Pause_But.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Pause_But.Name = "Pause_But";
            this.Pause_But.Size = new System.Drawing.Size(109, 28);
            this.Pause_But.TabIndex = 6;
            this.Pause_But.Text = "Pause";
            this.Pause_But.UseVisualStyleBackColor = true;
            this.Pause_But.Click += new System.EventHandler(this.Pause_But_Click);
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
            this.chart1.Location = new System.Drawing.Point(281, 131);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.LabelBorderWidth = 5;
            series1.Legend = "Legend1";
            series1.MarkerSize = 1;
            series1.Name = "Battery";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(456, 453);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Battery Chart";
            this.chart1.Titles.Add(title1);
            // 
            // Remaining_Timer
            // 
            this.Remaining_Timer.Enabled = true;
            this.Remaining_Timer.Interval = 1000;
            this.Remaining_Timer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // Stopwatch_Timer
            // 
            this.Stopwatch_Timer.Tick += new System.EventHandler(this.Stopwatch_Timer_Tick);
            // 
            // listBox2
            // 
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(10, 153);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(267, 27);
            this.listBox2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 131);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Start Record";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Record Results";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // write_data
            // 
            this.write_data.Enabled = false;
            this.write_data.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.write_data.Location = new System.Drawing.Point(554, 96);
            this.write_data.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.write_data.Name = "write_data";
            this.write_data.Size = new System.Drawing.Size(133, 28);
            this.write_data.TabIndex = 13;
            this.write_data.Text = "Download Record";
            this.write_data.UseVisualStyleBackColor = true;
            this.write_data.Click += new System.EventHandler(this.write_data_Click);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(10, 207);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(267, 377);
            this.listBox1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(748, 396);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.write_data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.Reset_But);
            this.Controls.Add(this.Pause_But);
            this.Controls.Add(this.Record_But);
            this.Controls.Add(this.Start_But);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.Percentage);
            this.Controls.Add(this.PercentageBar);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battery Efficiency Meter";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.ProgressBar PercentageBar;
        private System.Windows.Forms.Label Percentage;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Button Start_But;
        private System.Windows.Forms.Button Record_But;
        private System.Windows.Forms.Button Reset_But;
        private System.Windows.Forms.Button Pause_But;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer Remaining_Timer;
        private System.Windows.Forms.Timer Stopwatch_Timer;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button write_data;
        private System.Windows.Forms.ListBox listBox1;
    }
}

