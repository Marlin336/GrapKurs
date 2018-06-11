using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Point[] tr1 = new Point[3];
            tr1[0] = new Point(300, 50, 0);
            tr1[1] = new Point(350, 150, 0);
            tr1[2] = new Point(400, 50, 0);
            Triangle test1 = new Triangle(tr1, Color.Green);
            Point[] tr2 = new Point[3];
            tr2[0] = new Point(90, 90, 0);
            tr2[1] = new Point(160, 185, 0);
            tr2[2] = new Point(210, 100, 0);
            Triangle test2 = new Triangle(tr2, Color.Red);
            Rotate(ref test1, 0, 0, 188, new Point(test1.Points[0]));
            DrawTriangle(test1, scene.bmp, scene.zBuf, scene.fill);
            DrawCircle(new Point(200, 300, 0), 45, 14, scene.bmp, Color.Red, scene.zBuf, scene.fill);
            //DrawTriangle(test2, scene.bmp, scene.zBuf, scene.fill);
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
                        if (idx > 0 && idx < zbuffer.Length)
                        {
                            if (zbuffer[idx] <= P.z)
                            {
                                zbuffer[idx] = P.z;
                                bitmap.SetPixel((int)P.x, (int)P.y, color);
                            }
                        }
                    }
                }
            }
        }
        void DrawTriangle(Triangle triangle, Bitmap bitmap, float[] zbuffer, bool fill)
        {
            DrawTriangle(triangle.Points[0], triangle.Points[1], triangle.Points[2], bitmap, triangle.color, zbuffer, fill);
        }
        void DrawCircle(Point center, float radius, int polygon, Bitmap bitmap, Color color, float[] zbuffer, bool fill)
        {
            for (int i = 0; i < polygon; i++)
            {
                DrawTriangle(new Point(center), new Point((float)(center.x+radius*(Math.Cos(Math.PI*(i/(polygon/2.0))))), (float)(center.y + radius * (Math.Sin(Math.PI * (i/ (polygon / 2.0))))), center.z), new Point((float)(center.x + radius * (Math.Cos(Math.PI * ((i+1) / (polygon / 2.0))))), (float)(center.y + radius * (Math.Sin(Math.PI * ((i+1) / (polygon / 2.0))))), center.z), bitmap, color, zbuffer, fill);
            }
        }

        public void Scale(ref Triangle triangle, double x_scale, double y_scale, double z_scale)
        {
            Matrix TMtx = new Matrix(4);
            TMtx.Elems[0, 0] = x_scale;
            TMtx.Elems[1, 1] = y_scale;
            TMtx.Elems[2, 2] = z_scale;
            for (int i = 0; i < 3; i++)
            {
                Matrix PMtx = new Matrix(4, 1);
                PMtx.Elems[0, 0] = triangle.Points[i].x;
                PMtx.Elems[1, 0] = triangle.Points[i].y;
                PMtx.Elems[2, 0] = triangle.Points[i].z;
                PMtx.Elems[3, 0] = 1;
                Matrix res = new Matrix(TMtx.Rows, PMtx.Columns);
                res = TMtx * PMtx;
                triangle.Points[i].x = (int)res.Elems[0, 0] / (int)res.Elems[3, 0];
                triangle.Points[i].y = (int)res.Elems[1, 0] / (int)res.Elems[3, 0];
                triangle.Points[i].z = (int)res.Elems[2, 0] / (int)res.Elems[3, 0];
            }
        }
        public void Shift(ref Triangle triangle, double xy, double xz, double yx, double yz, double zx, double zy)
        {
            Matrix TMtx = new Matrix(4);
            TMtx.Elems[0, 1] = xy;
            TMtx.Elems[0, 2] = xz;
            TMtx.Elems[1, 0] = yx;
            TMtx.Elems[1, 2] = yz;
            TMtx.Elems[2, 0] = zx;
            TMtx.Elems[2, 1] = zy;
            for (int i = 0; i < 3; i++)
            {
                Matrix PMtx = new Matrix(4, 1);
                PMtx.Elems[0, 0] = triangle.Points[i].x;
                PMtx.Elems[1, 0] = triangle.Points[i].y;
                PMtx.Elems[2, 0] = triangle.Points[i].z;
                PMtx.Elems[3, 0] = 1;
                Matrix res = new Matrix(TMtx.Rows, PMtx.Columns);
                res = TMtx * PMtx;
                triangle.Points[i].x = (int)res.Elems[0, 0] / (int)res.Elems[3, 0];
                triangle.Points[i].y = (int)res.Elems[1, 0] / (int)res.Elems[3, 0];
                triangle.Points[i].z = (int)res.Elems[2, 0] / (int)res.Elems[3, 0];
            }
        }
        public void Transform(ref Triangle triangle, double x_scale, double y_scale, double z_scale, double xy, double xz, double yx, double yz, double zx, double zy)
        {
            Matrix TMtx = new Matrix(4);
            TMtx.Elems[0, 0] = x_scale;
            TMtx.Elems[1, 1] = y_scale;
            TMtx.Elems[2, 2] = z_scale;
            TMtx.Elems[0, 1] = xy;
            TMtx.Elems[0, 2] = xz;
            TMtx.Elems[1, 0] = yx;
            TMtx.Elems[1, 2] = yz;
            TMtx.Elems[2, 0] = zx;
            TMtx.Elems[2, 1] = zy;
            for (int i = 0; i < 3; i++)
            {
                Matrix PMtx = new Matrix(4, 1);
                PMtx.Elems[0, 0] = triangle.Points[i].x;
                PMtx.Elems[1, 0] = triangle.Points[i].y;
                PMtx.Elems[2, 0] = triangle.Points[i].z;
                PMtx.Elems[3, 0] = 1;
                Matrix res = new Matrix(TMtx.Rows, PMtx.Columns);
                res = TMtx * PMtx;
                triangle.Points[i].x = (int)res.Elems[0, 0] / (int)res.Elems[3, 0];
                triangle.Points[i].y = (int)res.Elems[1, 0] / (int)res.Elems[3, 0];
                triangle.Points[i].z = (int)res.Elems[2, 0] / (int)res.Elems[3, 0];
            }
        }

        public void Rotate(ref Triangle triangle, double x_angle, double y_angle, double z_angle, Point axis)
        { 
            double x = x_angle * (Math.PI / 180);//Градусы -> радианы
            double y = y_angle * (Math.PI / 180);
            double z = z_angle * (Math.PI / 180);
            Moving(ref triangle, -axis.x, -axis.y, -axis.z);
            Transform(ref triangle, 1, Math.Cos(x), Math.Cos(x), 0, 0, 0, -Math.Sin(x), 0, Math.Sin(x));
            Transform(ref triangle, Math.Cos(y), 1, Math.Cos(y), 0, Math.Sin(y), 0, 0, -Math.Sin(y), 0);
            Transform(ref triangle, Math.Cos(z), Math.Cos(z), 1, -Math.Sin(z), 0, Math.Sin(z), 0, 0, 0);
            Moving(ref triangle, axis.x, axis.y, axis.z);
        }
        public void Moving(ref Triangle triangle, float x_move, float y_move, float z_move)
        {
            Matrix MoveMtx = new Matrix(4);
            MoveMtx.Elems[0, 3] = x_move;
            MoveMtx.Elems[1, 3] = y_move;
            MoveMtx.Elems[2, 3] = z_move;
            for (int i = 0; i < 3; i++)
            {
                Matrix PointMtx = new Matrix(4, 1);
                PointMtx.Elems[0, 0] = triangle.Points[i].x;
                PointMtx.Elems[1, 0] = triangle.Points[i].y;
                PointMtx.Elems[2, 0] = triangle.Points[i].z;
                PointMtx.Elems[3, 0] = 1;
                Matrix res = new Matrix(MoveMtx.Rows, PointMtx.Columns);
                res = MoveMtx * PointMtx;
                triangle.Points[i].x = (int)res.Elems[0, 0] / (int)res.Elems[3, 0];
                triangle.Points[i].y = (int)res.Elems[1, 0] / (int)res.Elems[3, 0];
                triangle.Points[i].z = (int)res.Elems[2, 0] / (int)res.Elems[3, 0];
            }
        }

        private void DrawCircleBrez(int x0, int y0, int rad, Bitmap bitmap)//Алгоритм Брезенхэма
        {
            int x = 0;
            int y = rad;
            int del = 1 - 2 * rad;
            int err = 0;
            while (y >= 0)
            {
                bitmap.SetPixel(x0 + x, y0 + y, Color.Red);
                bitmap.SetPixel(x0 + x, y0 - y, Color.Red);
                bitmap.SetPixel(x0 - x, y0 + y, Color.Red);
                bitmap.SetPixel(x0 - x, y0 - y, Color.Red);
                err = 2 * (del + y) - 1;
                if ((del < 0) && (err <= 0))
                {
                    del += 2 * ++x + 1;
                    continue;
                }
                err = 2 * (del - x) - 1;
                if ((del > 0) && (err > 0))
                {
                    del += 1 - 2 * --y;
                    continue;
                }
                x++;
                del += 2 * (x - y);
                y--;
            }
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
