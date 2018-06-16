using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrapKurs
{
    public class WorkScene
    {
        public List<Triangle> triangles = new List<Triangle>();
        public List<Object> objs = new List<Object>();
        public Point Shifting = new Point();
        public Point eye;
        public Point focus;
        public bool fill = true;
        public bool cenoutl = true;
        public Bitmap bmp;
        public int[] zBuf;
        public WorkScene(int width, int height)
        {
            bmp = new Bitmap(width, height);
            zBuf = new int[bmp.Width * bmp.Height];
            eye = new Point(width/2, height/2,200);
            focus = new Point(width / 2, height / 2, 0);
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
                case "ParamObj":
                    ParamObj paramObj = (ParamObj)obj;
                    foreach (Triangle item in paramObj.polygs)
                        triangles.Add(item);
                    break;
                default:
                    break;
            }
            objs.Add(obj);
        }
    }
}
