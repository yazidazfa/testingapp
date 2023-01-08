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
using System.Text.RegularExpressions;
using MindFusion.Diagramming.Fluent;

namespace CollectionOfTestingApp
{
    public partial class UserGroup3 : UserControl
    {
        public UserGroup3()
        {
            InitializeComponent();
        }

        List<ClassDataType> ClassCollection = new List<ClassDataType>();
        List<string[]> classStrings = new List<string[]>();
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
                //int id = 0;
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
                                List<string> lines = new List<string>();
                                List<string> classLines = new List<string>();
                                bool onClass = false;

                                lines = File.ReadAllLines(filePath).ToList();
                                for (int i = 0; i < lines.Count; i++)
                                {
                                    if (((lines[i].Contains("class") || lines[i].Contains("interface")) ^ onClass) && !(i == lines.Count() - 1))
                                    {
                                        onClass = true;
                                        classLines.Add(lines[i]);
                                    }
                                    else if ((lines[i].Contains("class") || lines[i].Contains("interface")) && onClass)
                                    {
                                        var asignClass = classLines.ToArray();
                                        classStrings.Add(asignClass);
                                        classLines.Clear();
                                        classLines.Add(lines[i]);
                                    }
                                    else if (i == lines.Count() - 1)
                                    {
                                        classLines.Add(lines[i]);
                                        var asignClass = classLines.ToArray();
                                        classStrings.Add(asignClass);
                                        classLines.Clear();
                                    }

                                    builder.AppendLine(lines[i]);
                                }

                                builder.AppendLine("----------------------------------");
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
                                List<string> lines = new List<string>();
                                List<string> classLines = new List<string>();
                                bool onClass = false;

                                lines = File.ReadAllLines(filePath).ToList();
                                for (int i = 0; i < lines.Count; i++)
                                {
                                    if ((lines[i].Contains("class") ^ onClass) && !(i == lines.Count() - 1))
                                    {
                                        onClass = true;
                                        classLines.Add(lines[i]);
                                    }
                                    else if (lines[i].Contains("class") && onClass)
                                    {
                                        var asignClass = classLines.ToArray();
                                        classStrings.Add(asignClass);
                                        classLines.Clear();
                                        classLines.Add(lines[i]);
                                    }
                                    else if (i == lines.Count() - 1)
                                    {
                                        classLines.Add(lines[i]);
                                        var asignClass = classLines.ToArray();
                                        classStrings.Add(asignClass);
                                        classLines.Clear();
                                    }

                                    builder.AppendLine(lines[i]);
                                }

