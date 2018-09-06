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
        //public List<Triangle> triangles = new List<Triangle>();
        public List<ParamObj> objs = new List<ParamObj>();
        public Point Shifting = new Point();
        public Point eye;
        public bool fill = true;
        public bool cenoutl = false;
        public Bitmap bmp;
        public int[] zBuf;
        public WorkScene(int width, int height)
        {
            bmp = new Bitmap(width, height);
            zBuf = new int[bmp.Width * bmp.Height];
            eye = new Point(width/2, height/2,-1000);
            ClearzBuf();
        }
        public void ClearzBuf()
        {
            for (int i = 0; i < zBuf.Length; i++)
                zBuf.SetValue(int.MinValue, i);
        }
        public void AddObj(Object obj)
        {
            ParamObj paramObj = (ParamObj)obj;
            /*foreach (Triangle item in paramObj.polygs)
                triangles.Add(item);*/
            objs.Add(paramObj);
        }
    }
}
