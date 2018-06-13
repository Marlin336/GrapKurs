using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrapKurs
{
    public class Point
    {
        public double x { get; set; } = 0;
        public double y { get; set; } = 0;
        public double z { get; set; } = 0;
        public Point() { }
        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Point(Point pt)
        {
            x = pt.x;
            y = pt.y;
            z = pt.z;
        }
        public static Point operator *(Point pt1, double dig)
        {
            return new Point((pt1.x * dig), (pt1.y * dig), (pt1.z * dig));
        }
        public static bool operator ==(Point pt1, Point pt2)
        {
            if (pt1.x == pt2.x && pt1.y == pt2.y && pt1.z == pt2.z)
                return true;
            else
                return false;
        }
        public static bool operator !=(Point pt1, Point pt2)
        {
            if (pt1.x != pt2.x || pt1.y != pt2.y || pt1.z != pt2.z)
                return true;
            else
                return false;
        }
        public static Point operator +(Point pt1, Point pt2)
        {
            return new Point(pt1.x + pt2.x, pt1.y + pt2.y, pt1.z + pt2.z);
        }
        public static Point operator -(Point pt)
        {
            return new Point(-pt.x, -pt.y, -pt.z);
        }
        public static Point operator -(Point pt1, Point pt2)
        {
            return pt1 + (-pt2);
        }
        public override bool Equals(object obj)
        {
            var point = obj as Point;
            return point != null &&
                   x == point.x &&
                   y == point.y &&
                   z == point.z;
        }
        public override int GetHashCode()
        {
            var hashCode = 373119288;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }
    }
    public class Line
    {
        public Point[] Points { get; } = new Point[2];
        public double Length { get; }
        public Line(Point pt1, Point pt2)
        {
            if (pt1 == pt2)
            {
                throw new Exception("pt1 и pt2 одна и та же точка");
            }
            this.Points = new Point[] { pt1, pt2 };
            Length = Math.Sqrt(Math.Pow(pt1.x - pt2.x, 2) + Math.Pow(pt1.y - pt2.y, 2) + Math.Pow(pt1.z - pt2.z, 2));
        }
        public Line(Point[] points) : this(new Point(points[0]), new Point(points[1])) { }
        public Line(float x1, float y1, float z1, float x2, float y2, float z2) : this(new Point(x1, y1, z1), new Point(x2, y2, z2)) { }
    }
    public class Triangle
    {
        public Point[] Points { get; } = new Point[3];
        public Point Center { get; }
        public Color Color;
        public Triangle(Point pt1, Point pt2, Point pt3, Color color)
        {
            Points = new Point[] { pt1, pt2, pt3 };
            Center = new Point((Points[0].x + Points[1].x + Points[2].x) / 3, (Points[0].y + Points[1].y + Points[2].y) / 3, (Points[0].z + Points[1].z + Points[2].z) / 3);
            Color = color;
        }
        public Triangle(Point[] points, Color col) : this(new Point(points[0]), new Point(points[1]), new Point(points[2]), col) { }
        public Triangle(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, Color col) : this(new Point(x1, y1, z1), new Point(x2, y2, z2), new Point(x3, y3, z3), col) { }
        public void Scale(double x_scale, double y_scale, double z_scale, Point axis)
        {
            if (x_scale <=0 || y_scale <= 0 || z_scale <= 0) 
                return;
            Matrix TMtx = new Matrix(4);
            TMtx.Elems[0, 0] = x_scale;
            TMtx.Elems[1, 1] = y_scale;
            TMtx.Elems[2, 2] = z_scale;
            Moving(-axis.x, -axis.y, -axis.z);
            for (int i = 0; i < 3; i++)
            {
                Matrix PMtx = new Matrix(4, 1);
                PMtx.Elems[0, 0] = Points[i].x;
                PMtx.Elems[1, 0] = Points[i].y;
                PMtx.Elems[2, 0] = Points[i].z;
                PMtx.Elems[3, 0] = 1;
                Matrix res = new Matrix(TMtx.Rows, PMtx.Columns);
                res = TMtx * PMtx;
                Points[i].x = (int)res.Elems[0, 0] / (int)res.Elems[3, 0];
                Points[i].y = (int)res.Elems[1, 0] / (int)res.Elems[3, 0];
                Points[i].z = (int)res.Elems[2, 0] / (int)res.Elems[3, 0];
            }
            Moving(axis.x, axis.y, axis.z);
        }
        public void Slip(double xy, double xz, double yx, double yz, double zx, double zy, Point axis)
        {
            Matrix TMtx = new Matrix(4);
            TMtx.Elems[0, 1] = xy;
            TMtx.Elems[0, 2] = xz;
            TMtx.Elems[1, 0] = yx;
            TMtx.Elems[1, 2] = yz;
            TMtx.Elems[2, 0] = zx;
            TMtx.Elems[2, 1] = zy;
            Moving(-axis.x, -axis.y, -axis.z);
            for (int i = 0; i < 3; i++)
            {
                Matrix PMtx = new Matrix(4, 1);
                PMtx.Elems[0, 0] = Points[i].x;
                PMtx.Elems[1, 0] = Points[i].y;
                PMtx.Elems[2, 0] = Points[i].z;
                PMtx.Elems[3, 0] = 1;
                Matrix res = new Matrix(TMtx.Rows, PMtx.Columns);
                res = TMtx * PMtx;
                Points[i].x = (int)res.Elems[0, 0] / (int)res.Elems[3, 0];
                Points[i].y = (int)res.Elems[1, 0] / (int)res.Elems[3, 0];
                Points[i].z = (int)res.Elems[2, 0] / (int)res.Elems[3, 0];
            }
            Moving(-axis.x, -axis.y, -axis.z);
        }
        private void Transform(double x_scale, double y_scale, double z_scale, double xy, double xz, double yx, double yz, double zx, double zy)
        {
            Matrix TMtx = new Matrix(4);
            TMtx.Elems[0, 0] = x_scale;
            TMtx.Elems[1, 1] = y_scale;
            TMtx.Elems[2, 2] = z_scale;
            TMtx.Elems[0, 1] = xy;
            TMtx.Elems[0, 2] = xz;
            TMtx.Elems[1, 0] = yx;
            TMtx.Elems[1, 2] = yz;
            TMtx.Elems[2, 0] = zx;
            TMtx.Elems[2, 1] = zy;
            for (int i = 0; i < 3; i++)
            {
                Matrix PMtx = new Matrix(4, 1);
                PMtx.Elems[0, 0] = Points[i].x;
                PMtx.Elems[1, 0] = Points[i].y;
                PMtx.Elems[2, 0] = Points[i].z;
                PMtx.Elems[3, 0] = 1;
                Matrix res = new Matrix(TMtx.Rows, PMtx.Columns);
                res = TMtx * PMtx;
                Points[i].x = (int)res.Elems[0, 0] / (int)res.Elems[3, 0];
                Points[i].y = (int)res.Elems[1, 0] / (int)res.Elems[3, 0];
                Points[i].z = (int)res.Elems[2, 0] / (int)res.Elems[3, 0];
            }
        }
        public void Rotate(double x_angle, double y_angle, double z_angle, Point axis)
        {
            double x = x_angle * (Math.PI / 180);//Градусы -> радианы
            double y = y_angle * (Math.PI / 180);
            double z = z_angle * (Math.PI / 180);
            Moving(-axis.x, -axis.y, -axis.z);
            Transform(1, Math.Cos(x), Math.Cos(x), 0, 0, 0, -Math.Sin(x), 0, Math.Sin(x));
            Transform(Math.Cos(y), 1, Math.Cos(y), 0, Math.Sin(y), 0, 0, -Math.Sin(y), 0);
            Transform(Math.Cos(z), Math.Cos(z), 1, -Math.Sin(z), 0, Math.Sin(z), 0, 0, 0);
            Moving(axis.x, axis.y, axis.z);
        }
        public void Moving(double x_move, double y_move, double z_move)
        {
            Matrix MoveMtx = new Matrix(4);
            MoveMtx.Elems[0, 3] = x_move;
            MoveMtx.Elems[1, 3] = y_move;
            MoveMtx.Elems[2, 3] = z_move;
            for (int i = 0; i < 3; i++)
            {
                Matrix PointMtx = new Matrix(4, 1);
                PointMtx.Elems[0, 0] = Points[i].x;
                PointMtx.Elems[1, 0] = Points[i].y;
                PointMtx.Elems[2, 0] = Points[i].z;
                PointMtx.Elems[3, 0] = 1;
                Matrix res = new Matrix(MoveMtx.Rows, PointMtx.Columns);
                res = MoveMtx * PointMtx;
                Points[i].x = (int)res.Elems[0, 0] / (int)res.Elems[3, 0];
                Points[i].y = (int)res.Elems[1, 0] / (int)res.Elems[3, 0];
                Points[i].z = (int)res.Elems[2, 0] / (int)res.Elems[3, 0];
            }
        }
    }
    public class Circle
    {
        public Triangle[] polygons { get; } = new Triangle[20];
        public Point Center { get; }
        public double Radius { get; }
        private double Area { get; }
        public Color Color;
        public Circle(Point center, double radius, Color color)
        {
            Radius = radius;
            Color = color;
            Center = center;
            Area = Math.PI * radius * radius;
            if (Area == 0)
                throw new Exception("Площадь равна нулю");
            for (int i = 0; i < polygons.Length; i++)
                polygons[i]= new Triangle(new Point(center), new Point((int)(center.x + radius * (Math.Cos(Math.PI * (i / (polygons.Length/2.0))))), (int)(center.y + radius * (Math.Sin(Math.PI * (i / (polygons.Length/2.0))))), center.z), new Point((int)(center.x + radius * (Math.Cos(Math.PI * ((i + 1.0) / (polygons.Length/2.0))))), (int)(center.y + radius * (Math.Sin(Math.PI * ((i + 1.0) / (polygons.Length/2.0))))), center.z), color);
        }
        public void Scale(double x_scale, double y_scale, double z_scale, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].Scale(x_scale, y_scale, z_scale, axis);
            }
        }
        public void Slip(double xy, double xz, double yx, double yz, double zx, double zy, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].Slip(xy, xz, yx, yz, zx, zy, axis);
            }
        }
        public void Rotate(double x_angle, double y_angle, double z_angle, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].Rotate(x_angle, y_angle, z_angle, axis);
            }
        }
        public void Moving(float x_move, float y_move, float z_move)
        {
            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].Moving(x_move, y_move, z_move);
            }
        }
    }
    /*public class Rectangle
    {
        public Point[] Points { get; } = new Point[4];
        public double Area { get; }
        public Rectangle(Point pt1, Point pt2)
        {
            this.Points = new Point[] { pt1, new Point(pt1.x, pt2.y, pt2.z), pt2, new Point(pt2.x, pt1.y, pt1.z) };
            Area = new Line(Points[0], Points[1]).Length * new Line(Points[0], Points[3]).Length;
            if (Area == 0)
            {
                throw new Exception("Площадь равна нулю");
            }
        }
        public Rectangle(Point[] points) : this(new Point(points[0]), new Point(points[1])) { }
        public Rectangle(double x1, double y1, double z1, double x2, double y2, double z2) : this(new Point(x1, y1, z1), new Point(x2, y2, z2)) { }
        public Rectangle(Point startpt, double length, double width) : this(startpt, new Point(startpt.x + length, startpt.y + width, startpt.z)) { }
    }
    public class Circle
    {
        public Point Center { get; }
        public double Radius { get; }
        public double Area { get; }
        public double Circuit { get; }
        public Circle(Point center, double radius)
        {
            this.Radius = radius;
            this.Center = center;
            Area = Math.PI * radius * radius;
            Circuit = 2 * Math.PI * radius;
            if (Area == 0)
            {
                throw new Exception("Площадь равна нулю");
            }
        }
        public Circle(Point pt1, Point pt2) : this(new Point((pt1.x + pt2.x) / 2, (pt1.y + pt2.y) / 2, (pt1.z + pt2.z) / 2), new Line(pt1, pt2).Length / 2) { }
    }
    public class Box
    {
        public Rectangle Basis { get; }
        public double Height { get; }
        public double Volume { get; }
        public Box(Rectangle basis, double height)
        {
            this.Basis = basis;
            this.Height = height;
            Volume = basis.Area * Math.Abs(height);
            if (Volume == 0)
            {
                throw new Exception("Объём равен нулю");
            }
        }
        public Box(Point startpt, double length, double width, double height): this(new Rectangle(startpt, length, width), height) { }
    }
    public class Cylinder
    {
        public Circle Basis { get; }
        public double Height { get; }
        public double Volume { get; }
        public Cylinder(Circle basis, double height)
        {
            this.Basis = basis;
            this.Height = height;
            Volume = basis.Area * Math.Abs(height);
            if (Volume == 0)
            {
                throw new Exception("Объём равен нулю");
            }
        }
    }
    public class Tube : Cylinder
    {
        public Circle Hole { get; }
        public Tube(Circle basis, Circle hole, double height) : base(basis, height)
        {
            if (hole.Area >= basis.Area)
            {
                throw new Exception("Радиус цилиндра-отверстия не меньше основного цилиндра");
            }
            this.Hole = hole;
        }
    }*/
}
