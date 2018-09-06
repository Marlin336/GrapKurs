using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapKurs
{
    public class ParamObj
    {
        public Point Start { set; get; }
        public double bar_len, bar_diam, mag_len, box_width, cev_len, targ_ang, sp_ang, dist;
        public int nas, rings;
        public List<Triangle> polygs = new List<Triangle>();
        public ParamObj(){  }
        public ParamObj(Point start_point, double bar_len, double bar_diam, double mag_len, double box_width, double cev_len, double targ_ang, int nas, int rings, double sp_ang, double dist)
        {
            Start = new Point(start_point);
            this.bar_len = bar_len;
            this.bar_diam = bar_diam;
            this.mag_len = mag_len;
            this.box_width = box_width;
            this.cev_len = cev_len;
            this.targ_ang = targ_ang;
            this.sp_ang = sp_ang;
            this.dist = dist;
            this.nas = nas;
            this.rings = rings;
            /*Ствол*/
            Tube barrel = new Tube(Start, bar_diam, bar_diam - 1.5, bar_len, Color.DarkGray);//bar_len = 200; bar_diam = 4
            barrel.Rotate(0, 0, 90, Start);
            barrel.Resave();
            foreach (Triangle item in barrel.polygons)
                polygs.Add(item);
            /*Магазин*/
            Cylinder magazine = new Cylinder(Start, 4, mag_len, Color.DarkGray);//mag_len = 180
            magazine.Rotate(0, 0, 90, Start);
            magazine.Moving(0, -bar_diam, 0);
            magazine.Resave();
            foreach (Triangle item in magazine.polygons)
                polygs.Add(item);
            /*Цевьё*/
            Cylinder cev = new Cylinder(Start, 5.5, cev_len, Color.SaddleBrown);//cev_len = 170
            cev.Rotate(0, 0, 90, Start);
            cev.Scale(1, 1.3, 1, Start);
            cev.Moving(0, -bar_diam + 2, 0);
            cev.Resave();
            foreach (Triangle item in cev.polygons)
                polygs.Add(item);
            /*Затворная коробка*/
            Point box1 = new Point(Start.x, Start.y + 7 + bar_diam, Start.z + box_width / 2); //box_width = 6
            Point box2 = new Point(Start.x + 80, Start.y - (bar_diam + 3), Start.z - box_width / 2);
            Box box = new Box(box1, box2, Color.DarkGray);
            box.Resave();
            foreach (Triangle item in box.polygons)
                polygs.Add(item);
            /*Целик*/
            Point celStart = new Point(box1.x - dist, Start.y + bar_diam * 1.5 + 5, Start.z - bar_diam / 2);//dist = 30
            Box cel = new Box(celStart, new Point((celStart.x) + 25, celStart.y + 2, celStart.z + bar_diam), Color.LightGray);
            cel.Rotate(0, 0, targ_ang, celStart);//targ_ang = 8
            cel.Resave();
            foreach (Triangle item in cel.polygons)
                polygs.Add(item);
            /*Рукоять*/
            Point handStart = new Point((box1.x + 80) - 10, Start.y, Start.z);
            Cylinder hand = new Cylinder(handStart, 5, 50, Color.SaddleBrown);
            hand.Scale(1.3, 1, 1, handStart);
            hand.Rotate(0, 0, -100, handStart);
            hand.Resave();
            foreach (Triangle item in hand.polygons)
                polygs.Add(item);
            /*Приклад*/
            Point buttStart = new Point((box1.x + 80) + 35, Start.y - 7, Start.z);
            Cone butt = new Cone(buttStart, 5, 12, 70, Color.SaddleBrown);
            butt.Scale(1.5, 1, 0.7, buttStart);
            butt.Rotate(0, 0, -100, buttStart);
            butt.Resave();
            foreach (Triangle item in butt.polygons)
                polygs.Add(item);
            /*Рычаг*/
            Point cirStart = new Point(buttStart.x - 50, buttStart.y - 3, buttStart.z);
            Tube cir_trig = new Tube(cirStart, 6, 7, 5, Color.DarkGray);
            cir_trig.Rotate(90, 0, 0, cirStart);
            cir_trig.Moving(0, 0, -2.5); ;
            cir_trig.Resave();
            foreach (Triangle item in cir_trig.polygons)
                polygs.Add(item);

            Point leverStart = new Point(cirStart.x + 25, cirStart.y - 5, cirStart.z);
            Tube lever = new Tube(leverStart, 7, 8.5, 5, Color.DarkGray);
            lever.Scale(1, 1, 2.5, leverStart);
            lever.Rotate(90, 0, 75, leverStart);
            lever.Moving(0, 0, -2.5);
            lever.Resave();
            foreach (Triangle item in lever.polygons)
                polygs.Add(item);
            /*Спуск*/
            Point trigStart = new Point(cirStart.x + 2, cirStart.y + 3, cirStart.z);
            Cone trig = new Cone(trigStart, 3, 1, -8, Color.DarkGray);
            trig.Scale(0.7, 1, 1, trigStart);
            trig.Rotate(0, 0, -sp_ang, trigStart);//sp_ang = 20
            trig.Resave();
            foreach (Triangle item in trig.polygons)
                polygs.Add(item);
            /*Кольца*/
            if (rings >= 1)
            {
                Tube ring_1 = new Tube(new Point(Start.x - 60, Start.y + 1, Start.z), 7, 8, 5, Color.Silver);
                ring_1.Scale(1.2, 1, 1, ring_1.Bottom.Center);
                ring_1.Rotate(0, 0, 90, ring_1.Bottom.Center);
                ring_1.Resave();
                foreach (Triangle item in ring_1.polygons)
                    polygs.Add(item);
            }
            if (rings >= 2)
            {
                Tube ring_2 = new Tube(new Point(Start.x - 100, Start.y + 1, Start.z), 7, 8, 5, Color.Silver);
                ring_2.Scale(1.2, 1, 1, ring_2.Bottom.Center);
                ring_2.Rotate(0, 0, 90, ring_2.Bottom.Center);
                ring_2.Resave();
                foreach (Triangle item in ring_2.polygons)
                    polygs.Add(item);
            }
            if (rings == 3)
            {
                Tube ring_3 = new Tube(new Point(Start.x - 140, Start.y + 1, Start.z), 7, 8, 5, Color.Silver);
                ring_3.Scale(1.2, 1, 1, ring_3.Bottom.Center);
                ring_3.Rotate(0, 0, 90, ring_3.Bottom.Center);
                ring_3.Resave();
                foreach (Triangle item in ring_3.polygons)
                    polygs.Add(item);
            }
            /*Насечки*/
            if (nas >= 1)
            {
                Cylinder scr_1 = new Cylinder(new Point(buttStart.x + 30, buttStart.y - 5, buttStart.z), 9, 1, Color.SandyBrown);
                scr_1.Rotate(0, 0, 90, new Point(buttStart.x + 30, buttStart.y - 5, buttStart.z));
                scr_1.Scale(1, 1, 0.75, new Point(buttStart.x + 30, buttStart.y - 5, buttStart.z));
                scr_1.Resave();
                foreach (Triangle item in scr_1.polygons)
                    polygs.Add(item);
            }
            if (nas >= 2)
            {
                Cylinder scr_2 = new Cylinder(new Point(buttStart.x + 35, buttStart.y - 5, buttStart.z), 10, 1, Color.SandyBrown);
                scr_2.Rotate(0, 0, 90, new Point(buttStart.x + 35, buttStart.y - 5, buttStart.z));
                scr_2.Scale(1, 1, 0.75, new Point(buttStart.x + 35, buttStart.y - 5, buttStart.z));
                scr_2.Resave();
                foreach (Triangle item in scr_2.polygons)
                    polygs.Add(item);
            }
            if (nas >=3)
            {
                Cylinder scr_3 = new Cylinder(new Point(buttStart.x + 40, buttStart.y - 5, buttStart.z), 11, 1, Color.SandyBrown);
                scr_3.Rotate(0, 0, 90, new Point(buttStart.x + 40, buttStart.y - 5, buttStart.z));
                scr_3.Scale(1, 1, 0.75, new Point(buttStart.x + 40, buttStart.y - 5, buttStart.z));
                scr_3.Resave();
                foreach (Triangle item in scr_3.polygons)
                    polygs.Add(item);
            }
            if (nas == 4)
            {
                Cylinder scr_4 = new Cylinder(new Point(buttStart.x + 45, buttStart.y - 5, buttStart.z), 11, 1, Color.SandyBrown);
                scr_4.Rotate(0, 0, 90, new Point(buttStart.x + 45, buttStart.y - 5, buttStart.z));
                scr_4.Scale(1, 1, 0.75, new Point(buttStart.x + 45, buttStart.y - 5, buttStart.z));
                scr_4.Resave();
                foreach (Triangle item in scr_4.polygons)
                    polygs.Add(item);
            }
            Start = new Point(start_point);
        }
    }
}
