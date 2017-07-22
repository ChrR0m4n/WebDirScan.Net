namespace WebDirScan.Net
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.clbDicts = new System.Windows.Forms.CheckedListBox();
            this.lvResult = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProssBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lssLblSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.修改字典路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLblDctPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLblFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(47, 6);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(507, 21);
            this.txtUrl.TabIndex = 1;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(560, 4);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // clbDicts
            // 
            this.clbDicts.FormattingEnabled = true;
            this.clbDicts.HorizontalScrollbar = true;
            this.clbDicts.Location = new System.Drawing.Point(641, 4);
            this.clbDicts.Name = "clbDicts";
            this.clbDicts.Size = new System.Drawing.Size(169, 452);
            this.clbDicts.TabIndex = 3;
            // 
            // lvResult
            // 
            this.lvResult.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvResult.HotTracking = true;
            this.lvResult.HoverSelection = true;
            this.lvResult.Location = new System.Drawing.Point(12, 33);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(623, 423);
            this.lvResult.TabIndex = 4;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProssBar,
            this.lssLblSpeed,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel1,
            this.tssLblDctPath,
            this.tssLblFile});
            this.statusStrip1.Location = new System.Drawing.Point(0, 471);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(822, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProssBar
            // 
            this.tsProssBar.Name = "tsProssBar";
            this.tsProssBar.Size = new System.Drawing.Size(100, 16);
            // 
            // lssLblSpeed
            // 
            this.lssLblSpeed.Name = "lssLblSpeed";
            this.lssLblSpeed.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改字典路径ToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // 修改字典路径ToolStripMenuItem
            // 
            this.修改字典路径ToolStripMenuItem.Name = "修改字典路径ToolStripMenuItem";
            this.修改字典路径ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改字典路径ToolStripMenuItem.Text = "修改字典路径";
            this.修改字典路径ToolStripMenuItem.Click += new System.EventHandler(this.修改字典路径ToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "字典路径:";
            // 
            // tssLblDctPath
            // 
            this.tssLblDctPath.Name = "tssLblDctPath";
            this.tssLblDctPath.Size = new System.Drawing.Size(131, 17);
            this.tssLblDctPath.Text = "toolStripStatusLabel2";
            // 
            // tssLblFile
            // 
            this.tssLblFile.Name = "tssLblFile";
            this.tssLblFile.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 493);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvResult);
            this.Controls.Add(this.clbDicts);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "胖子御剑^_^";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.CheckedListBox clbDicts;
        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar tsProssBar;
        private System.Windows.Forms.ToolStripStatusLabel tssLblDctPath;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem 修改字典路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tssLblFile;
        private System.Windows.Forms.ToolStripStatusLabel lssLblSpeed;
    }
}

