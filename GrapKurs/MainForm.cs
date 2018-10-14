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
        double scale = 1;
        public MainForm()
        {
            InitializeComponent();
            scene = new WorkScene(PBox.Width, PBox.Height);
            Redraw();
        }

        public void Redraw()
        {
            scene.bmp = new Bitmap(PBox.Width, PBox.Height);
            scene.ClearzBuf();
            foreach (ParamObj item in scene.objs)
            {
                foreach (Triangle tr in item.polygs)
                {
                    Triangle polyg = new Triangle(tr);
                    polyg.Scale(item.scale * scale, item.scale * scale, item.scale * scale, item.Start);
                    polyg.LookAt(scene.camera.eye, scene.camera.target);
                    polyg.Moving(-scene.camera.eye.x + scene.bmp.Width / 2, -scene.camera.eye.y + scene.bmp.Height / 2, -scene.camera.eye.z);
                    DrawTriangle(polyg, scene);
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
        void DrawLine(Point p1, Point p2, WorkScene scene, Color color)
        {
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
                        if (P.x >= scene.bmp.Width || P.x < 0 || P.y >= scene.bmp.Height || P.y < 0 || new Line(scene.camera.eye, P).Length < scene.camera.near || new Line(scene.camera.eye, P).Length > scene.camera.far) continue;
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
                string[] cam_str = stream.ReadLine().Split(sep);
                string[] targ_str = stream.ReadLine().Split(sep);
                scene.camera.eye = new Point(Double.Parse(cam_str[1]), Double.Parse(cam_str[2]), Double.Parse(cam_str[3]));
                scene.camera.target = new Point(Double.Parse(targ_str[1]), Double.Parse(targ_str[2]), Double.Parse(targ_str[3]));
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
                        continue;
                    }
                    string[] line = service.Split(sep);
                    if (line.Length == 13)
                    {
                        paramObj.Start = new Point(double.Parse(line[0]), double.Parse(line[1]), double.Parse(line[2]));
                        paramObj.bar_len = double.Parse(line[3]);
                        paramObj.bar_diam = double.Parse(line[4]);
                        paramObj.mag_len = double.Parse(line[5]);
                        paramObj.box_width = double.Parse(line[6]);
                        paramObj.cev_len = double.Parse(line[7]);
                        paramObj.targ_ang = double.Parse(line[8]);
                        paramObj.nas = int.Parse(line[9]);
                        paramObj.rings = int.Parse(line[10]);
                        paramObj.sp_ang = double.Parse(line[11]);
                        paramObj.dist = double.Parse(line[12]);
                    }
                    else
                    {
                        Triangle polygon = new Triangle(new Point(double.Parse(line[0]), double.Parse(line[1]), double.Parse(line[2])), new Point(double.Parse(line[3]), double.Parse(line[4]), double.Parse(line[5])), new Point(double.Parse(line[6]), double.Parse(line[7]), double.Parse(line[8])), Color.FromArgb(int.Parse(line[9])));
                        paramObj.polygs.Add(polygon);
                    }

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
                vertex += "cam:" + scene.camera.eye.x + "/" + scene.camera.eye.y + "/" + scene.camera.eye.z + "\n";
                vertex += "targ:" + scene.camera.target.x + "/" + scene.camera.target.y + "/" + scene.camera.target.z + "\n";
                for (int i = 0; i < scene.objs.Count; i++)
                {
                    vertex += "[Obj]\n";
                    vertex += scene.objs[i].Start.x + "/" + scene.objs[i].Start.y + "/" + scene.objs[i].Start.z + "/" + scene.objs[i].bar_len + "/" + scene.objs[i].bar_diam + "/" + scene.objs[i].mag_len + "/" + scene.objs[i].box_width + "/" + scene.objs[i].cev_len + "/" + scene.objs[i].targ_ang + "/" + scene.objs[i].nas + "/" + scene.objs[i].rings + "/" + scene.objs[i].sp_ang + "/" + scene.objs[i].dist + "\n";
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

        private void ScaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            Point axis = new Point();
            if (lboxObj.SelectedIndex == -1)
            {
                scale = (double)ScaleUpDown.Value;
            }
            else
            {
                int index = lboxObj.SelectedIndex;
                ParamObj paramObj = (ParamObj)scene.objs[index];
                paramObj.scale = (double)ScaleUpDown.Value;
            }
            Redraw();
        }
        //Добавить вращение всех типов объектов
        private void bRotate_Click(object sender, EventArgs e)
        {
            Point axis = new Point();
            if (lboxObj.SelectedIndex == -1)
            {
                foreach (ParamObj item in scene.objs)
                {
                    foreach (Triangle initem in item.polygs)
                    {
                        initem.Reset();
                        initem.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                    }
                }
            }
            else
            {
                int index = lboxObj.SelectedIndex;
                ParamObj paramObj = scene.objs[index];
                axis = paramObj.Start;
                foreach (Triangle item in paramObj.polygs)
                {
                    item.Reset();
                    item.Rotate((double)Rotate_x.Value, (double)Rotate_y.Value, (double)Rotate_z.Value, new Point(axis));
                }
            }
            ScaleUpDown_ValueChanged(sender, e);
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
            scene.objs.RemoveAt(lboxObj.SelectedIndex);
            lboxObj.Items.RemoveAt(lboxObj.SelectedIndex);
            Redraw();
        }

        private void ПараллельнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool check = scene.center_per;
            if (check)
            {
                scene.center_per = false;
                Redraw();
            }
        }

        private void ЦентральнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool check = scene.center_per;
            if (!check)
            {
                scene.center_per = true;
                Redraw();
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            ParamForm form = new ParamForm(this, scene.objs[lboxObj.SelectedIndex].Start, scene.objs[lboxObj.SelectedIndex].bar_len, scene.objs[lboxObj.SelectedIndex].bar_diam, scene.objs[lboxObj.SelectedIndex].mag_len, scene.objs[lboxObj.SelectedIndex].box_width, scene.objs[lboxObj.SelectedIndex].cev_len, scene.objs[lboxObj.SelectedIndex].targ_ang, scene.objs[lboxObj.SelectedIndex].nas, scene.objs[lboxObj.SelectedIndex].rings, scene.objs[lboxObj.SelectedIndex].sp_ang, scene.objs[lboxObj.SelectedIndex].dist);
            form.ShowDialog();
        }

        private void lboxObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxObj.SelectedIndex != -1)
            {
                bEdit.Enabled = bDel.Enabled = true;
                ScaleUpDown.Value = Convert.ToDecimal(scene.objs[lboxObj.SelectedIndex].scale);
            }
            else
            {
                bEdit.Enabled = bDel.Enabled = false;
                ScaleUpDown.Value = Convert.ToDecimal(scale);
            }
        }

        private void bMoveCam_p_Click(object sender, EventArgs e)
        {
            byte axis = 0;
            if (rbX.Checked)
                axis = 1;
            if (rbY.Checked)
                axis = 2;
            if (rbZ.Checked)
                axis = 3;
            switch (axis)
            {
                case 1:
                    scene.camera.MoveCam(direct.right);
                    break;
                case 2:
                    scene.camera.MoveCam(direct.up);
                    break;
                case 3:
                    scene.camera.MoveCam(direct.front);
                    break;
                default:
                    break;
            }
            Redraw();
        }
        private void bMoveCam_m_Click(object sender, EventArgs e)
        {
            byte axis = 0;
            if (rbX.Checked)
                axis = 1;
            if (rbY.Checked)
                axis = 2;
            if (rbZ.Checked)
                axis = 3;
            switch (axis)
            {
                case 1:
                    scene.camera.MoveCam(direct.left);
                    break;
                case 2:
                    scene.camera.MoveCam(direct.down);
                    break;
                case 3:
                    scene.camera.MoveCam(direct.back);
                    break;
                default:
                    break;
            }
            Redraw();
        }
        private void bCen_m_Click(object sender, EventArgs e)
        {
            byte axis = 0;
            if (rbCX.Checked)
                axis = 1;
            if (rbCY.Checked)
                axis = 2;
            if (rbCZ.Checked)
                axis = 3;
            switch (axis)
            {
                case 1:
                    scene.camera.MoveTarg(direct.left);
                    break;
                case 2:
                    scene.camera.MoveTarg(direct.down);
                    break;
                case 3:
                    scene.camera.MoveTarg(direct.back);
                    break;
                default:
                    break;
            }
            Redraw();
        }
        private void bCen_p_Click(object sender, EventArgs e)
        {
            byte axis = 0;
            if (rbCX.Checked)
                axis = 1;
            if (rbCY.Checked)
                axis = 2;
            if (rbCZ.Checked)
                axis = 3;
            switch (axis)
            {
                case 1:
                    scene.camera.MoveTarg(direct.right);
                    break;
                case 2:
                    scene.camera.MoveTarg(direct.up);
                    break;
                case 3:
                    scene.camera.MoveTarg(direct.front);
                    break;
                default:
                    break;
            }
            Redraw();
        }
        private void bObj_m_Click(object sender, EventArgs e)
        {
            byte axis = 0;
            if (rbObjX.Checked)
                axis = 1;
            if (rbObjY.Checked)
                axis = 2;
            if (rbObjZ.Checked)
                axis = 3;
            switch (axis)
            {
                case 1:
                    if (lboxObj.SelectedIndex == -1)
                    {
                        foreach (ParamObj item in scene.objs)
                        {
                            item.Start.Moving(-15, 0, 0);
                            foreach (Triangle initem in item.polygs)
                            {
                                initem.Moving(-15, 0, 0);
                            }
                        }
                    }
                    else
                    {
                        int index = lboxObj.SelectedIndex;
                        ParamObj paramObj = scene.objs[index];
                        paramObj.Start.Moving(-15, 0, 0);
                        foreach (Triangle item in paramObj.polygs)
                            item.Moving(-15, 0, 0);
                    }
                    break;
                case 2:
                    if (lboxObj.SelectedIndex == -1)
                    {
                        foreach (ParamObj item in scene.objs)
                        {
                            item.Start.Moving(0, -15, 0);
                            foreach (Triangle initem in item.polygs)
                            {
                                initem.Moving(0, -15, 0);
                            }
                        }
                    }
                    else
                    {
                        int index = lboxObj.SelectedIndex;
                        ParamObj paramObj = scene.objs[index];
                        paramObj.Start.Moving(0, -15, 0);
                        foreach (Triangle item in paramObj.polygs)
                            item.Moving(0, -15, 0);
                    }
                    break;
                case 3:
                    if (lboxObj.SelectedIndex == -1)
                    {
                        foreach (ParamObj item in scene.objs)
                        {
                            item.Start.Moving(0, 0, -15);
                            foreach (Triangle initem in item.polygs)
                            {
                                initem.Moving(0, 0, -15);
                            }
                        }
                    }
                    else
                    {
                        int index = lboxObj.SelectedIndex;
                        ParamObj paramObj = scene.objs[index];
                        paramObj.Start.Moving(0, 0, -15);
                        foreach (Triangle item in paramObj.polygs)
                            item.Moving(0, 0, -15);
                    }
                    break;
                default:
                    break;
            }
            Redraw();
        }
        private void bObj_p_Click(object sender, EventArgs e)
        {
            byte axis = 0;
            if (rbObjX.Checked)
                axis = 1;
            if (rbObjY.Checked)
                axis = 2;
            if (rbObjZ.Checked)
                axis = 3;
            switch (axis)
            {
                case 1:
                    if (lboxObj.SelectedIndex == -1)
                    {
                        foreach (ParamObj item in scene.objs)
                        {
                            item.Start.Moving(15, 0, 0);
                            foreach (Triangle initem in item.polygs)
                            {
                                initem.Moving(15, 0, 0);
                            }
                        }
                    }
                    else
                    {
                        int index = lboxObj.SelectedIndex;
                        ParamObj paramObj = scene.objs[index];
                        paramObj.Start.Moving(15, 0, 0);
                        foreach (Triangle item in paramObj.polygs)
                            item.Moving(15, 0, 0);
                    }
                    break;
                case 2:
                    if (lboxObj.SelectedIndex == -1)
                    {
                        foreach (ParamObj item in scene.objs)
                        {
                            item.Start.Moving(0, 15, 0);
                            foreach (Triangle initem in item.polygs)
                            {
                                initem.Moving(0, 15, 0);
                            }
                        }
                    }
                    else
                    {
                        int index = lboxObj.SelectedIndex;
                        ParamObj paramObj = scene.objs[index];
                        paramObj.Start.Moving(0, 15, 0);
                        foreach (Triangle item in paramObj.polygs)
                            item.Moving(0, 15, 0);
                    }
                    break;
                case 3:
                    if (lboxObj.SelectedIndex == -1)
                    {
                        foreach (ParamObj item in scene.objs)
                        {
                            item.Start.Moving(0, 0, 15);
                            foreach (Triangle initem in item.polygs)
                            {
                                initem.Moving(0, 0, 15);
                            }
                        }
                    }
                    else
                    {
                        int index = lboxObj.SelectedIndex;
                        ParamObj paramObj = scene.objs[index];
                        paramObj.Start.Moving(0, 0, 15);
                        foreach (Triangle item in paramObj.polygs)
                            item.Moving(0, 0, 15);
                    }
                    break;
                default:
                    break;
            }
            Redraw();
        }
    }
}
