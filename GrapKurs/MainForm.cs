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
using ObjParser;
using ObjParser.Types;

namespace GrapKurs
{
    public partial class MainForm : Form
    {
        WorkScene scene;
        public MainForm()
        {
            Random r = new Random();
            InitializeComponent();
            scene = new WorkScene(PBox.Width, PBox.Height);
            Point[] pa1 = new Point[3];
            pa1[0] = new Point(-10, 50, 0);
            pa1[1] = new Point(150, 150, 0);
            pa1[2] = new Point(110, 50, 0);
            Triangle tr1 = new Triangle(pa1, System.Drawing.Color.FromArgb(255,r.Next(0,255), r.Next(0, 255), r.Next(0, 255)));
            scene.objs.Add(tr1);
            lboxObj.Items.Add(tr1);
            Point[] pa2 = new Point[3];
            pa2[0] = new Point(30, 70, -10);
            pa2[1] = new Point(80, 150, 10);
            pa2[2] = new Point(130, 70, -10);
            Triangle tr2 = new Triangle(pa2, System.Drawing.Color.FromArgb(255, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            scene.objs.Add(tr2);
            lboxObj.Items.Add(tr2);
            Circle crcl1 = new Circle(new Point(200, 200, 0), 50, System.Drawing.Color.Red);
            scene.objs.Add(crcl1);
            lboxObj.Items.Add(crcl1);
            scene.AddObj(tr1);
            scene.AddObj(tr2);
            scene.AddObj(crcl1);
            Redraw();
        }

        void Redraw()
        {
            scene.bmp = new Bitmap(PBox.Width, PBox.Height);
            foreach (Triangle item in scene.triangles)
            {
                DrawTriangle(item, scene.bmp, scene.zBuf, scene.fill);
            }
            scene.bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            PBox.Image = scene.bmp;
        }
 
        void Swap(ref double a, ref double b)
        {
            double swap = a;
            a = b;
            b = swap;
        }
        void Swap(ref Point a, ref Point b)
        {
            Point swap = a;
            a = b;
            b = swap;
        }
        void ReadObj3D(Obj obj)
        {
            scene = new WorkScene(PBox.Width, PBox.Height);
            Matrix World = new Matrix(4);
            for (int i = 0; i < obj.FaceList.Count; i++)
            {
                int[] face = obj.FaceList[i].VertexIndexList;
                for (int j = 0; j < 3; j++)
                {
                    Point p1 = new Point();
                    Point p2 = new Point();

                    p1.x = (obj.VertexList[face[j]].X);
                    p1.y = (obj.VertexList[face[j]].Y);
                    p1.z = (obj.VertexList[face[j]].Z);

                    p2.x = obj.VertexList[face[(j + 1) % 3]].X;
                    p2.y = obj.VertexList[face[(j + 1) % 3]].Y;
                    p2.z = obj.VertexList[face[(j + 1) % 3]].Z;
                }
            }
        }

        void DrawLine(double x1, double y1, double x2, double y2, Bitmap bitmap, System.Drawing.Color color)
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
        void DrawTriangle(Point p1, Point p2, Point p3, Bitmap bitmap, System.Drawing.Color color, int[] zbuffer, bool fill)
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
                    float beta = (float)(i - (second_half ? p2.y - p1.y : 0)) / segment_height;
                    Point A = p1 + (p3 - p1) * alpha;
                    Point B = second_half ? p2 + (p3 - p2) * beta : p1 + (p2 - p1) * beta;
                    if (A.x > B.x) Swap(ref A, ref B);
                    for (int j = (int)A.x; j <= B.x; j++)
                    {
                        double phi = B.x == A.x ? 1 : (j - A.x) / (B.x - A.x);
                        Point P = new Point(A) + new Point(B - A) * phi;
                        P.x = j; P.y = p1.y + i;
                        int idx = (int)(P.x + P.y * bitmap.Width);
                        if (P.x >= bitmap.Width || P.x < 0 || P.y >= bitmap.Height || P.y < 0) continue;
                        if (zbuffer[idx] < P.z)
                        {
                            zbuffer[idx] = (int)P.z;
                            bitmap.SetPixel((int)P.x, (int)P.y, color);
                        }
                    }
                }
            }
        }
        void DrawTriangle(Triangle triangle, Bitmap bitmap, int[] zbuffer, bool fill)
        {
            DrawTriangle(triangle.Points[0], triangle.Points[1], triangle.Points[2], bitmap, triangle.Color, zbuffer, fill);
        }

