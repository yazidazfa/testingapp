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
using System.IO;

namespace CollectionOfTestingApp
{
    public partial class FormGroup5 : MetroFramework.Forms.MetroForm
    {
        public FormGroup5()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();
            float finet = pINET.NextValue();
            metroProgressBarCPU.Value = (int)fcpu;
            metroProgressBarRAM.Value = (int)fram;
            metroProgressBarINET.Value = (int)finet;
            lblCPU.Text = string.Format("{0:0.0%}", fcpu);
            lblRAM.Text = string.Format("{0:0.0%}", fram);
            lblINET.Text = string.Format("{0:0.0%}", finet);
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);
            chart1.Series["INET"].Points.AddY(finet);
            dgv1.Rows.Add(fcpu, fram, finet);
        }

        private void ExportExcel(DataGridView dataGrid, string filename)
        {
            string Output = "";
            string Headers = "";

            //Export Title
            for (int j = 0; j<dataGrid.Columns.Count; j++)
            {
                Headers = Headers.ToString() + Convert.ToString(dataGrid.Columns[j].HeaderText) + "\t";
            }
            Output += Headers + "\r\n";

            //Export Data
            for(int i = 0; i < dataGrid.RowCount -1;  i++) 
            {
                string line = "";
                for(int j=0;j < dataGrid.Rows[i].Cells.Count; j++)
                {
                    line = line.ToString() + Convert.ToString(dataGrid.Rows[i].Cells[j].Value) + "\t";
                }
                Output+= line + "\r\n";
            }
            Encoding encoding = Encoding.GetEncoding(1254);
            byte[] outputs = encoding.GetBytes(Output);
            FileStream file = new FileStream(filename, FileMode.Create);
            BinaryWriter binary = new BinaryWriter(file);
            binary.Write(outputs,0,outputs.Length);
            binary.Flush();
            binary.Close();
            file.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Documents (*.csv)|.csv";
            save.FileName = "CPU & RAM Monitoring.csv";

            if(save.ShowDialog() == DialogResult.OK)
            {
                ExportExcel(dgv1,save.FileName);
            }
        }
    }
}
