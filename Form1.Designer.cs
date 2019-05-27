namespace signal_waveform_tool
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_wave_type = new System.Windows.Forms.ComboBox();
            this.txt_chaoxian_count = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_wave_top = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_info = new System.Windows.Forms.Label();
            this.radioBtn_txt = new System.Windows.Forms.RadioButton();
            this.radioBtn_bin = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.myChart1 = new signal_waveform_tool.MyChart2();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1089, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Chose Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Point Type：";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "int16",
            "uint16",
            "int32",
            "uint32",
            "float"});
            this.comboBox1.Location = new System.Drawing.Point(135, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_wave_type);
            this.splitContainer1.Panel1.Controls.Add(this.txt_chaoxian_count);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txt_wave_top);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lb_info);
            this.splitContainer1.Panel1.Controls.Add(this.radioBtn_txt);
            this.splitContainer1.Panel1.Controls.Add(this.radioBtn_bin);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.myChart1);
            this.splitContainer1.Size = new System.Drawing.Size(1411, 642);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(872, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Wave Type：";
            // 
            // comboBox_wave_type
            // 
            this.comboBox_wave_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_wave_type.FormattingEnabled = true;
            this.comboBox_wave_type.Items.AddRange(new object[] {
            "Scatter",
            "Curve"});
            this.comboBox_wave_type.Location = new System.Drawing.Point(966, 6);
            this.comboBox_wave_type.Name = "comboBox_wave_type";
            this.comboBox_wave_type.Size = new System.Drawing.Size(101, 23);
            this.comboBox_wave_type.TabIndex = 17;
            // 
            // txt_chaoxian_count
            // 
            this.txt_chaoxian_count.Location = new System.Drawing.Point(442, 42);
            this.txt_chaoxian_count.Name = "txt_chaoxian_count";
            this.txt_chaoxian_count.Size = new System.Drawing.Size(80, 25);
            this.txt_chaoxian_count.TabIndex = 15;
            this.txt_chaoxian_count.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Threshold Number:";
            // 
            // txt_wave_top
            // 
            this.txt_wave_top.Location = new System.Drawing.Point(168, 42);
            this.txt_wave_top.Name = "txt_wave_top";
            this.txt_wave_top.Size = new System.Drawing.Size(100, 25);
            this.txt_wave_top.TabIndex = 13;
            this.txt_wave_top.Text = "5081";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Threshold of Peak：";
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Location = new System.Drawing.Point(548, 50);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(87, 15);
            this.lb_info.TabIndex = 11;
            this.lb_info.Text = "Peak Info:";
            // 
            // radioBtn_txt
            // 
            this.radioBtn_txt.AutoSize = true;
            this.radioBtn_txt.Location = new System.Drawing.Point(335, 11);
            this.radioBtn_txt.Name = "radioBtn_txt";
            this.radioBtn_txt.Size = new System.Drawing.Size(52, 19);
            this.radioBtn_txt.TabIndex = 10;
            this.radioBtn_txt.Text = "TXT";
            this.radioBtn_txt.UseVisualStyleBackColor = true;
            // 
            // radioBtn_bin
            // 
            this.radioBtn_bin.AutoSize = true;
            this.radioBtn_bin.Checked = true;
            this.radioBtn_bin.Location = new System.Drawing.Point(251, 11);
            this.radioBtn_bin.Name = "radioBtn_bin";
            this.radioBtn_bin.Size = new System.Drawing.Size(76, 19);
            this.radioBtn_bin.TabIndex = 9;
            this.radioBtn_bin.TabStop = true;
            this.radioBtn_bin.Text = "Binary";
            this.radioBtn_bin.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(502, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 25);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Coefficient:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(650, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max Number:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "5000",
            "10000",
            "20000",
            "40000",
            "50000",
            "100000",
            "200000",
            "300000",
            "400000",
            "500000"});
            this.comboBox2.Location = new System.Drawing.Point(747, 7);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(101, 23);
            this.comboBox2.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "所有文件|*.*";
            this.openFileDialog1.Multiselect = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(642, 37);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(757, 48);
            this.textBox2.TabIndex = 18;
            // 
            // myChart1
            // 
            this.myChart1.BackColor = System.Drawing.Color.White;
            this.myChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myChart1.Location = new System.Drawing.Point(0, 0);
            this.myChart1.Name = "myChart1";
            this.myChart1.Size = new System.Drawing.Size(1411, 550);
            this.myChart1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 642);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "signal_waveform_tool(coded by michal.hu)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyChart2 myChart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioBtn_txt;
        private System.Windows.Forms.RadioButton radioBtn_bin;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.TextBox txt_wave_top;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_chaoxian_count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_wave_type;
        private System.Windows.Forms.TextBox textBox2;
    }
}

