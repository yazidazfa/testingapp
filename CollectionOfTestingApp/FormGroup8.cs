using CollectionOfTestingApp.model;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace CollectionOfTestingApp
{
    public partial class FormGroup8 : Form
    {

        ClassList classListName = new ClassList();

        public FormGroup8()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string? line;
            int stringClass = 0;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK && classListName.nameList?.Count != 0)
            {
                try
                {
                    string[] files = Directory.GetFiles(dialog.SelectedPath);
                    StringBuilder sb = new StringBuilder();
                    if (classListName.nameList?[0] != null)
                    {
                        foreach (string file in files)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(file);
                            string fileExt = Path.GetExtension(file);
                            if (fileExt.CompareTo(".cs") == 0 && fileName != classListName.nameList[0])
                            {
                                StreamReader sr = new StreamReader(file);
                                while ((line = sr.ReadLine()) != null)
                                {
                                    if (Regex.IsMatch(line, classListName.nameList[0]))
                                    {
                                        richTextBox1.Text = classListName.nameList[0];
                                        stringClass++;
                                    }
                                    sb.AppendLine(line);
                                }
                                sr.Close();
                                textBoxClass.Text = stringClass.ToString();

                                textBoxTotalOut.Text = stringClass.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxTotalIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelTotalIn_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int stringExtends = 0;
            int stringNew = 0;

            string? line;

            string lineList = "";
            string[] lineArr = Array.Empty<string>();
            List<string> classList = new List<string>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "C Sharp Files (.cs)|*.cs";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                try
                {
                    StreamReader sr = new StreamReader(file);
                    StringBuilder sb = new StringBuilder();

                    while ((line = sr.ReadLine()) != null)
                    {

                        if (Regex.IsMatch(line, @"\s:\s")) stringExtends++;
                        if (Regex.IsMatch(line, @"\snew\s")) stringNew++;
                        if (Regex.IsMatch(line, @"\sclass\s"))
                        {
                            lineArr = line.Split("class");
                            lineList = lineArr[1];
                            string[] classArr = lineList.Split(' ');
                            classList.Add(classArr[1]);
                            classListName.nameList?.Add(classArr[1]);
                        }
                        sb.AppendLine(line);
                    }

                    sr.Close();

                    richTextBox1.Text = classListName.nameList?[0];
                    textBoxExtend.Text = stringExtends.ToString();
                    textBoxNew.Text = stringNew.ToString();

                    textBoxTotalIn.Text = (stringExtends + stringNew).ToString();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }


        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}