                                builder.AppendLine("----------------------------------");
                                txtBox_sourceCode.Text = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }

                }

                /*Console.WriteLine("jumlah class string " + classStrings.Count());
                int test = 0;
                foreach (var strs in classStrings)
                {
                    Console.WriteLine(test++);
                    foreach (var str in strs)
                    {
                        Console.WriteLine(str);
                    }
                }*/

                for (int i = 0; i < classStrings.Count; i++)
                {
                    var kelas = new ClassDataType("", "");
                    foreach (var line in classStrings[i])
                    {

                        //menentukan nama class
                        if (line.Contains("class"))
                        {
                            string[] lineArr = line.Split(' ');
                            if (line.Contains("extends"))
                            {
                                kelas.className = lineArr[Array.FindIndex(lineArr, row => row.Contains("class")) + 1];
                                kelas.superClass = lineArr[Array.FindIndex(lineArr, row => row.Contains("extends")) + 1];
                                kelas.id = i + 1;
                            }
                            else if (line.Contains("implements"))
                            {
                                kelas.className = lineArr[Array.FindIndex(lineArr, row => row.Contains("class")) + 1];
                                kelas.superClass = lineArr[Array.FindIndex(lineArr, row => row.Contains("implements")) + 1];
                                kelas.id = i + 1;
                            }
                            else if (line.Contains(":"))
                            {
                                kelas.className = lineArr[Array.FindIndex(lineArr, row => row.Contains("class")) + 1];
                                kelas.superClass = lineArr[Array.FindIndex(lineArr, row => row.Contains(":")) + 1];
                                kelas.id = i + 1;
                            }
                            else
                            {
                                kelas.className = lineArr[Array.FindIndex(lineArr, row => row.Contains("class")) + 1];
                                kelas.id = i + 1;
                            }

                        }
                        else if (line.Contains("interface"))
                        {
                            string[] lineArr = line.Split(' ');
                            kelas.className = lineArr[Array.FindIndex(lineArr, row => row.Contains("interface")) + 1];
                            kelas.id = i + 1;
                        }


                        // menentukan properti                        
                        if (line.Contains($"{kelas.className}(") && !line.Contains("return"))
                        {
                            Console.WriteLine("constuctor line : " + line);
                            int indexStart = line.IndexOf($"{kelas.className}(");
                            int indexStop = line.IndexOf(")") - indexStart + 1;
                            var methodName = line.Substring(indexStart, indexStop);
                            kelas.methods.Add(methodName);
                        }
                        else if (Regex.IsMatch(line, @" int ") && line != null)
                        {
                            if (line.Contains("("))
                            {
                                int indexStart = line.IndexOf("int ");
                                int indexStop = line.IndexOf(")") - indexStart + 1;
                                var methodName = line.Substring(indexStart, indexStop);
                                kelas.methods.Add(methodName);
                            }
                            else
                            {
                                string[] lineArr = line.Split(' ');
                                var variableName = "int " + lineArr[Array.FindIndex(lineArr, row => row.Contains("int")) + 1];
                                kelas.variables.Add(variableName);
                            }
                        }
                        else if (Regex.IsMatch(line, @" string ") && line != null)
                        {
                            if (line.Contains("("))
                            {
                                int indexStart = line.IndexOf("string ");
                                int indexStop = line.IndexOf(")") - indexStart + 1;
                                var methodName = line.Substring(indexStart, indexStop);
                                kelas.methods.Add(methodName);
                            }
                            else
                            {
                                string[] lineArr = line.Split(' ');
                                var variableName = "string " + lineArr[Array.FindIndex(lineArr, row => row.Contains("string")) + 1];
                                kelas.variables.Add(variableName);
                            }
                        }
                        else if (Regex.IsMatch(line, @" double ") && line != null)
                        {
                            if (line.Contains("("))
                            {
                                int indexStart = line.IndexOf("double ");
                                int indexStop = line.IndexOf(")") - indexStart + 1;
                                var methodName = line.Substring(indexStart, indexStop);
                                kelas.methods.Add(methodName);
                            }
                            else
                            {
                                string[] lineArr = line.Split(' ');
                                var variableName = "double " + lineArr[Array.FindIndex(lineArr, row => row.Contains("double")) + 1];
                                kelas.variables.Add(variableName);
                            }
                        }
                        else if (Regex.IsMatch(line, @" boolean ") && line != null)
                        {
                            if (line.Contains("("))
                            {
                                int indexStart = line.IndexOf("boolean ");
                                int indexStop = line.IndexOf(")") - indexStart + 1;
                                var methodName = line.Substring(indexStart, indexStop);
                                kelas.methods.Add(methodName);
                            }
                            else
                            {
                                string[] lineArr = line.Split(' ');
                                var variableName = "boolean " + lineArr[Array.FindIndex(lineArr, row => row.Contains("boolean")) + 1];
                                kelas.variables.Add(variableName);
                            }
                        }

                        else if (Regex.IsMatch(line, @" void ") && line != null)
                        {
                            int indexStart = line.IndexOf("void");
                            int indexStop = line.IndexOf(")") - indexStart + 1;
                            var methodName = line.Substring(indexStart, indexStop);
                            kelas.methods.Add(methodName);
                        }

                    }
                    ClassCollection.Add(kelas);
                }

                // other class add
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
                    Console.WriteLine(string.Format("variable list: ({0}).", string.Join(", ", item.variables)));
                    Console.WriteLine(string.Format("methods list: ({0}).", string.Join(", ", item.methods)));

                    if (item.superClass.Any())
                    {
                        foreach (var itemclass in ClassCollection)
                        {
                            if (item.superClass == itemclass.className)
                            {
                                item.target = itemclass.id;

                                foreach (var method in item.methods)
                                {
                                    foreach (var aMethod in itemclass.methods)
                                    {
                                        if (method == aMethod)
                                        {
                                            //Console.WriteLine("sama ges");
                                            //Console.WriteLine(method + " - " + aMethod);
                                            int i = item.methods.Select((element, index) => new { element, index }).FirstOrDefault(x => x.element.Equals(method))?.index ?? -1;
                                            int j = itemclass.methods.Select((element, index) => new { element, index }).FirstOrDefault(x => x.element.Equals(aMethod))?.index ?? -1;
                                            item.methodId.Add(i);
                                            item.methodTarget.Add(j);
                                        }
                                    }
                                }
                                item.methodId = item.methodId.Distinct().ToList();
                                item.methodTarget = item.methodTarget.Distinct().ToList();

                                foreach (var methodIndex in item.methodId)
                                {
                                    item.methodParameter.Add(item.methods[methodIndex]);
                                }
                            }

                            //var res = item.methods.Intersect(itemclass.);
                        }

                    }

                    Console.WriteLine(string.Format("methodsID list: ({0}).", string.Join(", ", item.methodId)));
                    Console.WriteLine(string.Format("methodsTarget list: ({0}).", string.Join(", ", item.methodTarget)));
                    Console.WriteLine(string.Format("methodsParameter list: ({0}).", string.Join(", ", item.methodParameter)));
                }

                /*ClassesData.DataSource = ClassCollection;
                dgv_sourceCode.DataSource = ClassCollection;*/
                foreach (var item in ClassCollection)
                {
                    if (!item.superClass.Any())
                    {
                        dgv_sourceCode.Rows.Add(item.className, string.Join(", ", item.variables), string.Join(", ", item.methods), "", item.id, item.target);
                    }
                    else
                    {
                        dgv_sourceCode.Rows.Add(item.className, string.Join(", ", item.variables), string.Join(", ", item.methods), item.superClass, item.id, item.target, string.Join(", ", item.methodId), string.Join(", ", item.methodTarget), string.Join(", ", item.methodParameter));
                    }

                }

                //write xml documents
                xmlDocuments.Add(@"<?xml version=""1.0"" encoding=""utf-8"" ?>");
                xmlDocuments.Add("<Graph>");
                xmlDocuments.Add("<Nodes>");
                foreach (var item in ClassCollection)
                {
                    xmlDocuments.Add($"<Node id=\"{item.id}\" name=\"{item.className}\" methods=\"{string.Join(", ", item.methods)}\" variables=\"{string.Join(", ", item.variables)}\"/>");
                }
                xmlDocuments.Add("</Nodes>");
                xmlDocuments.Add("<Links>");
                foreach (var item in ClassCollection)
                {
                    if (item.superClass.Any())
                    {
                        xmlDocuments.Add($"<Link origin=\"{item.id}\" target=\"{item.target}\" parameter=\"{string.Join(", ", item.methodParameter)}\" />");
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
                RectangleF bounds = new RectangleF(0, 0, 32, 48);

                XmlDocument document = new XmlDocument();
                document.Load(XMLFilePath);

                // Load node data
                XmlNodeList nodes = document.SelectNodes("/Graph/Nodes/Node");
                foreach (XmlElement node in nodes)
                {
                    ShapeNode diagramNode = diagram.Factory.CreateShapeNode(bounds);
                    nodeMap[node.GetAttribute("id")] = diagramNode;
                    if (node.GetAttribute("variables") == "")
                    {
                        diagramNode.Text = node.GetAttribute("name") + "\n\nmethods : " + node.GetAttribute("methods");
                    }
                    else
                    {
                        diagramNode.Text = node.GetAttribute("name") + "\n\nvariables : " + node.GetAttribute("variables") + "\n\nmethods : " + node.GetAttribute("methods");
                    }

                    // text align center
                    StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
                    format1.LineAlignment = StringAlignment.Near;
                    format1.Alignment = StringAlignment.Center;
                    diagramNode.TextFormat(format1);
                }

                // Load link data
                XmlNodeList links = document.SelectNodes("/Graph/Links/Link");
                foreach (XmlElement link in links)
                {
                    diagram.Factory.CreateDiagramLink(
                        nodeMap[link.GetAttribute("origin")],
                        nodeMap[link.GetAttribute("target")]);
                }

                foreach (XmlElement link in links)
                {
                    foreach (var nodeLink in diagram.Links)
                    {
                        if (nodeLink.Origin == nodeMap[link.GetAttribute("origin")] && nodeMap[link.GetAttribute("target")] == nodeLink.Destination)
                        {
                            //Console.WriteLine("sama");
                            nodeLink.Text = link.GetAttribute("parameter");
                        }
                    }
                }

                // Arrange the graph
                LayeredLayout layout = new LayeredLayout();
                layout.LayerDistance = 32;
                layout.NodeDistance = 48;
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
            classStrings.Clear();
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
                    classCollectionCSV.Add("Class Name,Variables,Methods,Super Class Name,Class ID,Class Target,Method ID,Method Target,Method Parameter");
                    foreach (var item in ClassCollection)
                    {
                        classCollectionCSV.Add($"{item.className},{string.Join("; ", item.variables)},{string.Join("; ", item.methods).Replace(',', '.')},{item.superClass},{item.id},{item.target},{string.Join("; ", item.methodId)},{string.Join("; ", item.methodTarget)},{string.Join("; ", item.methodParameter).Replace(',', '.')}");
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
