using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Lyh.Controls.WindowsForms.BigData;
using Lyh.Test.WindowsFormsApplication.ServiceReference;

namespace Lyh.Test.WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        public void DrawGrid(Graphics grap, RectangleF rect)
        {
            var greenPen = new Pen(Color.Green);

            var topLeftPoint = new PointF(rect.Left, rect.Top);
            var topCenterPoint = new PointF((rect.Left + rect.Right)/2, rect.Top);
            var topRightPoint = new PointF(rect.Right, rect.Top);
            var middleLeftPoint = new PointF(rect.Left, (rect.Top + rect.Bottom)/2);
            var middleRightPoint = new PointF(rect.Right, (rect.Top + rect.Bottom)/2);
            var bottomLeftPoint = new PointF(rect.Left, rect.Bottom);
            var bottomCenterPoint = new PointF((rect.Left + rect.Right)/2, rect.Bottom);
            var bottomRightPoint = new PointF(rect.Right, rect.Bottom);

            grap.DrawRectangle(greenPen, rect.X, rect.Y, rect.Width, rect.Height);
            greenPen.DashStyle = DashStyle.Dash;
            grap.DrawLine(greenPen, topLeftPoint, bottomRightPoint);
            grap.DrawLine(greenPen, topCenterPoint, bottomCenterPoint);
            grap.DrawLine(greenPen, topRightPoint, bottomLeftPoint);
            grap.DrawLine(greenPen, middleLeftPoint, middleRightPoint);
        }

        public void DrawStep(Graphics graphics, Font font, string word, int[] order)
        {
            var isClosed = false;
            var pen = new Pen(Color.Red);
            var brush = new SolidBrush(Color.Black);
            var path = new GraphicsPath();
            var subPath = new GraphicsPath();

            path.AddString(word, font.FontFamily, (int) font.Style, font.Size, new PointF(0, 0),
                StringFormat.GenericDefault);
            var iterator = new GraphicsPathIterator(path);
            var rect = path.GetBounds();
            graphics.PageUnit = font.Unit;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            DrawGrid(graphics, rect);
            graphics.DrawPath(pen, path);

            for (var i = 0; i < iterator.SubpathCount; i++)
            {
                Thread.Sleep(1000);
                iterator.Rewind();
                for (var j = 0; j < order[i]; j++)
                {
                    iterator.NextSubpath(subPath, out isClosed);
                }
                graphics.FillPath(brush, subPath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BeginInvoke(new Action(delegate { NewMethod(); }));
        }

        private void NewMethod()
        {
            var fontFamily = new FontFamily("楷体_GB2312");
            var font = new Font(fontFamily, 264, FontStyle.Regular);
            int[] order = { 1, 3, 2, 6, 4, 7, 5 };

            drawChar1.Character = "我";
            drawChar1.Order = order;
            drawChar1.CharFont = font;
            drawChar1.Draw();
        }

    }
}