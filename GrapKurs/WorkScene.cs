using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapKurs
{
    class WorkScene
    {
        List<Triangle> tr = new List<Triangle>();
        public List<ParamObj> objs = new List<ParamObj>();
        float near = 50;
        float far = 5000;
        Point eye = new Point(-300, -300, 300);
        Point center = new Point(0, 0, 0);
        public double pos_cam_x = 180, pos_cam_y = 0;
        public double pos_center_x, pos_center_y;
        public bool projection_centr = false;
        bool carcas = false;
        public Bitmap bmp;
        byte[] pixels;
        double[] zBuf;
        public WorkScene(int width, int height)
        {
            bmp = new Bitmap(width, height);
        }
    }
}
