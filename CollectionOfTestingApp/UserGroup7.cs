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
using System.Management;
using System.Management.Instrumentation;



namespace CollectionOfTestingApp
{
    public partial class UserGroup7 : UserControl
    {
        public UserGroup7()
        {
            InitializeComponent();
        }

        private void Remaining_Timer_Tick(object sender, EventArgs e)
        {
            /*
            try
            {               
                // Buat objek ManagementObjectSearcher untuk menjalankan query WMI
                //ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery WHERE DeviceID = '123456789Ice LakeLi-ion Battery'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery WHERE DeviceID = 0");

                // Looping setiap hasil query
                foreach (ManagementObject obj in searcher.Get())
                {
                    // Dapatkan nilai kapasitas baterai yang tersisa dan penuh dalam mAh
                    int remainingCapacity = (int)(uint)obj["RemainingCapacity"];
                    int fullChargeCapacity = (int)(uint)obj["FullChargeCapacity"];

                    // Hitung persentase baterai
                    double batteryPercentage = (double)remainingCapacity / fullChargeCapacity * 100;

                    // Tampilkan nilai persentase baterai dengan menggunakan format string
                    Percentage.Text = string.Format("{0:0.000}%", batteryPercentage);
                }
            }
            catch (ManagementException ex)
            {
                // Tampilkan pesan error jika terjadi exception
                MessageBox.Show("Error: " + ex.Message + "\n\n" + ex.StackTrace);
            }
            */

            try
            {
                PowerStatus ps = SystemInformation.PowerStatus;

                PercentageBar.Value = (int)(ps.BatteryLifePercent * 100);
                if (ps.BatteryLifeRemaining < 0)
                    TimeLabel.Text = "Charging";
                else
                    TimeLabel.Text = "Remaining Time = " + new TimeSpan(0, 0, ps.BatteryLifeRemaining);
                Percentage.Text = string.Format($"{ps.BatteryLifePercent * 100} %");
            }
            catch (ManagementException ex)
            {
                // Tampilkan pesan error jika terjadi exception
                MessageBox.Show("Error: " + ex.Message);
            }



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
                listBox2.Items.Add(FN++ + ".  " + lbl_Time.Text + " =  " + Percentage.Text);

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
        int FN2 = +2;
        private void Record_But_Click(object sender, EventArgs e)
        {
            PowerStatus ps = SystemInformation.PowerStatus;
            listBox1.Items.Add(FN2++ + ".  " + lbl_Time.Text + " =  " + Percentage.Text);

            var batteryLifePercent = Convert.ToInt32(ps.BatteryLifePercent);
            chart1.Series["Battery"].Points.AddXY(FNChart, ps.BatteryLifePercent * 100);

            //Make line at chart1 thicker and adjust interval AxisY
            chart1.Series["Battery"].BorderWidth = 2;
            //chart1.Series["Battery"].BorderWidth = 100;

            //chart1.ChartAreas[0].AxisY.Interval = 5;
            chart1.ChartAreas[0].AxisY.Interval = 2;


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
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                stopwatch.Reset();
                lbl_Time.Text = "00 : 00 : 00 : 000";
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                FNChart = 0;
                FN = 1;
                FN2 = 2;

                FNc = 1;
                FNc2 = 2;

                Record_But.Enabled = false;
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

        //FNc = Front Number .csv
        int FNc = 1;
        int FNc2 = +2;
        private void write_data_Click(object sender, EventArgs e)
        {
            //automatically pause when downloading data ,and pause button = false
            Stopwatch_Timer.Stop();
            stopwatch.Stop();
            Start_But.Enabled = true;
            Pause_But.Enabled = false;
            Record_But.Enabled = false;

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
                        //write line to CSV file                                                                      
                        sw.WriteLine(FNc + ";" + lbl_Time.Text + ";" + " =  " + ";" + Percentage.Text + "\n");
                    }

                    sw.WriteLine("Record Result :");
                    foreach (object item in listBox1.Items)
                    {
                        sw.WriteLine(FNc2++ + ";" + lbl_Time.Text + ";" + " =  " + ";" + Percentage.Text);
                    }


                    //displays a download confirmation message box
                    string message = "File successfully downloaded at : ";
                    string message2 = "Do you want to open the file?";
                    string title = "Confirmation";

                    //Show the MessageBox with OK and Cancel buttons
                    DialogResult result = MessageBox.Show(message + "\n" + saveFileDialog.FileName + "\n\n" + message2, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    //If the user clicks the custom button, open the CSV file                    
                    if (result == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(saveFileDialog.FileName);
                    }

                }
            }





        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Click \"Start\" button to monitor the energy usage\n2. Click \"Pause\" button to pause the process of energy usage monitoring\n3. Click \"Record\" button to record the currend time and battery\n4. Click \"Download Record\" button to generate the csv file", "Help");
        }
    }

}

