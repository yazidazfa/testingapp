namespace CollectionOfTestingApp
{
    partial class UserGroup3
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabControl tabControl;
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_sourceCode = new System.Windows.Forms.DataGridView();
            this.className = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variables = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.methods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.superClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.methodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.methodTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.methodParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtBox_sourceCode = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.diagramView1 = new MindFusion.Diagramming.WinForms.DiagramView();
            this.diagram = new MindFusion.Diagramming.Diagram();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExportDiagram = new System.Windows.Forms.Button();
            this.btnVisualize = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_csharp = new System.Windows.Forms.RadioButton();
            this.rb_java = new System.Windows.Forms.RadioButton();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.diagram1 = new MindFusion.Diagramming.Diagram();
            this.diagram2 = new MindFusion.Diagramming.Diagram();
            this.ClassesData = new System.Windows.Forms.BindingSource(this.components);
            tabControl = new System.Windows.Forms.TabControl();
            tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sourceCode)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClassesData)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(this.tabPage1);
            tabControl.Controls.Add(this.tabPage2);
            tabControl.Controls.Add(this.tabPage3);
            tabControl.Location = new System.Drawing.Point(0, 245);
            tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(1571, 806);
            tabControl.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_sourceCode);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1563, 777);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_sourceCode
            // 
            this.dgv_sourceCode.AllowUserToAddRows = false;
            this.dgv_sourceCode.AllowUserToDeleteRows = false;
            this.dgv_sourceCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_sourceCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_sourceCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sourceCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.className,
            this.variables,
            this.methods,
            this.superClass,
            this.Id,
            this.target,
            this.methodId,
            this.methodTarget,
            this.methodParameter});
            this.dgv_sourceCode.Location = new System.Drawing.Point(3, 2);
            this.dgv_sourceCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_sourceCode.Name = "dgv_sourceCode";
            this.dgv_sourceCode.ReadOnly = true;
            this.dgv_sourceCode.RowHeadersWidth = 51;
            this.dgv_sourceCode.RowTemplate.Height = 24;
            this.dgv_sourceCode.Size = new System.Drawing.Size(1557, 773);
            this.dgv_sourceCode.TabIndex = 5;
            // 
            // className
            // 
            this.className.DataPropertyName = "className";
            this.className.FillWeight = 115.0157F;
            this.className.HeaderText = "Class Name";
            this.className.MinimumWidth = 6;
            this.className.Name = "className";
            this.className.ReadOnly = true;
            // 
            // variables
            // 
            this.variables.FillWeight = 115.0157F;
            this.variables.HeaderText = "Variables";
            this.variables.MinimumWidth = 6;
            this.variables.Name = "variables";
            this.variables.ReadOnly = true;
            // 
            // methods
            // 
            this.methods.FillWeight = 115.0157F;
            this.methods.HeaderText = "Methods";
            this.methods.MinimumWidth = 6;
            this.methods.Name = "methods";
            this.methods.ReadOnly = true;
            // 
            // superClass
            // 
            this.superClass.DataPropertyName = "superClass";
            this.superClass.FillWeight = 115.0157F;
            this.superClass.HeaderText = "Super Class";
            this.superClass.MinimumWidth = 6;
            this.superClass.Name = "superClass";
            this.superClass.ReadOnly = true;
            this.superClass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.FillWeight = 49.20459F;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // target
            // 
            this.target.DataPropertyName = "target";
            this.target.FillWeight = 45.68527F;
            this.target.HeaderText = "target";
            this.target.MinimumWidth = 6;
            this.target.Name = "target";
            this.target.ReadOnly = true;
            // 
            // methodId
            // 
            this.methodId.FillWeight = 115.0157F;
            this.methodId.HeaderText = "Method Id";
            this.methodId.MinimumWidth = 6;
            this.methodId.Name = "methodId";
            this.methodId.ReadOnly = true;
            // 
            // methodTarget
            // 
            this.methodTarget.FillWeight = 115.0157F;
            this.methodTarget.HeaderText = "Method Target";
            this.methodTarget.MinimumWidth = 6;
            this.methodTarget.Name = "methodTarget";
            this.methodTarget.ReadOnly = true;
            // 
            // methodParameter
            // 
            this.methodParameter.FillWeight = 115.0157F;
            this.methodParameter.HeaderText = "Method Parameter";
            this.methodParameter.MinimumWidth = 6;
            this.methodParameter.Name = "methodParameter";
            this.methodParameter.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtBox_sourceCode);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1563, 777);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "SourceCode";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtBox_sourceCode
            // 
            this.txtBox_sourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBox_sourceCode.Location = new System.Drawing.Point(4, 4);
            this.txtBox_sourceCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBox_sourceCode.Name = "txtBox_sourceCode";
            this.txtBox_sourceCode.Size = new System.Drawing.Size(1555, 769);
            this.txtBox_sourceCode.TabIndex = 2;
            this.txtBox_sourceCode.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.diagramView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1563, 777);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Visualize";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // diagramView1
            // 
            this.diagramView1.Diagram = this.diagram;
            this.diagramView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagramView1.LicenseKey = null;
            this.diagramView1.Location = new System.Drawing.Point(3, 2);
            this.diagramView1.Margin = new System.Windows.Forms.Padding(4);
            this.diagramView1.Name = "diagramView1";
            this.diagramView1.Size = new System.Drawing.Size(1557, 773);
            this.diagramView1.TabIndex = 0;
            this.diagramView1.Text = "diagramView1";
            // 
            // diagram
            // 
            this.diagram.TouchThreshold = 0F;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lbl_Title);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(tabControl);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1777, 1051);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnExportDiagram);
            this.groupBox3.Controls.Add(this.btnVisualize);
            this.groupBox3.Location = new System.Drawing.Point(768, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(411, 68);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Visualize";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(267, 23);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 38);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExportDiagram
            // 
            this.btnExportDiagram.Location = new System.Drawing.Point(117, 23);
            this.btnExportDiagram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportDiagram.Name = "btnExportDiagram";
            this.btnExportDiagram.Size = new System.Drawing.Size(143, 38);
            this.btnExportDiagram.TabIndex = 5;
            this.btnExportDiagram.Text = "Export as PNG";
            this.btnExportDiagram.UseVisualStyleBackColor = true;
            this.btnExportDiagram.Click += new System.EventHandler(this.btnExportDiagram_Click);
            // 
            // btnVisualize
            // 
            this.btnVisualize.Location = new System.Drawing.Point(7, 23);
            this.btnVisualize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVisualize.Name = "btnVisualize";
            this.btnVisualize.Size = new System.Drawing.Size(105, 38);
            this.btnVisualize.TabIndex = 1;
            this.btnVisualize.Text = "Visualize";
            this.btnVisualize.UseVisualStyleBackColor = true;
            this.btnVisualize.Click += new System.EventHandler(this.btnVisualize_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_csharp);
            this.groupBox1.Controls.Add(this.rb_java);
            this.groupBox1.Location = new System.Drawing.Point(1212, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(352, 68);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Programming Languages";
            // 
            // rb_csharp
            // 
            this.rb_csharp.AutoSize = true;
            this.rb_csharp.Location = new System.Drawing.Point(111, 30);
            this.rb_csharp.Margin = new System.Windows.Forms.Padding(4);
            this.rb_csharp.Name = "rb_csharp";
            this.rb_csharp.Size = new System.Drawing.Size(44, 20);
            this.rb_csharp.TabIndex = 1;
            this.rb_csharp.Text = "C#";
            this.rb_csharp.UseVisualStyleBackColor = true;
            // 
            // rb_java
            // 
            this.rb_java.AutoSize = true;
            this.rb_java.Checked = true;
            this.rb_java.Location = new System.Drawing.Point(19, 30);
            this.rb_java.Margin = new System.Windows.Forms.Padding(4);
            this.rb_java.Name = "rb_java";
            this.rb_java.Size = new System.Drawing.Size(58, 20);
            this.rb_java.TabIndex = 0;
            this.rb_java.TabStop = true;
            this.rb_java.Text = "Java";
            this.rb_java.UseVisualStyleBackColor = true;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(12, 4);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(193, 25);
            this.lbl_Title.TabIndex = 8;
            this.lbl_Title.Text = "Code Visualization";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Location = new System.Drawing.Point(352, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(392, 68);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source Code";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(248, 23);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(131, 38);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(7, 23);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(105, 38);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse File";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(117, 23);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(124, 38);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export as csv";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // diagram1
            // 
            this.diagram1.TouchThreshold = 0F;
            // 
            // diagram2
            // 
            this.diagram2.TouchThreshold = 0F;
            // 
            // UserGroup3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserGroup3";
            this.Size = new System.Drawing.Size(1777, 1051);
            tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sourceCode)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClassesData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExportDiagram;
        private System.Windows.Forms.Button btnVisualize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_csharp;
        private System.Windows.Forms.RadioButton rb_java;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgv_sourceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn className;
        private System.Windows.Forms.DataGridViewTextBoxColumn variables;
        private System.Windows.Forms.DataGridViewTextBoxColumn methods;
        private System.Windows.Forms.DataGridViewTextBoxColumn superClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn target;
        private System.Windows.Forms.DataGridViewTextBoxColumn methodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn methodTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn methodParameter;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox txtBox_sourceCode;
        private System.Windows.Forms.TabPage tabPage3;
        private MindFusion.Diagramming.WinForms.DiagramView diagramView1;
        private MindFusion.Diagramming.Diagram diagram;
        private MindFusion.Diagramming.Diagram diagram1;
        private System.Windows.Forms.BindingSource ClassesData;
        private MindFusion.Diagramming.Diagram diagram2;
    }
}
