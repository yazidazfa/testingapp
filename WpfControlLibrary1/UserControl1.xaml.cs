using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;
using Button = System.Windows.Controls.Button;
using UserControl = System.Windows.Controls.UserControl;
using System.Linq.Expressions;
using System.Runtime.Versioning;
//using System.Drawing;
using System.Management;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.ObjectModel;
using System.Windows.Forms.Integration;
using System.Windows.Markup;

namespace WpfControlLibrary1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        double totalPhysicalMemorySize = 0,
               totalVirtualMemorySize = 0,
               averageCPU = 0,
               averageDiskRead = 0,
               averageDiskWrite = 0;

        string systemName = "",
               appName = "",
               appDirectory = "";

        bool nextAdvance = false,
             handler = true,
             closingHandler = false,
             startingHandler = true,
             boxHandler = true;

        int timeRun = 0;

        long peakWorkingSet = 0,
             peakVirtualMem = 0,
             memoryUsage = 0,
             averageMemory = 0,
             bandwidthSent = 0,
             bandwidthReceived = 0,
             peakBandwidthSent = 0,
             peakBandwidthReceived = 0,
             totalAverageBandwidthSent = 0,
             totalAverageBandwidthReceived = 0,
             stop = 0,
             timeHandler;

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            SystemInfo();
        }

        private bool IsConnectedToInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        void SystemInfo()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcheri = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcheri.Get();

            foreach (ManagementObject result in results)
            {
                totalPhysicalMemorySize = Convert.ToDouble(result["TotalVisibleMemorySize"]);
                totalVirtualMemorySize = Convert.ToDouble(result["TotalVirtualMemorySize"]);

                TextBlockTotalPhysicalMemory.Text = $"{Math.Round(totalPhysicalMemorySize / 1000, 2)} MB";
                TextBlockTotalVirtualMemory.Text = $"{Math.Round(totalVirtualMemorySize / 1000, 2)} MB";
            }

            System.Management.ObjectQuery query = new ObjectQuery("Select * FROM Win32_Battery");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject mo in collection)
            {
                foreach (PropertyData property in mo.Properties)
                {

                    if (!(property.Name == "DeviceID" || property.Name == "SystemName"))
                    {
                        continue;
                    }

                    if (property.Name == "DeviceID")
                    {
                        TextBlockBatteryName.Text = $"{property.Value}";
                    }

                    if (property.Name == "SystemName")
                    {
                        systemName = $"{property.Value}";
                        TextBlockSystemName.Text = systemName;
                    }
                }
            }
        }

        private void ButtonChooseApp_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Application";
            dialog.DefaultExt = ".exe";
            dialog.Filter = "Executable File (.exe)|*.exe";

            bool? resultGO = dialog.ShowDialog();

            if (resultGO == true)
            {
                appDirectory = dialog.FileName;

                int parameter = 0;

                for (int i = appDirectory.Length - 1; i >= 0; i--)
                {
                    if (Convert.ToString(appDirectory[i]) == @"\")
                    {
                        parameter = i + 1;
                        break;
                    }
                }

                appName = appDirectory.Substring(parameter);
                TextBlockAppName.Text = appName;
            }

            nextAdvance = true;

            TextBoxRunTime.Visibility = nextAdvance ? Visibility.Visible : Visibility.Collapsed;
            TextBlockTestingTime.Visibility = nextAdvance ? Visibility.Visible : Visibility.Collapsed;
            ButtonTestApplication.Visibility = nextAdvance ? Visibility.Visible : Visibility.Collapsed;
        }

        Process myProcess;
        System.Timers.Timer statusTime = new System.Timers.Timer();
        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

        private void ButtonTestApplication_Click(object sender, RoutedEventArgs e)
        {
            var isNumeric = int.TryParse(TextBoxRunTime.Text, out int n);

            if (isNumeric && !String.IsNullOrEmpty(appDirectory))
            {
                ButtonCallAll.Visibility = Visibility.Collapsed;
                ButtonCSV.Visibility = Visibility.Collapsed;

                foreach (var all in summonGraph)
                {
                    foreach (var sub in all)
                    {
                        sub.Clear();
                    }
                    all.Clear();
                }

                summonGraph.Clear();

                graphPhysicalMemoryAll.Clear();
                graphPhysicalMemory.Clear();
                graphPhysicalMemoryPeak.Clear();
                graphPhysicalMemoryAverage.Clear();
                graphPhysicalMemoryPercentage.Clear();

                graphVirtualMemoryAll.Clear();
                graphVirtualMemory.Clear();
                graphVirtualMemoryPercentage.Clear();

                graphCPUAll.Clear();
                graphCPU.Clear();
                graphCPUAverage.Clear();

                graphBandwidthAll.Clear();
                graphBandwidthSent.Clear();
                graphBandwidthSentPeak.Clear();
                graphBandwidthSentAverage.Clear();
                graphBandwidthReceived.Clear();
                graphBandwidthReceivedPeak.Clear();
                graphBandwidthReceivedAverage.Clear();

                graphDiskAll.Clear();
                graphDiskRead.Clear();
                graphDiskWrite.Clear();

                summonGraph.Clear();

                timeRun = Convert.ToInt32(TextBoxRunTime.Text);

                myProcess = Process.Start(appDirectory);
                stop = DateTimeOffset.Now.ToUnixTimeMilliseconds() + timeRun * 1000;
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(2);

                StackPanelTimeRemaining.Visibility = Visibility.Visible;

                statusTime.Interval = 1000;
                statusTime.Elapsed += new System.Timers.ElapsedEventHandler(StatusTimeElapsed);
                statusTime.Enabled = true;
            }

            else
            {
                MessageBox.Show("Insert valid value!");
            }
        }

        Dictionary<int, double> value;

        List<List<double>> graphPhysicalMemoryAll = new List<List<double>>();
        List<double> graphPhysicalMemory = new List<double>();
        List<double> graphPhysicalMemoryPeak = new List<double>();
        List<double> graphPhysicalMemoryAverage = new List<double>();
        List<double> graphPhysicalMemoryPercentage = new List<double>();

        List<List<double>> graphVirtualMemoryAll = new List<List<double>>();
        List<double> graphVirtualMemory = new List<double>();
        List<double> graphVirtualMemoryPercentage = new List<double>();

        List<List<double>> graphCPUAll = new List<List<double>>();
        List<double> graphCPU = new List<double>();
        List<double> graphCPUAverage = new List<double>();

        List<List<double>> graphBandwidthAll = new List<List<double>>();
        List<double> graphBandwidthSent = new List<double>();
        List<double> graphBandwidthSentPeak = new List<double>();
        List<double> graphBandwidthSentAverage = new List<double>();
        List<double> graphBandwidthReceived = new List<double>();
        List<double> graphBandwidthReceivedPeak = new List<double>();
        List<double> graphBandwidthReceivedAverage = new List<double>();

        List<List<double>> graphDiskAll = new List<List<double>>();
        List<double> graphDiskRead = new List<double>();
        List<double> graphDiskWrite = new List<double>();

        List<List<List<double>>> summonGraph = new List<List<List<double>>>();

        private void StatusTimeElapsed(object sender, ElapsedEventArgs e)
        {
            if (stop >= DateTimeOffset.Now.ToUnixTimeMilliseconds() && !myProcess.HasExited)
            {
                while (startingHandler)
                {
                    this.Dispatcher.Invoke((Action)delegate
                    {
                        TextBlockTimeRemaining.Text = "Starting...";
                        TextBlockPhysicalMemoryUsage.Text = "Starting...";
                        TextBlockAveragePhysicalMemoryUsage.Text = "Starting...";
                        TextBlockPeakPhysicalMemoryUsage.Text = "Starting...";
                        TextBlockVirtualMemoryUsage.Text = "Starting...";
                        TextBlockCPUAverageUsagePercentage.Text = "Starting...";
                        TextBlockCPUUsagePercentage.Text = "Starting...";
                        TextBlockBandwidthReceived.Text = "Starting...";
                        TextBlockBandwidthSent.Text = "Starting...";
                        TextBlockTotalAverageBandwidthReceived.Text = "Starting...";
                        TextBlockTotalAverageBandwidthSent.Text = "Starting...";
                        TextBlockPeakBandwidthReceived.Text = "Starting...";
                        TextBlockPeakBandwidthSent.Text = "Starting...";
                        TextBlockPhysicalMemoryUsagePercentage.Text = "Starting...";
                        TextBlockVirtualMemoryUsagePercentage.Text = "Starting...";
                        TextBlockDiskRead.Text = "Starting...";
                        TextBlockDiskWrite.Text = "Starting...";
                    });
                    startingHandler = false;
                }

                myProcess.Refresh();
                memoryUsage = myProcess.WorkingSet64;
                averageMemory = averageMemory == 0 ? myProcess.WorkingSet64 : (averageMemory + myProcess.WorkingSet64) / 2;

                peakWorkingSet = myProcess.PeakWorkingSet64;
                peakVirtualMem = myProcess.PeakVirtualMemorySize64;

                double dbAverageMemory = Convert.ToDouble(averageMemory);
                double dbVirtualMemory = Convert.ToDouble(peakVirtualMem);
                double dbTotalPhysicalMemory = Convert.ToDouble(totalPhysicalMemorySize * 1000);
                double dbTotalVirtualMemory = Convert.ToDouble(totalVirtualMemorySize * 1000);

                double dbPhysicalMemoryUsagePercentage = Math.Round(averageMemory / dbTotalPhysicalMemory * 100, 3);
                double dbVirtualMemoryUsagePercentage = Math.Round(peakVirtualMem / dbTotalVirtualMemory * 100, 3);

                if (IsConnectedToInternet())
                {
                    foreach (NetworkInterface ni in interfaces)
                    {
                        if (ni.GetIPv4Statistics().BytesSent != 0 && ni.GetIPv4Statistics().BytesReceived != 0)
                        {
                            bandwidthReceived = ni.GetIPv4Statistics().BytesReceived;
                            bandwidthSent = ni.GetIPv4Statistics().BytesSent;

                            if (peakBandwidthSent < ni.GetIPv4Statistics().BytesSent)
                            {
                                peakBandwidthSent = ni.GetIPv4Statistics().BytesSent;
                            }

                            if (peakBandwidthReceived < ni.GetIPv4Statistics().BytesReceived)
                            {
                                peakBandwidthReceived = ni.GetIPv4Statistics().BytesReceived;
                            }

                            if (totalAverageBandwidthSent == 0 && totalAverageBandwidthReceived == 0)
                            {
                                totalAverageBandwidthSent = ni.GetIPv4Statistics().BytesSent;
                                totalAverageBandwidthReceived = ni.GetIPv4Statistics().BytesReceived;
                            }
                            else
                            {
                                totalAverageBandwidthSent = (totalAverageBandwidthSent + ni.GetIPv4Statistics().BytesSent) / 2;
                                totalAverageBandwidthReceived = (totalAverageBandwidthReceived + ni.GetIPv4Statistics().BytesReceived) / 2;
                            }
                        }
                    }
                }

                System.Management.ObjectQuery queryo = new ObjectQuery("Select * from Win32_PerfRawData_PerfDisk_PhysicalDisk where Name='0 C: D:'");
                ManagementObjectSearcher searchero = new ManagementObjectSearcher(queryo);

                ManagementObjectCollection collectionz = searchero.Get();

                foreach (ManagementObject mz in collectionz)
                {
                    foreach (PropertyData property in mz.Properties)
                    {
                        if (property.Name == "DiskReadBytesPersec")
                        {
                            averageDiskRead = Convert.ToDouble(property.Value);
                        }
                        else if (property.Name == "DiskWriteBytesPersec")
                        {
                            averageDiskWrite = Convert.ToDouble(property.Value);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue();
                averageCPU = averageCPU == 0 ? cpuCounter.NextValue() : Math.Round((averageCPU + cpuCounter.NextValue()) / 2, 5);

                if (!closingHandler)
                {
                    this.Dispatcher.Invoke((Action)delegate
                    {
                        if (handler)
                        {
                            stop = DateTimeOffset.Now.ToUnixTimeMilliseconds() + timeRun * 1000;
                            handler = false;
                        }

                        if (DateTimeOffset.Now.ToUnixTimeMilliseconds() / 1000 >= timeHandler)
                        {
                            graphPhysicalMemory.Add(Math.Round(Convert.ToDouble(memoryUsage) / 1000000, 5));
                            graphPhysicalMemoryPeak.Add(Math.Round(Convert.ToDouble(peakWorkingSet) / 1000000, 5));
                            graphPhysicalMemoryAverage.Add(Math.Round(Convert.ToDouble(averageMemory) / 1000000, 5));
                            graphPhysicalMemoryPercentage.Add(dbPhysicalMemoryUsagePercentage);

                            graphVirtualMemory.Add(Math.Round(Convert.ToDouble(peakVirtualMem) / 1000000, 5));
                            graphVirtualMemoryPercentage.Add(dbVirtualMemoryUsagePercentage);

                            graphCPU.Add(Convert.ToInt32(cpuCounter.NextValue()));
                            graphCPUAverage.Add(averageCPU);

                            graphBandwidthSent.Add(Math.Round(Convert.ToDouble(bandwidthSent) / 1000000, 5));
                            graphBandwidthSentPeak.Add(Math.Round(Convert.ToDouble(peakBandwidthSent) / 1000000, 5));
                            graphBandwidthSentAverage.Add(Math.Round(Convert.ToDouble(totalAverageBandwidthSent) / 1000000, 5));
                            graphBandwidthReceived.Add(Math.Round(Convert.ToDouble(bandwidthReceived) / 1000000, 2));
                            graphBandwidthReceivedPeak.Add(Math.Round(Convert.ToDouble(peakBandwidthReceived) / 1000000, 5));
                            graphBandwidthReceivedAverage.Add(Math.Round(Convert.ToDouble(totalAverageBandwidthReceived) / 1000000, 5));

                            graphDiskRead.Add(Math.Round((averageDiskRead / 1000000), 2));
                            graphDiskWrite.Add(Math.Round((averageDiskWrite / 1000000), 2));
                        }

                        timeHandler = DateTimeOffset.Now.ToUnixTimeMilliseconds() / 1000 + 1;

                        long secNow = (stop - DateTimeOffset.Now.ToUnixTimeMilliseconds()) / 1000;

                        TextBlockTimeRemaining.Text = secNow >= 0 ? $"{secNow}s" : "0s";
                        TextBlockPhysicalMemoryUsage.Text = $"{graphPhysicalMemory[graphPhysicalMemory.Count - 1]} MB";
                        TextBlockAveragePhysicalMemoryUsage.Text = $"{graphPhysicalMemoryAverage[graphPhysicalMemoryAverage.Count - 1]} MB";
                        TextBlockPeakPhysicalMemoryUsage.Text = $"{graphPhysicalMemoryPeak[graphPhysicalMemoryPeak.Count - 1]} MB";
                        TextBlockVirtualMemoryUsage.Text = $"{graphVirtualMemory[graphVirtualMemory.Count - 1]} MB";
                        TextBlockCPUAverageUsagePercentage.Text = $"{graphCPUAverage[graphCPUAverage.Count - 1]}%";
                        TextBlockCPUUsagePercentage.Text = $"{graphCPU[graphCPU.Count - 1]}%";
                        TextBlockBandwidthReceived.Text = $"{graphBandwidthReceived[graphBandwidthReceived.Count - 1]} MB";
                        TextBlockBandwidthSent.Text = $"{graphBandwidthSent[graphBandwidthSent.Count - 1]} MB";
                        TextBlockTotalAverageBandwidthReceived.Text = $"{graphBandwidthReceivedAverage[graphBandwidthReceivedAverage.Count - 1]} MB";
                        TextBlockTotalAverageBandwidthSent.Text = $"{graphBandwidthSentAverage[graphBandwidthSentAverage.Count - 1]} MB";
                        TextBlockPeakBandwidthReceived.Text = $"{graphBandwidthReceivedPeak[graphBandwidthReceivedPeak.Count - 1]} MB";
                        TextBlockPeakBandwidthSent.Text = $"{graphBandwidthSentPeak[graphBandwidthSentPeak.Count - 1]} MB";
                        TextBlockPhysicalMemoryUsagePercentage.Text = $"{dbPhysicalMemoryUsagePercentage}%";
                        TextBlockVirtualMemoryUsagePercentage.Text = $"{dbVirtualMemoryUsagePercentage}%";
                        TextBlockDiskRead.Text = $"{graphDiskRead[graphDiskRead.Count - 1]} MB/s";
                        TextBlockDiskWrite.Text = $"{graphDiskWrite[graphDiskWrite.Count - 1]} MB/s";

                        CallGraph(graphPhysicalMemory);
                        NameGraph.Visibility = Visibility.Visible;
                    });
                }
            }

            else
            {
                myProcess.CloseMainWindow();
                statusTime.Enabled = false;

                string timeStatus = stop >= DateTimeOffset.Now.ToUnixTimeMilliseconds() ? "Unfinished!" : "Done!";

                this.Dispatcher.Invoke((Action)delegate
                {
                    TextBlockTimeRemaining.Text = timeStatus;
                    ButtonCallAll.Visibility = Visibility.Visible;
                    ButtonCSV.Visibility = Visibility.Visible;
                });

                while (boxHandler)
                {
                    MessageBox.Show(timeStatus == "Done!" ? "Time up, closing test!" : "Testing interupted");
                    boxHandler = false;
                }
            }
        }

        void CallGraph(List<double> paraList)
        {
            StackPanelGraph.Children.Clear();

            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.Name = "host";
            host.Height = 300;
            StackPanelGraph.Children.Add(host);

            Chart[] firstChart = new Chart[1];
            var firstChartSet = new Chart();
            firstChart[0] = firstChartSet;
            firstChartSet.Name = "MyWinformChart";
            firstChartSet.Dock = DockStyle.Fill;
            host.Child = firstChartSet;

            Series[] firstSeriesChart = new Series[1];
            var firstSeriesChartSet = new Series();
            firstSeriesChart[0] = firstSeriesChartSet;
            firstSeriesChartSet.Name = "series";
            firstSeriesChartSet.ChartType = SeriesChartType.Line;
            firstChartSet.Series.Add(firstSeriesChartSet);

            ChartArea[] firstChartArea = new ChartArea[1];
            var firstChartAreaSet = new ChartArea();
            firstSeriesChart[0] = firstSeriesChartSet;
            firstChartSet.ChartAreas.Add(firstChartAreaSet);

            int lost = timeRun;

            if (lost > paraList.Count)
            {
                lost = paraList.Count;
            }

            value = new Dictionary<int, double>();
            for (int i = 0; i < lost; i++)
                value.Add(i, paraList[i]);

            Chart chart = firstChartSet as Chart;
            chart.DataSource = value;
            chart.Series["series"].XValueMember = "Key";
            chart.Series["series"].YValueMembers = "Value";
        }

        private void ButtonCall_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string parameter = button.Name;

            switch (parameter)
            {
                case "ButtonPhysicalMemory":
                    CallGraph(graphPhysicalMemory);
                    NameGraphInside.Text = "Physical Memory (in MB)";
                    break;
                case "ButtonCPU":
                    CallGraph(graphCPU);
                    NameGraphInside.Text = "CPU Percentage";
                    break;
                case "ButtonBandwidthSent":
                    CallGraph(graphBandwidthSent);
                    NameGraphInside.Text = "Bandwidth Sent (in MB)";
                    break;
                case "ButtonBandwidthReceived":
                    CallGraph(graphBandwidthReceived);
                    NameGraphInside.Text = "Bandwidth Received (in MB)";
                    break;
                case "ButtonDiskRead":
                    CallGraph(graphDiskRead);
                    NameGraphInside.Text = "Disk Read (in MB)";
                    break;
                case "ButtonDiskWrite":
                    CallGraph(graphDiskWrite);
                    NameGraphInside.Text = "Disk Write (in MB)";
                    break;
            }
        }

        private void ButtonCSV_Click(object sender, RoutedEventArgs e)
        {
            string mainPath = $"{System.AppDomain.CurrentDomain.BaseDirectory}" + @"\Test Result";

            if (!Directory.Exists(mainPath))
            {
                Directory.CreateDirectory(mainPath);
            }

            DateTime dateTime = DateTime.UtcNow.Date;
            string uniqueID = $"{appName} {dateTime.ToString("dd-MM-yyyy")} {DateTimeOffset.Now.ToUnixTimeMilliseconds()}";

            string extendPath = mainPath + @"\" + uniqueID;

            if (!Directory.Exists(extendPath))
            {
                Directory.CreateDirectory(extendPath);
            }

            graphPhysicalMemoryAll.Add(graphPhysicalMemory);
            graphPhysicalMemoryAll.Add(graphPhysicalMemoryPeak);
            graphPhysicalMemoryAll.Add(graphPhysicalMemoryAverage);
            graphPhysicalMemoryAll.Add(graphPhysicalMemoryPercentage);

            graphVirtualMemoryAll.Add(graphVirtualMemory);
            graphVirtualMemoryAll.Add(graphVirtualMemoryPercentage);

            graphCPUAll.Add(graphCPU);
            graphCPUAll.Add(graphCPUAverage);

            graphBandwidthAll.Add(graphBandwidthSent);
            graphBandwidthAll.Add(graphBandwidthSentPeak);
            graphBandwidthAll.Add(graphBandwidthSentAverage);
            graphBandwidthAll.Add(graphBandwidthReceived);
            graphBandwidthAll.Add(graphBandwidthReceivedPeak);
            graphBandwidthAll.Add(graphBandwidthReceivedAverage);

            graphDiskAll.Add(graphDiskRead);
            graphDiskAll.Add(graphDiskWrite);

            summonGraph.Add(graphPhysicalMemoryAll);
            summonGraph.Add(graphVirtualMemoryAll);
            summonGraph.Add(graphCPUAll);
            summonGraph.Add(graphBandwidthAll);
            summonGraph.Add(graphDiskAll);

            List<string> lineHelper = new List<string>();
            int i = 0;

            string filePath = extendPath + @"\" + uniqueID + ".csv";
            using (StreamWriter sw = File.CreateText(filePath))
            {
                foreach (var all in summonGraph)
                {
                    foreach (var sub in all)
                    {
                        int j = 0;
                        foreach (var value in sub)
                        {
                            i = sub.Count;
                            lineHelper.Add("");
                            lineHelper[j] += $"{value};";
                            j++;
                        }
                    }
                }

                string cut1 = "Sec;Physical Memory;Physical Memory(Average);Physical Memory(Peak);Physical Memory(Percentage);";
                string cut2 = "Virtual Memory;Virtual Memory(Percentage);CPU % Overall; CPU % (Average) Overall;";
                string cut3 = "Bandwidth Sent Overall;Bandwidth Sent (Peak) Overall;Bandwidth Sent (Average) Overall;";
                string cut4 = "Bandwidth Received Overall; Bandwidth Received (Peak) Overall; Bandwidth Received (Average) Overall;";
                string cut5 = "Disk Read Overall;Disk Write Overall";

                sw.WriteLine($"{cut1}{cut2}{cut3}{cut4}{cut5}");

                for (int k = 0; k < i; k++)
                {
                    sw.WriteLine($"{k + 1};{lineHelper[k]}");
                }
            }

            MessageBox.Show("CSV Created!");
            MessageBox.Show($"Saved at {extendPath}");
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            closingHandler = true;
            MessageBox.Show("Closing called!");

            if (stop >= DateTimeOffset.Now.ToUnixTimeMilliseconds() && !myProcess.HasExited)
            {
                myProcess.CloseMainWindow();
                stop = 0;
                statusTime.Enabled = false;
            }
        }
    }
}


