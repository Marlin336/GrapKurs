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
        public List<Triangle> triangles = new List<Triangle>();
        public List<Object> objs = new List<Object>();
        public Point Shifting = new Point();
        public Point eye = new Point();
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
            zBuf = new int[bmp.Width * bmp.Height];
            ClearzBuf();
        }
        public void ClearzBuf()
        {
            for (int i = 0; i < zBuf.Length; i++)
                zBuf.SetValue(int.MinValue, i);
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
                        triangles.Add(item);
                    break;
                default:
                    break;
            }
        }
    }
}
