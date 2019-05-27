using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace signal_waveform_tool
{
    public partial class Form1 : Form
    {
        string titile = "signal_waveform_tool(coded by michal.hu)";
        float yinzi = 1; //映射因子
        string dataType;
        int maxPoints = 2000;
        int fileType = 0; //0二进制   1进制
        float yuzhi = 5081; //阈值
        float minContinueCount = 100;//最小连续超限点数量

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 2;
            comboBox_wave_type.SelectedIndex = 0;
            //设置允许拖放属性
            this.AllowDrop = true;  
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                yinzi = float.Parse(textBox1.Text.Trim());
                string[] fileNames = this.openFileDialog1.FileNames;
                button1.Text = "Handle...";
                button1.Enabled = false;
                maxPoints = int.Parse(comboBox2.Text);
                dataType = comboBox1.Text;
                fileType = radioBtn_bin.Checked ? 0 : 1;
                yuzhi = float.Parse(txt_wave_top.Text);
                minContinueCount = int.Parse(txt_chaoxian_count.Text);
                if (fileNames.Length == 1)
                {
                    this.Text = titile + " " + fileNames[0];
                    DoWork(fileNames[0], dataType);
                }
                else
                {
                    foreach (string file in fileNames)
                    {
                        new Form2(this.yinzi, this.dataType, file, this.maxPoints, this.fileType,this.comboBox_wave_type.Text).Show();
                    }

                    button1.Text = "Chose Files";
                    button1.Enabled = true;
                }
            }

        }


        private void DoWork(string fileName, string dataType)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    List<float> lst = new List<float>();
                    #region 二进制
                    if (fileType == 0)
                    {
                        byte[] bytes = null;
                        using (FileStream stream = new FileStream(fileName, FileMode.Open))
                        {
                            if (dataType == "uint16")
                            {
                                bytes = new byte[2];
                            }
                            else if (dataType == "int16")
                            {
                                bytes = new byte[2];
                            }
                            else if (dataType == "uint32")
                            {
                                bytes = new byte[4];
                            }
                            else if (dataType == "int32")
                            {
                                bytes = new byte[4];
                            }
                            else if (dataType == "float")
                            {
                                bytes = new byte[4];
                            }

                            while (stream.Read(bytes, 0, bytes.Length) != 0)
                            {
                                if (dataType == "uint16")
                                {
                                    lst.Add((float)(yinzi * BitConverter.ToUInt16(bytes, 0)));
                                }
                                else if (dataType == "int16")
                                {
                                    lst.Add((float)(yinzi * BitConverter.ToInt16(bytes, 0)));
                                }
                                else if (dataType == "uint32")
                                {
                                    lst.Add((float)(yinzi * BitConverter.ToUInt32(bytes, 0)));
                                }
                                else if (dataType == "int32")
                                {
                                    lst.Add((float)(yinzi * BitConverter.ToInt32(bytes, 0)));
                                }
                                else if (dataType == "float")
                                {
                                    lst.Add((float)(yinzi * BitConverter.ToSingle(bytes, 0)));
                                }
                            }
                        }
                    }
                    #endregion
                    else
                    {
                        using (StreamReader sr = new StreamReader(fileName))
                        {
                            string str = null;
                            string[] strs;
                            bool isvalid;
                            float pValue;
                            List<float> tempLst = new List<float>();
                            while ((str = sr.ReadLine()) != null)
                            {
                                strs = str.Split(new char[] { ',', ' ', '\t', '|' }, StringSplitOptions.RemoveEmptyEntries);
                                isvalid = true;
                                pValue = 0;
                                tempLst.Clear();
                                foreach (string item in strs)
                                {
                                    if (float.TryParse(item, out pValue))
                                    {
                                        tempLst.Add(yinzi * pValue);
                                    }
                                    else
                                    {
                                        isvalid = false;
                                        break;
                                    }
                                }

                                if (isvalid == false)
                                    continue;

                                lst.AddRange(tempLst);
                            }
                        }
                    }


                    this.Invoke(new EventHandler(delegate
                    {
                        this.myChart1.SetMaxPoint(this.maxPoints);
                        this.myChart1.SetWaveType(this.comboBox_wave_type.Text);
                        this.myChart1.BindPoints(lst);
                    }));

                    FindTopPoint(lst);
                }
                catch { }
                finally
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        button1.Text = "Chose Files";
                        button1.Enabled = true;
                    }
                    ));
                }

            });
            thread.IsBackground = true;
            thread.Start();

        }


        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] rs = (string[])e.Data.GetData(DataFormats.FileDrop);
                MessageBox.Show(rs[0]);
            }

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            //只允许文件拖放
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


     
      
        //找出波峰的点
        private void FindTopPoint(List<float> list)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    List<TopPint> tops = new List<TopPint>();
                    TopPint max = new TopPint();
                    int tongji_times = 0;
                    bool isUpCheck = false; //大于阈值部分是否检查OK
                    float item = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        item = list[i];
                        if (item > yuzhi)
                        {
                            if (item > max.Vlaue)
                            {
                                max.Index = i;
                                max.Vlaue = item;
                            }

                            if (isUpCheck == false)
                            {
                                tongji_times++;
                                if (tongji_times >= minContinueCount)
                                {
                                    isUpCheck = true;//开启去统计小于阈值的部分了
                                    tongji_times = 0;
                                }
                            }
                            else
                            {
                                tongji_times = 0;
                            }

                        }
                        else if (item < yuzhi)
                        {
                            if (isUpCheck == false) //还上大于阈值时遇到不连续大于值时重新开始
                            {
                                tongji_times = 0;
                            }
                            else
                            {
                                tongji_times++;
                                if (tongji_times >= minContinueCount) //小于部分也达到统计要求了
                                {
                                    //已成功找一个峰点
                                    tops.Add(max);
                                    isUpCheck = false;
                                    tongji_times = 0;
                                    max = new TopPint();
                                }
                            }
                        }
                    }

                    this.Invoke(new EventHandler(delegate
                    {
                        StringBuilder sb = new StringBuilder();
                        int i = 0;
                        foreach(TopPint top1 in tops)
                        {
                            sb.AppendFormat("[{0},{1}]", top1.Index, top1.Vlaue);
                            if (++i > 100)
                            {
                                sb.AppendFormat("[...,...]");
                                break;
                            }
                        }

                        textBox2.Text = "Peak：count-" + tops.Count +  " "+sb.ToString();
                    }));
                }
                catch { }
            });
            thread.IsBackground = true;
            thread.Start();


        }
    }

    class TopPint
    {
        public int Index { get; set; }
        public float Vlaue { get; set; }
    }
}
