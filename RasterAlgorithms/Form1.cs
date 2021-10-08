using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterAlgorithms
{
    enum FillingState
    {
        Default,
        Draw,
        SimpleFill,
        PictureFill,
        BorderFill
    }
    public partial class Form1 : Form
    {
        private Color _currentColor;
        private Pen _currentPen;
        private Pen _fillPen;
        private Bitmap _mainBmp;
        private Graphics _mainGraphics;
        private Point lastPoint = Point.Empty;
        private FillingState _fillingState;
        private OpenFileDialog _openFileDialog;
        private Bitmap _fillPicture;
        public Form1()
        {
            InitializeComponent();
            _currentPen = new Pen(Color.Black, 3);
            _fillPen = new Pen(Color.Black, 1);
            _mainBmp = new Bitmap(Width, Height);
            _openFileDialog = new OpenFileDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            _mainGraphics = Graphics.FromImage(_mainBmp);
            pictureBox1.Image = _mainBmp;
        }

        private void ColorChooseButton(object sender, EventArgs e)
        {
            _currentColor = (sender as Button).BackColor;
            _currentPen.Color = _currentColor;
            _fillPen.Color = _currentColor;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_fillingState)
            {
                case FillingState.SimpleFill:
                    AFill(e.Location);
                    return;
                case FillingState.PictureFill:
                    BFill(e.Location);
                    return;
                case FillingState.BorderFill:
                    CFill(e.Location);
                    return;
                case FillingState.Draw:
                    lastPoint = e.Location;
                    return;
                case FillingState.Default:
                    _fillingState = FillingState.Draw;
                    break;
            }
        }
        private Point nearPixel(int xsource, int ysource, int direction)
        {

            switch (direction)
            {
                case 0:
                    return new Point(xsource + 1, ysource);
                case 1:
                    return new Point(xsource + 1, ysource - 1);
                case 2:
                    return new Point(xsource, ysource - 1);
                case 3:
                    return new Point(xsource - 1, ysource - 1);
                case 4:
                    return new Point(xsource - 1, ysource);
                case 5:
                    return new Point(xsource - 1, ysource + 1);
                case 6:
                    return new Point(xsource, ysource + 1);
                case 7:
                    return new Point(xsource + 1, ysource + 1);
                default:
                    throw new Exception("wtf?");
            }
        }
        private List<Point> FindBorder(Bitmap image, int x, int y)
        {
            List<Point> points = new List<Point>();

            Color c = image.GetPixel(x, y + 1);
            var startPoint = new Point(x, y);
            int direction = 5;
            points.Add(startPoint);

            while (true)
            {
                Point point = new Point(-1, -1);
                for (int i = 0; i < 8; i++)
                {
                    point = nearPixel(x, y, ((direction - i) + 8) % 8);
                    if (image.GetPixel(point.X, point.Y) != c)
                    {
                        direction = (direction - i + 10) % 8;
                        points.Add(new Point(point.X, point.Y));
                        x = point.X;
                        y = point.Y;
                        break;
                    }
                }
                if (startPoint.X == point.X && startPoint.Y == point.Y && (direction - 5 + 8) % 8 < 4)
                    return points;
            }
        }

        private void CFill(Point location)
        {
            Color freeAreaColor = _mainBmp.GetPixel(location.X, location.Y);
            Bitmap tempBmp = new Bitmap(_mainBmp);
            Console.WriteLine("dfkfdkj");
            var startColor = tempBmp.GetPixel(location.X, location.Y);
            var nextPixelColor = tempBmp.GetPixel(location.X, location.Y);
            var nextY = location.Y;

            while (startColor == nextPixelColor)
            {
                --nextY;
                nextPixelColor = tempBmp.GetPixel(location.X, nextY);
            }
            List<Point> t = FindBorder(tempBmp, location.X, nextY);
            foreach (var point in t)
            {
                _mainBmp.SetPixel(point.X, point.Y, _currentColor);
            }
        }
        private void BFill(Point location)
        {
            Color freeAreaColor = _mainBmp.GetPixel(location.X, location.Y);
            Queue<(int X, int Y)> points = new Queue<(int X, int Y)>();
            points.Enqueue((location.X, location.Y));


            while (points.Count != 0)
            {
                var currPoint = points.Dequeue();
                if (currPoint.Y > pictureBox1.Height || currPoint.Y < 0
                    || _mainBmp.GetPixel(currPoint.X, currPoint.Y) != freeAreaColor)
                {
                    continue;
                }
                //right border finding            
                var rightBorder = currPoint;
                int xi = _fillPicture.Width / 2;
                
                for (; rightBorder.X < pictureBox1.Width; rightBorder.X += 1)
                {
                    Color getPix = _mainBmp.GetPixel(rightBorder.X, rightBorder.Y);
                    if (getPix != freeAreaColor)
                    {
                        break;
                    }
                    Color fillColor =
                        _fillPicture.GetPixel(Math.Abs(rightBorder.X - location.X + _fillPicture.Width / 2) % _fillPicture.Width, Math.Abs(currPoint.Y - location.Y + _fillPicture.Height / 2) % _fillPicture.Height);
                    _mainBmp.SetPixel(rightBorder.X, rightBorder.Y, fillColor);
                    points.Enqueue((rightBorder.X, rightBorder.Y + 1));
                    points.Enqueue((rightBorder.X, rightBorder.Y - 1));
                }
                int xli = _fillPicture.Width / 2;
                // left border 
                var leftBorder = currPoint;
                leftBorder.X -= 1;
                
                for (; leftBorder.X > 0; --leftBorder.X)
                {
                    Color getPix = _mainBmp.GetPixel(leftBorder.X, leftBorder.Y);

                    if (getPix != freeAreaColor)
                    {
                        break;
                    }
                    Color fillColor = _fillPicture.GetPixel(Math.Abs(leftBorder.X - location.X + _fillPicture.Width / 2) % _fillPicture.Width, Math.Abs(currPoint.Y - location.Y + _fillPicture.Height / 2) % _fillPicture.Height);
                    _mainBmp.SetPixel(leftBorder.X, leftBorder.Y, fillColor);
                    points.Enqueue((leftBorder.X, leftBorder.Y + 1));
                    points.Enqueue((leftBorder.X, leftBorder.Y - 1));
                    xli--;
                }
            }

        }
        private void AFill(Point location)
        {
            Color freeAreaColor = _mainBmp.GetPixel(location.X, location.Y);
            Queue<(int X, int Y)> points = new Queue<(int X, int Y)>();
            points.Enqueue((location.X, location.Y));


            while (points.Count != 0)
            {
                var currPoint = points.Dequeue();
                if (currPoint.Y > pictureBox1.Height || currPoint.Y < 0
                    || _mainBmp.GetPixel(currPoint.X, currPoint.Y) != freeAreaColor)
                {
                    continue;
                }
                //right border finding            
                var rightBorder = currPoint;
                for (; rightBorder.X < pictureBox1.Width; rightBorder.X += 1)
                {
                    Color getPix = _mainBmp.GetPixel(rightBorder.X, rightBorder.Y);
                    if (getPix != freeAreaColor)
                    {
                        break;
                    }
                    _mainBmp.SetPixel(rightBorder.X, rightBorder.Y, _currentColor);
                    points.Enqueue((rightBorder.X, rightBorder.Y + 1));
                    points.Enqueue((rightBorder.X, rightBorder.Y - 1));
                }

                // left border 
                var leftBorder = currPoint;
                leftBorder.X -= 1;

                for (; leftBorder.X > 0; --leftBorder.X)
                {
                    Color getPix = _mainBmp.GetPixel(leftBorder.X, leftBorder.Y);

                    if (getPix != freeAreaColor)
                    {
                        break;
                    }
                    _mainBmp.SetPixel(leftBorder.X, leftBorder.Y, _currentColor);
                    points.Enqueue((leftBorder.X, leftBorder.Y + 1));
                    points.Enqueue((leftBorder.X, leftBorder.Y - 1));
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_fillingState == FillingState.Draw)
            {
                _fillingState = FillingState.Default;
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_fillingState != FillingState.Draw)
            {
                lastPoint = e.Location;
                return;
            }
            if (!lastPoint.IsEmpty)
            {
                _mainGraphics.DrawLine(_currentPen, lastPoint, e.Location);
                _mainGraphics.SmoothingMode = SmoothingMode.AntiAlias;

            }
            lastPoint = e.Location;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            _fillingState = FillingState.SimpleFill;
        }

        private void FillPictureButton(object sender, EventArgs e)
        {
            _fillingState = FillingState.PictureFill;
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(_openFileDialog.FileName);

                    SetPicture(_openFileDialog.FileName);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void SetPicture(string fileName)
        {
            _fillPicture = new Bitmap(fileName);

        }

        private void DrawButton(object sender, EventArgs e)
        {
            _fillingState = FillingState.Default;
        }

        private void BorderFillButton(object sender, EventArgs e)
        {
            _fillingState = FillingState.BorderFill;
        }
    }
}
