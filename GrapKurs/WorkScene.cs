using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrapKurs
{
    class WorkScene
    {
        public List<Triangle> triangles_save = new List<Triangle>();
        public List<Triangle> triangles = new List<Triangle>();
        public double Zoom = 1;
        Point eye = new Point(100, 100, 100);
        public Point Center { get; set; }
        public double pos_cam_x = 180, pos_cam_y = 0;
        public double pos_center_x { get; set; }
        public double pos_center_y { get; set; }
        public bool projection_centr = false;
        public bool fill = true;
        public Bitmap bmp;
        public int[] zBuf;
        public WorkScene(int width, int height)
        {
            bmp = new Bitmap(width, height);
            Center = new Point(height / 2, width / 2, 0);
            zBuf = new int[bmp.Width * bmp.Height];
            ClearzBuf();
        }
        public void ClearzBuf()
        {
            for (int i = 0; i < zBuf.Length; i++)
                zBuf.SetValue(int.MinValue, i);
        }
        public void EyePos(int x_pos, int y_pos, int z_pos)
        {
            try
            {
                eye = new Point(x_pos, y_pos, z_pos);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось переместить камеру");
                throw;
            }
        }
        public void CenterPos(int x_pos, int y_pos, int z_pos)
        {
            try
            {
                Center = new Point(Center.x+x_pos, Center.y+y_pos, Center.z+z_pos);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось переместь фокус камеры");
                throw;
            }
        }
        public void AddObj(Object obj)
        {
            switch (obj.GetType().Name)
            {
                case "Triangle":
                    Triangle triangle = (Triangle)obj;
                    triangles.Add(triangle);
                    break;
                case "Circle":
                    Circle circle = (Circle)obj;
                    foreach (Triangle item in circle.polygons)
                    {
                        triangles.Add(item);
                    }
                    break;
                default:
                    break;
            }
            triangles_save = new List<Triangle>(triangles);
        }
    }
}
