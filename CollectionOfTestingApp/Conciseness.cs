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
    public partial class Conciseness : UserControl
    {
        public Conciseness()
        {
            InitializeComponent();
        }
        private string selectedFilePath;

        private void bt_upload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "C# Files (*.cs)|*.cs|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    textBox1.Text = selectedFilePath;
                }
            }
        }

        private void bt_calculate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                string[] lines = File.ReadAllLines(selectedFilePath);
                int totalFeatures = CountFeatures(lines);
                int totalLines = CountNonEmptyNonCommentLines(lines);
                int totalLOC = CountCommentLines(lines);

                if (totalLines > 0)
                {
                    double conciseness1 = (double)totalLOC / totalFeatures;
                    double conciseness2 = (double)totalLines / totalFeatures;
                    label2.Text =
                        $"File Name : {Path.GetFileName(selectedFilePath)}\n" +
                        $"Total Number of Function : {totalFeatures}\n" +
                        $"Total Number Line of Code : {totalLOC}\n" +
                        $"Total Number of Executable Line of Code : {totalLines}\n" +
                        $"\nConciseness (#Line of Code / Function) = {conciseness1:F2}" +
                        $"\nConciseness  (#Executable Line of Code / Function) = {conciseness2:F2}";

                    string methodNames = ExtractMethodNames(lines);
                    label3.Text = $"{methodNames}";
                }
                else
                {
                    label2.Text = "No code found in the file.";
                }
            }
            else
            {
                MessageBox.Show("Please select a C# file first.");
            }
        }

        private int CountFeatures(string[] lines)
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
        private int CountNonEmptyNonCommentLines(string[] lines)
        {
            int nonEmptyLines = 0;
            bool inMultilineComment = false;

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

                    if (!trimmedLine.StartsWith("//") && !string.IsNullOrWhiteSpace(trimmedLine))
                    {
                        nonEmptyLines++;
                    }
                }
            }
            return nonEmptyLines;
        }

        private int CountCommentLines(string[] lines)
        {
            int allLines = 0;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                allLines++;
            }
            return allLines;
        }

        private string ExtractMethodNames(string[] lines)
        {
            List<string> methodNames = new List<string>();
            bool inMultilineComment = false;
            int sequenceNumber = 1;

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
                        string[] parts = trimmedLine.Split('(');
                        string methodDeclaration = parts[0].Trim();
                        string methodLine = $"{sequenceNumber}. {methodDeclaration}";
                        methodNames.Add(methodLine);
                        sequenceNumber++;
                    }
                }
            }
            return string.Join("\n", methodNames);
        }

        private void bt_export_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                string[] lines = File.ReadAllLines(selectedFilePath);
                int totalFeatures = CountFeatures(lines);
                int totalLines = CountNonEmptyNonCommentLines(lines);
                int totalLOC = CountCommentLines(lines);

                if (totalLines > 0)
                {
                    double conciseness1 = (double)totalLOC / totalFeatures;
                    double conciseness2 = (double)totalLines / totalFeatures;

                    StringBuilder csvContent = new StringBuilder();
                    csvContent.AppendLine($"Conciseness;");
                    csvContent.AppendLine(";;");
                    csvContent.AppendLine($"File Name : ; {Path.GetFileName(selectedFilePath)};");
                    csvContent.AppendLine(";;");
                    csvContent.AppendLine("Name;Output;");
                    csvContent.AppendLine($"Total Number of Function : ;{totalFeatures};");
                    csvContent.AppendLine($"Total Number of Line of Code : ;{totalLOC};");
                    csvContent.AppendLine($"Total Number of Executable Line of Code : ;{totalLines};");
                    csvContent.AppendLine($"Conciseness (#Line of Code / Function) : ;{conciseness1:F2};");
                    csvContent.AppendLine($"Conciseness (#Executable Line of Code / Function) : ;{conciseness2:F2};");
                    csvContent.AppendLine();
                    csvContent.AppendLine("Function Name;");

                    string methodNames = ExtractMethodNames(lines);
                    string[] methods = methodNames.Split('\n');
                    int sequenceNumber = 1;

                    foreach (string method in methods)
                    {
                        if (!string.IsNullOrWhiteSpace(method))
                        {
                            string methodName = method.Trim();
                            methodName = System.Text.RegularExpressions.Regex.Replace(methodName, @"^\d+\.", "");
                            csvContent.AppendLine($"{sequenceNumber}. {methodName.Replace(". ", ";")};");
                            sequenceNumber++;
                        }
                    }

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                        saveFileDialog.FilterIndex = 1;
                        saveFileDialog.RestoreDirectory = true;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string csvFilePath = saveFileDialog.FileName;
                            File.WriteAllText(csvFilePath, csvContent.ToString());

                            MessageBox.Show($"CSV file exported successfully: {csvFilePath}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No code found in the file.");
                }
            }
            else
            {
                MessageBox.Show("Please select a C# file first.");
            }
        }

        private void bt_help_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(bt_help, new Point(0, bt_help.Height));
        }

        private void howTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "How to Use the Application:\n\n";
            message += "1. Upload your C# file\n";
            message += "2. Click the 'Calculate Conciseness' button to calculate the Conciseness score\n";
            message += "3. The result of the calculation will be displayed on the screen\n";
            message += "4. If you want to export the result to a CSV file, please click the 'Export to CSV' button";

            MessageBox.Show(message, "How to Use the Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void docNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder explanation = new StringBuilder();
            explanation.AppendLine("Introduction to Conciseness in Software Quality Factors:");
            explanation.AppendLine();
            explanation.AppendLine("Conciseness is a vital feature derived from the Software Quality Factors, playing a crucial role in assessing and enhancing the overall quality of software systems. This feature is based on McCall's Factor Models, specifically focusing on the Conciseness factor. According to McCall, Conciseness is a measure of the program's compactness, particularly in terms of the number of Lines of Code (LOC). It is specifically designed for programs written in the C# language, evaluating their efficiency and clarity.");
            explanation.AppendLine();
            explanation.AppendLine("The Conciseness feature employs two key metrics to evaluate and quantify the quality of a C# program:");
            explanation.AppendLine();
            explanation.AppendLine("1. Conciseness (LoC / Total Features):");
            explanation.AppendLine("   Conciseness, in this context, is calculated by dividing the total number of Lines of Code (LoC) by the total number of features, where features refer to methods, functions, or procedures within the program. This metric provides insights into the overall compactness of the codebase, emphasizing the importance of minimizing unnecessary code to enhance readability and maintainability.");
            explanation.AppendLine();
            explanation.AppendLine("2. Conciseness (Executable LoC / Total Features):");
            explanation.AppendLine("   Another facet of Conciseness is measured by considering only the Executable Lines of Code (Executable LoC) in the calculation. Similar to the first metric, this approach offers a more focused evaluation by excluding non-executable lines, such as comments. It provides a nuanced perspective on the efficiency of the program, emphasizing the importance of concise and purposeful code execution.");
            MessageBox.Show(explanation.ToString(), "Conciseness Explanation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
