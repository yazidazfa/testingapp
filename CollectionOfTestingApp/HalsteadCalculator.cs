using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;   
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionOfTestingApp
{
    public partial class HalsteadCalculator : UserControl
    {
        public HalsteadCalculator()
        {
            InitializeComponent();
        }

        double csv = new double();

        private void srcBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PHP Files|*.php";
            openFileDialog.Title = "Select a PHP File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = openFileDialog.FileName;
            }
        }

        private void AnalyzePHPFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                HashSet<string> uniqueOperators = new HashSet<string>();
                HashSet<string> uniqueOperands = new HashSet<string>();

                foreach (string line in lines)
                {
                    MatchCollection operatorMatches = Regex.Matches(line, @"(\+|\-|\*|\/|\%|\*\*|\=|==|\>|\<|\>=|\<=|\!=|\&&|\|\|)");
                    foreach (Match match in operatorMatches)
                    {
                        uniqueOperators.Add(match.Value);
                    }

                    MatchCollection operandMatches = Regex.Matches(line, @"(\$[a-zA-Z_\x7f-\xff][a-zA-Z0-9_\x7f-\xff]*)");
                    foreach (Match match in operandMatches)
                    {
                        uniqueOperands.Add(match.Value);
                    }
                }

                int operatorCount = uniqueOperators.Count;
                int operandCount = uniqueOperands.Count;

                // Menampilkan hasil analisis pada RichTextBox
                operatorsPath.Text = $"Total Operators: {operatorCount}\n" + $"Total Operands: {operandCount}\n";

                // Menghitung dan menampilkan hasil rumus Halstead Complexity Measures
                int totalOperatorsAndOperands = operatorCount + operandCount;
                double programVolume = totalOperatorsAndOperands * Math.Log(operatorCount + operandCount, 2);
                double programDifficulty = (operatorCount / 2.0) * (operandCount / operandCount);
                double programEffort = programVolume * programDifficulty;
                double expectedBugs = programVolume / 3000.0;

                operandsPath.Text = $"Program Length (N): {totalOperatorsAndOperands}\n";
                operandsPath.Text += $"Program Volume (V): {programVolume}\n";
                operandsPath.Text += $"Program Difficulty (D): {programDifficulty}\n";
                operandsPath.Text += $"Program Effort (E): {programEffort}\n";
                operandsPath.Text += $"Expected Bugs (B): {expectedBugs}\n";

                SaveToCsv("output.csv", operatorCount, operandCount, totalOperatorsAndOperands, programVolume, programDifficulty, programEffort, expectedBugs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            var fileName = filePath.Text;
            AnalyzePHPFile(fileName);
        }

        private void showCode_Click(object sender, EventArgs e)
        {
            var fileName = filePath.Text;
            string[] fileCode = File.ReadAllLines(fileName);
            StringBuilder linesCode = new StringBuilder();
            foreach (string line in fileCode)
            {
                linesCode.AppendLine(line);
            }
            analyzeResult.Text = linesCode?.ToString();
        }

        static void SaveToCsv(string filePath, int operatorCount, int operandCount, int totalOperatorsAndOperands, double programVolume, double programDifficulty, double programEffort, double expectedBugs)
        {
            // Membuat konten CSV
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("Metric,Value");
            csvContent.AppendLine($"Total Operators,{operatorCount}");
            csvContent.AppendLine($"Total Operands,{operandCount}");
            csvContent.AppendLine($"Program Length (N),{totalOperatorsAndOperands}");
            csvContent.AppendLine($"Program Volume (V),{programVolume}");
            csvContent.AppendLine($"Program Difficulty (D),{programDifficulty}");
            csvContent.AppendLine($"Program Effort (E),{programEffort}");
            csvContent.AppendLine($"Expected Bugs (B),{expectedBugs}");

            // Menyimpan konten CSV ke dalam file
            File.WriteAllText(filePath, csvContent.ToString());

            MessageBox.Show($"Hasil analisis telah disimpan dalam file: {filePath}");
        }

        private void userGuide_Click(object sender, EventArgs e)
        {
            string helpGuide = @"
                Halstead Complexity Measures Calculator - User Guide
                Getting Started:

                1. File Selection:
                    * Click on the 'Browse' button to select the PHP file you want to analyze.
                    * Alternatively, manually input the file path into the 'File Path' field.

                2. Displaying Code:
                    * Click on the 'Show Code' button to display the content of the selected PHP file in the 'Code Display' section.

                3. Analyzing Code:
                    * After displaying the code, the software will calculate unique operators and operands along with various Halstead Complexity Measures.
                    * The results will be shown in the 'Analysis Results' section.

                4. Interpreting Results:
                    * Review the counts of unique operators and operands.
                    * Examine the calculated Halstead Complexity Measures, including Program Length, Program Volume, Program Difficulty, Program Effort, and Expected Bugs.

                Notes:

                * The software identifies operators based on common PHP operators and operands as variables starting with `$`.
                * Exception handling is in place to provide feedback in case of errors during file reading or analysis.

                Tips:

                * Ensure that the selected file is a valid PHP file.
                * If you encounter any issues, check the error messages displayed in case of an error.

            ";

            using (Form helpForm = new Form())
            {
                helpForm.Text = "Halstead Complexity Measures Calculator - User Guide";

                TextBox textBox = new TextBox();
                textBox.Multiline = true;
                textBox.ReadOnly = true;
                textBox.ScrollBars = ScrollBars.Vertical;
                textBox.Dock = DockStyle.Fill;
                textBox.ReadOnly = true;
                textBox.Text = helpGuide;

                helpForm.Controls.Add(textBox);
                helpForm.Size = new Size(790, 570);
                helpForm.ShowDialog();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            showHelpGuid();
        }
        private void showHelpGuid()
        {
            string helpGuid = GetherGuidMessage();
            MessageBox.Show(helpGuid, "User Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string GetherGuidMessage()
        {
            StringBuilder guidMessage = new StringBuilder();
            guidMessage.AppendLine("Halstead Complexity Measures Metric - User Guide");
            guidMessage.AppendLine("Getting Started:");
            guidMessage.AppendLine("=================================================");
            guidMessage.AppendLine();   
            guidMessage.AppendLine("1. File Selection:");
            guidMessage.AppendLine("Click on the 'Browse' button to select the PHP file you want to analyze.");
            guidMessage.AppendLine("Alternatively, manually input the file path into the 'File Path' field.");
            guidMessage.AppendLine("2. Displaying Code:");
            guidMessage.AppendLine("Click on the 'Show Code' button to display the content of the selected PHP file in the 'Code Display' section.");
            guidMessage.AppendLine("3. Analyzing Code:");
            guidMessage.AppendLine("After displaying the code, the software will calculate unique operators and operands along with various Halstead Complexity Measures.");
            guidMessage.AppendLine("The results will be shown in the 'Analysis Results' section.");
            guidMessage.AppendLine("4. Interpreting Results:");
            guidMessage.AppendLine("Review the counts of unique operators and operands.");
            guidMessage.AppendLine("Examine the calculated Halstead Complexity Measures, including Program Length, Program Volume, Program Difficulty, Program Effort, and Expected Bugs.");
            guidMessage.AppendLine("Notes:");
            guidMessage.AppendLine("The software identifies operators based on common PHP operators and operands as variables starting with $.");
            guidMessage.AppendLine("Exception handling is in place to provide feedback in case of errors during file reading or analysis.");

            return guidMessage.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string list = Info();
            MessageBox.Show(list, "Info :", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string Info()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("The operator and operand are the lines of code that begins with the $ sign\r\n");
            info.AppendLine("The program volume = Total Operators and Operands * Log2(Uniq Operator + Uniq Operands)\r\n");
            info.AppendLine("The program difficulty = (Uniq Operators/2) * (Total Operands/Uniq Operands)\r\n");
            info.AppendLine("The program effort = Program difficulty * Program effort\r\n");
            info.AppendLine("The program exepted bugs = Program effort/3000\r\n");

            return info.ToString();
        }
    }
}
