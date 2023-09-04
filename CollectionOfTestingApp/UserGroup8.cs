using CsvHelper;
using CollectionOfTestingApp.model;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using CsvHelper.Configuration;
using System.Windows.Forms;
using System;

namespace CollectionOfTestingApp
{
    public partial class UserGroup8 : UserControl
    {

        List<ClassList> classList = new List<ClassList>();
        List<ObjectList> objectList = new List<ObjectList>();

        int objectUsage = 0;
        int totalIn = 0;
        int totalOut = 0;
        int totalAllIn = 0;
        int totalAllOut = 0;
        int averageIn = 0;
        int averageOut = 0;

        string stringNumber = "";
        string stringObjectName = "";
        string stringObjectUsage = "";
        string stringFenIn = "";
        string stringFenOut = "";
        string stringAverageFenOut = "";
        string stringAverageFenIn = "";
        string stringModularitySum = "";

        public UserGroup8()
        {
            InitializeComponent();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            StringBuilder sb = new StringBuilder();
            string? line;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] files = Directory.GetFiles(dialog.SelectedPath);
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        string fileExt = Path.GetExtension(file);
                        if (fileExt.CompareTo(".cs") == 0)
                        {
                            ClassList classItem = new ClassList();
                            classItem.ClassName = fileName;
                            classList.Add(classItem);
                        }
                    }
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        string fileExt = Path.GetExtension(file);
                        string newLine = "";
                        string[] lineArr = Array.Empty<string>();
                        string[] lineArr2;

