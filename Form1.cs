using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Draws the smallest area triangle with vertexes from a set of given points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen redPen = new Pen(Color.Red, 2);
            Pen bluePen = new Pen(Color.Blue, 2);
            Random rnd = new Random();
            List<Point> pointsList = new List<Point> ();
            int pointsNr = rnd.Next(3, 20);
            int count = 0;
            while(count < pointsNr)
            {
                int x = rnd.Next(panel1.Width);
                int y = rnd.Next(panel1.Height);
                Point p = new Point(x, y);
                pointsList.Add(p);
                g.DrawEllipse(redPen, x, y, 2, 2);
                count++;
            }
            Point vertex1 = new Point(panel1.Width, panel1.Height);
            Point vertex2 = new Point(panel1.Width, panel1.Height);
            Point vertex3 = new Point(panel1.Width, panel1.Height);
          //  Point[] triangleVertexes = new Point[3];
            double smallestArea = panel1.Width * panel1.Height;
            for (int i = 0; i < pointsList.Count; i++)
            {
                for(int j = i; j < pointsList.Count; j++)
                {
                    for(int k = j; k < pointsList.Count; k++)
                    {
                        double currentArea = TriangleArea(pointsList[i], pointsList[j], pointsList[k]);
                        if (currentArea < smallestArea && currentArea != 0 )
                        {
                            smallestArea = currentArea;
                            vertex1 = pointsList[i];
                            vertex2 = pointsList[j];
                            vertex3 = pointsList[k];
                         
                        }
                    }
                }
               
            }
           // g.DrawLines(bluePen, triangleVertexes);
            g.DrawLine(bluePen, vertex1, vertex2);
            g.DrawLine(bluePen, vertex2, vertex3);
            g.DrawLine(bluePen, vertex3, vertex1);


        }
        /// <summary>
        /// Returns the area of the abc triangle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static double TriangleArea(Point a, Point b, Point c)
        {
            double area = 0.5 * Math.Abs(a.X * b.Y - b.X * a.Y + b.X * c.Y - c.X * b.Y +c.X * a.Y - a.X * c.Y );
            return area;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
