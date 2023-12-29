
namespace CollectionOfTestingApp
{
    partial class HalsteadCalculator
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
            this.userGuide = new System.Windows.Forms.Button();
            this.showCode = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.operandsPath = new System.Windows.Forms.RichTextBox();
            this.analyzeResult = new System.Windows.Forms.RichTextBox();
            this.operatorsPath = new System.Windows.Forms.RichTextBox();
            this.srcBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.filePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // userGuide
            // 
            this.userGuide.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.userGuide.Cursor = System.Windows.Forms.Cursors.Help;
            this.userGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userGuide.Font = new System.Drawing.Font("Matura MT Script Capitals", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userGuide.Location = new System.Drawing.Point(966, 78);
            this.userGuide.Margin = new System.Windows.Forms.Padding(2);
            this.userGuide.Name = "userGuide";
            this.userGuide.Size = new System.Drawing.Size(80, 80);
            this.userGuide.TabIndex = 22;
            this.userGuide.Text = "?";
            this.userGuide.UseVisualStyleBackColor = false;
            // 
            // showCode
            // 
            this.showCode.BackColor = System.Drawing.Color.Chartreuse;
            this.showCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showCode.Location = new System.Drawing.Point(731, 277);
            this.showCode.Margin = new System.Windows.Forms.Padding(2);
            this.showCode.Name = "showCode";
            this.showCode.Size = new System.Drawing.Size(153, 36);
            this.showCode.TabIndex = 21;
            this.showCode.Text = "Show Code";
            this.showCode.UseVisualStyleBackColor = false;
            this.showCode.Click += new System.EventHandler(this.showCode_Click);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Chartreuse;
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(310, 277);
            this.startBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(153, 36);
            this.startBtn.TabIndex = 20;
            this.startBtn.Text = "Start Analyze";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // operandsPath
            // 
            this.operandsPath.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.operandsPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.operandsPath.Location = new System.Drawing.Point(261, 534);
            this.operandsPath.Margin = new System.Windows.Forms.Padding(2);
            this.operandsPath.Name = "operandsPath";
            this.operandsPath.Size = new System.Drawing.Size(321, 199);
            this.operandsPath.TabIndex = 19;
            this.operandsPath.Text = "";
            // 
            // analyzeResult
            // 
            this.analyzeResult.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.analyzeResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.analyzeResult.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyzeResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.analyzeResult.Location = new System.Drawing.Point(608, 332);
            this.analyzeResult.Margin = new System.Windows.Forms.Padding(2);
            this.analyzeResult.Name = "analyzeResult";
            this.analyzeResult.Size = new System.Drawing.Size(323, 401);
            this.analyzeResult.TabIndex = 18;
            this.analyzeResult.Text = "";
            // 
            // operatorsPath
            // 
            this.operatorsPath.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.operatorsPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.operatorsPath.Location = new System.Drawing.Point(261, 332);
            this.operatorsPath.Margin = new System.Windows.Forms.Padding(2);
            this.operatorsPath.Name = "operatorsPath";
            this.operatorsPath.Size = new System.Drawing.Size(321, 183);
            this.operatorsPath.TabIndex = 17;
            this.operatorsPath.Text = "";
            // 
            // srcBtn
            // 
            this.srcBtn.BackColor = System.Drawing.Color.Gray;
            this.srcBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srcBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.srcBtn.Location = new System.Drawing.Point(787, 208);
            this.srcBtn.Margin = new System.Windows.Forms.Padding(2);
            this.srcBtn.Name = "srcBtn";
            this.srcBtn.Size = new System.Drawing.Size(109, 35);
            this.srcBtn.TabIndex = 16;
            this.srcBtn.Text = "Browse..";
            this.srcBtn.UseVisualStyleBackColor = false;
            this.srcBtn.Click += new System.EventHandler(this.srcBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(255, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "Input file:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Geometr706 BlkCn BT", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(433, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(336, 48);
            this.label1.TabIndex = 14;
            this.label1.Text = "Halstead Calculator";
            // 
            // filePath
            // 
            this.filePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePath.Location = new System.Drawing.Point(411, 203);
            this.filePath.Margin = new System.Windows.Forms.Padding(2);
            this.filePath.Multiline = true;
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(491, 45);
            this.filePath.TabIndex = 13;
            // 
            // HalsteadCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userGuide);
            this.Controls.Add(this.showCode);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.operandsPath);
            this.Controls.Add(this.analyzeResult);
            this.Controls.Add(this.operatorsPath);
            this.Controls.Add(this.srcBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePath);
            this.Location = new System.Drawing.Point(255, 0);
            this.Name = "HalsteadCalculator";
            this.Size = new System.Drawing.Size(1183, 854);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button userGuide;
        private System.Windows.Forms.Button showCode;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.RichTextBox operandsPath;
        private System.Windows.Forms.RichTextBox analyzeResult;
        private System.Windows.Forms.RichTextBox operatorsPath;
        private System.Windows.Forms.Button srcBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filePath;
    }
}
