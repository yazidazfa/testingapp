using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionOfTestingApp
{
    public partial class SelfDocumentation : UserControl
    {
        public SelfDocumentation()
        {
            InitializeComponent();
        }

        private (double, double) AnalyzeAndDisplayResults(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int totalFunctions = HitungFungsi(lines);
            double totalCommentFunctions = HitungCommentFunctions(lines);
            double totalCommentInFunctions = HitungKomentarDalamFungsi(lines);

            if (totalFunctions > 0)
            {
                double selfdocumentation1 = totalCommentFunctions / totalFunctions * 100;
                double selfdocumentation2 = totalCommentInFunctions / totalFunctions * 100;

                dataGridView1.Rows.Add(Path.GetFileName(filePath), totalFunctions, totalCommentFunctions, $"{selfdocumentation1:F2}%");
                dataGridView2.Rows.Add(Path.GetFileName(filePath), totalFunctions, totalCommentInFunctions, $"{selfdocumentation2:F2}%");

                return (selfdocumentation1, selfdocumentation2);
            }
            else
            {
                dataGridView1.Rows.Add(Path.GetFileName(filePath), "0");
                dataGridView2.Rows.Add(Path.GetFileName(filePath), "0");
                return (0, 0);
            }
        }

        private int HitungFungsi(string[] lines)
        {
            int featureCount = 0;
            bool inMultilineComment = false;
            string pattern = @"^\s*(private|public|protected|internal|static)?\s\w+\s\w+\s*\(.*\)";
            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (inMultilineComment)
                {
                    if (trimmedLine.Contains("*/"))
                    {
                        inMultilineComment = false;
                    }
                }
                else
                {
                    if (trimmedLine.StartsWith("/*"))
                    {
                        inMultilineComment = true;
                        continue;
                    }
                    if (!trimmedLine.StartsWith("//") && Regex.IsMatch(trimmedLine, pattern))
                    {
                        featureCount++;
                    }
                }
            }
            return featureCount;
        }
        private int HitungCommentFunctions(string[] lines)
        {
            int count = 0;
            bool isPreviousLineComment = false;
            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmedLine))
                {
                    continue; // Abaikan baris kosong
                }
                if (CekComment(trimmedLine))
                {
                    isPreviousLineComment = true;
                }
                else if (CekFungsi(trimmedLine) && isPreviousLineComment)
                {
                    count++;
                    isPreviousLineComment = false;
                }
                else
                {
                    isPreviousLineComment = false; // Reset status jika tidak ada deklarasi fungsi pada baris ini
                }
            }
            return count;
        }

        private int HitungKomentarDalamFungsi(string[] lines)
        {
            int count = 0;
            bool isInsideFunction = false;
            bool alreadyCountedCommentInFunction = false;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (isInsideFunction)
                {
                    // Hanya hitung komentar jika bukan baris kosong dan bukan deklarasi fungsi
                    if (!string.IsNullOrWhiteSpace(trimmedLine) && !CekFungsi(trimmedLine))
                    {
                        if (trimmedLine.StartsWith("/*"))
                        {
                            // Baris dimulai dengan /*, menandakan komentar multiline dimulai
                            count++;
                            isInsideFunction = !trimmedLine.EndsWith("*/");
                            alreadyCountedCommentInFunction = true;
                        }
                        else if (CekComment(trimmedLine) && !alreadyCountedCommentInFunction)
                        {
                            // Baris adalah komentar pada fungsi
                            count++;
                            alreadyCountedCommentInFunction = true;
                        }
                    }

                    // Periksa apakah fungsi telah selesai
                    if (trimmedLine.Contains("}"))
                    {
                        isInsideFunction = false;
                        alreadyCountedCommentInFunction = false;
                    }
                }
                else if (CekFungsi(trimmedLine))
                {
                    isInsideFunction = true;
                    alreadyCountedCommentInFunction = false;
                }
            }

            return count;
        }

        static bool CekComment(string line)
        {
            return Regex.IsMatch(line, @"^\s*//|^\s*/\*|^\s*\*/|^\s*\*"); // Anda dapat menyesuaikan pola sesuai dengan format komentar pada file C#
        }

        static bool CekFungsi(string line)
        {
            return Regex.IsMatch(line, @"^\s*(private|public|protected|internal|static)?\s\w+\s\w+\s*\(.*\)"); // Anda dapat menyesuaikan pola sesuai dengan format deklarasi fungsi pada file C#
        }
        private void bt_upload_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;
                    string[] files = Directory.GetFiles(folderPath, "*.cs"); // Mendapatkan semua file dengan ekstensi .cs di dalam folder
                    if (files.Length > 0)
                    {
                        textBox1.Text = $"{folderPath}";
                        dataGridView1.Rows.Clear();
                        dataGridView2.Rows.Clear();// Mengosongkan DataGridView sebelum menambahkan hasil baru
                        double totalselfdocumentation1 = 0;
                        double totalselfdocumentation2 = 0;

                        foreach (string file in files)
                        {
                            (double fileselfdocumentation1, double fileselfdocumentation2) = AnalyzeAndDisplayResults(file);
                            totalselfdocumentation1 += fileselfdocumentation1;
                            totalselfdocumentation2 += fileselfdocumentation2;
                        }

                        double averageselfdocumentation1 = totalselfdocumentation1 / files.Length;
                        double averageselfdocumentation2 = totalselfdocumentation2 / files.Length;

                        dataGridView1.Rows.Add("", "", "", "");
                        dataGridView1.Rows.Add("", "", "", $"Average : {averageselfdocumentation1:F2}%");

                        dataGridView2.Rows.Add("", "", "", "");
                        dataGridView2.Rows.Add("", "", "", $"Average : {averageselfdocumentation2:F2}%");
                    }
                    else
                    {
                        MessageBox.Show("No C# files found in the selected folder.");
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            textBox1.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string helpMessage = "This is a testing tool to calculate the Self-Documentation of a software in which contains C# files.\n\n" +
                                 "1. Click 'Browse' to select a folder containing C# files.\n" +
                                 "2. The application will analyze each file and display the results in the table.\n" +
                                 "3. Click 'Export to CSV' to save the analysis results to a CSV file.\n" +
                                 "4. Click 'Reset' to clear the table and selected folder.";
            MessageBox.Show(helpMessage, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportToCSV_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 || dataGridView2.Rows.Count > 0)
            {
                try
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                        saveFileDialog.FilterIndex = 1;
     
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFileDialog.FileName;

                            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
                            {
                                // Menambahkan baris informasi pemisah kolom yang digunakan
                                sw.WriteLine("sep=,");

                                sw.WriteLine();
                                sw.WriteLine("Self-Documentation Data Report");
                                sw.WriteLine();
                                sw.WriteLine();

                                // Menulis header dataGridView1
                                foreach (DataGridViewColumn column in dataGridView1.Columns)
                                {
                                    sw.Write("\"" + column.HeaderText.Replace("\"", "\"\"") + "\",");
                                }
                                sw.WriteLine();

                                // Menulis data dataGridView1
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        sw.Write("\"" + cell.Value?.ToString().Replace("\"", "\"\"") + "\",");
                                    }
                                    sw.WriteLine();
                                }

                                // Menambahkan baris kosong sebagai pemisah antara dataGridView1 dan dataGridView2
                                sw.WriteLine();
                                sw.WriteLine();

                                // Menulis header dataGridView2
                                foreach (DataGridViewColumn column in dataGridView2.Columns)
                                {
                                    sw.Write("\"" + column.HeaderText.Replace("\"", "\"\"") + "\",");
                                }
                                sw.WriteLine();

                                // Menulis data dataGridView2
                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        sw.Write("\"" + cell.Value?.ToString().Replace("\"", "\"\"") + "\",");
                                    }
                                    sw.WriteLine();
                                }
                            }

                            MessageBox.Show("Data has been exported to CSV successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No data to export.", "Export Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnHelp_Click(object sender, EventArgs e)
        {
            listmenu.Show(btnHelp, 0, btnHelp.Height);
        }

        private void userguide_Click(object sender, EventArgs e)
        {
            string helpMessage = "This is a testing tool to calculate the Self-Documentation of a software in which contains C# files.\n\n" +
                     "1. Click 'Browse' to select a folder containing C# files.\n" +
                     "2. The application will analyze each file and display the results in the table.\n" +
                     "3. Click 'Export to CSV' to save the analysis results to a CSV file.\n" +
                     "4. Click 'Reset' to clear the table and selected folder.";
            MessageBox.Show(helpMessage, "User Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void info_Click(object sender, EventArgs e)
        {
            string helpMessage = "Self-Documentation (McCall)\n\n" +
                     "Self-Documentation is an aspect within the McCall factor that reflects the extent to which the application's source code can explain itself without requiring external interpretation.\n\n" +
                     "In this context, Self-Documentation is assessed in terms of the number of comments that explain the functions present in the source code files.\n\n" +
                     "How to Calculate Self-Documentation :\n\n" +
                     "Calculate Total Function Comments : Identify and count the number of comments placed above the functions in the source code files.\n" +
                     "Calculate Total Functions : Determine the total number of functions present in the source code files.\n" +
                     "Calculate Self Documentation Ratio (SDR) : Calculate the ratio between the number of comments explaining functions and the total number of functions. The formula can be expressed as follows :\n" +
                     "SDR = Number of Function Comments / Total Functions\n\n" +
                     "On the other hand, calculating Self-Documentation can also be done by counting the number of comments explaining the code inside functions divided by the total number of all functions (in the second table).\n\n" +
                     "As a conclusion, SDR provides an overview of how well each function in the source code is documented.";
            MessageBox.Show(helpMessage, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
