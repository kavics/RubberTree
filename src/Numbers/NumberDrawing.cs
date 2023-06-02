using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class NumberDrawing
    {
        private Pen linepen;
        private Pen pen;
        private Font font;
        private SolidBrush brush;
        private SolidBrush brushBackGround;
        private StringFormat format;
        private Graphics _graphics;

        public Graphics Graph
        {
            get
            {
                return _graphics;
            }
            set
            {
                _graphics = value;
            }
        }

        public NumberDrawing(Graphics graphics)
        {
            //linepen = new Pen(Color.Black, 2);
            linepen = new Pen(Color.Black, 2);
            pen = new Pen(Color.Black);
            font = new Font("Arial", 8);
            brush = new SolidBrush(Color.Black);
            brushBackGround = new SolidBrush(Color.White);
            format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            _graphics = graphics;
        }


        public void DrawNumber(Number number, PointF origo, bool lines)
        {
            int x = Convert.ToInt32(number.X + origo.X);
            int y = Convert.ToInt32(number.Y + origo.Y);
            if (lines)
            {
                foreach (Number parent in number.Parents)
                {
                    int w = 1;
                    int targetx = Convert.ToInt32(parent.X + origo.X);
                    int targety = Convert.ToInt32(parent.Y + origo.Y);
                    _graphics.DrawLine(linepen, x, y, targetx, targety);
                    _graphics.DrawLine(linepen, x, y, targetx + w, targety + w);
                    _graphics.DrawLine(linepen, x, y, targetx + w, targety - w);
                    _graphics.DrawLine(linepen, x, y, targetx - w, targety + w);
                    _graphics.DrawLine(linepen, x, y, targetx - w, targety - w);
                }
                return;
            }
            string str = number.ToString();
            int L = str.Length;
            if (L == 1) L = 2;
            RectangleF rectEllipse = new RectangleF(x - 5 * L, y - 10, 10 * L, 20);
            RectangleF rectText = new RectangleF(rectEllipse.Left + 1, rectEllipse.Top + 4, rectEllipse.Width, 20);
            //-- lines
            //-- fill
            _graphics.FillEllipse(brushBackGround, rectEllipse);
            _graphics.DrawEllipse(pen, rectEllipse);
            _graphics.DrawString(str, font, brush, rectText, format);
        }

        public void DrawNumberCircle(NumberCollection circle, PointF origo)
        {
            foreach (Number number in circle)
            {
                DrawBranch(number, origo, true);
            }
            foreach (Number number in circle)
            {
                DrawBranch(number, origo, false);
            }
        }

        private void DrawBranch(Number number, PointF origo, bool lines)
        {
            DrawNumber(number, origo, lines);
            foreach (Number parent in number.Parents)
            {
                if (!parent.IsCircleMember)
                    DrawBranch(parent, origo, lines);
            }
        }
    }
}
