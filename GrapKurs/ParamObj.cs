using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapKurs
{
    class ParamObj
    {
        public Point Start { set; get; }
        public List<Triangle> polygs = new List<Triangle>();
        public ParamObj(Point start_point, double bar_len, double bar_diam, double mag_len, double box_width, double cev_len, double targ_ang, int nas, int rings, double sp_ang, double dist)
        {
            Start = new Point(start_point);
            Tube barrel = new Tube(Start, bar_diam, (bar_diam * 1.1), bar_len, Color.Red);
            foreach (Triangle item in barrel.polygons)
            {
                polygs.Add(item);
            }
            Cylinder magazine = new Cylinder(new Point(Start), 10, mag_len, Color.LightGray);
            magazine.Moving(0, -(bar_diam * 1.5 + 10), 0);
            foreach (Triangle item in magazine.polygons)
            {
                polygs.Add(item);
            }
            Cylinder cev = new Cylinder(Start, 10, cev_len, Color.Brown);
            cev.Scale(1.2, 1, 1, Start);
            cev.Resave();
            cev.Moving(0, -(bar_diam * 1.5 + 10), 0);
            foreach (Triangle item in cev.polygons)
            {
                polygs.Add(item);
            }
            Box box = new Box(new Point(Start.x, Start.y + bar_diam / 2, Start.z - bar_diam / 2 - box_width / 2), new Point(Start.x + 150, Start.y - bar_diam / 2, Start.z + bar_diam / 2 + box_width / 2), Color.DarkOrchid);
            foreach (Triangle item in box.polygons)
            {
                polygs.Add(item);
            }
        }
    }
}
