namespace CollectionOfTestingApp
{
    partial class Instrumentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instrumentation));
            this.exportCsv = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.totInstrument = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.totalItem = new System.Windows.Forms.TextBox();
            this.labell = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.totIns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textSourceCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersentase = new System.Windows.Forms.TextBox();
            this.btnCountInstrument = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lb_Instrumentation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // exportCsv
            // 
            this.exportCsv.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exportCsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportCsv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exportCsv.Location = new System.Drawing.Point(988, 711);
            this.exportCsv.Margin = new System.Windows.Forms.Padding(2);
            this.exportCsv.Name = "exportCsv";
            this.exportCsv.Size = new System.Drawing.Size(124, 42);
            this.exportCsv.TabIndex = 32;
            this.exportCsv.Text = "Export CSV";
            this.exportCsv.UseVisualStyleBackColor = false;
            this.exportCsv.Click += new System.EventHandler(this.exportCsv_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(207, 219);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 26);
            this.label2.TabIndex = 30;
            this.label2.Text = "Source Code";
            // 
            // totInstrument
            // 
            this.totInstrument.BackColor = System.Drawing.SystemColors.ControlLight;
            this.totInstrument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totInstrument.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totInstrument.Location = new System.Drawing.Point(899, 519);
            this.totInstrument.Margin = new System.Windows.Forms.Padding(2);
            this.totInstrument.Multiline = true;
            this.totInstrument.Name = "totInstrument";
            this.totInstrument.Size = new System.Drawing.Size(214, 40);
            this.totInstrument.TabIndex = 29;
            this.totInstrument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(663, 526);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 26);
            this.label1.TabIndex = 28;
            this.label1.Text = "Number of Instruments ";
            // 
            // totalItem
            // 
            this.totalItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.totalItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalItem.Location = new System.Drawing.Point(899, 582);
            this.totalItem.Margin = new System.Windows.Forms.Padding(2);
            this.totalItem.Multiline = true;
            this.totalItem.Name = "totalItem";
            this.totalItem.Size = new System.Drawing.Size(214, 42);
            this.totalItem.TabIndex = 27;
            this.totalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labell
            // 
            this.labell.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labell.Location = new System.Drawing.Point(550, 587);
            this.labell.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labell.Name = "labell";
            this.labell.Size = new System.Drawing.Size(390, 53);
            this.labell.TabIndex = 26;
            this.labell.Text = "Total Items should be Instrumented ";
            // 
            // dataGridView
            // 
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.totIns,
            this.total});
            this.dataGridView.Location = new System.Drawing.Point(563, 266);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(549, 196);
            this.dataGridView.TabIndex = 25;
            // 
            // totIns
            // 
            this.totIns.FillWeight = 200F;
            this.totIns.HeaderText = "Result";
            this.totIns.MinimumWidth = 12;
            this.totIns.Name = "totIns";
            this.totIns.Width = 400;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 8;
            this.total.Name = "total";
            this.total.Width = 265;
            // 
            // textSourceCode
            // 
            this.textSourceCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSourceCode.Location = new System.Drawing.Point(45, 266);
            this.textSourceCode.Margin = new System.Windows.Forms.Padding(2);
            this.textSourceCode.Multiline = true;
            this.textSourceCode.Name = "textSourceCode";
            this.textSourceCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textSourceCode.Size = new System.Drawing.Size(487, 514);
            this.textSourceCode.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(682, 652);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 26);
            this.label3.TabIndex = 23;
            this.label3.Text = "Percentage ";
            // 
            // txtPersentase
            // 
            this.txtPersentase.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtPersentase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPersentase.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersentase.Location = new System.Drawing.Point(820, 643);
            this.txtPersentase.Margin = new System.Windows.Forms.Padding(2);
            this.txtPersentase.Multiline = true;
            this.txtPersentase.Name = "txtPersentase";
            this.txtPersentase.Size = new System.Drawing.Size(293, 43);
            this.txtPersentase.TabIndex = 22;
            this.txtPersentase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCountInstrument
            // 
            this.btnCountInstrument.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCountInstrument.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCountInstrument.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCountInstrument.Location = new System.Drawing.Point(858, 144);
            this.btnCountInstrument.Margin = new System.Windows.Forms.Padding(2);
            this.btnCountInstrument.Name = "btnCountInstrument";
            this.btnCountInstrument.Size = new System.Drawing.Size(120, 42);
            this.btnCountInstrument.TabIndex = 21;
            this.btnCountInstrument.Text = "Check";
            this.btnCountInstrument.UseVisualStyleBackColor = false;
            this.btnCountInstrument.Click += new System.EventHandler(this.btnCountInstrument_Click);
            // 
            // txtPath
            // 
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(199, 149);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(629, 31);
            this.txtPath.TabIndex = 20;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrowse.Location = new System.Drawing.Point(45, 144);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(122, 42);
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Text = "Browse File";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lb_Instrumentation
            // 
            this.lb_Instrumentation.AutoSize = true;
            this.lb_Instrumentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Instrumentation.Location = new System.Drawing.Point(441, 49);
            this.lb_Instrumentation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Instrumentation.Name = "lb_Instrumentation";
            this.lb_Instrumentation.Size = new System.Drawing.Size(320, 51);
            this.lb_Instrumentation.TabIndex = 33;
            this.lb_Instrumentation.Text = "Instrumentation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(783, 219);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 26);
            this.label4.TabIndex = 34;
            this.label4.Text = "Result";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CollectionOfTestingApp.Properties.Resources.help_FILL0_wght400_GRAD0_opsz48;
            this.pictureBox1.InitialImage = global::CollectionOfTestingApp.Properties.Resources.help_FILL0_wght400_GRAD0_opsz48;
            this.pictureBox1.Location = new System.Drawing.Point(1106, 807);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 45);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(1057, 809);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 45);
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Instrumentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_Instrumentation);
            this.Controls.Add(this.exportCsv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totInstrument);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalItem);
            this.Controls.Add(this.labell);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.textSourceCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPersentase);
            this.Controls.Add(this.btnCountInstrument);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.Location = new System.Drawing.Point(255, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Instrumentation";
            this.Size = new System.Drawing.Size(1156, 854);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exportCsv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totInstrument;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox totalItem;
        private System.Windows.Forms.Label labell;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textSourceCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersentase;
        private System.Windows.Forms.Button btnCountInstrument;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lb_Instrumentation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn totIns;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
