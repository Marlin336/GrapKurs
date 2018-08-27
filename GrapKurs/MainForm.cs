using ObjParser;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GrapKurs
{
    public partial class MainForm : Form
    {
        public WorkScene scene;
        Random r = new Random();
        Point Start;
        public MainForm()
        {
            InitializeComponent();
            scene = new WorkScene(PBox.Width, PBox.Height);

            /*Ствол*/
            Start = new Point(250, 250, 0);
            Tube barrel = new Tube(Start, 4, 2.5, 200, Color.Red);
            barrel.Rotate(0, 0, 90, Start);
            barrel.Resave();
            scene.AddObj(barrel);
            /*Магазин*/
            Cylinder magazine = new Cylinder(Start, 4, 180, Color.Brown);
            magazine.Rotate(0, 0, 90, Start);
            magazine.Moving(0, -4, 0);
            magazine.Resave();
            scene.AddObj(magazine);
            /*Цевьё*/
            Cylinder cev = new Cylinder(Start, 5.5, 170, Color.RoyalBlue);
            cev.Rotate(0, 0, 90, Start);
            cev.Scale(1, 1.3, 1, Start);
            cev.Moving(0, -2, 0);
            cev.Resave();
            scene.AddObj(cev);
            /*Затворная коробка*/
            Point box1 = new Point(Start.x, Start.y + 10, Start.z + 3);
            Point box2 = new Point(Start.x + 80, Start.y - (3 + 5), Start.z - 3);
            Box box = new Box(box1, box2, Color.Beige);
            box.Resave();
            scene.AddObj(box);
            /*Целик*/
            Point celStart = new Point(box1.x - 10, box1.y - 2, box1.z);
            Box cel = new Box(celStart, new Point((celStart.x) + 25, (celStart.y) + 2, celStart.z - 6), Color.Black);
            cel.Rotate(0, 0, 8, celStart);
            cel.Resave();
            scene.AddObj(cel);
            /*Рукоять*/
            Point handStart = new Point((box1.x + 80)-10, Start.y, Start.z);
            Cylinder hand = new Cylinder(handStart, 5, 50, Color.Brown);
            hand.Scale(1.3, 1, 1, handStart);
            hand.Rotate(0, 0, -100, handStart);
            hand.Resave();
            scene.AddObj(hand);
            /*Приклад*/
            Point buttStart = new Point((box1.x + 80) + 35, Start.y - 7, Start.z);
            Cone butt = new Cone(buttStart, 5, 12, 70, Color.RosyBrown);
            butt.Scale(1.5, 1, 0.7, buttStart);
            butt.Rotate(0, 0, -100, buttStart);
            butt.Resave();
            scene.AddObj(butt);
            /*Рычаг*/
            Point cirStart = new Point(buttStart.x - 50, buttStart.y - 3, buttStart.z);
            Tube cir_trig = new Tube(cirStart, 6, 7, 5, Color.Violet);
            cir_trig.Rotate(90, 0, 0, cirStart);
            cir_trig.Moving(0, 0, -2.5); ;
            cir_trig.Resave();
            scene.AddObj(cir_trig);

            Point leverStart = new Point(cirStart.x + 25, cirStart.y - 5, cirStart.z);
            Tube lever = new Tube(leverStart, 7, 8, 5, Color.AliceBlue);
            lever.Scale(1, 1, 2.5, leverStart);
            lever.Rotate(90, 0, 75, leverStart);
            lever.Moving(0, 0, -2.5);
            lever.Resave();
            scene.AddObj(lever);
            /*Спуск*/
            Point trigStart = new Point(cirStart.x + 2, cirStart.y + 2, cirStart.z);
            Cone trig = new Cone(trigStart, 3, 1, -7, Color.Chartreuse);
            trig.Scale(0.7, 1, 1, trigStart);
            trig.Rotate(0, 0, -20, trigStart);//Угол спускового крючка 
            trig.Resave();
            scene.AddObj(trig);
            /*Кольца*/
            Tube ring_1 = new Tube(new Point(Start.x - 60, Start.y+1, Start.z), 7, 8, 5, Color.Chocolate);
            ring_1.Scale(1.2, 1, 1, ring_1.Bottom.Center);
            ring_1.Rotate(0, 0, 90, ring_1.Bottom.Center);
            ring_1.Resave();
            scene.AddObj(ring_1);
            Tube ring_2 = new Tube(new Point(Start.x - 100, Start.y + 1, Start.z), 7, 8, 5, Color.Chocolate);
            ring_2.Scale(1.2, 1, 1, ring_2.Bottom.Center);
            ring_2.Rotate(0, 0, 90, ring_2.Bottom.Center);
            ring_2.Resave();
            scene.AddObj(ring_2);
            Tube ring_3 = new Tube(new Point(Start.x - 140, Start.y + 1, Start.z), 7, 8, 5, Color.Chocolate);
            ring_3.Scale(1.2, 1, 1, ring_3.Bottom.Center);
            ring_3.Rotate(0, 0, 90, ring_3.Bottom.Center);
            ring_3.Resave();
            scene.AddObj(ring_3);
            /*Насечки*/
            Cylinder scr_1 = new Cylinder(new Point(buttStart.x + 30, buttStart.y - 5, buttStart.z), 9, 1, Color.Red);
            scr_1.Rotate(0, 0, 90, new Point(buttStart.x + 30, buttStart.y - 5, buttStart.z));
            scr_1.Scale(1, 1, 0.75, new Point(buttStart.x + 30, buttStart.y - 5, buttStart.z));
            scr_1.Resave();
            scene.AddObj(scr_1);
            Cylinder scr_2 = new Cylinder(new Point(buttStart.x + 35, buttStart.y - 5, buttStart.z), 10, 1, Color.Red);
            scr_2.Rotate(0, 0, 90, new Point(buttStart.x + 35, buttStart.y - 5, buttStart.z));
            scr_2.Scale(1, 1, 0.75, new Point(buttStart.x + 35, buttStart.y - 5, buttStart.z));
            scr_2.Resave();
            scene.AddObj(scr_2);
            Cylinder scr_3 = new Cylinder(new Point(buttStart.x + 40, buttStart.y - 5, buttStart.z), 11, 1, Color.Red);
            scr_3.Rotate(0, 0, 90, new Point(buttStart.x + 40, buttStart.y - 5, buttStart.z));
            scr_3.Scale(1, 1, 0.75, new Point(buttStart.x + 40, buttStart.y - 5, buttStart.z));
            scr_3.Resave();
            scene.AddObj(scr_3);
            Cylinder scr_4 = new Cylinder(new Point(buttStart.x + 45, buttStart.y - 5, buttStart.z), 11, 1, Color.Red);
            scr_4.Rotate(0, 0, 90, new Point(buttStart.x + 45, buttStart.y - 5, buttStart.z));
            scr_4.Scale(1, 1, 0.75, new Point(buttStart.x + 45, buttStart.y - 5, buttStart.z));
            scr_4.Resave();
            scene.AddObj(scr_4);

            foreach (Object item in scene.objs)
            {
                lboxObj.Items.Add(item);
            }
            Redraw();
        }

        public void Redraw()
        {
            scene.bmp = new Bitmap(PBox.Width, PBox.Height);
            scene.ClearzBuf();
            foreach (Object item in scene.objs)
            {
                switch (item.GetType().Name)
                {
                    case "Triangle":
                        Triangle triangle = (Triangle)item;
                        DrawTriangle(triangle, scene);
                        break;
                    case "Circle":
                        Circle circle = (Circle)item;
                        foreach (Triangle tr in circle.polygons)
                        {
                            DrawTriangle(tr, scene);
                        }
                        break;
                    case "ParamObj":
                        ParamObj paramObj = (ParamObj)item;
                        foreach (Triangle tr in paramObj.polygs)
                        {
                            DrawTriangle(tr, scene);
                        }
                        break;
                    case "Rectangle":
                        Rectangle rectangle = (Rectangle)item;
                        foreach (Triangle tr in rectangle.polygons)
                        {
                            DrawTriangle(tr, scene);
                        }
                        break;
                    case "Box":
                        Box box = (Box)item;
                        foreach (Triangle tr in box.polygons)
                        {
                            DrawTriangle(tr, scene);
                        }
                        break;
                    case "Cylinder":
                        Cylinder cylinder = (Cylinder)item;
                        foreach (Triangle tr in cylinder.polygons)
                        {
                            DrawTriangle(tr, scene);
                        }
                        break;
                    case "Cone":
                        Cone cone = (Cone)item;
                        foreach (Triangle tr in cone.polygons)
                        {
                            DrawTriangle(tr, scene);
                        }
                        break;
                    case "Ring":
                        Ring ring = (Ring)item;
                        foreach (Triangle tr in ring.polygons)
                        {
                            DrawTriangle(tr, scene);
                        }
                        break;
                    case "Tube":
                        Tube tube = (Tube)item;
                        foreach (Triangle tr in tube.polygons)
                        {
                            DrawTriangle(tr, scene);
                        }
                        break;
                    default:
                        break;
                }
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
        ParamObj ReadObj3D(Obj obj, Color color)
        {
            Point[] VertexList = new Point[obj.VertexList.Count];
            ParamObj ret = new ParamObj(new Point(100,100,0),100,100,100,100,100,100,100,100,100,100);
            for (int i = 0; i < obj.VertexList.Count; i++)
            {
                VertexList[i] = new Point(obj.VertexList[i].X, obj.VertexList[i].Y, obj.VertexList[i].Z);
            }
            for (int i = 0; i < obj.FaceList.Count; i++)
            {
                Point p1 = new Point(VertexList[obj.FaceList[i].VertexIndexList[0] - 1]);
                Point p2 = new Point(VertexList[obj.FaceList[i].VertexIndexList[1] - 1]);
                Point p3 = new Point(VertexList[obj.FaceList[i].VertexIndexList[2] - 1]);
                ret.polygs.Add(new Triangle(p1, p2, p3, color));
            }
            return ret;
        }
        void DrawLine(Point p1, Point p2, WorkScene scene, Color color)
        {
            if (scene.cenoutl)
            {
                p1.Outlook(new Line(p1,scene.eye).Length);
                p2.Outlook(new Line(p2, scene.eye).Length);
            }
            double x1 = p1.x;
            double y1 = p1.y;
            double x2 = p2.x;
            double y2 = p2.y;

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
                        scene.bmp.SetPixel(y, x, color);
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        scene.bmp.SetPixel(x, y, color);
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
        void DrawLine(double x1, double y1, double x2, double y2, WorkScene scene, Color color)
        {
            DrawLine(new Point(x1, y1, 0), new Point(x2, y2, 0), scene, color);
        }
        void DrawTriangle(Point p1, Point p2, Point p3, WorkScene scene, Color color)
        {
            if (p1.y > p2.y) Swap(ref p1, ref p2);
            if (p1.y > p3.y) Swap(ref p1, ref p3);
            if (p2.y > p3.y) Swap(ref p2, ref p3);
            if (!scene.fill)
            {
                DrawLine(p1.x, p1.y, p2.x, p2.y, scene, color);
                DrawLine(p2.x, p2.y, p3.x, p3.y, scene, color);
                DrawLine(p3.x, p3.y, p1.x, p1.y, scene, color);
            }
            else
            {
                if (scene.cenoutl)
                {
                    p1 = p1.Outlook(new Line(p1, scene.eye).Length);
                    p2 = p2.Outlook(new Line(p2, scene.eye).Length);
                    p3 = p3.Outlook(new Line(p3, scene.eye).Length);
                }
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
                        int idx = (int)(P.x + P.y * scene.bmp.Width);
                        if (P.x >= scene.bmp.Width || P.x < 0 || P.y >= scene.bmp.Height || P.y < 0) continue;
                        try
                        {
                            if (scene.zBuf[idx] < P.z)
                            {
                                scene.zBuf[idx] = (int)P.z;
                                scene.bmp.SetPixel((int)P.x, (int)P.y, color);
                            }
                        }
                        catch { }
                    }
                }
            }
        }
        void DrawTriangle(Triangle triangle, WorkScene scene)
        {
            DrawTriangle(triangle.Points[0], triangle.Points[1], triangle.Points[2], scene, triangle.Color);
        }

        private void РеалистичныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.fill = true;
            Redraw();
        }
        private void КаркасныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.fill = false;
            Redraw();
        }
        private void ЗагрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                StreamWriter stream = new StreamWriter(saveFD.FileName, false, System.Text.Encoding.Default);
                string vertex = "";
                for (int i = 0; i < scene.triangles.Count; i++)
                {
                    vertex = scene.triangles[i].Points[0].x + "/" + scene.triangles[i].Points[0].y + "/" + scene.triangles[i].Points[0].z + "\r";
                    vertex += scene.triangles[i].Points[1].x + "/" + scene.triangles[i].Points[1].y + "/" + scene.triangles[i].Points[1].z + "\r";
                    vertex += scene.triangles[i].Points[2].x + "/" + scene.triangles[i].Points[2].y + "/" + scene.triangles[i].Points[2].z + "\r";
                    vertex += scene.triangles[i].Color.ToArgb() + "\r";
                    stream.Write(vertex);
                }
                stream.Close();
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
                scene.Shifting.Moving(0, -15, 0);
                scene.eye.Moving(0, -15, 0);
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
                        circle.Moving(0, 15, 0);
                        break;
                    case "ParamObj":
                        ParamObj paramObj = (ParamObj)scene.objs[index];
                        foreach (Triangle item in paramObj.polygs)
                        {
                            item.Moving(0, 15, 0);
                        }
                        break;
                    case "Rectangle":
                        Rectangle rectangle = (Rectangle)scene.objs[index];
                        rectangle.Moving(0, 15, 0);
                        break;
                    case "Box":
                        Box box = (Box)scene.objs[index];
                        box.Moving(0, 15, 0);
                        break;
                    case "Cylinder":
                        Cylinder cylinder = (Cylinder)scene.objs[index];
                        cylinder.Moving(0, 15, 0);
                        break;
                    case "Cone":
                        Cone cone = (Cone)scene.objs[index];
                        cone.Moving(0, 15, 0);
                        break;
                    case "Ring":
                        Ring ring = (Ring)scene.objs[index];
                        ring.Moving(0, 15, 0);
                        break;
                    case "Tube":
                        Tube tube = (Tube)scene.objs[index];
                        tube.Moving(0, 15, 0);
                        break;
                    default:
                        break;
                }
            }
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
                scene.Shifting.Moving(0, 15, 0);
                scene.eye.Moving(0, 15, 0);
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
                        circle.Moving(0, -15, 0);
                        break;
                    case "ParamObj":
                        ParamObj paramObj = (ParamObj)scene.objs[index];
                        foreach (Triangle item in paramObj.polygs)
                        {
                            item.Moving(0, -15, 0);
                        }
                        break;
                    case "Rectangle":
                        Rectangle rectangle = (Rectangle)scene.objs[index];
                        rectangle.Moving(0, -15, 0);
                        break;
                    case "Box":
                        Box box = (Box)scene.objs[index];
                        box.Moving(0, -15, 0);
                        break;
                    case "Cylinder":
                        Cylinder cylinder = (Cylinder)scene.objs[index];
                        cylinder.Moving(0, -15, 0);
                        break;
                    case "Cone":
                        Cone cone = (Cone)scene.objs[index];
                        cone.Moving(0, -15, 0);
                        break;
                    case "Ring":
                        Ring ring = (Ring)scene.objs[index];
                        ring.Moving(0, -15, 0);
                        break;
                    case "Tube":
                        Tube tube = (Tube)scene.objs[index];
                        tube.Moving(0, -15, 0);
                        break;
                    default:
                        break;
                }
            }
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
                scene.Shifting.Moving(-15, 0, 0);
                scene.eye.Moving(-15, 0, 0);
            }
            else
            {
                int index = lboxObj.SelectedIndex;
                switch (scene.objs[index].GetType().Name)
                {
                    case "Triangle":
                        Triangle triangle = (Triangle)scene.objs[index];
                        triangle.Moving(15, 0, 0);
                        break;
                    case "Circle":
                        Circle circle = (Circle)scene.objs[index];
                        circle.Moving(15, 0, 0);
                        break;
                    case "ParamObj":
                        ParamObj paramObj = (ParamObj)scene.objs[index];
                        foreach (Triangle item in paramObj.polygs)
                        {
                            item.Moving(15, 0, 0);
                        }
                        break;
                    case "Rectangle":
                        Rectangle rectangle = (Rectangle)scene.objs[index];
                        rectangle.Moving(15, 0, 0);
                        break;
                    case "Box":
                        Box box = (Box)scene.objs[index];
                        box.Moving(15, 0, 0);
                        break;
                    case "Cylinder":
                        Cylinder cylinder = (Cylinder)scene.objs[index];
                        cylinder.Moving(15, 0, 0);
                        break;
                    case "Cone":
                        Cone cone = (Cone)scene.objs[index];
                        cone.Moving(15, 0, 0);
                        break;
                    case "Ring":
                        Ring ring = (Ring)scene.objs[index];
                        ring.Moving(15, 0, 0);
                        break;
                    case "Tube":
                        Tube tube = (Tube)scene.objs[index];
                        tube.Moving(15, 0, 0);
                        break;
                    default:
                        break;
                }
            }
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
                scene.Shifting.Moving(15, 0, 0);
                scene.eye.Moving(15, 0, 0);
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
                        circle.Moving(-15, 0, 0);
                        break;
                    case "ParamObj":
                        ParamObj paramObj = (ParamObj)scene.objs[index];
                        foreach (Triangle item in paramObj.polygs)
                        {
                            item.Moving(-15, 0, 0);
                        }
                        break;
                    case "Rectangle":
                        Rectangle rectangle = (Rectangle)scene.objs[index];
                        rectangle.Moving(-15, 0, 0);
                        break;
                    case "Box":
                        Box box = (Box)scene.objs[index];
                        box.Moving(-15, 0, 0);
                        break;
                    case "Cylinder":
                        Cylinder cylinder = (Cylinder)scene.objs[index];
                        cylinder.Moving(-15, 0, 0);
                        break;
                    case "Cone":
                        Cone cone = (Cone)scene.objs[index];
                        cone.Moving(-15, 0, 0);
                        break;
                    case "Ring":
                        Ring ring = (Ring)scene.objs[index];
                        ring.Moving(-15, 0, 0);
                        break;
                    case "Tube":
                        Tube tube = (Tube)scene.objs[index];
                        tube.Moving(-15, 0, 0);
                        break;
                    default:
                        break;
                }
            }
            Redraw();
        }
        private void ScaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            Point axis;
            try
            {
                char[] sep = new char[] { ',' };
                axis = radNC.Checked ? new Point() : new Point(Start);//вместо null взять центр объекта
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось найти осевую точку масштабирования");
                throw;
            }
            if (lboxObj.SelectedIndex == -1)
            {
                foreach (Triangle item in scene.triangles)
                {
                    item.Reset();
                    item.Scale((double)ScaleUpDown.Value, (double)ScaleUpDown.Value, (double)ScaleUpDown.Value, axis);
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
                        triangle.Scale((double)ScaleUpDown.Value, (double)ScaleUpDown.Value, (double)ScaleUpDown.Value, axis);
                        break;
                    case "Circle":
                        Circle circle = (Circle)scene.objs[index];
                        foreach (Triangle item in circle.polygons)
                        {
                            item.Reset();
                            item.Scale((double)ScaleUpDown.Value, (double)ScaleUpDown.Value, (double)ScaleUpDown.Value, axis);
                        }
                        break;
                    case "ParamObj":
                        ParamObj paramObj = (ParamObj)scene.objs[index];
                        foreach (Triangle item in paramObj.polygs)
                        {
                            item.Reset();
                            item.Scale((double)ScaleUpDown.Value, (double)ScaleUpDown.Value, (double)ScaleUpDown.Value, axis);
                        }
                        break;
                    default:
                        break;
                }
            }
            Redraw();
        }
        //Добавить вращение всех типов объектов
        private void bRotate_Click(object sender, EventArgs e)
        {
            Point axis;
            try
            {
                char[] sep = new char[] { ',' };
                axis = radNC.Checked ? new Point() : new Point(Start);//вместо null взять центр объекта
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось найти осевую точку вращения");
                throw;
            }
            if (lboxObj.SelectedIndex == -1)
            {
                foreach (Triangle item in scene.triangles)
                {
                    item.Reset();
                    item.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
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
                        triangle.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                        break;
                    case "Circle":
                        Circle circle = (Circle)scene.objs[index];
                        circle.Reset();
                        circle.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                        break;
                    case "ParamObj":
                        ParamObj paramObj = (ParamObj)scene.objs[index];
                        foreach (Triangle item in paramObj.polygs)
                        {
                            item.Reset();
                            item.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                        }
                        break;
                    case "Rectangle":
                        Rectangle rectangle = (Rectangle)scene.objs[index];
                        rectangle.Reset();
                        rectangle.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                        break;
                    case "Box":
                        Box box = (Box)scene.objs[index];
                        box.Reset();
                        box.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                        break;
                    case "Cylinder":
                        Cylinder cylinder = (Cylinder)scene.objs[index];
                        cylinder.Reset();
                        cylinder.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                        break;
                    case "Cone":
                        Cone cone = (Cone)scene.objs[index];
                        cone.Reset();
                        cone.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                        break;
                    case "Ring":
                        Ring ring = (Ring)scene.objs[index];
                        ring.Reset();
                        ring.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                        break;
                    case "Tube":
                        Tube tube = (Tube)scene.objs[index];
                        tube.Reset();
                        tube.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                        break;
                    default:
                        break;
                }
            }
            ScaleUpDown_ValueChanged(sender, e);
            Redraw();
        }

        public void AddObj(Point state, double scale, System.Drawing.Color color)
        {
            Obj obj = new Obj();
            obj.LoadObj("../../Mar.obj");
            ScaleUpDown.Value = 1;
            ParamObj nobj = ReadObj3D(obj, color);
            scene.AddObj(nobj);
            lboxObj.Items.Add(nobj);
            for (int i = 0; i < nobj.polygs.Count; i++)
                nobj.polygs[i].Scale(scale, scale, scale, new Point());
            for (int i = 0; i < nobj.polygs.Count; i++)
                nobj.polygs[i].Moving(state.x, state.y, state.z);
            Redraw();
        }

        private void lboxObj_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lboxObj.SelectedIndex = -1;
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            ParamForm Form = new ParamForm(this);
            Form.ShowDialog();
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (lboxObj.SelectedIndex == -1)
                return;
            scene.objs.RemoveAt(lboxObj.SelectedIndex);
            lboxObj.Items.RemoveAt(lboxObj.SelectedIndex);
            Redraw();
        }

        private void ПараллельнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.cenoutl = false;
            Redraw();
        }

        private void ЦентральнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scene.cenoutl = true;
            Redraw();
        }
    }
}
