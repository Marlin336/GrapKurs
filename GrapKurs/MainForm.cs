﻿using System;
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
        public MainForm()
        {
            InitializeComponent();
            WorkScene scene = new WorkScene(PBox.Width, PBox.Height);
            scene.zBuf = new int[scene.bmp.Height * scene.bmp.Width];
            for (int i = 0; i < scene.zBuf.Length; i++)
            {
                scene.zBuf[i] = int.MinValue;
            }
            Point[] tr1 = new Point[3];
            tr1[0] = new Point(275, 0, 0);
            tr1[1] = new Point(325, 100, 30);
            tr1[2] = new Point(375, 0, 0);
            Triangle test = new Triangle(tr1, Color.Black);
            Round(ref test, 135, new Point(test.Points[1]));
            //Moving(ref triangle1, 100, 50);
            DrawTriangle(test, scene.bmp, scene.zBuf);
            scene.bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            PBox.Image = scene.bmp; 
        }
 
        void Swap(ref int a, ref int b)
        {
            int swap = a;
            a = b;
            b = swap;
        }
        void Swap(ref Point a, ref Point b)
        {
            Point swap = a;
            a = b;
            b = swap;
        }

        void DrawLine(int x1, int y1, int x2, int y2, Bitmap bitmap, Color color)//Улучшеный алг. Брезенхэма
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
            int dx = x2 - x1;
            int dy = y2 - y1;
            int derror2 = Math.Abs(dy) * 2;
            int error2 = 0;
            int y = y1;
            for (int x = x1; x <= x2; x++)
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
        void DrawTriangle(Point p1, Point p2, Point p3, Bitmap bitmap, Color color, int[] zbuffer)
        {
            if (p1.y > p2.y) Swap(ref p1, ref p2);
            if (p1.y > p3.y) Swap(ref p1, ref p3);
            if (p2.y > p3.y) Swap(ref p2, ref p3);
            int total_height = p3.y - p1.y;
            for (int i = 0; i < total_height; i++)
            {
                bool second_half = i > p2.y - p1.y || p2.y == p1.y;
                int segment_height = second_half ? p3.y - p2.y : p2.y - p1.y;
                float alpha = (float)i / total_height;
                float beta = (float)(i - (second_half ? p2.y - p1.y : 0)) / segment_height; // be careful: with above conditions no division by zero here
                Point A = p1 + (p3 - p1) * alpha;
                Point B = second_half ? p2 + (p3 - p2) * beta : p1 + (p2 - p1) * beta;
                if (A.x > B.x) Swap(ref A, ref B);
                for (int j = A.x; j <= B.x; j++) // attention, due to int casts t0.y+i != A.y
                {
                    //bitmap.SetPixel(j, p1.y + i, color);
                    float phi = B.x == A.x ? 1 : (j - A.x) / (B.x - A.x);
                    Point P = new Point(A) + new Point(B - A) * phi;
                    P.x = j; P.y = p1.y + i;
                    int idx = P.x + P.y * bitmap.Width;
                    if (zbuffer[idx] < P.z)
                    {
                        zbuffer[idx] = P.z;
                        bitmap.SetPixel(P.x, P.y, color);
                    }
                }
            }
        }
        void DrawTriangle(Triangle triangle, Bitmap bitmap, int[] zbuffer)
        {
            DrawTriangle(triangle.Points[0], triangle.Points[1], triangle.Points[2], bitmap, triangle.color, zbuffer);
        }

        /*private void Transform(ref Point pt, double x_scale, double y_scale, double x_shift, double y_shift)
        {
            Matrix TransformMtx = new Matrix(3);
            TransformMtx.Elems[0, 0] = x_scale;
            TransformMtx.Elems[1, 0] = x_shift;
            TransformMtx.Elems[0, 1] = y_shift;
            TransformMtx.Elems[1, 1] = y_scale;
            Matrix PointMtx = new Matrix(3, 1);
            PointMtx.Elems[0, 0] = pt.x;
            PointMtx.Elems[1, 0] = pt.y;
            PointMtx.Elems[2, 0] = 1;
            Matrix res = new Matrix(TransformMtx.Rows, PointMtx.Columns);
            res = TransformMtx*PointMtx;
            pt.x = (int)res.Elems[0, 0];
            pt.y = (int)res.Elems[1, 0];
        }*/
        public void Transform(ref Triangle triangle, double x_scale, double y_scale, double x_shift, double y_shift)
        {
            Matrix TransformMtx = new Matrix(3);
            TransformMtx.Elems[0, 0] = x_scale;
            TransformMtx.Elems[1, 0] = x_shift;
            TransformMtx.Elems[0, 1] = y_shift;
            TransformMtx.Elems[1, 1] = y_scale;
            for (int i = 0; i < 3; i++)
            {
                Matrix PointMtx = new Matrix(3, 1);
                PointMtx.Elems[0, 0] = triangle.Points[i].x;
                PointMtx.Elems[1, 0] = triangle.Points[i].y;
                PointMtx.Elems[2, 0] = 1;
                Matrix res = new Matrix(TransformMtx.Rows, PointMtx.Columns);
                res = TransformMtx * PointMtx;
                triangle.Points[i].x = (int)res.Elems[0, 0];
                triangle.Points[i].y = (int)res.Elems[1, 0];
            }
        }

        public void Round(ref Triangle triangle, double angle, Point axis)
        { 
            double alpha = angle * (Math.PI / 180);//Градусы -> радианы
            Moving(ref triangle, -axis.x, -axis.y);
            Transform(ref triangle, Math.Cos(alpha), Math.Cos(alpha), Math.Sin(alpha), -Math.Sin(alpha));
            Moving(ref triangle, axis.x, axis.y);
        }
        public void Moving(ref Triangle triangle, int x_move, int y_move)
        {
            Matrix MoveMtx = new Matrix(3);
            MoveMtx.Elems[0, 2] = x_move;
            MoveMtx.Elems[1, 2] = y_move;
            for (int i = 0; i < 3; i++)
            {
                Matrix PointMtx = new Matrix(3, 1);
                PointMtx.Elems[0, 0] = triangle.Points[i].x;
                PointMtx.Elems[1, 0] = triangle.Points[i].y;
                PointMtx.Elems[2, 0] = 1;
                Matrix res = new Matrix(MoveMtx.Rows, PointMtx.Columns);
                res = MoveMtx * PointMtx;
                triangle.Points[i].x = (int)res.Elems[0, 0];
                triangle.Points[i].y = (int)res.Elems[1, 0];
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
    }
}
