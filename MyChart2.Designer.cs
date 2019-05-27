namespace signal_waveform_tool
{
    partial class MyChart2
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复位ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_total = new System.Windows.Forms.Label();
            this.lb_xy = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复位ToolStripMenuItem,
            this.保存图片ToolStripMenuItem,
            this.切换ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 76);
            // 
            // 复位ToolStripMenuItem
            // 
            this.复位ToolStripMenuItem.Name = "复位ToolStripMenuItem";
            this.复位ToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.复位ToolStripMenuItem.Text = "reset";
            this.复位ToolStripMenuItem.Click += new System.EventHandler(this.复位ToolStripMenuItem_Click);
            // 
            // 保存图片ToolStripMenuItem
            // 
            this.保存图片ToolStripMenuItem.Name = "保存图片ToolStripMenuItem";
            this.保存图片ToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.保存图片ToolStripMenuItem.Text = "save to picture";
            this.保存图片ToolStripMenuItem.Click += new System.EventHandler(this.保存图片ToolStripMenuItem_Click);
            // 
            // 切换ToolStripMenuItem
            // 
            this.切换ToolStripMenuItem.Name = "切换ToolStripMenuItem";
            this.切换ToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.切换ToolStripMenuItem.Text = "switch";
            this.切换ToolStripMenuItem.Click += new System.EventHandler(this.切换ToolStripMenuItem_Click);
            // 
            // lb_total
            // 
            this.lb_total.AutoSize = true;
            this.lb_total.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_total.ForeColor = System.Drawing.Color.Black;
            this.lb_total.Location = new System.Drawing.Point(830, 0);
            this.lb_total.Name = "lb_total";
            this.lb_total.Size = new System.Drawing.Size(55, 15);
            this.lb_total.TabIndex = 1;
            this.lb_total.Text = "total-";
            // 
            // lb_xy
            // 
            this.lb_xy.AutoSize = true;
            this.lb_xy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_xy.Location = new System.Drawing.Point(0, 488);
            this.lb_xy.Name = "lb_xy";
            this.lb_xy.Size = new System.Drawing.Size(31, 15);
            this.lb_xy.TabIndex = 2;
            this.lb_xy.Text = "x,y";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "bmp|*.bmp|jpg|*.jpg";
            // 
            // MyChart2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lb_xy);
            this.Controls.Add(this.lb_total);
            this.Name = "MyChart2";
            this.Size = new System.Drawing.Size(885, 503);
            this.Load += new System.EventHandler(this.MyChart_Load);
            this.SizeChanged += new System.EventHandler(this.MyChart_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyChart_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyChart_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyChart_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MyChart_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复位ToolStripMenuItem;
        private System.Windows.Forms.Label lb_total;
        private System.Windows.Forms.Label lb_xy;
        private System.Windows.Forms.ToolStripMenuItem 保存图片ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 切换ToolStripMenuItem;
    }
}
