namespace CollectionOfTestingApp
{
    partial class UserGroup8
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.className = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occurance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fanIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fanOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fanInAverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fanOutAverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modularity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1577, 1051);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.className,
            this.occurance,
            this.fanIn,
            this.fanOut,
            this.fanInAverage,
            this.fanOutAverage,
            this.modularity});
            this.dataGridView1.Location = new System.Drawing.Point(157, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1404, 1051);
            this.dataGridView1.TabIndex = 7;
            // 
            // number
            // 
            this.number.FillWeight = 30.5F;
            this.number.HeaderText = "No.";
            this.number.MinimumWidth = 6;
            this.number.Name = "number";
            this.number.ReadOnly = true;
            // 
            // className
            // 
            this.className.FillWeight = 131.2366F;
            this.className.HeaderText = "Class / Object Name";
            this.className.MinimumWidth = 6;
            this.className.Name = "className";
            this.className.ReadOnly = true;
            // 
            // occurance
            // 
            this.occurance.FillWeight = 147.1076F;
            this.occurance.HeaderText = "Number of Object Occurance";
            this.occurance.MinimumWidth = 6;
            this.occurance.Name = "occurance";
            this.occurance.ReadOnly = true;
            // 
            // fanIn
            // 
            this.fanIn.FillWeight = 51.70429F;
            this.fanIn.HeaderText = "Fan In";
            this.fanIn.MinimumWidth = 6;
            this.fanIn.Name = "fanIn";
            this.fanIn.ReadOnly = true;
            // 
            // fanOut
            // 
            this.fanOut.FillWeight = 70.80624F;
            this.fanOut.HeaderText = "Fan Out";
            this.fanOut.MinimumWidth = 6;
            this.fanOut.Name = "fanOut";
            this.fanOut.ReadOnly = true;
            // 
            // fanInAverage
            // 
            this.fanInAverage.FillWeight = 103.6573F;
            this.fanInAverage.HeaderText = "Fan In Average";
            this.fanInAverage.MinimumWidth = 6;
            this.fanInAverage.Name = "fanInAverage";
            this.fanInAverage.ReadOnly = true;
            // 
            // fanOutAverage
            // 
            this.fanOutAverage.FillWeight = 102.3322F;
            this.fanOutAverage.HeaderText = "Fan Out Average";
            this.fanOutAverage.MinimumWidth = 6;
            this.fanOutAverage.Name = "fanOutAverage";
            this.fanOutAverage.ReadOnly = true;
            // 
            // modularity
            // 
            this.modularity.FillWeight = 75.03303F;
            this.modularity.HeaderText = "Modularity";
            this.modularity.MinimumWidth = 6;
            this.modularity.Name = "modularity";
            this.modularity.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFolder);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(157, 1051);
            this.panel2.TabIndex = 8;
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(12, 10);
            this.btnFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(132, 29);
            this.btnFolder.TabIndex = 1;
            this.btnFolder.Text = "Choose Folder";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 78);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(132, 29);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Generate to CSV";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(12, 43);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(132, 29);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // UserGroup8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserGroup8";
            this.Size = new System.Drawing.Size(1577, 1051);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn className;
        private System.Windows.Forms.DataGridViewTextBoxColumn occurance;
        private System.Windows.Forms.DataGridViewTextBoxColumn fanIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fanOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn fanInAverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn fanOutAverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn modularity;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnShow;
    }
}
