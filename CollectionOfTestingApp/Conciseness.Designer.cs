
namespace CollectionOfTestingApp
{
    partial class Conciseness
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
            this.bt_export = new System.Windows.Forms.Button();
            this.bt_help = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bt_calculate = new System.Windows.Forms.Button();
            this.bt_upload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.howTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_export
            // 
            this.bt_export.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_export.Location = new System.Drawing.Point(714, 611);
            this.bt_export.Name = "bt_export";
            this.bt_export.Size = new System.Drawing.Size(153, 36);
            this.bt_export.TabIndex = 12;
            this.bt_export.Text = "Export to CSV";
            this.bt_export.UseVisualStyleBackColor = true;
            this.bt_export.Click += new System.EventHandler(this.bt_export_Click);
            // 
            // bt_help
            // 
            this.bt_help.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_help.Location = new System.Drawing.Point(914, 611);
            this.bt_help.Name = "bt_help";
            this.bt_help.Size = new System.Drawing.Size(153, 36);
            this.bt_help.TabIndex = 13;
            this.bt_help.Text = "Help";
            this.bt_help.UseVisualStyleBackColor = true;
            this.bt_help.Click += new System.EventHandler(this.bt_help_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(773, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 35);
            this.label4.TabIndex = 17;
            this.label4.Text = "Functions Name";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(714, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 371);
            this.panel1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "-";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 336);
            this.label2.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.label2.MinimumSize = new System.Drawing.Size(355, 250);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.Size = new System.Drawing.Size(541, 373);
            this.label2.TabIndex = 15;
            this.label2.Text = "Total Number of Function :\nTotal Number of Line of Code :\nTotal Number of Executa" +
    "ble Line of Code :\n\nConciseness (#Line of Code / Function) =\nConciseness  (#Exec" +
    "utable Line of Code / Function) =\n";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(132, 216);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(346, 36);
            this.textBox1.TabIndex = 14;
            // 
            // bt_calculate
            // 
            this.bt_calculate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_calculate.Location = new System.Drawing.Point(132, 269);
            this.bt_calculate.Name = "bt_calculate";
            this.bt_calculate.Size = new System.Drawing.Size(541, 40);
            this.bt_calculate.TabIndex = 11;
            this.bt_calculate.Text = "Calculate Conciseness";
            this.bt_calculate.UseVisualStyleBackColor = true;
            this.bt_calculate.Click += new System.EventHandler(this.bt_calculate_Click);
            // 
            // bt_upload
            // 
            this.bt_upload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_upload.Location = new System.Drawing.Point(520, 216);
            this.bt_upload.Name = "bt_upload";
            this.bt_upload.Size = new System.Drawing.Size(153, 36);
            this.bt_upload.TabIndex = 10;
            this.bt_upload.Text = "Upload File";
            this.bt_upload.UseVisualStyleBackColor = true;
            this.bt_upload.Click += new System.EventHandler(this.bt_upload_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 46);
            this.label1.TabIndex = 9;
            this.label1.Text = "Conciseness";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howTToolStripMenuItem,
            this.onlineNotesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 48);
            // 
            // howTToolStripMenuItem
            // 
            this.howTToolStripMenuItem.Name = "howTToolStripMenuItem";
            this.howTToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.howTToolStripMenuItem.Text = "How to Use Tool";
            this.howTToolStripMenuItem.Click += new System.EventHandler(this.howTToolStripMenuItem_Click);
            // 
            // onlineNotesToolStripMenuItem
            // 
            this.onlineNotesToolStripMenuItem.Name = "onlineNotesToolStripMenuItem";
            this.onlineNotesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.onlineNotesToolStripMenuItem.Text = "Online Notes";
            this.onlineNotesToolStripMenuItem.Click += new System.EventHandler(this.onlineNotesToolStripMenuItem_Click);
            // 
            // Conciseness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bt_export);
            this.Controls.Add(this.bt_help);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bt_calculate);
            this.Controls.Add(this.bt_upload);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(255, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Conciseness";
            this.Size = new System.Drawing.Size(1183, 854);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_export;
        private System.Windows.Forms.Button bt_help;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bt_calculate;
        private System.Windows.Forms.Button bt_upload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem howTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineNotesToolStripMenuItem;
    }
}
