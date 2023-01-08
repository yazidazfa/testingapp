using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace CollectionOfTestingApp
{
    public partial class UserGroup2 : UserControl
    {
        protected Worker worker;

        protected List<string> buffer;

        protected int bufferLastSize;

        protected bool abort;

        protected readonly static string[] localIPs = null;

        protected string lastUrl = "";

        protected int requestsTotal = 0;

        protected int requestsOk = 0;

        protected readonly string formTitle = "";

        static UserGroup2()
        {
            localIPs = new string[] {
                "192.168",
                "10.",
                "172.16.",
                "172.17.",
                "172.18.",
                "172.19.",
                "172.20.",
                "172.21.",
                "172.22.",
                "172.23.",
                "172.24.",
                "172.25.",
                "172.26.",
                "172.27.",
                "172.28.",
                "172.29.",
                "172.30.",
                "172.31.",
            };
        }

        public UserGroup2()
        {
            InitializeComponent();
            formTitle = this.Text;
            comboBoxUrl.SelectedItem = comboBoxUrl.Items[0];
        }

        protected void Start()
        {
            abort = false;
            buffer = new List<string>();
            bufferLastSize = buffer.Count;

            //TODO: combine and check url
            string url = comboBoxUrl.Text + "://" + textBoxUrl.Text + ":" + numericUpDownUrl.Value;
            if (url != lastUrl)
            {
                requestsTotal = 0;
                requestsOk = 0;
            }
            int timeout = (int)(1000 * numericUpDownTimeout.Value);

            worker = new Worker(url, timeout);
            worker.onWorkResult += StoreResult;

            int iteratesCount = (int)numericUpDownIterates.Value;
            int threadsCount = (int)numericUpDownThreadsMin.Value;
            int threadsMax = (int)numericUpDownThreadsMax.Value;
            int threadsInc = (int)numericUpDownThreadsInc.Value;

            for (int i = 1; i <= iteratesCount; i++)
            {
                if (abort)
                    break;
                worker.DoWork(i, threadsCount);
                AwaitResults();
                threadsCount += threadsInc;
                if (threadsCount > threadsMax)
                    threadsCount = threadsMax;
            }
            Thread.Sleep(timeout);
            AwaitResults();
        }

        protected void Stop()
        {
            abort = true;
            if (null != worker)
            {
                worker.Abort();
                AwaitResults();
            }
        }

        protected void AwaitResults()
        {
            while (worker.IsAlive)
            {
                DisplayResult();
                Application.DoEvents();
            }
            DisplayResult();
            Application.DoEvents();
        }

        protected void StoreResult(Worker sender, WorkerResult result)
        {
            string label, data, responseTime, responseTimee;
            requestsTotal++;
            if (null != result.response)
            {
                responseTime = result.response.GetResponseHeader("Date");
                responseTimee = DateTime.Now.ToString("hh.mm.ss.fff");

                DateTime waktuLain = DateTime.Now;

                label =
                    "Response " +
                    "[" + result.data.iterateNum + "|" +
                    result.data.threadNum + "/" + result.data.threadsCount +
                    "]: ";
                Thread.Sleep(490);

                DateTime waktuSekarang = DateTime.Now;
                TimeSpan selisih = waktuSekarang.Subtract(waktuLain);
                data = " Response : " + responseTimee + " - " + "Time difference: " + selisih.TotalMilliseconds + " MS";
                if (result.response.StatusCode == HttpStatusCode.OK)
                    requestsOk++;
            }
            else
            {
                label =
                    "Error " +
                    "[" + result.data.iterateNum + "|" +
                    result.data.threadNum + "/" + result.data.threadsCount +
                    "]: ";
                data = result.error;
            }
            buffer.Add(label + new String(' ', 25 - label.Length) + data);
        }

        protected void DisplayResult()
        {
            if (bufferLastSize != buffer.Count)
            {
                this.Text = formTitle +
                    " - requests/OK " + requestsTotal +
                    "/" + requestsOk + " (" + Math.Round((double)requestsOk / requestsTotal * 100) + "%)";
                for (int i = bufferLastSize; i < buffer.Count; i++)
                    textBoxResults.Text += buffer[i] + Environment.NewLine;
                bufferLastSize = buffer.Count;
                textBoxResults.Refresh();
            }
        }

        protected bool HostIsLocal(string host)
        {
#if DEBUG
            return true;
#endif
#if !DEBUG
            IPAddress[] ips;
            try {
                ips = Dns.GetHostAddresses(host);
            } catch (Exception) {
                MessageBox.Show("Host not resolved, correct it or enter another host", "Host not resolved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            foreach (IPAddress ip in ips) {
                if (IPAddress.IsLoopback(ip))
                    return true;
                
                string ipStr = ip.ToString();
                foreach (string localIP in localIPs) {
                    if (0 == ipStr.IndexOf(localIP))
                        return true;
                }
            }
            
            return false;
#endif
        }

        void MainFormKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Start();
            else if (e.KeyChar == (char)Keys.Escape)
                Stop();
        }

        void ButtonStartClick(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            Start();
            buttonStart.Enabled = true;
        }

        void ButtonStopClick(object sender, EventArgs e)
        {
            Stop();
            buttonStart.Enabled = true;
        }

        void TextBoxResultsTextChanged(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            tbx.SelectionStart = tbx.Text.Length;
            tbx.ScrollToCaret();
        }

        void NumericUpDownThreadsMinValueChanged(object sender, EventArgs e)
        {
            NumericUpDown thisElement = (NumericUpDown)sender;
            if (thisElement.Value > numericUpDownThreadsMax.Value)
                numericUpDownThreadsMax.Value = thisElement.Value;
        }

        void NumericUpDownThreadsMaxValueChanged(object sender, EventArgs e)
        {
            NumericUpDown thisElement = (NumericUpDown)sender;
            if (thisElement.Value < numericUpDownThreadsMin.Value)
                numericUpDownThreadsMin.Value = thisElement.Value;
        }

        void MainFormResize(object sender, EventArgs e)
        {
            textBoxResults.Width = this.Width - groupBox1.Width - 22;
        }

        void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }

        void ButtonClearClick(object sender, EventArgs e)
        {
            textBoxResults.Text = "";
            this.Text = formTitle;
        }

        void TextBoxUrlValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (txt.Text == "" || !HostIsLocal(txt.Text))
            {
                txt.Text = "localhost";
                e.Cancel = true;
            }
        }

        void ComboBoxUrlTextChanged(object sender, EventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;
            if ("http" == cbx.Text)
                numericUpDownUrl.Value = 80;
            else if ("https" == cbx.Text)
                numericUpDownUrl.Value = 443;
        }

        private void write_data_Click(object sender, EventArgs e)
        {
            //button stop
            Stop();
            buttonStart.Enabled = true;

            // Data yang akan ditulis ke file CSV
            string data1 = textBoxResults.Text;

            // Buat objek SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Atur filter untuk hanya menampilkan file CSV
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";

            // Atur default extension untuk file CSV
            saveFileDialog.DefaultExt = "csv";

            // Atur title dari file explorer
            saveFileDialog.Title = "Save data to CSV file";

            // Tampilkan file explorer dan simpan file jika pengguna memilih file dan mengklik tombol Save
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Buka file CSV untuk menulis
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    // Tulis baris ke file CSV
                    //sw.WriteLine(data);
                    //sw.Write(data1 + ",");
                    //sw.WriteLine(data2);
                    //sw.WriteLine(data1 + "," + data2);
                    //sw.WriteLine(data1 + data2);                    
                    //sw.WriteLine(data1 + "," + data2);

                    foreach (object item in textBoxResults.Text)
                    {
                        // Tulis baris ke file CSV

                        sw.WriteLine(data1);
                    }


                }
            }
        }
    }
}

