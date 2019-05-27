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
    public partial class Form2 : Form
    {
        List<float> lst = new List<float>();
        float yinzi = 1; //映射因子
        string dataType;
        string fileName;
        int maxPoionts;
        int fileType = 0; //0二进制   1进制
        string waveType = "曲线";

        public Form2(float yinzi1,string dataType1,string fileName1,int maxPoints1,int fileType1,string waveType1)
        {
            this.yinzi = yinzi1;
            this.dataType= dataType1;
            this.fileName= fileName1;
            this.maxPoionts= maxPoints1;
            this.fileType = fileType1;
            this.waveType = waveType1;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = fileName;
            DoWork();
        }

        private void DoWork()
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
                    #region 文本
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
                                        tempLst.Add(this.yinzi*pValue);
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
                    #endregion
                    this.Invoke(new EventHandler(delegate
                    {
                        this.myChart1.SetMaxPoint(this.maxPoionts);
                        this.myChart1.SetWaveType(this.waveType);
                        this.myChart1.BindPoints(lst);
                    }));
                }
                catch { }
               

            });
            thread.IsBackground = true;
            thread.Start();

        }
    }
}
