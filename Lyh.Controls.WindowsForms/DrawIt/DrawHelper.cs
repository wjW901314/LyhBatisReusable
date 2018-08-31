using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lyh.Controls.WindowsForms.DrawIt
{
    public class DrawHelper
    {

        public static void DrawGrid(Graphics grap, RectangleF rect)
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

        public static void DrawStep(Graphics graphics, Font font, string word, int[] order)
        {
            var isClosed = false;
            var pen = new Pen(Color.Red);
            var brush = new SolidBrush(Color.Black);
            var subPath = new GraphicsPath();
            var path = GetPath(font, word);
            var rect = path.GetBounds();

            graphics.PageUnit = font.Unit;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            DrawGrid(graphics, rect);
            graphics.DrawPath(pen, path);

            var iterator = new GraphicsPathIterator(path);
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

        private static RectangleF GetRectangle(Font font, string word)
        {
            var path = GetPath(font, word);
            return path.GetBounds();
        }

        private static GraphicsPath GetPath(Font font, string word)
        {
            var path = new GraphicsPath();
            path.AddString(word, font.FontFamily, (int)font.Style, font.Size, new PointF(0, 0),
                StringFormat.GenericTypographic);
            return path;
        }
    }
}
