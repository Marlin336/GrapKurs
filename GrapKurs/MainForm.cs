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
        public MainForm()
        {
            InitializeComponent();
            scene = new WorkScene(PBox.Width, PBox.Height);
            /*foreach (Object item in scene.objs)
            {
                lboxObj.Items.Add(item);
            }*/
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

            if (openFD.ShowDialog() == DialogResult.OK)
            {
                char[] sep = { '/', ':' };
                StreamReader stream = new StreamReader(openFD.FileName, System.Text.Encoding.Default, false);
                ParamObj paramObj = null;
                while (!stream.EndOfStream)
                {
                    string service = stream.ReadLine();
                    if (service == "[Obj]")
                    {
                        if(paramObj != null)
                        {
                            scene.AddObj(paramObj);
                            lboxObj.Items.Add(paramObj);
                        }
                        paramObj = new ParamObj();
                        stream.ReadLine();
                        continue;
                    }
                    string[] line = service.Split(sep);
                    Triangle polygon = new Triangle(new Point(double.Parse(line[0]), double.Parse(line[1]), double.Parse(line[2])), new Point(double.Parse(line[3]), double.Parse(line[4]), double.Parse(line[5])), new Point(double.Parse(line[6]), double.Parse(line[7]), double.Parse(line[8])), Color.FromArgb(int.Parse(line[9])));
                    paramObj.polygs.Add(polygon);
                }
                scene.AddObj(paramObj);
                lboxObj.Items.Add(paramObj);
                Redraw();
            }
        }
        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                StreamWriter stream = new StreamWriter(saveFD.FileName, false, System.Text.Encoding.Default);
                string vertex = null;
                for (int i = 0; i < scene.objs.Count; i++)
                {
                    vertex += "[Obj]\n";
                    for (int j = 0; j < scene.objs[i].polygs.Count; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            vertex += scene.objs[i].polygs[j].Points[k].x + "/" + scene.objs[i].polygs[j].Points[k].y + "/" + scene.objs[i].polygs[j].Points[k].z+":";
                        }
                        vertex += scene.objs[i].polygs[j].Color.ToArgb().ToString() + "\n";
                    }
                }
                stream.Write(vertex);
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
                int index = lboxObj.SelectedIndex;
                ParamObj paramObj = scene.objs[index];
                foreach (Triangle item in paramObj.polygs)
                    item.Moving(0, 15, 0);
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
                int index = lboxObj.SelectedIndex;
                ParamObj paramObj = scene.objs[index];
                foreach (Triangle item in paramObj.polygs)
                    item.Moving(0, -15, 0);
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
                ParamObj paramObj = scene.objs[index];
                foreach (Triangle item in paramObj.polygs)
                    item.Moving(15, 0, 0);
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
                int index = lboxObj.SelectedIndex;
                ParamObj paramObj = scene.objs[index];
                foreach (Triangle item in paramObj.polygs)
                    item.Moving(-15, 0, 0);
            }
            Redraw();
        }
        private void ScaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            Point axis = new Point();
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
                int index = lboxObj.SelectedIndex;
                ParamObj paramObj = (ParamObj)scene.objs[index];
                foreach (Triangle item in paramObj.polygs)
                {
                    item.Reset();
                    item.Scale((double)ScaleUpDown.Value, (double)ScaleUpDown.Value, (double)ScaleUpDown.Value, axis);
                }
            }
            Redraw();
        }
        //Добавить вращение всех типов объектов
        private void bRotate_Click(object sender, EventArgs e)
        {
            Point axis = new Point();
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
                int index = lboxObj.SelectedIndex;
                ParamObj paramObj = (ParamObj)scene.objs[index];
                foreach (Triangle item in paramObj.polygs)
                {
                    item.Reset();
                    item.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
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
