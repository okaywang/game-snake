namespace 贪吃蛇
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新游戏toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.简单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.慢ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.一般ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.快ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于贪吃蛇ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(21, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 319);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新游戏ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(400, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新游戏ToolStripMenuItem
            // 
            this.新游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新游戏toolStripMenuItem1,
            this.简单ToolStripMenuItem,
            this.toolStripSeparator1,
            this.慢ToolStripMenuItem1,
            this.一般ToolStripMenuItem,
            this.快ToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出ToolStripMenuItem});
            this.新游戏ToolStripMenuItem.Name = "新游戏ToolStripMenuItem";
            this.新游戏ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.新游戏ToolStripMenuItem.Text = "&游戏";
            // 
            // 新游戏toolStripMenuItem1
            // 
            this.新游戏toolStripMenuItem1.Name = "新游戏toolStripMenuItem1";
            this.新游戏toolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.新游戏toolStripMenuItem1.Text = "&新游戏";
            this.新游戏toolStripMenuItem1.Click += new System.EventHandler(this.新游戏toolStripMenuItem1_Click);
            // 
            // 简单ToolStripMenuItem
            // 
            this.简单ToolStripMenuItem.Name = "简单ToolStripMenuItem";
            this.简单ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.简单ToolStripMenuItem.Text = "&速度";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // 慢ToolStripMenuItem1
            // 
            this.慢ToolStripMenuItem1.Checked = true;
            this.慢ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.慢ToolStripMenuItem1.Name = "慢ToolStripMenuItem1";
            this.慢ToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.慢ToolStripMenuItem1.Text = "慢";
            this.慢ToolStripMenuItem1.Click += new System.EventHandler(this.慢ToolStripMenuItem1_Click);
            // 
            // 一般ToolStripMenuItem
            // 
            this.一般ToolStripMenuItem.Name = "一般ToolStripMenuItem";
            this.一般ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.一般ToolStripMenuItem.Text = "一般";
            this.一般ToolStripMenuItem.Click += new System.EventHandler(this.一般ToolStripMenuItem_Click);
            // 
            // 快ToolStripMenuItem
            // 
            this.快ToolStripMenuItem.Name = "快ToolStripMenuItem";
            this.快ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.快ToolStripMenuItem.Text = "快";
            this.快ToolStripMenuItem.Click += new System.EventHandler(this.快ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(109, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出ToolStripMenuItem.Text = "&退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于贪吃蛇ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "关于";
            // 
            // 关于贪吃蛇ToolStripMenuItem
            // 
            this.关于贪吃蛇ToolStripMenuItem.Name = "关于贪吃蛇ToolStripMenuItem";
            this.关于贪吃蛇ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关于贪吃蛇ToolStripMenuItem.Text = "&关于贪吃蛇";
            this.关于贪吃蛇ToolStripMenuItem.Click += new System.EventHandler(this.关于贪吃蛇ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("华文隶书", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(69, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 111);
            this.label1.TabIndex = 3;
            this.label1.Text = "Welcome!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 391);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(350, 10);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "贪吃蛇";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 简单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 新游戏toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 慢ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 一般ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 快ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于贪吃蛇ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

