using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_2
{
    public partial class Form1 : Form
    {
        Point point;
        private Graphics g;
        bool Start = false;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
           
        }


        private void Bresenham(Pen pen, int x1, int y1, int x2, int y2)
        {

            var bmp = (pictureBox1.Image as Bitmap);
            double dx = Math.Abs(x2 - x1);
            double dy = Math.Abs(y2 - y1);
            double gradient = dy / dx; //угловой коэффициент
            int signX = Math.Sign(x2 - x1);
            int singY = Math.Sign(y2 - y1);
            
            int x = x1;
            int y = y1;

            if(gradient <= 1)
            {
                double d = 2 * dy - dx;
                while(x != x2 || y != y2)
                {
                    if(d < 0)
                    {
                        d += 2 * dy;
                    }
                    else 
                    {
                        y += singY;
                        d += 2 * (dy - dx);
                    }
                    x += signX;
                    bmp.SetPixel(x,y,pen.Color);
                    pictureBox1.Invalidate();
                }
            }
            if(gradient > 1)
            {
               double d = 2 * dx - dy;
                while(x != x2 || y != y2)
                {
                    if(d < 0)
                    {
                        d += 2 * dx;
                    }
                    else 
                    {
                        x += signX;
                        d += 2 * (dx - dy);
                    }
                    y += singY;
                    bmp.SetPixel(x, y, pen.Color);
                    pictureBox1.Invalidate();
                }
            }
        }

        private void DrawPoint(Graphics g, bool steep, int x, int y, double gradient)
        {
            gradient = 1 - gradient;
            g = pictureBox1.CreateGraphics();
            Bitmap bm = new Bitmap(1, 1);
            bm.SetPixel(0, 0, Color.FromArgb((int)(255 * gradient), (int)(255 * gradient), (int)(255 * gradient)));
            if (steep)
                g.DrawImageUnscaled(bm, y, x);
            else
                g.DrawImageUnscaled(bm, x, y);

        }

        private void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }


       private void Wu(Graphics g, Pen p, int x0, int y0, int x1, int y1)
       {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if(steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);                  
            }
            if(x0 > x1 )
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            DrawPoint(g, steep, x0, y0, 1);
            DrawPoint(g, steep, x1, y1, 1);
            float deltaX = x1 - x0;
            float deltaY = y1 - y0;
            float gradient = deltaY / deltaX;
            float y = y0 + gradient;
            for(var x = x0 + 1;x <= x1 - 1; x++)
            {
                DrawPoint(g, steep, x, (int)y, 1 - (y - (int)y));
                DrawPoint(g, steep, x, (int)y + 1, y - (int)y);     
                y += gradient;
            }
       }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Start)
            {
                  if (comboBox1.SelectedIndex == 0)
                  {
                      Bresenham(Pens.Black, point.X, point.Y, e.X, e.Y);
                  }
                  if(comboBox1.SelectedIndex == 1)
                  {
                      Wu(g,Pens.Black, point.X, point.Y, e.X, e.Y);
                  }
            }
            else
                point = e.Location;
                Start = !Start;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
    }
}
