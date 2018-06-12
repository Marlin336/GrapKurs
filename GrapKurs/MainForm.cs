using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrapKurs
{
    public partial class MainForm : Form
    {
        WorkScene scene;
        public MainForm()
        {
            InitializeComponent();
            scene = new WorkScene(PBox.Width, PBox.Height);
            scene.zBuf = new float[scene.bmp.Height * scene.bmp.Width];
            for (int i = 0; i < scene.zBuf.Length; i++)
            {
                scene.zBuf[i] = float.MinValue;
            }
            Redraw();
        }

        void Redraw()
        {
            scene.bmp = new Bitmap(PBox.Width, PBox.Height);
            Point[] pa1 = new Point[3];
            pa1[0] = new Point(10, 50, 0);
            pa1[1] = new Point(60, 150, 0);
            pa1[2] = new Point(110, 50, 0);
            Triangle tr1 = new Triangle(pa1, Color.Green);
            Point[] pa2 = new Point[3];
            pa2[0] = new Point(30, 70, -10);
            pa2[1] = new Point(80, 170, -10);
            pa2[2] = new Point(130, 70, -10);
            Triangle tr2 = new Triangle(pa2, Color.Blue);
            //Rotate(ref test1, 0, 0, -45, new Point(test1.Points[0]));
            //Scale(ref test1, 1.5, 1, 1);
            DrawTriangle(tr2, scene.bmp, scene.zBuf, scene.fill);
            DrawTriangle(tr1, scene.bmp, scene.zBuf, scene.fill);
            Circle crcl1 = new Circle(new Point(200, 200, 0), 50, Color.Red);
            DrawCircle(crcl1, scene.bmp, scene.zBuf, scene.fill);
            scene.bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            PBox.Image = scene.bmp;
        }
 
        void Swap(ref float a, ref float b)
        {
            float swap = a;
            a = b;
            b = swap;
        }
        void Swap(ref Point a, ref Point b)
        {
            Point swap = a;
            a = b;
            b = swap;
        }

        void DrawLine(float x1, float y1, float x2, float y2, Bitmap bitmap, Color color)
        {
            bool steep = false;
            if (Math.Abs(x1 - x2) < Math.Abs(y1 - y2))
            {
                Swap(ref x1, ref y1);
                Swap(ref x2, ref y2);
                steep = true;
            }
            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }
            int dx = (int)(x2 - x1);
            int dy = (int)(y2 - y1);
            int derror2 = Math.Abs(dy) * 2;
            int error2 = 0;
            int y = (int)y1;
            for (int x = (int)x1; x <= x2; x++)
            {
                if (steep)
                {
                    try
                    {
                        bitmap.SetPixel(y, x, color);
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        bitmap.SetPixel(x, y, color);
                    }
                    catch { }
                }
                error2 += derror2;

                if (error2 > dx)
                {
                    y += (y2 > y1 ? 1 : -1);
                    error2 -= dx * 2;
                }
            }
        }
        void DrawTriangle(Point p1, Point p2, Point p3, Bitmap bitmap, Color color, float[] zbuffer, bool fill)
        {
            if (p1.y > p2.y) Swap(ref p1, ref p2);
            if (p1.y > p3.y) Swap(ref p1, ref p3);
            if (p2.y > p3.y) Swap(ref p2, ref p3);
            if(!fill)
            {
                DrawLine(p1.x, p1.y, p2.x, p2.y, bitmap, color);
                DrawLine(p2.x, p2.y, p3.x, p3.y, bitmap, color);
                DrawLine(p3.x, p3.y, p1.x, p1.y, bitmap, color);
            }
            else
            { 
            int total_height = (int)(p3.y - p1.y);
                for (int i = 0; i < total_height; i++)
                {
                    bool second_half = i > p2.y - p1.y || p2.y == p1.y;
                    int segment_height = second_half ? (int)(p3.y - p2.y) : (int)(p2.y - p1.y);
                    float alpha = (float)i / total_height;
                    float beta = (i - (second_half ? p2.y - p1.y : 0)) / segment_height; // be careful: with above conditions no division by zero here
                    Point A = p1 + (p3 - p1) * alpha;
                    Point B = second_half ? p2 + (p3 - p2) * beta : p1 + (p2 - p1) * beta;
                    if (A.x > B.x) Swap(ref A, ref B);
                    for (int j = (int)A.x; j <= B.x; j++) // attention, due to int casts t0.y+i != A.y
                    {
                        float phi = B.x == A.x ? 1 : (j - A.x) / (B.x - A.x);
                        Point P = new Point(A) + new Point(B - A) * phi;
                        P.x = j; P.y = p1.y + i;
                        int idx = (int)(P.x + P.y * bitmap.Width);
                        if (P.x > bitmap.Width || P.x < 0 || P.y > bitmap.Height || P.y < 0) continue;
                        if (zbuffer[idx] <= P.z)
                        {
                            zbuffer[idx] = P.z;
                            bitmap.SetPixel((int)P.x, (int)P.y, color);
                        }
                    }
                }
            }
        }
        void DrawTriangle(Triangle triangle, Bitmap bitmap, float[] zbuffer, bool fill)
        {
            DrawTriangle(triangle.Points[0], triangle.Points[1], triangle.Points[2], bitmap, triangle.color, zbuffer, fill);
        }
        void DrawCircle(Circle circle, Bitmap bitmap, float[] zbuffer, bool fill)
        {
            for (int i = 0; i < 20; i++)
                DrawTriangle(circle.polygons[i], bitmap, zbuffer, fill);
        }

        private void реалистичныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.fill = true;
            Redraw();
        }

        private void каркасныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.fill = false;
            Redraw();
        }
    }
}
