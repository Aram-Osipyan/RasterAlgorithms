using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradientTriangle
{
    public class Line
    {
        public Point First { get; set; }
        public Point Second { get; set; }

        public Color FirstColor { get; set; }
        public Color SecondColor { get; set; }

        public List<Tuple<Point, Color>> Points { get; set; }

        public Line(Point first, Point second, Color firstColor, Color secondColor)
        {
            First = first;
            Second = second;
            FirstColor = firstColor;
            SecondColor = secondColor;

            Points = new List<Tuple<Point, Color>>();
            FillPoints(First.X, First.Y, Second.X, Second.Y);
            Points = Points.OrderByDescending(p => p.Item1.Y).ToList();
        }

        public void Draw(Bitmap bitmap)
        {
            foreach (Tuple<Point, Color> p in Points)
            {
                bitmap.SetPixel(p.Item1.X, p.Item1.Y, p.Item2);
            }
        }

        void FillPoints(int x1, int y1, int x2, int y2)
        {
            Color firstColor = FirstColor;
            Color secondColor = SecondColor;
            if (x1 > x2)
            {
                int t = y1;
                y1 = y2;
                y2 = t;
                t = x1;
                x1 = x2;
                x2 = t;
                firstColor = SecondColor;
                secondColor = FirstColor;
            }
            int Rdiff = secondColor.R - firstColor.R;
            int Gdiff = secondColor.G - firstColor.G;
            int Bdiff = secondColor.B - firstColor.B;

            double doubleR = firstColor.R;
            double doubleG = firstColor.G;
            double doubleB = firstColor.B;

            int dx = x2 - x1;
            int dy = y2 - y1;
            int xi = x1;
            int yi = y1;
            int step = 1;
            int di = 2 * dy - dx;
            if (dx == 0 || Math.Abs(dy / (double)dx) > 1)
            {
                int rows = Math.Abs(y1 - y2);
                double stepR = (double)Rdiff / rows;
                double stepG = (double)Gdiff / rows;
                double stepB = (double)Bdiff / rows;
                if (dy / (double)dx < 0)
                {
                    xi = x2;
                    step = -1;
                    dy = -dy;
                    int t = y1;
                    y1 = y2;
                    y2 = t;

                    Rdiff = firstColor.R - secondColor.R;
                    Gdiff = firstColor.G - secondColor.G;
                    Bdiff = firstColor.B - secondColor.B;

                    doubleR = secondColor.R;
                    doubleG = secondColor.G;
                    doubleB = secondColor.B;

                    stepR = (double)Rdiff / rows;
                    stepG = (double)Gdiff / rows;
                    stepB = (double)Bdiff / rows;
                }

                for (yi = y1; yi <= y2; yi++)
                {
                    Color running = Color.FromArgb((int)doubleR, (int)doubleG, (int)doubleB);
                    Points.Add(new Tuple<Point, Color>(new Point(xi, yi), running));
                    if (di >= 0)
                    {
                        xi += step;
                        di += 2 * (dx - dy);
                    }
                    else
                    {
                        di += 2 * dx;
                    }
                    doubleR += stepR;
                    doubleG += stepG;
                    doubleB += stepB;
                }
            }
            else
            {
                int rows = Math.Abs(x1 - x2);
                double stepR = (double)Rdiff / rows;
                double stepG = (double)Gdiff / rows;
                double stepB = (double)Bdiff / rows;
                if (dy / (double)dx < 0)
                {
                    step = -1;
                    dy = -dy;
                }
                for (xi = x1; xi <= x2; xi++)
                {
                    Color running = Color.FromArgb((int)doubleR, (int)doubleG, (int)doubleB);
                    Points.Add(new Tuple<Point, Color>(new Point(xi, yi), running));
                    if (di >= 0)
                    {
                        yi += step;
                        di += 2 * (dy - dx);
                    }
                    else
                    {
                        di += 2 * dy;
                    }
                    doubleR += stepR;
                    doubleG += stepG;
                    doubleB += stepB;
                }
            }
        }
    }
}