                        if (fileExt.CompareTo(".cs") == 0)
                        {
                            for (int i = 0; i < classList?.Count; i++)
                            {
                                if (classList[i].ClassName != fileName)
                                {
                                    StreamReader sr = new StreamReader(file);
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        if (Regex.IsMatch(line, $" {classList[i].ClassName} " ?? ""))
                                        {
                                            lineArr = line.Split(new string[] { classList[i].ClassName }, StringSplitOptions.None);
                                            newLine = lineArr[1];
                                            lineArr2 = newLine.Split(' ');
                                            ObjectList objectItem = new ObjectList();
                                            objectItem.ClassName = classList[i].ClassName;
                                            objectItem.ObjectName = lineArr2[1];
                                            objectItem.ObjectUsage = 0;
                                            objectItem.FanIn = 0;
                                            objectItem.FanOut = 0;
                                            objectItem.AverageFanIn = 0;
                                            objectItem.AverageFanOut = 0;
                                            objectItem.Modularity = 0;
                                            objectList.Add(objectItem);
                                        }
                                        sb.AppendLine(line);
                                    }
                                    sr.Close();
                                }
                                else
                                {
                                    ObjectList objectItem = new ObjectList();
                                    objectItem.ClassName = classList[i].ClassName;
                                    objectItem.ObjectName = "";
                                    objectItem.ObjectUsage = 0;
                                    objectItem.FanIn = 0;
                                    objectItem.FanOut = 0;
                                    objectItem.AverageFanIn = 0;
                                    objectItem.AverageFanOut = 0;
                                    objectItem.Modularity = 0;
                                    objectList.Add(objectItem);
                                }
                            }
                        }

                    }
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        string fileExt = Path.GetExtension(file);
                        if (fileExt.CompareTo(".cs") == 0)
                        {
                            foreach (ObjectList objectItem in objectList)
                            {
                                StreamReader sr = new StreamReader(file);
                                while ((line = sr.ReadLine()) != null)
                                {
                                    if (Regex.IsMatch(line, objectItem.ObjectName ?? "") && objectItem.ObjectName != "")
                                    {
                                        objectUsage++;
                                        objectItem.ObjectUsage += objectUsage;
                                    }
                                    sb.AppendLine(line);
                                }
                                sr.Close();
                                objectUsage = 0;
                            }
                        }
                    }
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        string fileExt = Path.GetExtension(file);
                        if (fileExt.CompareTo(".cs") == 0)
                        {
                            foreach (ObjectList objectItem in objectList)
                            {
                                StreamReader sr = new StreamReader(file);
                                while ((line = sr.ReadLine()) != null)
                                {
                                    if (objectItem.ClassName != fileName)
                                    {
                                        if (Regex.IsMatch(line, objectItem.ObjectName ?? "") && objectItem.ObjectName != "")
                                        {
                                            totalIn++;
                                        }
                                    }
                                    if (Regex.IsMatch(line, @"\s:\s"))
                                    {
                                        totalIn++;
                                    }
                                    sb.AppendLine(line);
                                }
                                objectItem.FanIn += totalIn;
                                totalAllIn += totalIn;
                                sr.Close();
                                totalIn = 0;
                            }
                        }
                    }
                    foreach (ObjectList objectItem in objectList)
                    {
                        foreach (string file in files)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(file);
                            string fileExt = Path.GetExtension(file);
                            if (fileExt.CompareTo(".cs") == 0)
                            {
                                if (fileName != objectItem.ClassName)
                                {
                                    StreamReader sr = new StreamReader(file);
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        if (Regex.IsMatch(line, objectItem.ObjectName ?? "") && objectItem.ObjectName != "")
                                        {
                                            totalOut++;
                                        }
                                        sb.AppendLine(line);
                                    }
                                    sr.Close();
                                }
                            }
                        }
                        objectItem.FanOut += totalOut;
                        totalAllOut += totalOut;
                        totalOut = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                int number = 0;
                averageIn = totalAllIn / objectList.Count;
                averageOut = totalAllOut / objectList.Count;
                foreach (var item in objectList)
                {
                    if (item.ObjectName != "")
                    {
                        stringObjectName = $"{item.ClassName} / {item.ObjectName}";
                    }
                    else
                    {
                        stringObjectName = $"{item.ClassName} / -";
                    }
                    item.AverageFanIn = averageIn;
                    item.AverageFanOut = averageOut;
                    item.Modularity = (item.FanIn * item.FanIn) - (item.FanOut * item.FanOut);
                    number++;
                    stringNumber = number.ToString();
                    stringObjectUsage = item.ObjectUsage.ToString() ?? "";
                    stringFenIn = item.FanIn.ToString() ?? "";
                    stringFenOut = item.FanOut.ToString() ?? "";
                    stringAverageFenIn = averageIn.ToString();
                    stringAverageFenOut = averageOut.ToString();
                    stringModularitySum = item.Modularity.ToString() ?? "";
                    dataGridView1.Rows.Add(stringNumber, stringObjectName, stringObjectUsage, stringFenIn, stringFenOut, stringAverageFenIn, stringAverageFenOut, stringModularitySum);
                }
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Select the folder of project which you want to test first!");
            }
        }


        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int number = 0;
                averageIn = totalAllIn / objectList.Count;
                averageOut = totalAllOut / objectList.Count;
                var records = new List<Data>();
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
                {
                    sfd.Title = "Select the folder of project which you want to test";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        List<string> numbers = new List<string>();
                        List<string> classNames = new List<string>();
                        List<string> objUsage = new List<string>();
                        List<string> fanIn = new List<string>();
                        List<string> fanOut = new List<string>();
                        List<string> avgFanIn = new List<string>();
                        List<string> avgFanOut = new List<string>();
                        List<string> modularity = new List<string>();
                        foreach (var item in objectList)
                        {
                            if (item.ObjectName != "")
                            {
                                classNames.Add($"{item.ClassName} / {item.ObjectName}");
                            }
                            else
                            {
                                classNames.Add($"{item.ClassName} / -");
                            }
                            number++;
                            item.AverageFanIn = averageIn;
                            item.AverageFanOut = averageOut;
                            item.Modularity = (item.FanIn * item.FanIn) - (item.FanOut * item.FanOut);
                            numbers.Add(number.ToString());
                            objUsage.Add(item.ObjectUsage.ToString() ?? "");
                            fanIn.Add(item.FanIn.ToString() ?? "");
                            fanOut.Add(item.FanOut.ToString() ?? "");
                            avgFanIn.Add(averageIn.ToString());
                            avgFanOut.Add(averageOut.ToString());
                            modularity.Add(item.Modularity.ToString() ?? "");
                        }
                        int lim = numbers.Count;
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            sw.WriteLine("sep=,");
                            using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
                            {
                                for (int i = 0; i < lim; i++)
                                {

                                    records.Add(new Data { Number = numbers[i].ToString(), Objects = classNames[i], Usage = objUsage[i].ToString(), Fan_In = fanIn[i].ToString(), Fan_Out = fanOut[i].ToString(), avg_fanIn = avgFanIn[i].ToString(), avg_fanOut = avgFanOut[i].ToString(), Modularity = modularity[i].ToString() });

                                }
                                cw.Context.RegisterClassMap<csvMap>();
                                cw.WriteRecords(records);
                            }
                        }

                        MessageBox.Show("Your data has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Select the folder of project which you want to test first!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Click \"Choose Folder\" button and choose your project folder that you want to measure the modularity\n2. Click \"Show\" button to see the results in table form\n3. Click \"Generate to CSV\" button if you want to generate the result in CSV form", "Help");
        }
    }
}