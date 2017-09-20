namespace WebDirScan.Net
{
    partial class FormConfig
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nudHttpTimeout = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTasks = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudHttpTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "HTTP超时时间（毫秒）：";
            // 
            // nudHttpTimeout
            // 
            this.nudHttpTimeout.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudHttpTimeout.Location = new System.Drawing.Point(155, 7);
            this.nudHttpTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudHttpTimeout.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudHttpTimeout.Name = "nudHttpTimeout";
            this.nudHttpTimeout.Size = new System.Drawing.Size(51, 21);
            this.nudHttpTimeout.TabIndex = 1;
            this.nudHttpTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "并发数：";
            // 
            // nudTasks
            // 
            this.nudTasks.Location = new System.Drawing.Point(155, 37);
            this.nudTasks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTasks.Name = "nudTasks";
            this.nudTasks.Size = new System.Drawing.Size(51, 21);
            this.nudTasks.TabIndex = 3;
            this.nudTasks.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(74, 84);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 119);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.nudTasks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudHttpTimeout);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormConfig";
            this.Text = "配置";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHttpTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudHttpTimeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTasks;
        private System.Windows.Forms.Button btnOk;
    }
}