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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadTesting));
            this.lbl_LoadTesting = new System.Windows.Forms.Label();
            this.lblInputTimeOut = new System.Windows.Forms.Label();
            this.lblInputNumberOfRequest = new System.Windows.Forms.Label();
            this.textBoxInputUrl = new System.Windows.Forms.TextBox();
            this.lblInputUrl = new System.Windows.Forms.Label();
            this.start_Button = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.textBoxInputRequest = new System.Windows.Forms.TextBox();
            this.textBoxInputTimeout = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_LoadTesting
            // 
            this.lbl_LoadTesting.AutoSize = true;
            this.lbl_LoadTesting.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LoadTesting.Location = new System.Drawing.Point(391, 39);
            this.lbl_LoadTesting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LoadTesting.Name = "lbl_LoadTesting";
            this.lbl_LoadTesting.Size = new System.Drawing.Size(339, 63);
            this.lbl_LoadTesting.TabIndex = 9;
            this.lbl_LoadTesting.Text = "Load Testing";
            // 
            // lblInputTimeOut
            // 
            this.lblInputTimeOut.AutoSize = true;
            this.lblInputTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputTimeOut.Location = new System.Drawing.Point(725, 156);
            this.lblInputTimeOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInputTimeOut.Name = "lblInputTimeOut";
            this.lblInputTimeOut.Size = new System.Drawing.Size(343, 31);
            this.lblInputTimeOut.TabIndex = 19;
            this.lblInputTimeOut.Text = "Input Timeout (in seconds):";
            // 
            // lblInputNumberOfRequest
            // 
            this.lblInputNumberOfRequest.AutoSize = true;
            this.lblInputNumberOfRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputNumberOfRequest.Location = new System.Drawing.Point(375, 156);
            this.lblInputNumberOfRequest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInputNumberOfRequest.Name = "lblInputNumberOfRequest";
            this.lblInputNumberOfRequest.Size = new System.Drawing.Size(325, 31);
            this.lblInputNumberOfRequest.TabIndex = 17;
            this.lblInputNumberOfRequest.Text = "Input Number of Request:";
            // 
            // textBoxInputUrl
            // 
            this.textBoxInputUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInputUrl.Location = new System.Drawing.Point(30, 200);
            this.textBoxInputUrl.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxInputUrl.Name = "textBoxInputUrl";
            this.textBoxInputUrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInputUrl.Size = new System.Drawing.Size(335, 38);
            this.textBoxInputUrl.TabIndex = 1;
            // 
            // lblInputUrl
            // 
            this.lblInputUrl.AutoSize = true;
            this.lblInputUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputUrl.Location = new System.Drawing.Point(25, 156);
            this.lblInputUrl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInputUrl.Name = "lblInputUrl";
            this.lblInputUrl.Size = new System.Drawing.Size(145, 31);
            this.lblInputUrl.TabIndex = 14;
            this.lblInputUrl.Text = "Input URL:";
            // 
            // start_Button
            // 
            this.start_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_Button.Location = new System.Drawing.Point(481, 283);
            this.start_Button.Margin = new System.Windows.Forms.Padding(2);
            this.start_Button.Name = "start_Button";
            this.start_Button.Size = new System.Drawing.Size(125, 49);
            this.start_Button.TabIndex = 4;
            this.start_Button.Text = "Start";
            this.start_Button.UseVisualStyleBackColor = true;
            this.start_Button.Click += new System.EventHandler(this.startButton_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(25, 379);
            this.lblOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(104, 31);
            this.lblOutput.TabIndex = 20;
            this.lblOutput.Text = "Output:";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(30, 422);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(1035, 244);
            this.outputTextBox.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(648, 716);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(125, 49);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(323, 716);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 49);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBoxInputRequest
            // 
            this.textBoxInputRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInputRequest.Location = new System.Drawing.Point(381, 200);
            this.textBoxInputRequest.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxInputRequest.Name = "textBoxInputRequest";
            this.textBoxInputRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInputRequest.Size = new System.Drawing.Size(335, 38);
            this.textBoxInputRequest.TabIndex = 2;
            this.textBoxInputRequest.TextChanged += new System.EventHandler(this.textBoxInputRequest_TextChanged);
            // 
            // textBoxInputTimeout
            // 
            this.textBoxInputTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInputTimeout.Location = new System.Drawing.Point(731, 200);
            this.textBoxInputTimeout.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxInputTimeout.Name = "textBoxInputTimeout";
            this.textBoxInputTimeout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInputTimeout.Size = new System.Drawing.Size(335, 38);
            this.textBoxInputTimeout.TabIndex = 3;
            this.textBoxInputTimeout.TextChanged += new System.EventHandler(this.textBoxInputTimeout_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CollectionOfTestingApp.Properties.Resources.help_FILL0_wght400_GRAD0_opsz48;
            this.pictureBox1.InitialImage = global::CollectionOfTestingApp.Properties.Resources.help_FILL0_wght400_GRAD0_opsz48;
            this.pictureBox1.Location = new System.Drawing.Point(1048, 737);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 45);
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(999, 739);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 43);
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // LoadTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxInputTimeout);
            this.Controls.Add(this.textBoxInputRequest);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblInputTimeOut);
            this.Controls.Add(this.lblInputNumberOfRequest);
            this.Controls.Add(this.textBoxInputUrl);
            this.Controls.Add(this.lblInputUrl);
            this.Controls.Add(this.start_Button);
            this.Controls.Add(this.lbl_LoadTesting);
            this.Location = new System.Drawing.Point(255, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoadTesting";
            this.Size = new System.Drawing.Size(1098, 784);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox textBoxInputRequest;
        private System.Windows.Forms.TextBox textBoxInputTimeout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
