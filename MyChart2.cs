using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace signal_waveform_tool
{
    public partial class MyChart2 : UserControl
    {
        List<float> points = new List<float>(); //原始数据点
        List<MyPoint> points_sample = new List<MyPoint>(); //抽样数据点，也就是最终显示的点
        int max_points_sample = 2500; //为了提高绘制效率超过多少个点进行抽样 
        int sample_count_per;//每几点进行一个点的抽样 一般 ( points.count/max_points_sample +1)
        readonly int distance = 50; //X/Y轴距离边界的距离
        PointF y_up;
        PointF y_down;
        PointF y_avg; //平均线
        PointF x_right;
        float Y_yinzi;//Y轴刻度因子
        float X_yinzi; //X轴刻度因子
        float avg_value; //平均值

        int selectX1 = -1; //选择区域的起始坐标
        int selectY1 = -1;
        int selectX2 = -1; //选择区域的结束坐标
        int selectY2 = -1;
        bool isMouseDown = false; //是否鼠标按下
        bool isSelectOver = false; //是否选择完成

        Color p_color = Color.Blue; //数据点颜色
        readonly Color xy_color = Color.Black;//XY轴颜色
        readonly float xy_pen_width = 1f;//XY轴宽度
        readonly float point_pen_width = 1f;//数据点宽度
        readonly Color select_color = Color.Red;//选择颜色
        int offsetIndex = 0;   //放大偏移量
        PointF[] drawData = null; // 要画的点
        bool needInit = false; //是否需要重新初始化
        List<float> drawlist = null; //选择区域的点
        string waveType = "Curve";

        public MyChart2()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            InitializeComponent();
        }

        public void SetMaxPoint(int max)
        {
            this.max_points_sample = max;
        }

        public void SetWaveType(string wave)
        {
            this.waveType = wave;
        }

        public void BindPoints(List<float> list)
        {
            needInit = true;
            this.points = list;
            offsetIndex = 0;
            drawlist = null;
            this.selectX1 = -1;
            this.selectX2 = -1;
            this.Refresh();

        }

        private void MyChart_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (points.Count == 0) return;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;


                //初始化
                if (needInit || isSelectOver)
                {
                    Init();
                    needInit = false;
                    isSelectOver = false;

                }

                // 画点 当点大于10万时不画点，因为时间太长引起卡顿现象
                if (isMouseDown == false)
                {
                    //画XY轴
                    g.DrawLines(new Pen(xy_color, xy_pen_width), new List<PointF>() { new PointF() { X = y_up.X, Y = y_up.Y }, y_down, x_right }.ToArray());
                    //画刻度
                    DrawXYKedu(g);
                    if (points_sample.Count >= 2)
                    {
                        if (this.waveType == "Curve")
                        {
                            g.DrawCurve(new Pen(p_color, point_pen_width), drawData, 0);
                        }
                        else
                        {
                            Brush brush = new SolidBrush(p_color);
                            foreach (PointF point in drawData)
                            {
                                g.FillEllipse(brush, point.X - 1, point.Y - 1, 2, 2);
                            }
                        }
                       
                    }

                    if (points_sample.Count <= 200)
                    {
                        if(this.waveType == "Curve")
                        {
                            Brush brush = new SolidBrush(p_color);
                            foreach (PointF point in drawData)
                            {
                                g.FillEllipse(brush, point.X - 2, point.Y - 2, 4, 4);
                            }
                        }
                       
                    }

                }

                if (isMouseDown)
                {
                    if (this.selectX1 != -1 && this.selectX2 != -1 && this.selectY1 != -1 && this.selectY2 != -1)
                    {
                        g.DrawRectangle(new Pen(select_color, 1), new Rectangle(this.selectX1, this.selectY1, this.selectX2 - this.selectX1,
                            this.selectY2 - this.selectY1));
                    }
                }
            }
            catch (Exception ex)
            {
                isSelectOver = false;
                this.selectX1 = -1;
                this.selectX2 = -1;
                offsetIndex = 0;
            }

        }


        /// <summary>
        /// 初始化，计算好XY线段的起止点
        /// </summary>
        private void Init()
        {
            int w = this.Width;
            int h = this.Height;

            y_up = new PointF() { X = distance + 50, Y = distance };
            y_down = new PointF() { X = distance + 50, Y = h - distance };
            x_right = new PointF() { X = w - distance, Y = h - distance };
            y_avg = new PointF() { X = distance + 50, Y = (y_up.Y + y_down.Y) / 2 };
            //构造点
            if (isSelectOver == false) //非选择
            {
                if (drawlist == null)
                {
                    CreatePointSample(this.points);
                }
                else
                {
                    CreatePointSample(drawlist);
                }
            }
            else
            {
                //有选择区域，相当于进行缩放。先通过选择区域计算到数据点大概所在范围
                List<MyPoint> selectPoints = points_sample.FindAll(item => item.X >= this.selectX1 && item.X <= this.selectX2);
                //最获取大索引
                int firstIndex = offsetIndex + selectPoints.First().Index;
                int lastIndex = offsetIndex + selectPoints.Last().Index;
                drawlist = this.points.GetRange(firstIndex, lastIndex - firstIndex);
                CreatePointSample(drawlist);
                offsetIndex = firstIndex;
            }

        }

        /// <summary>
        /// 构建采集后的数据点
        /// </summary>
        /// <param name="lst"></param>
        private void CreatePointSample(List<float> lst)
        {
            sample_count_per = (lst.Count - 1) / max_points_sample + 1;
            points_sample.Clear();

            float maxY = lst.Max();
            float minY = lst.Min();
            float max_abs = Math.Abs(maxY) >= Math.Abs(minY) ? Math.Abs(maxY) : Math.Abs(minY);
            float areaY = 0;
            avg_value = (maxY + minY) / 2;
            if (minY >= 0)
            {
                areaY = maxY - minY + 1;
            }
            else if (maxY < 0)
            {
                areaY = maxY - minY + 1;
            }
            else
            {
                areaY = maxY + Math.Abs(minY);
            }

            Y_yinzi = (y_down.Y - y_up.Y - 40) / areaY; //Y轴刻度因子
            X_yinzi = (x_right.X - y_down.X - 40) / (lst.Count / sample_count_per + 1); //X轴刻度因子,正常抽样点加上第一个点
                                                                                        //第一个点需要画出来
            points_sample.Insert(0, new MyPoint() { Index = 0, X = y_down.X, Y = (y_avg.Y - (lst[0] - avg_value) * Y_yinzi), Value = lst[0] });
            List<MyPoint> maxPoints = new List<MyPoint>();
            Brush brush = new SolidBrush(p_color);
            for (int i = 1; i < lst.Count; i += sample_count_per)
            {

                int max_index = -1; //最大值索引
                float max = 0;
                //当前采样中找到一个最大点
                maxPoints.Clear();
                for (int j = i; j < i + sample_count_per; j++)
                {
                    if (j == lst.Count) break;

                    if (Math.Abs(lst[j]) >= max)
                    {
                        max_index = j;
                        max = Math.Abs(lst[j]);
                    }

                }
                if (max_index != -1)
                {
                    MyPoint myPoint = new MyPoint()
                    {
                        Index = max_index,
                        X = y_down.X + points_sample.Count * X_yinzi,
                        Y = y_avg.Y - (lst[max_index] - avg_value) * Y_yinzi,
                        Value = lst[max_index]
                    };

                    points_sample.Add(myPoint);
                }
            }

            drawData = new PointF[points_sample.Count];
            for (int i = 0; i < points_sample.Count; i++)
            {
                drawData[i] = new PointF() { X = points_sample[i].X, Y = points_sample[i].Y };
            }

            lb_total.Text = "total-" + points.Count + ",plan-" + lst.Count + ",current-" + drawData.Length + ",max=" + points_sample.Max(item => item.Value)
                + ",min=" + points_sample.Min(item => item.Value);
        }

        private void DrawXYKedu(Graphics g)
        {
            Pen pen = new Pen(xy_color, xy_pen_width);
            Font font = new Font("宋体", 8, FontStyle.Regular);
            Brush brush = new SolidBrush(xy_color);
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            //ZERO 上面
            float x1 = y_up.X - 2;
            float x2 = y_up.X + 2;
            float showValue = 0;
            string showString;
            for (float i = y_up.Y; i < this.y_down.Y; i += 40)
            {
                g.DrawLine(pen, new PointF() { X = x1, Y = i }, new PointF() { X = x2, Y = i });
                showValue = avg_value + (y_avg.Y - i) / Y_yinzi;
                if (showValue >= 0)
                {
                    showString = Math.Round(showValue, Math.Abs(showValue) > 1 ? 2 : 4).ToString();
                }
                else
                {
                    showString = Math.Round(Math.Abs(showValue), Math.Abs(showValue) > 1 ? 2 : 4).ToString() + "-";
                }
                g.DrawString(showString, font, brush, new PointF() { X = x1, Y = i }, sf);

                //最后一个点
                if ((i + 50) >= this.y_down.Y)
                {
                    showValue = avg_value + (y_avg.Y - this.y_down.Y) / Y_yinzi;
                    if (showValue >= 0)
                    {
                        showString = Math.Round(showValue, Math.Abs(showValue) > 1 ? 2 : 4).ToString();
                    }
                    else
                    {
                        showString = Math.Round(Math.Abs(showValue), Math.Abs(showValue) > 1 ? 2 : 4).ToString() + "-";
                    }
                    g.DrawString(showString, font, brush, new PointF() { X = x1, Y = this.y_down.Y }, sf);
                    break;
                }

            }

            //X轴
            sf = new StringFormat(StringFormatFlags.DirectionVertical);
            float y1 = y_down.Y - 2;
            float y2 = y_down.Y + 2;
            float x = y_down.X;

            int step = 1;
            step = points_sample.Count / 20;
            if (step == 0) step = 1;
            float curr_x = 0;
            for (int i = 0; i < points_sample.Count; i += step)
            {
                curr_x = points_sample[i].X;
                g.DrawLine(pen, new PointF() { X = curr_x, Y = y1 }, new PointF() { X = curr_x, Y = y2 });
                g.DrawString(i.ToString(), font, brush, new PointF() { X = curr_x, Y = y2 }, sf);
            }
        }

        private void MyChart_SizeChanged(object sender, EventArgs e)
        {
            needInit = true;
            this.Refresh();
        }

        private void MyChart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (points_sample.Count <= 50000)
                {
                    Bitmap bmp = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                    this.BackgroundImage = bmp;
                }

                isMouseDown = true;
                this.selectX1 = e.X;
                this.selectY1 = e.Y;
                this.selectX2 = -1;
                this.selectY2 = -1;
            }
        }

        private void MyChart_MouseMove(object sender, MouseEventArgs e)
        {
            int comp = 1;
            if (points_sample.Count <= 500)
            {
                comp = 2;
            }
            else if (points_sample.Count <= 200)
            {
                comp = 3;
            }

            MyPoint selectPoint = points_sample.Find(item => Math.Abs(item.X - e.X) <= comp && Math.Abs(item.Y - e.Y) <= comp);

            if (selectPoint != null)
            {
                lb_xy.Text = "x(og)=" + (this.offsetIndex + selectPoint.Index).ToString() +
                    ",x=" + points_sample.FindIndex(item => Math.Abs(item.X - e.X) <= comp && Math.Abs(item.Y - e.Y) <= comp)
                    + ",y=" + selectPoint.Value;
            }
            else
            {
                lb_xy.Text = "";
            }

            if (isMouseDown)
            {
                this.selectX2 = e.X;
                this.selectY2 = e.Y;
                this.Refresh();
            }
        }

        private void MyChart_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.BackgroundImage = null;
                if (isMouseDown)
                {

                    isMouseDown = false;

                    if (e.X != this.selectX1 && e.Y != this.selectY1)
                    {
                        isSelectOver = true;
                        this.selectX2 = e.X;
                        this.selectY2 = e.Y;
                        this.Refresh();
                    }

                }

            }
        }

        private void 复位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            needInit = true;
            isSelectOver = false;
            drawlist = null;
            this.selectX1 = -1;
            this.selectX2 = -1;
            offsetIndex = 0;
            this.Refresh();
        }

        private void MyChart_Load(object sender, EventArgs e)
        {

        }

        private void 保存图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.saveFileDialog1.ShowDialog()== DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                bmp.Save(this.saveFileDialog1.FileName);
                MessageBox.Show("Save Success!");
            }
        }

        private void 切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.waveType == "Curve")
            {
                this.waveType = "Scatter";
            }
            else
            {
                this.waveType = "Curve";
            }

            this.Refresh();
        }
    }

    class MyPoint
    {
        public int Index { get; set; }
        public float X
        {
            get; set;
        }
        public float Y { get; set; }

        public float Value { get; set; }
    }
}
