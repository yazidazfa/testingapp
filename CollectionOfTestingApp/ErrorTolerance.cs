﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CollectionOfTestingApp
{
    public partial class ErrorTolerance : UserControl
    {
        public ErrorTolerance()
        {
            InitializeComponent();
        }

        private double totalErrorTolerance = 0;
        private int fileCount = 0;

        private string GenerateHelpMessage()
        {
            StringBuilder helpMessage = new StringBuilder();

            helpMessage.AppendLine("User Guide for Error Tolerance Application");
            helpMessage.AppendLine();
            helpMessage.AppendLine("1. Select the file types you want to count.");
            helpMessage.AppendLine("2. Browse your file.");
            helpMessage.AppendLine("    - You can select 'Open File' button to select just one file .");
            helpMessage.AppendLine("    - You can select 'Open Folder' button to select all files in one folder.");
            helpMessage.AppendLine("3. Click 'Calculate' to run testing.");
            helpMessage.AppendLine("4. The Apllication will show the result.");
            helpMessage.AppendLine("5. you can export result 'Export to .CSV'.");
            helpMessage.AppendLine("6. If you want to recalculate the error tolerance, please click the reset button first.");
            helpMessage.AppendLine("7. Repeat the same steps if you want to calculate the error tolerance again.");

            return helpMessage.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewResults.Rows.Clear();

            foreach (string fileName in listBoxFiles.Items)
            {
                try
                {
                    string[] lines = File.ReadAllLines(fileName);
                    int komputasiCount = 0;
                    int kontrolCount = 0;
                    int errorHandlerCount = 0;

                    if (IsPythonFile(fileName))
                    {
                        // Jika file Python, gunakan metode penghitungan khusus Python
                        CountPythonFileMetrics(lines, ref komputasiCount, ref kontrolCount, ref errorHandlerCount);
                    }
                    else if (IsCppFile(fileName))
                    {
                        // Penghitungan untuk file C++
                        CountCppFileMetrics(lines, ref komputasiCount, ref kontrolCount, ref errorHandlerCount);
                    }
                    else
                    {
                        // Jika bukan file Python, gunakan metode penghitungan c#
                        foreach (string line in lines)
                        {
                            if (line.TrimStart().StartsWith("//"))
                                continue;

                            if (line.Contains("//"))
                            {
                                string codeLine = line.Split(new[] { "//" }, StringSplitOptions.None)[0].Trim();
                                if (string.IsNullOrEmpty(codeLine))
                                    continue;
                            }

                            if (line.Contains("+") || line.Contains("-") || line.Contains("*") || line.Contains("/"))
                            {
                                komputasiCount++;
                            }

                            if (line.Contains("if") || line.Contains("for") || line.Contains("while") || line.Contains("switch"))
                            {
                                kontrolCount++;
                            }

                            if (line.Contains("catch") || line.Contains("try") || line.Contains("finally") || line.Contains("throw"))
                            {
                                errorHandlerCount++;
                            }
                        }
                    }

                    double persentaseErrorTolerance = CalculateErrorTolerance(komputasiCount, kontrolCount, errorHandlerCount);

                    totalErrorTolerance += persentaseErrorTolerance;
                    fileCount++;

                    dataGridViewResults.Rows.Add(fileName, komputasiCount, kontrolCount, errorHandlerCount, persentaseErrorTolerance);
                }
                catch (FileNotFoundException)
                {
                    // Handle file not found exception
                    MessageBox.Show($"File {fileName} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (fileCount > 0)
            {
                double averageErrorTolerance = totalErrorTolerance / fileCount;
                textBox3.Text = "Average Error Tolerance: " + averageErrorTolerance.ToString("0.00") + "%";
            }
        }
        private double CalculateErrorTolerance(int komputasiCount, int kontrolCount, int errorHandlerCount)
        {
            // Implementasikan rumus error tolerance sesuai kebutuhan


            if (komputasiCount + kontrolCount == 0)
            {
                return 0.0;
            }

            return ((double)errorHandlerCount / (komputasiCount + kontrolCount)) * 100.0;
        }

        private void buttonBrowseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = GetFileFilter(); // <-- Error occurs here
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog.FileName;
                    listBoxFiles.Items.Clear();
                    listBoxFiles.Items.Add(openFileDialog.FileName);
                }
            }
        }

        private void Folder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    listBoxFiles.Items.Clear();
                    string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath, GetFileExtensionFilter());
                    listBoxFiles.Items.AddRange(files);

                }
            }
        }
        private string GetFileFilter()
        {
            if (radioButtonCSharp != null && radioButtonCSharp.Checked)
                return "C# Files (*.cs)|*.cs";
            else if (radioButtonCpp != null && radioButtonCpp.Checked)
                return "C++ Files (*.cpp)|*.cpp";
            else if (radioButtonPython != null && radioButtonPython.Checked)
                return "Python Files (*.py)|*.py";

            // Jika tidak ada radio button yang dipilih, kembalikan filter default
            return "All Files (*.cs, *.cpp, *.java, *.py)|*.cs;*.cpp;*.java;*.py";
        }

        private string GetFileExtensionFilter()
        {
            if (radioButtonCSharp.Checked)
                return "*.cs";
            else if (radioButtonCpp != null && radioButtonCpp.Checked)
                return "C++ Files (*.cpp)|*.cpp";
            else if (radioButtonPython != null && radioButtonPython.Checked)
                return "Python Files (*.py)|*.py";

            // Jika tidak ada radio button yang dipilih, kembalikan ekstensi default
            return "*.*";
        }

        private bool IsCppFile(string fileName)
        {
            return Path.GetExtension(fileName).Equals(".cpp", StringComparison.OrdinalIgnoreCase);
        }

        private void CountCppFileMetrics(string[] lines, ref int komputasiCount, ref int kontrolCount, ref int errorHandlerCount)
        {
            foreach (string line in lines)
            {
                if (line.TrimStart().StartsWith("//"))
                    continue;

                if (line.Contains("//"))
                {
                    string codeLine = line.Split(new[] { "//" }, StringSplitOptions.None)[0].Trim();
                    if (string.IsNullOrEmpty(codeLine))
                        continue;
                }

                if (line.Contains("+") || line.Contains("-") || line.Contains("*") || line.Contains("/"))
                {
                    komputasiCount++;
                }

                if (line.Contains("if") || line.Contains("for") || line.Contains("while") || line.Contains("switch"))
                {
                    kontrolCount++;
                }

                if (line.Contains("catch"))
                {
                    errorHandlerCount++;
                }

                // Tambahan untuk C++: Pemeriksaan terhadap ekspresi try, catch, dan throw
                if (line.Contains("try"))
                {
                    // Contoh sederhana, Anda mungkin perlu melakukan analisis lebih lanjut untuk menangani kasus yang lebih kompleks
                    errorHandlerCount++; // Anggap setiap blok 'try' sebagai error handling
                }
                else if (line.Contains("throw"))
                {
                    errorHandlerCount++; // Anggap setiap 'throw' sebagai error handling
                }
            }
        }

        private bool IsPythonFile(string fileName)
        {
            return Path.GetExtension(fileName).Equals(".py", StringComparison.OrdinalIgnoreCase);
        }
        private void CountPythonFileMetrics(string[] lines, ref int komputasiCount, ref int kontrolCount, ref int errorHandlerCount)
        {
            foreach (string line in lines)
            {
                if (line.TrimStart().StartsWith("#"))
                    continue;

                if (line.Contains("#"))
                {
                    string codeLine = line.Split(new[] { "#" }, StringSplitOptions.None)[0].Trim();
                    if (string.IsNullOrEmpty(codeLine))
                        continue;
                }

                if (line.Contains("+") || line.Contains("-") || line.Contains("*") || line.Contains("/") || line.Contains("%") || line.Contains("**"))
                {
                    komputasiCount++;
                }

                if (line.Contains("if") || line.Contains("for") || line.Contains("while") || line.Contains("switch"))
                {
                    kontrolCount++;
                }

                if (line.Contains("except") || line.Contains("try") || line.Contains("finally"))
                {
                    errorHandlerCount++;
                }
            }
        }

        private void ErrorTolerance_Load(object sender, EventArgs e)
        {
            radioButtonCSharp.Checked = true;
            dataGridViewResults.Columns.Add("FileName", "File Location");
            dataGridViewResults.Columns.Add("Computations", "Computations");
            dataGridViewResults.Columns.Add("ControlStructures", "Control Structures");
            dataGridViewResults.Columns.Add("ErrorHandlers", "Error Handlers");
            dataGridViewResults.Columns.Add("ErrorTolerance", "Error Tolerance");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowHelpMessageBox();
        }
        private void ShowHelpMessageBox()
        {
            string helpMessage = GenerateHelpMessage();
            MessageBox.Show(helpMessage, "User Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            listBoxFiles.Items.Clear();
            totalErrorTolerance = 0;
            fileCount = 0;
            dataGridViewResults.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Show SaveFileDialog to choose the file path for saving
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveFileDialog.Title = "Export to CSV";
                saveFileDialog.FileName = "ErrorToleranceResults.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Create a stream writer to write to the chosen file
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Write the header line
                        sw.WriteLine("ERROR TOLERANCE ");
                        sw.WriteLine(" ");
                        sw.WriteLine($"{textBox3.Text}");
                        sw.WriteLine(" ");
                        sw.WriteLine("File Location|Computations|Control Structures|Error Handlers|Error Tolerance");

                        // Write each row in the DataGridView
                        foreach (DataGridViewRow row in dataGridViewResults.Rows)
                        {
                            string line = $"{row.Cells["FileName"].Value}|{row.Cells["Computations"].Value}|{row.Cells["ControlStructures"].Value}|{row.Cells["ErrorHandlers"].Value}|{row.Cells["ErrorTolerance"].Value}";
                            sw.WriteLine(line);
                        }

                        // Write the average line
                        sw.WriteLine($"{textBox3.Text}");
                    }

                    MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ShowHelpMessageBox1();
        }

        private void ShowHelpMessageBox1()
        {
            string helpMessage = GenerateHelpMessage1();
            MessageBox.Show(helpMessage, "Error Tolerance Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string GenerateHelpMessage1()
        {
            StringBuilder helpMessage = new StringBuilder();

            helpMessage.AppendLine("Error Tolerance");
            helpMessage.AppendLine();
            helpMessage.AppendLine("1. Definition");
            helpMessage.AppendLine("    - The damage that occurs when a program encounters an error.");
            helpMessage.AppendLine();
            helpMessage.AppendLine("2. How the Application Works");
            helpMessage.AppendLine("    - Error tolerance refers to the application's capability to handle and quantify errors in source code, specifically related to computational, control structure, and error handling aspects. The code is designed to analyze code files in different programming languages (C#, C++, and Python) and calculate an error tolerance metric based on the occurrence of specific elements within the code.");
            helpMessage.AppendLine();
            helpMessage.AppendLine("3. How to Calculate Error Tolerance");
            helpMessage.AppendLine("    - The error tolerance is calculated using the formula: ");
            helpMessage.AppendLine("Error Tolerance (%) =");
            helpMessage.AppendLine("Error Handling Count /");
            helpMessage.AppendLine("(Computational Count + Control Structure Count) × 100 %");
            helpMessage.AppendLine("    - If the sum of computational and control structure counts is zero, the error tolerance is set to zero to avoid division by zero.");

            return helpMessage.ToString();
        }
    }
}
