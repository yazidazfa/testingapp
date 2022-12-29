using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MindFusion.Diagramming;
using System.Xml;
using Path = System.IO.Path;
using MindFusion.Diagramming.Layout;
using System.Net.Http.Headers;
using System.Globalization;

namespace CollectionOfTestingApp
{
    public partial class FormGroup3 : Form
    {
        public FormGroup3()
        {
            InitializeComponent();
        }

        List<ClassDataType> ClassCollection = new List<ClassDataType>();
        List<string> xmlDocuments = new List<string>();
        string XMLFilePath = "XMLDiagram.xml";        

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            string filePath = String.Empty;
            string fileExt = String.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder builder = new StringBuilder();
                int id = 0;
                foreach (string file in openFileDialog.FileNames)
                {
                    filePath = file;
                    fileExt = Path.GetExtension(filePath);
                    if (rb_java.Checked)
                    {
                        if (fileExt.CompareTo(".java") == 0)
                        {
                            try
                            {
                                StreamReader reader = new StreamReader(filePath);
                                string line = "";
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (line.Contains("class"))
                                    {
                                        string[] lineArr = line.Split(' ');
                                        id++;
                                        if (line.Contains("extends"))
                                        {
                                            var kelas = new ClassDataType(lineArr[Array.FindIndex(lineArr, row => row.Contains("class")) + 1], lineArr[Array.FindIndex(lineArr, row => row.Contains("extends")) + 1]);
                                            kelas.id = id;
                                            ClassCollection.Add(kelas);
                                        }
                                        else if (line.Contains("implements"))
                                        {
                                            var kelas = new ClassDataType(lineArr[Array.FindIndex(lineArr, row => row.Contains("class")) + 1], lineArr[Array.FindIndex(lineArr, row => row.Contains("implements")) + 1]);
                                            kelas.id = id;
                                            ClassCollection.Add(kelas);
                                        }
                                        else
                                        {
                                            var kelas = new ClassDataType(lineArr[Array.FindIndex(lineArr, row => row.Contains("class")) + 1], "");
                                            kelas.id = id;
                                            ClassCollection.Add(kelas);
                                        }
                                    }
                                    else if (line.Contains("interface"))
                                    {
                                        string[] lineArr = line.Split(' ');
                                        id++;
                                        var kelas = new ClassDataType(lineArr[Array.FindIndex(lineArr, row => row.Contains("interface")) + 1], "");
                                        kelas.id = id;
                                        ClassCollection.Add(kelas);
                                    }

                                    builder.AppendLine(line);

                                }

                                builder.AppendLine("----------------------------------");
                                reader.Close();
                                txtBox_sourceCode.Text = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    else if (rb_csharp.Checked)
                    {
                        if (fileExt.CompareTo(".cs") == 0)
                        {
                            try
                            {
                                StreamReader reader = new StreamReader(filePath);
                                string line = "";
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (line.Contains("class"))
                                    {

                                        string[] lineArr = line.Split(' ');
                                        id++;
                                        if (line.Contains(":"))
                                        {
                                            var kelas = new ClassDataType(lineArr[Array.FindIndex(lineArr, row => row.Contains("class")) + 1], lineArr[Array.FindIndex(lineArr, row => row.Contains(":")) + 1]);
                                            kelas.id = id;
                                            ClassCollection.Add(kelas);
                                        }
                                        else
                                        {
                                            var kelas = new ClassDataType(lineArr[Array.FindIndex(lineArr, row => row.Contains("class")) + 1], "");
                                            kelas.id = id;
                                            ClassCollection.Add(kelas);
                                        }
                                    }
                                    builder.AppendLine(line);

                                }

                                builder.AppendLine("----------------------------------");
                                reader.Close();
                                txtBox_sourceCode.Text = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }


                }
                List<ClassDataType> ClassCollectionTemp = new List<ClassDataType>();

                foreach (var item in ClassCollection)
                {
                    int inc = 1;
                    if (item.superClass.Any())
                    {
                        if (!(ClassCollection.Any(a => a.className == item.superClass)))
                        {
                            var kelas = new ClassDataType(item.superClass, "");
                            kelas.id = ClassCollection.Max(a => a.id + inc);
                            ClassCollectionTemp.Add(kelas);
                            inc++;
                        }
                    }
                }

                ClassCollection.AddRange(ClassCollectionTemp);

                foreach (var item in ClassCollection)
                {
                    Console.WriteLine(item.id);
                    Console.WriteLine("nama class : " + item.className);
                    Console.WriteLine("superClass : " + item.superClass);

                    if (item.superClass.Any())
                    {
                        foreach (var itemclass in ClassCollection)
                        {
                            if (item.superClass == itemclass.className)
                            {
                                item.target = itemclass.id;
                            }
                        }
                    }
                }




                /*ClassesData.DataSource = ClassCollection;
                dgv_sourceCode.DataSource = ClassCollection;*/
                foreach (var item in ClassCollection)
                {
                    if (!item.superClass.Any())
                    {
                        dgv_sourceCode.Rows.Add(item.className, "", item.id, item.target);
                    }
                    else
                    {
                        dgv_sourceCode.Rows.Add(item.className, item.superClass, item.id, item.target);
                    }

                }

                //write xml documents
                xmlDocuments.Add(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
                xmlDocuments.Add("<Graph>");
                xmlDocuments.Add("<Nodes>");
                foreach (var item in ClassCollection)
                {
                    xmlDocuments.Add($"<Node id=\"{item.id}\" name=\"{item.className}\" />");
                }
                xmlDocuments.Add("</Nodes>");
                xmlDocuments.Add("<Links>");
                foreach (var item in ClassCollection)
                {
                    if (item.superClass.Any())
                    {
                        xmlDocuments.Add($"<Link origin=\"{item.id}\" target=\"{item.target}\" />");
                    }
                }
                xmlDocuments.Add("</Links>");
                xmlDocuments.Add("</Graph>");

                File.WriteAllLines(XMLFilePath, xmlDocuments);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void diagram1_NodeCreated(object sender, MindFusion.Diagramming.NodeEventArgs e)
        {

        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            try
            {
                diagram.Nodes.Clear();
                Dictionary<string, DiagramNode> nodeMap = new Dictionary<string, DiagramNode>();
                RectangleF bounds = new RectangleF(0, 0, 18, 6);

                XmlDocument document = new XmlDocument();
                document.Load(XMLFilePath);

                // Load node data
                XmlNodeList nodes = document.SelectNodes("/Graph/Nodes/Node");
                foreach (XmlElement node in nodes)
                {
                    ShapeNode diagramNode = diagram.Factory.CreateShapeNode(bounds);
                    nodeMap[node.GetAttribute("id")] = diagramNode;
                    diagramNode.Text = node.GetAttribute("name");
                }

                // Load link data
                XmlNodeList links = document.SelectNodes("/Graph/Links/Link");
                foreach (XmlElement link in links)
                {
                    diagram.Factory.CreateDiagramLink(
                        nodeMap[link.GetAttribute("origin")],
                        nodeMap[link.GetAttribute("target")]);
                }

                // Arrange the graph
                LayeredLayout layout = new LayeredLayout();
                layout.LayerDistance = 16;
                layout.Arrange(diagram);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClassCollection.Clear();
            xmlDocuments.Clear();
            dgv_sourceCode.Rows.Clear();
            txtBox_sourceCode.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            diagram.Nodes.Clear();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var classCollectionCSV = new List<string>();
                    classCollectionCSV.Add("Class Name,Super Class Name,Class ID,Class Target");
                    foreach (var item in ClassCollection)
                    {
                        classCollectionCSV.Add($"{item.className},{item.superClass},{item.id},{item.target}");
                    }
                    File.WriteAllLines(sfd.FileName, classCollectionCSV);

                    MessageBox.Show("Your data has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExportDiagram_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PNG|*.png", ValidateNames = true })
            {
                sfd.DefaultExt = "png";
                sfd.Filter = "PNG files|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Image image = diagram.CreateImage();
                    image.Save(sfd.FileName);
                    image.Dispose();
                }
            }
        }
    }
}
