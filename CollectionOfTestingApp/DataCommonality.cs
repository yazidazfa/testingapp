﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CollectionOfTestingApp
{
    public partial class DataCommonality : UserControl
    {
        private string[] csFiles;
        string timeOfTesting;
        double dataCommonality_;
        int totalModules = 0;

        // UPDATE Variable Details
        public void updateVarDetails(Dictionary<(string, string), Dictionary<string, int>> varCount, string varName, string dataType, string fileName)
        {
            var key = (varName, dataType);

            if (!varCount.ContainsKey(key))
            {
                varCount[key] = new Dictionary<string, int>();
            }

            if (varCount[key].ContainsKey(fileName))
            {
                varCount[key][fileName]++;
            }
            else
            {
                varCount[key][fileName] = 1;
            }
        }

        public void mergeVarCount(Dictionary<(string, string), Dictionary<string, int>> varCount)
        {
            var mergedVarCount = new Dictionary<(string, string), Dictionary<string, int>>();

            foreach (var (varName, dataType) in varCount.Keys)
            {
                var fileCounts = varCount[(varName, dataType)];

                foreach (var fileName in fileCounts.Keys)
                {
                    var splitFileNames = fileName.Split(',');

                    foreach (var splitFileName in splitFileNames)
                    {
                        var key = (varName, dataType);

                        if (mergedVarCount.ContainsKey(key))
                        {
                            if (mergedVarCount[key].ContainsKey(splitFileName))
                            {
                                mergedVarCount[key][splitFileName] += fileCounts[fileName];
                            }
                            else
                            {
                                mergedVarCount[key][splitFileName] = fileCounts[fileName];
                            }
                        }
                        else
                        {
                            mergedVarCount[key] = new Dictionary<string, int> { { splitFileName, fileCounts[fileName] } };
                        }
                    }
                }
            }

            varCount.Clear();
            foreach (var (varName, dataType) in mergedVarCount.Keys)
            {
                string combinedFileNames = string.Join(", ", mergedVarCount[(varName, dataType)].Keys);

                int totalVarCount = mergedVarCount[(varName, dataType)].Values.Sum();

                varCount[(varName, dataType)] = new Dictionary<string, int> { { combinedFileNames, totalVarCount } };
            }
        }

        public void dataCommonality(IEnumerable<string> csFiles)
        {
            dataGridView1.Rows.Clear();
            label2.Text = string.Empty;

            if (csFiles == null)
            {
                return;
            }

            Dictionary<(string, string), Dictionary<string, int>> varCount = new Dictionary<(string, string), Dictionary<string, int>>();

            totalModules = csFiles.Count();

            foreach (var filePath in csFiles)
            {
                string fileName = Path.GetFileName(filePath);
                string sourceCode = File.ReadAllText(filePath);

                SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
                var root = syntaxTree.GetRoot();

                var addedVars = new HashSet<string>();

                var varDecs = root.DescendantNodes().OfType<VariableDeclarationSyntax>();
                foreach (var varDec in varDecs)
                {
                    string varName = varDec.DescendantNodes().OfType<VariableDeclaratorSyntax>().First().Identifier.Text;
                    string dataType = varDec.Type.ToString();

                    if (!string.IsNullOrEmpty(varName) && !varName.StartsWith("_") && char.IsLower(varName[0]))
                    {
                        if (addedVars.Add(varName))
                        {
                            updateVarDetails(varCount, varName, dataType, fileName);
                        }
                    }
                }
            }

            List<string> results = new List<string>();

            // Output combined filenames, varName, varCount, dataTypes, and dataCommonality????
            label2.Text = $"{totalModules}";
            mergeVarCount(varCount);
            var dupe = new HashSet<string>();
            var dupeName = new HashSet<string>();

            foreach (var key in varCount.Keys)
            {
                foreach (var count in varCount[key].Values)
                {
                    string filenames = string.Join(", ", varCount[key].Keys);
                    string varName = key.Item1;
                    string dataType = key.Item2;
                    var entry = $"{filenames}, {key.Item1}, {dataType}";

                    if (!dupe.Contains(entry))
                    {
                        int isUsedOnAllModules = 0;
                        if (count == totalModules)
                        {
                            isUsedOnAllModules = 100;
                        }
                        dataGridView1.Rows.Add(filenames, varName, dataType, count, $"{isUsedOnAllModules}%");
                        if (dupeName.Add(varName))
                        {
                            results.Add($"{varName} {isUsedOnAllModules}%");
                        }
                        dupe.Add(entry);
                    }
                }
            }
            dataGridView1.Sort(dataGridView1.Columns[3], System.ComponentModel.ListSortDirection.Descending);

            int totalResults = results.Count();
            int hundredPercent = results.Count(entry => entry.Contains("100%"));

            dataCommonality_ = ((double)hundredPercent / totalResults) * 100;

            label4.Text = $"{dataCommonality_}%";
        }
        public DataCommonality()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Title = "Open Source Code Folder";
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string folderPath = dialog.FileName;
                btnCheck.Enabled = true;
                csFiles = Directory.GetFiles(folderPath, "*.cs");
                string[] javaFiles = Directory.GetFiles(folderPath, "*.java");
                csFiles = csFiles.Concat(javaFiles).ToArray();

            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            totalModules = 0;
            dataCommonality(csFiles);
            btnCSV.Enabled = true;

            DateTime currentDate = DateTime.Now;
            string timeNOW = currentDate.ToString("yyyy MMMM dd - HH:mm:ss");
            timeOfTesting = timeNOW;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            label2.Text = "0";
            csFiles = null;
            btnCheck.Enabled = false;
            btnCSV.Enabled = false;
            totalModules = 0;
            label4.Text = "0";
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
           StringBuilder helpmsgBuilder = new StringBuilder();

            helpmsgBuilder.AppendLine("1. Press 'Open Folder' button to select a folder that has your application source code files");
            helpmsgBuilder.AppendLine("");
            helpmsgBuilder.AppendLine("2. Press 'Start Testing' button to check the use of standard data types and structure inside of your app");
            helpmsgBuilder.AppendLine("");
            helpmsgBuilder.AppendLine("3. After pressing 'Start Testing' button, the result will be displayed");
            helpmsgBuilder.AppendLine("");
            helpmsgBuilder.AppendLine("4. you can export the output into a csv file with 'Export CSV' button");
            helpmsgBuilder.AppendLine("");
            helpmsgBuilder.AppendLine("This app only accepts C# and Java source codes as input");
            helpmsgBuilder.AppendLine("It might not display results correctly tho if you use java as input...");

            string helpMessage = helpmsgBuilder.ToString();
            MessageBox.Show(helpMessage, "User Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.Title = "Save CSV File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                // Header
                sb.AppendLine("DATA COMMONALITY TESTING\n\n");
                sb.AppendLine($"TIME OF TESTING : {timeOfTesting}");
                sb.AppendLine("");
                sb.AppendLine("Source Code File,Data,Data Type,Number of Modules using this data element,Data Commonality");

                // Rows
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];

                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        object cellValue = row.Cells[j].Value;
                        string cellText = (cellValue == null) ? string.Empty : cellValue.ToString();

                        sb.Append($"\"{cellText}\"");
                        sb.Append(j == row.Cells.Count - 1 ? "\n" : ",");
                    }
                }

                // Additional Information
                sb.AppendLine($"Total Number of Modules : {totalModules}");
                sb.AppendLine($"Data Commonality : {dataCommonality_}%");

                File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);

                MessageBox.Show("Success! saved into a CSV file.", "Success");
            }
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            string message = "A. WHAT IS DATA COMMONALITY\n" +
                     "Data commonality is a measure of the degree to which data types and structures are used consistently throughout the program (Roger S. Pressman, Software Engineering: A Practitioner's Approach, 8th edition, page 510). \n\nHigh data commonality indicates that the program uses the same data types and structures consistently. This can facilitate interoperability with other systems, because other systems do not have to adapt to different data types and structures.\n" +
                     "\n\nB. HOW TO MEASURE DATA COMMONALITY?\n" +
                     "To measure the total data commonality of a program, it is necessary to first find the data commonality of a single data variable. To measure the data commonality of a single data variable, the following steps are performed: " +
                     "\n 1. Find all data variables in all files of the program that have the same data variable name.\n" +
                     "\n 2. The data commonality of a data variable is 100% if the data variable has the same data type or structure in each file. However, if the data variable has a different data type in one file, the data commonality is 0%.\n" +
                     "\n 3. Count the number of data variables that have a data commonality of 100%. \n\n" +
                     "\nTO MEASURE THE TOTAL OF DATA COMMONALITY OF A PROGRAM: \n" +
                     "\n Total data commonality = (Number of data variables with a data commonality of 100%) / (Number of data variables with the same name) * 100%";
            string title = "Information of Data Commonality";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
        }

        private void DataCommonality_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StringBuilder helpmsgBuilder = new StringBuilder();

            helpmsgBuilder.AppendLine("1. Press 'Open Folder' button to select a folder that has your application source code files");
            helpmsgBuilder.AppendLine("");
            helpmsgBuilder.AppendLine("2. Press 'Start Testing' button to check the use of standard data types and structure inside of your app");
            helpmsgBuilder.AppendLine("");
            helpmsgBuilder.AppendLine("3. After pressing 'Start Testing' button, the result will be displayed");
            helpmsgBuilder.AppendLine("");
            helpmsgBuilder.AppendLine("4. you can export the output into a csv file with 'Export CSV' button");
            helpmsgBuilder.AppendLine("");
            helpmsgBuilder.AppendLine("This app only accepts C# and Java source codes as input");
            helpmsgBuilder.AppendLine("It might not display results correctly tho if you use java as input...");

            string helpMessage = helpmsgBuilder.ToString();
            MessageBox.Show(helpMessage, "User Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string message = "A. WHAT IS DATA COMMONALITY\n" +
                     "Data commonality is a measure of the degree to which data types and structures are used consistently throughout the program (Roger S. Pressman, Software Engineering: A Practitioner's Approach, 8th edition, page 510). \n\nHigh data commonality indicates that the program uses the same data types and structures consistently. This can facilitate interoperability with other systems, because other systems do not have to adapt to different data types and structures.\n" +
                     "\n\nB. HOW TO MEASURE DATA COMMONALITY?\n" +
                     "To measure the total data commonality of a program, it is necessary to first find the data commonality of a single data variable. To measure the data commonality of a single data variable, the following steps are performed: " +
                     "\n 1. Find all data variables in all files of the program that have the same data variable name.\n" +
                     "\n 2. The data commonality of a data variable is 100% if the data variable has the same data type or structure in each file. However, if the data variable has a different data type in one file, the data commonality is 0%.\n" +
                     "\n 3. Count the number of data variables that have a data commonality of 100%. \n\n" +
                     "\nTO MEASURE THE TOTAL OF DATA COMMONALITY OF A PROGRAM: \n" +
                     "\n Total data commonality = (Number of data variables with a data commonality of 100%) / (Number of data variables with the same name) * 100%";
            string title = "Information of Data Commonality";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
        }
    }
}
