using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicKurs
{
    class WorkScene
    {
        Point camera = new Point(-20, -20, 20);
        Point target = new Point(0, 0, 0);
        List<GraphicObject> objects = new List<GraphicObject>();
    }
}
