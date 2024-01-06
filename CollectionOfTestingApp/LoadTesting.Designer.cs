namespace CollectionOfTestingApp
{
    partial class LoadTesting
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
            this.lbl_LoadTesting = new System.Windows.Forms.Label();
            this.lblInputTimeOut = new System.Windows.Forms.Label();
            this.lblInputNumberOfRequest = new System.Windows.Forms.Label();
            this.textBoxInputUrl = new System.Windows.Forms.TextBox();
            this.lblInputUrl = new System.Windows.Forms.Label();
            this.start_Button = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.textBoxInputRequest = new System.Windows.Forms.TextBox();
            this.textBoxInputTimeout = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_LoadTesting
            // 
            this.lbl_LoadTesting.AutoSize = true;
            this.lbl_LoadTesting.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LoadTesting.Location = new System.Drawing.Point(586, 60);
            this.lbl_LoadTesting.Name = "lbl_LoadTesting";
            this.lbl_LoadTesting.Size = new System.Drawing.Size(496, 91);
            this.lbl_LoadTesting.TabIndex = 9;
            this.lbl_LoadTesting.Text = "Load Testing";
            // 
            // lblInputTimeOut
            // 
            this.lblInputTimeOut.AutoSize = true;
            this.lblInputTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputTimeOut.Location = new System.Drawing.Point(1088, 240);
            this.lblInputTimeOut.Name = "lblInputTimeOut";
            this.lblInputTimeOut.Size = new System.Drawing.Size(502, 46);
            this.lblInputTimeOut.TabIndex = 19;
            this.lblInputTimeOut.Text = "Input Timeout (in seconds):";
            // 
            // lblInputNumberOfRequest
            // 
            this.lblInputNumberOfRequest.AutoSize = true;
            this.lblInputNumberOfRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputNumberOfRequest.Location = new System.Drawing.Point(563, 240);
            this.lblInputNumberOfRequest.Name = "lblInputNumberOfRequest";
            this.lblInputNumberOfRequest.Size = new System.Drawing.Size(474, 46);
            this.lblInputNumberOfRequest.TabIndex = 17;
            this.lblInputNumberOfRequest.Text = "Input Number of Request:";
            // 
            // textBoxInputUrl
            // 
            this.textBoxInputUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInputUrl.Location = new System.Drawing.Point(45, 308);
            this.textBoxInputUrl.Name = "textBoxInputUrl";
            this.textBoxInputUrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInputUrl.Size = new System.Drawing.Size(500, 53);
            this.textBoxInputUrl.TabIndex = 1;
            // 
            // lblInputUrl
            // 
            this.lblInputUrl.AutoSize = true;
            this.lblInputUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputUrl.Location = new System.Drawing.Point(38, 240);
            this.lblInputUrl.Name = "lblInputUrl";
            this.lblInputUrl.Size = new System.Drawing.Size(209, 46);
            this.lblInputUrl.TabIndex = 14;
            this.lblInputUrl.Text = "Input URL:";
            // 
            // start_Button
            // 
            this.start_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_Button.Location = new System.Drawing.Point(722, 435);
            this.start_Button.Name = "start_Button";
            this.start_Button.Size = new System.Drawing.Size(188, 75);
            this.start_Button.TabIndex = 4;
            this.start_Button.Text = "Start";
            this.start_Button.UseVisualStyleBackColor = true;
            this.start_Button.Click += new System.EventHandler(this.startButton_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(38, 583);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(150, 46);
            this.lblOutput.TabIndex = 20;
            this.lblOutput.Text = "Output:";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(45, 649);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(1550, 373);
            this.outputTextBox.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(1408, 1115);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(188, 75);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(46, 1115);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(188, 75);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.Location = new System.Drawing.Point(486, 1115);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(188, 75);
            this.btnInfo.TabIndex = 7;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(965, 1115);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(188, 75);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBoxInputRequest
            // 
            this.textBoxInputRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInputRequest.Location = new System.Drawing.Point(571, 308);
            this.textBoxInputRequest.Name = "textBoxInputRequest";
            this.textBoxInputRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInputRequest.Size = new System.Drawing.Size(500, 53);
            this.textBoxInputRequest.TabIndex = 2;
            this.textBoxInputRequest.TextChanged += new System.EventHandler(this.textBoxInputRequest_TextChanged);
            // 
            // textBoxInputTimeout
            // 
            this.textBoxInputTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInputTimeout.Location = new System.Drawing.Point(1096, 308);
            this.textBoxInputTimeout.Name = "textBoxInputTimeout";
            this.textBoxInputTimeout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInputTimeout.Size = new System.Drawing.Size(500, 53);
            this.textBoxInputTimeout.TabIndex = 3;
            this.textBoxInputTimeout.TextChanged += new System.EventHandler(this.textBoxInputTimeout_TextChanged);
            // 
            // LoadTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxInputTimeout);
            this.Controls.Add(this.textBoxInputRequest);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblInputTimeOut);
            this.Controls.Add(this.lblInputNumberOfRequest);
            this.Controls.Add(this.textBoxInputUrl);
            this.Controls.Add(this.lblInputUrl);
            this.Controls.Add(this.start_Button);
            this.Controls.Add(this.lbl_LoadTesting);
            this.Location = new System.Drawing.Point(255, 0);
            this.Name = "LoadTesting";
            this.Size = new System.Drawing.Size(1647, 1206);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_LoadTesting;
        private System.Windows.Forms.Label lblInputTimeOut;
        private System.Windows.Forms.Label lblInputNumberOfRequest;
        private System.Windows.Forms.TextBox textBoxInputUrl;
        private System.Windows.Forms.Label lblInputUrl;
        private System.Windows.Forms.Button start_Button;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox textBoxInputRequest;
        private System.Windows.Forms.TextBox textBoxInputTimeout;
    }
}
