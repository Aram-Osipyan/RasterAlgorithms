using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradientTriangle
{
    public class Triangle
    {
        public Line First { get; set; }
        public Line Second { get; set; }
        public Line Third { get; set; }

        public List<Line> Lines { get; set; }

        public Triangle(Line first, Line second, Line third)
        {
            First = first;
            Second = second;
            Third = third;
            Lines = new List<Line>();
            Lines.Add(first);
            Lines.Add(second);
            Lines.Add(third);
            Lines = Lines.OrderByDescending(l => l.First.Y).ThenByDescending(l => l.Second.Y).ToList();
        }

        public void Draw(Bitmap bitmap)
        {
            Point start = Lines[0].Points[0].Item1;
            Point finish = Lines[1].Points[0].Item1;
            Point third = Lines[2].Points[0].Item1;
            int i = 0;
            int j = 0;

            while (start != Lines[0].Points[Lines[0].Points.Count - 1].Item1)
            {
                var currStart = Lines[0].Points[i];
                while(start.Y == currStart.Item1.Y && i < Lines[0].Points.Count() - 1)
                {
                    ++i;
                    currStart = Lines[0].Points[i];
                }
                if (i == Lines[0].Points.Count() - 1)
                    break;
                var currFinish = Lines[1].Points[j];
                while (finish.Y == currFinish.Item1.Y && j < Lines[1].Points.Count() - 1)
                {
                    ++j;
                    currFinish = Lines[1].Points[j];
                }

                start = currStart.Item1;
                finish = currFinish.Item1;
                Lines.Add(new Line(start, finish, currStart.Item2, currFinish.Item2));
            }

            i = 0;
            start = third;
            while (start != Lines[2].Points[Lines[2].Points.Count - 1].Item1)
            {
                var currStart = Lines[2].Points[i];
                var currFinish = Lines[1].Points[j];
                

                start = currStart.Item1;
                finish = currFinish.Item1;
                Lines.Add(new Line(start, finish, currStart.Item2, currFinish.Item2));

                while (start.Y == currStart.Item1.Y && i < Lines[2].Points.Count() - 1)
                {
                    ++i;
                    currStart = Lines[2].Points[i];
                }
                if (i == Lines[0].Points.Count() - 1)
                    break;
                while (finish.Y == currFinish.Item1.Y && j < Lines[1].Points.Count() - 1)
                {
                    ++j;
                    currFinish = Lines[1].Points[j];
                }
            }

            foreach (Line line in Lines)
            {
                line.Draw(bitmap);
            }
        }
    }
}
