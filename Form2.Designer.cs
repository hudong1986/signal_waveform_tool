namespace signal_waveform_tool
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.myChart1 = new MyChart2();
            this.SuspendLayout();
            // 
            // myChart1
            // 
            this.myChart1.BackColor = System.Drawing.Color.White;
            this.myChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myChart1.Location = new System.Drawing.Point(0, 0);
            this.myChart1.Name = "myChart1";
            this.myChart1.Size = new System.Drawing.Size(1103, 625);
            this.myChart1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 625);
            this.Controls.Add(this.myChart1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MyChart2 myChart1;
    }
}