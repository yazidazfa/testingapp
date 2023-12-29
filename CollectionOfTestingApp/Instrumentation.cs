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
    public partial class Instrumentation : UserControl
    {
        private string pathSourceCode;
        public Instrumentation()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pathSourceCode = ofd.FileName;
                txtPath.Text = ofd.FileName;
                textSourceCode.Text = ReadSourceCode(pathSourceCode);
            }
        }

        private string ReadSourceCode(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        private int CountLogging(string sourceCode)
        {
            string loggingPattern = @"\b(?:log\.(?:error)|[a-zA-Z]+\.error|[a-zA-Z]+\.Error|Error)\(";

            Regex loggingRegex = new Regex(loggingPattern);
            int countLogStatements = loggingRegex.Matches(sourceCode).Count;

            return countLogStatements;
        }

        private int CountErrorHandling(string sourceCode)
        {
            string errorHandlingPattern = @"\bcatch\s*\([^{}]*\)";

            Regex errorHandlingRegex = new Regex(errorHandlingPattern);
            int countErrorHandlingBlocks = errorHandlingRegex.Matches(sourceCode).Count;

            return countErrorHandlingBlocks;
        }

        private int CountInstrument(string filePath)
        {
            string sourceCode = ReadSourceCode(filePath);
            int totalLogging = CountLogging(sourceCode);
            int totalErrorHandling = CountErrorHandling(sourceCode);

            int totalInstrument = totalLogging + totalErrorHandling;

            return totalInstrument;
        }

        private int CountInputOutput(string sourceCode)
        {
            string inputOutputPattern = @"\b(Console\.Read(Line)?|Console\.Write(Line)?|Console\.Error\.Write(Line)?|readlineSync\.question|readlineSync\.questionInt|fs\.readFile|fs\.writeFile|fetch)\b";

            Regex inputOutputRegex = new Regex(inputOutputPattern);
            int countInputOutputStatements = inputOutputRegex.Matches(sourceCode).Count;

            return countInputOutputStatements;
        }

        private int CountControlStatements(string sourceCode)
        {
            string controlStatementsPattern = @"\b(if|else|for|while|switch|case|do|foreach)\b";

            Regex controlStatementsRegex = new Regex(controlStatementsPattern);
            int countControlStatements = controlStatementsRegex.Matches(sourceCode).Count;

            return countControlStatements;
        }

        private int CountMethods(string sourceCode)
        {
            string methodPattern = @"(\bpublic\b|\bprivate\b|\bprotected\b|\binternal\b)?\s+(\bstatic\b)?\s+(\w+)\s+(\w+)\s*\([^)]*\)\s*{";

            Regex methodRegex = new Regex(methodPattern);
            int countMethods = methodRegex.Matches(sourceCode).Count;

            return countMethods;
        }

        private int CountTotalItem(string filePath)
        {
            string sourceCode = ReadSourceCode(filePath);

            int countMethods = CountMethods(sourceCode);
            int countInputOutput = CountInputOutput(sourceCode);
            int countControlStatements = CountControlStatements(sourceCode);

            return countMethods + countInputOutput + countControlStatements;
        }

        private double CountPercentage(int instrument, int totalItem)
        {
            double percentage = (double)instrument / totalItem * 100;

            return percentage;
        }

        private void btnCountInstrument_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pathSourceCode))
            {
                int instrument = CountInstrument(pathSourceCode);
                int totalItemCode = CountTotalItem(pathSourceCode);

                string sourceCode = ReadSourceCode(pathSourceCode);
                int totalLog = CountLogging(sourceCode);
                int totErrHand = CountErrorHandling(sourceCode);
                int totControl = CountControlStatements(sourceCode);
                int totFunc = CountMethods(sourceCode);
                int totInOut = CountInputOutput(sourceCode);

                double persentaseInstrumentasi = CountPercentage(instrument, totalItemCode);

                processUI(totalLog, totErrHand, totControl, totInOut, totFunc, instrument, totalItemCode, persentaseInstrumentasi);

            }

            else
            {
                MessageBox.Show("Please select the source code file first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void processUI(int totalLog, int totErrHand, int totControl, int totInOut, int totFunc, int instrument, int item, double percentage)
        {
            dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15);

            dataGridView.Rows.Clear();

            dataGridView.Rows.Add("Number Of Logging Error", totalLog.ToString());
            dataGridView.Rows.Add("Number Of Error Exception", totErrHand.ToString());
            dataGridView.Rows.Add("Number Of Control Flow", totControl.ToString());
            dataGridView.Rows.Add("Number Of Input Output", totInOut.ToString());
            dataGridView.Rows.Add("Number Of Methods", totFunc.ToString());
            totInstrument.Text = instrument.ToString();
            totalItem.Text = item.ToString();
            txtPersentase.Text = percentage + "%";
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string message = "Help:\n" +
                  "1. Press the browse file button\n" +
                  "2. Select and open the file\n" +
                  "3. Press the check button to calculate the percentage\n" +
                  "4. The result will be displayed\n" +
                  "5. Data in the table are criteria for calculating the formula\n" +
                  "6. The percentage result is located outside the table\n\n" +
                  "Important Information: Criteria for testing files or source code:\n" +
                  "1. Using C# or Typescript programming language\n" +
                  "2. Using object-oriented programming paradigm\n" +
                  "3. For C#, using third-party logging with Serilog\n" +
                  "4. For Typescript, using third-party logging with Winston";


            MessageBox.Show(message, "Help", MessageBoxButtons.OK);
        }

        private void ExportToCSV(string folderPath, string fileName, params object[] data)
        {
            try
            {
                string filePath = Path.Combine(folderPath, fileName);

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // Write header
                    sw.WriteLine("Category,Value");

                    // Write data
                    sw.WriteLine("Number Of Logging Error," + data[0]);
                    sw.WriteLine("Number Of Error Exception," + data[1]);
                    sw.WriteLine("Number Of Control Flow," + data[2]);
                    sw.WriteLine("Number Of Input Output," + data[3]);
                    sw.WriteLine("Number Of Methods," + data[4]);
                    sw.WriteLine("Total Instrument," + data[5]);
                    sw.WriteLine("Total Item should be Instrumented," + data[6]);
                    sw.WriteLine("Percentage," + data[7] + "%");
                }

                MessageBox.Show($"Data exported to {filePath} successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data to CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportCsv_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pathSourceCode))
            {
                int instrument = CountInstrument(pathSourceCode);
                int totalItemCode = CountTotalItem(pathSourceCode);

                string sourceCode = ReadSourceCode(pathSourceCode);
                int totalLog = CountLogging(sourceCode);
                int totErrHand = CountErrorHandling(sourceCode);
                int totControl = CountControlStatements(sourceCode);
                int totFunc = CountMethods(sourceCode);
                int totInOut = CountInputOutput(sourceCode);

                double persentaseInstrumentasi = CountPercentage(instrument, totalItemCode);

                // Allow the user to choose the folder
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string folderPath = folderBrowserDialog.SelectedPath;
                        processUI(totalLog, totErrHand, totControl, totInOut, totFunc, instrument, totalItemCode, persentaseInstrumentasi);
                        ExportToCSV(folderPath, "instrumentation.csv", totalLog, totErrHand, totControl, totInOut, totFunc, instrument, totalItemCode, persentaseInstrumentasi);
                    }
                }
            }
        }
    }
}
