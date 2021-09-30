using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace GradientTriangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            string firstCoord = textBox1.Text;
            string secondCoord = textBox2.Text;
            string thirdCoord = textBox3.Text;
            Graphics graphic = pictureBox1.CreateGraphics();
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            graphic.Clear(Color.White);

            if (!String.IsNullOrEmpty(firstCoord) && !String.IsNullOrEmpty(secondCoord) && !String.IsNullOrEmpty(thirdCoord))
            {
                string[] coordArr1 = firstCoord.Split(';');
                Point firstPoint = new Point(Convert.ToInt32(coordArr1[0]), Convert.ToInt32(coordArr1[1]));

                string[] coordArr2 = secondCoord.Split(';');
                Point secondPoint = new Point(Convert.ToInt32(coordArr2[0]), Convert.ToInt32(coordArr2[1]));

                string[] coordArr3 = thirdCoord.Split(';');
                Point thirdPoint = new Point(Convert.ToInt32(coordArr3[0]), Convert.ToInt32(coordArr3[1]));

                Line line1 = new Line(firstPoint, secondPoint, chooseFirstColor.BackColor, chooseSecondColor.BackColor);
                Line line2 = new Line(firstPoint, thirdPoint, chooseFirstColor.BackColor, chooseThirdColor.BackColor);
                Line line3 = new Line(secondPoint, thirdPoint, chooseSecondColor.BackColor, chooseThirdColor.BackColor);

                Triangle triangle = new Triangle( line1, line2, line3);
                Bitmap bmp = new Bitmap(width, height, graphic);
                triangle.Draw(bmp);
                pictureBox1.Image = bmp;
            }
        }

        private void chooseFirstColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                chooseFirstColor.BackColor = MyDialog.Color;
            }
        }

        private void chooseSecondColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                chooseSecondColor.BackColor = MyDialog.Color;
            }
        }

        private void chooseThirdColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                chooseThirdColor.BackColor = MyDialog.Color;
            }
        }
    }
}
