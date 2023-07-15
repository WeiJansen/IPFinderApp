namespace IPFinderApp
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.getButton = new System.Windows.Forms.Button();
            this.gatewayTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ipListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.myIPTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(363, 18);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(61, 39);
            this.getButton.TabIndex = 0;
            this.getButton.Text = "获取";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // gatewayTextBox
            // 
            this.gatewayTextBox.Location = new System.Drawing.Point(83, 13);
            this.gatewayTextBox.Name = "gatewayTextBox";
            this.gatewayTextBox.ReadOnly = true;
            this.gatewayTextBox.Size = new System.Drawing.Size(260, 21);
            this.gatewayTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "网关地址：";
            // 
            // ipListView
            // 
            this.ipListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ipListView.ContextMenuStrip = this.contextMenuStrip;
            this.ipListView.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ipListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ipListView.HideSelection = false;
            this.ipListView.Location = new System.Drawing.Point(14, 83);
            this.ipListView.Name = "ipListView";
            this.ipListView.Size = new System.Drawing.Size(410, 355);
            this.ipListView.TabIndex = 4;
            this.ipListView.UseCompatibleStateImageBehavior = false;
            this.ipListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "                              设备名称 - IP地址";
            this.columnHeader1.Width = 400;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "本机地址：";
            // 
            // myIPTextBox
            // 
            this.myIPTextBox.Location = new System.Drawing.Point(83, 40);
            this.myIPTextBox.Name = "myIPTextBox";
            this.myIPTextBox.ReadOnly = true;
            this.myIPTextBox.Size = new System.Drawing.Size(260, 21);
            this.myIPTextBox.TabIndex = 5;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(76, 26);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.ListViewToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.myIPTextBox);
            this.Controls.Add(this.ipListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gatewayTextBox);
            this.Controls.Add(this.getButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "省管207合同后端设备扫描_没有的对方可能开了防火墙";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.TextBox gatewayTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ipListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox myIPTextBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
    }
}

