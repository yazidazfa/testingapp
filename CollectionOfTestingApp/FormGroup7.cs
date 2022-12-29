using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

using System.Web;
using System.Web.UI;

namespace CollectionOfTestingApp
{
    public partial class FormGroup7 : Form
    {
        public FormGroup7()
        {
            InitializeComponent();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            PowerStatus ps = SystemInformation.PowerStatus;

            PercentageBar.Value = (int)(ps.BatteryLifePercent * 100);
            if (ps.BatteryLifeRemaining < 0)
                TimeLabel.Text = "Charging";
            else
                TimeLabel.Text = "Remaining Time = " + new TimeSpan(0 , 0 , ps.BatteryLifeRemaining);
                Percentage.Text = string.Format($"{ps.BatteryLifePercent * 100} %");            
        }

        //Stopwatch
        //Chart                
        //FN = FrontNumber
        int FN = 1;
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        private void Start_But_Click(object sender, EventArgs e)
        {                        
            if (FN == 1)
            {                
                Stopwatch_Timer.Start();
                stopwatch.Start();                
                PowerStatus ps = SystemInformation.PowerStatus;
                listBox2.Items.Add(FN++ + ".  " + lbl_Time.Text + " =   " + Percentage.Text);                

                var batteryLifePercent = Convert.ToInt32(ps.BatteryLifePercent);
                chart1.Series["Battery"].Points.AddXY(FNChart, ps.BatteryLifePercent * 100);                
                
            }
            else
            {
                Stopwatch_Timer.Start();
                stopwatch.Start();
                
            }
            Start_But.Enabled = false;
            Pause_But.Enabled = true;
            Reset_But.Enabled = true;
            Record_But.Enabled = true;
            write_data.Enabled = true;

        }
        private void Stopwatch_Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan Lap = stopwatch.Elapsed;
            lbl_Time.Text = string.Format("{0:00} : {1:00} : {2:00} : {3:00}",
                Math.Floor(Lap.TotalHours), Lap.Minutes, Lap.Seconds, Lap.Milliseconds);
        }
        
        int FNChart = 0;
        //FN = FrontNumber
        int FN2 =+ 2;
        private void Record_But_Click(object sender, EventArgs e)
        {
            PowerStatus ps = SystemInformation.PowerStatus;            
            listBox1.Items.Add(FN2++ + ".  " + lbl_Time.Text + " =   " + Percentage.Text);

            var batteryLifePercent = Convert.ToInt32(ps.BatteryLifePercent);
            chart1.Series["Battery"].Points.AddXY(FNChart, ps.BatteryLifePercent * 100);

            //Make line at chart1 thicker and adjust interval AxisY
            chart1.Series["Battery"].BorderWidth = 2;
            chart1.ChartAreas[0].AxisY.Interval = 5;


        }


        
        private void Pause_But_Click(object sender, EventArgs e)
        {
            Stopwatch_Timer.Stop();
            stopwatch.Stop();            
            Start_But.Enabled = true;            
            Pause_But.Enabled = false;
        }


        private void Reset_But_Click(object sender, EventArgs e)
        {
            string message = "Are you sure want to reset this record?";
            string title = "Reset all record battery";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                stopwatch.Reset();
                lbl_Time.Text = "00 : 00 : 00 : 000";
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                FNChart = 0;
                FN2 = 2;
                
                Record_But.Enabled = false;
                FN = 1;
                chart1.Series["Battery"].Points.Clear();
                Start_But.Enabled = true;
                Reset_But.Enabled = false;
                Pause_But.Enabled = false;
                write_data.Enabled = false;

            }
            else
            {
                //do nothing
            }
            
        }

        private void write_data_Click(object sender, EventArgs e)
        {
            //automatically pause when downloading data ,and pause button = false
            Stopwatch_Timer.Stop();
            stopwatch.Stop();            
            Start_But.Enabled = true;
            Pause_But.Enabled = false;                        
            Record_But.Enabled = false;


            // The data to be written to the CSV file
            string data1 = lbl_Time.Text;
            string data2 = Percentage.Text;

            // Create a SaveFileDialog object
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the filter to only show CSV files
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";

            // Set the default extension for the CSV file
            saveFileDialog.DefaultExt = "csv";

            // Set the title of the file explorer
            saveFileDialog.Title = "Save data to CSV file";

            // Show file explorer and save file if user select file and click Save button
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Open CSV file to write
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {                                        
                    sw.WriteLine("Start Record :");
                    foreach (object item in listBox2.Items)
                    {
                        // write line to CSV file                       
                        sw.WriteLine(item + "\n"); 
                    }

                    sw.WriteLine("Record Result :");
                    foreach (object item in listBox1.Items)
                    {
                        
                        sw.WriteLine(item);
                    }

                    //displays a download confirmation message box
                    string message = "File successfully downloaded at : ";
                    string title = "Confirmation";                    
                    MessageBox.Show(message + saveFileDialog.FileName, title, MessageBoxButtons.OK, MessageBoxIcon.Information);                                       

                }
            }            
            



        }

        

    }

}
