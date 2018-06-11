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
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Point(Point pt)
        {
            this.x = pt.x;
            this.y = pt.y;
            this.z = pt.z;
        }
        public static Point operator *(Point pt1, float dig)
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
        public double Area { get; }
        public double Perimeter { get; }
        public Color color;
        public Triangle(Point pt1, Point pt2, Point pt3, Color col)
        {
            this.Points = new Point[] { pt1, pt2, pt3 };
            Perimeter = new Line(pt1, pt2).Length + new Line(pt2, pt3).Length + new Line(pt3, pt1).Length;
            double p = Perimeter / 2;
            Area = Math.Sqrt(p * (p - (new Line(pt1, pt2).Length)) * (p - (new Line(pt2, pt3).Length)) * (p - (new Line(pt3, pt1).Length)));
            if (Area == 0)
            {
                throw new Exception("Площадь равна нулю");
            }
            color = col;
        }
        public Triangle(Point[] points, Color col) : this(new Point(points[0]), new Point(points[1]), new Point(points[2]), col) { }
        public Triangle(int x1, int y1, int z1, int x2, int y2, int z2, int x3, int y3, int z3, Color col) : this(new Point(x1, y1, z1), new Point(x2, y2, z2), new Point(x3, y3, z3), col) { }
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