        private void РеалистичныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.fill = true;
            scene.ClearzBuf();
            Redraw();
        }
        private void КаркасныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.fill = false;
            scene.ClearzBuf();
            Redraw();
        }

        private void ЗагрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Obj obj = new Obj();
                    obj.LoadObj(openFD.FileName);
                    ReadObj3D(obj);
                    Redraw();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось открыть файл.\r\n"+ex.Message, "Ошибка окрытия файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            if (lboxObj.SelectedIndex == -1)
            { 
                foreach (Triangle item in scene.triangles)
            {
                item.Moving(0, 15, 0);
            }
                scene.CenterPos(0, 15, 0);
            }
            else
            {
                int index = scene.objs.IndexOf(lboxObj.Items[lboxObj.SelectedIndex]);
                switch (scene.objs[index].GetType().Name)
                {
                    case "Triangle":
                        Triangle triangle = (Triangle)scene.objs[index];
                        triangle.Moving(0, 15, 0);
                        break;
                    case "Circle":
                        Circle circle = (Circle)scene.objs[index];
                        foreach (Triangle item in circle.polygons)
                        {
                            item.Moving(0, 15, 0);
                        }
                        break;
                    default:
                        break;
                }
            }
            scene.ClearzBuf();
            Redraw();
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            if (lboxObj.SelectedIndex == -1)
            {
                foreach (Triangle item in scene.triangles)
                {
                    item.Moving(0, -15, 0);
                }
                scene.CenterPos(0, -15, 0);
            }
            else
            {
                int index = scene.objs.IndexOf(lboxObj.Items[lboxObj.SelectedIndex]);
                switch (scene.objs[index].GetType().Name)
                {
                    case "Triangle":
                        Triangle triangle = (Triangle)scene.objs[index];
                        triangle.Moving(0, -15, 0);
                        break;
                    case "Circle":
                        Circle circle = (Circle)scene.objs[index];
                        foreach (Triangle item in circle.polygons)
                        {
                            item.Moving(0, -15, 0);
                        }
                        break;
                    default:
                        break;
                }
            }
            scene.ClearzBuf();
            Redraw();
        }

        private void bRight_Click(object sender, EventArgs e)
        {
            if (lboxObj.SelectedIndex == -1)
            {
                foreach (Triangle item in scene.triangles)
                {
                    item.Moving(15, 0, 0);
                }
                scene.CenterPos(15, 0, 0);
            }
            else
            {
                int index = scene.objs.IndexOf(lboxObj.Items[lboxObj.SelectedIndex]);
                switch (scene.objs[index].GetType().Name)
                {
                    case "Triangle":
                        Triangle triangle = (Triangle)scene.objs[index];
                        triangle.Moving(15, 0, 0);
                        break;
                    case "Circle":
                        Circle circle = (Circle)scene.objs[index];
                        foreach (Triangle item in circle.polygons)
                        {
                            item.Moving(15, 0, 0);
                        }
                        break;
                    default:
                        break;
                }
            }
            scene.ClearzBuf();
            Redraw();
        }

        private void bLeft_Click(object sender, EventArgs e)
        {
            if (lboxObj.SelectedIndex == -1)
            {
                foreach (Triangle item in scene.triangles)
                {
                    item.Moving(-15, 0, 0);
                }
                scene.CenterPos(-15, 0, 0);
            }
            else
            {
                int index = scene.objs.IndexOf(lboxObj.Items[lboxObj.SelectedIndex]);
                switch (scene.objs[index].GetType().Name)
                {
                    case "Triangle":
                        Triangle triangle = (Triangle)scene.objs[index];
                        triangle.Moving(-15, 0, 0);
                        break;
                    case "Circle":
                        Circle circle = (Circle)scene.objs[index];
                        foreach (Triangle item in circle.polygons)
                        {
                            item.Moving(-15, 0, 0);
                        }
                        break;
                    default:
                        break;
                }
            }
            scene.ClearzBuf();
            Redraw();
        }

        private void ScaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (lboxObj.SelectedIndex == -1)
            {
                foreach (Triangle item in scene.triangles)
                {
                    item.Reset();
                    item.Scale((double)ScaleUpDown.Value, (double)ScaleUpDown.Value, (double)ScaleUpDown.Value, scene.Center);
                }
            }
            else
            {
                int index = scene.objs.IndexOf(lboxObj.Items[lboxObj.SelectedIndex]);
                switch (scene.objs[index].GetType().Name)
                {
                    case "Triangle":
                        Triangle triangle = (Triangle)scene.objs[index];
                        triangle.Reset();
                        triangle.Scale((double)ScaleUpDown.Value, (double)ScaleUpDown.Value, (double)ScaleUpDown.Value, triangle.Center);
                        break;
                    case "Circle":
                        Circle circle = (Circle)scene.objs[index];
                        foreach (Triangle item in circle.polygons)
                        {
                            item.Reset();
                            item.Scale((double)ScaleUpDown.Value, (double)ScaleUpDown.Value, (double)ScaleUpDown.Value, circle.Center);
                        }
                        break;
                    default:
                        break;
                }
            }
            scene.ClearzBuf();
            Redraw();
        }

        private void lboxObj_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lboxObj.SelectedIndex = -1;
            }
        }
    }
}
