using System;
using System.Collections.Generic;
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
        bool projection_centr = false;
    }
}
