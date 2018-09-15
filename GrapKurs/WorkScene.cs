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
        public List<ParamObj> objs = new List<ParamObj>();
        public Camera camera;
        public bool center_per = false;
        public bool fill = true;
        public Bitmap bmp;
        public int[] zBuf;
        public WorkScene(int width, int height)
        {
            bmp = new Bitmap(width, height);
            zBuf = new int[bmp.Width * bmp.Height];
            camera = new Camera(new Point(0, 0, 1000), new Point(0, 0, 0));
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
            objs.Add(paramObj);
        }
    }
}
