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
        public double x = 0;
        public double y = 0;
        public double z = 0;
        private double sx = 0;
        private double sy = 0;
        private double sz = 0;
        private double xsh = 0;
        private double ysh = 0;
        private double zsh = 0;
        public Point() { }
        public Point(double x, double y, double z)
        {
            this.x = sx = x;
            this.y = sy = y;
            this.z = sz = z;
        }
        public Point(Point pt)
        {
            x = pt.x;
            y = pt.y;
            z = pt.z;
            sx = pt.sx;
            sy = pt.sy;
            sz = pt.sz;
            xsh = pt.xsh;
            ysh = pt.ysh;
            zsh = pt.zsh;
        }
        public void Reset()
        {
            x = sx + xsh;
            y = sy + ysh;
            z = sz + zsh;
        }
        public void Resave()
        {
            sx = x;
            sy = y;
            sz = z;
        }
        public void Moving(double x_move, double y_move, double z_move)
        {
            Matrix MoveMtx = new Matrix(4);
            MoveMtx.Elems[0, 3] = x_move;
            MoveMtx.Elems[1, 3] = y_move;
            MoveMtx.Elems[2, 3] = z_move;
            Matrix PointMtx = new Matrix(4, 1);
            PointMtx.Elems[0, 0] = x;
            PointMtx.Elems[1, 0] = y;
            PointMtx.Elems[2, 0] = z;
            PointMtx.Elems[3, 0] = 1;
            Matrix res = new Matrix(MoveMtx.Rows, PointMtx.Columns);
            res = MoveMtx * PointMtx;
            x = res.Elems[0, 0] / res.Elems[3, 0];
            y = res.Elems[1, 0] / res.Elems[3, 0];
            z = res.Elems[2, 0] / res.Elems[3, 0];
            xsh += x_move;
            ysh += y_move;
            zsh += z_move;
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
        public void Scale(double x_scale, double y_scale, double z_scale, Point axis)
        {
            if (x_scale <= 0 || y_scale <= 0 || z_scale <= 0)
                return;
            Matrix TMtx = new Matrix(4);
            TMtx.Elems[0, 0] = x_scale;
            TMtx.Elems[1, 1] = y_scale;
            TMtx.Elems[2, 2] = z_scale;
            Moving(-axis.x, -axis.y, -axis.z);
            Matrix PMtx = new Matrix(4, 1);
            PMtx.Elems[0, 0] = x;
            PMtx.Elems[1, 0] = y;
            PMtx.Elems[2, 0] = z;
            PMtx.Elems[3, 0] = 1;
            Matrix res = new Matrix(TMtx.Rows, PMtx.Columns);
            res = TMtx * PMtx;
            x = (int)res.Elems[0, 0] / (int)res.Elems[3, 0];
            y = (int)res.Elems[1, 0] / (int)res.Elems[3, 0];
            z = (int)res.Elems[2, 0] / (int)res.Elems[3, 0];
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
            Matrix PMtx = new Matrix(4, 1);
            PMtx.Elems[0, 0] = x;
            PMtx.Elems[1, 0] = y;
            PMtx.Elems[2, 0] = z;
            PMtx.Elems[3, 0] = 1;
            Matrix res = new Matrix(TMtx.Rows, PMtx.Columns);
            res = TMtx * PMtx;
            x = res.Elems[0, 0] / res.Elems[3, 0];
            y = res.Elems[1, 0] / res.Elems[3, 0];
            z = res.Elems[2, 0] / res.Elems[3, 0];
            Moving(-axis.x, -axis.y, -axis.z);
        }
        public void Transform(double x_scale, double y_scale, double z_scale, double xy, double xz, double yx, double yz, double zx, double zy)
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
            Matrix PMtx = new Matrix(4, 1);
            PMtx.Elems[0, 0] = x;
            PMtx.Elems[1, 0] = y;
            PMtx.Elems[2, 0] = z;
            PMtx.Elems[3, 0] = 1;
            Matrix res = new Matrix(TMtx.Rows, PMtx.Columns);
            res = TMtx * PMtx;
            x = (int)res.Elems[0, 0] / (int)res.Elems[3, 0];
            y = (int)res.Elems[1, 0] / (int)res.Elems[3, 0];
            z = (int)res.Elems[2, 0] / (int)res.Elems[3, 0];

            PMtx.Elems[0, 0] = sx;
            PMtx.Elems[1, 0] = sy;
            PMtx.Elems[2, 0] = sz;
            PMtx.Elems[3, 0] = 1;
            res = new Matrix(TMtx.Rows, PMtx.Columns);
            res = TMtx * PMtx;
            sx = res.Elems[0, 0] / res.Elems[3, 0];
            sy = res.Elems[1, 0] / res.Elems[3, 0];
            sz = res.Elems[2, 0] / res.Elems[3, 0];

        }
        public Point Outlook(double distance)
        {
            Matrix OlMtx = new Matrix(4);
            OlMtx.Elems[3, 2] = -1 / distance;
            Matrix PMtx = new Matrix(4, 1);
            PMtx.Elems[0, 0] = x;
            PMtx.Elems[1, 0] = y;
            PMtx.Elems[2, 0] = z;
            PMtx.Elems[3, 0] = 1;
            Matrix res = new Matrix(OlMtx.Rows, PMtx.Columns);
            res = OlMtx * PMtx;
            return new Point(res.Elems[0, 0] / res.Elems[3, 0], res.Elems[1, 0] / res.Elems[3, 0], res.Elems[2, 0] / res.Elems[3, 0]);
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
            Points = new Point[] { pt1, pt2 };
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
        public double Area;
        public Triangle(Triangle triangle)
        {
            triangle.Points.CopyTo(Points, 0);
            Center = new Point(triangle.Center);
            Color = triangle.Color;
        }
        public Triangle(Point pt1, Point pt2, Point pt3, Color color)
        {
            double[] side = new double[3];
            side[0] = new Line(pt1, pt2).Length;
            side[1] = new Line(pt2, pt3).Length;
            side[2] = new Line(pt3, pt1).Length;
            double p = side.Sum() / 2;
            Area = Math.Sqrt(p * (p - side[0]) * (p - side[1]) * (p - side[2]));
            Points = new Point[] { pt1, pt2, pt3 };
            Center = new Point((Points[0].x + Points[1].x + Points[2].x) / 3, (Points[0].y + Points[1].y + Points[2].y) / 3, (Points[0].z + Points[1].z + Points[2].z) / 3);
            Color = color;
        }
        public Triangle(Point[] points, Color col) : this(new Point(points[0]), new Point(points[1]), new Point(points[2]), col) { }
        public void Reset()
        {
            for (int i = 0; i < 3; i++)
                Points[i].Reset();
        }
        public void Resave()
        {
            for (int i = 0; i < 3; i++)
            {
                Points[i].Resave();
            }
        }
        public void Scale(double x_scale, double y_scale, double z_scale, Point axis)
        {
            for (int i = 0; i < 3; i++)
                Points[i].Scale(x_scale, y_scale, z_scale, axis);
        }
        public void Slip(double xy, double xz, double yx, double yz, double zx, double zy, Point axis)
        {
            for (int i = 0; i < 3; i++)
                Points[i].Slip(xy, xz, yx, yz, zx, zy, axis);
        }
        private void Transform(double x_scale, double y_scale, double z_scale, double xy, double xz, double yx, double yz, double zx, double zy)
        {
            for (int i = 0; i < 3; i++)
                Points[i].Transform(x_scale, y_scale, z_scale, xy, xz, yx, yz, zx, zy);
        }
        public void Rotate(double x_angle, double y_angle, double z_angle, Point axis)
        {
            for (int i = 0; i < 3; i++)
                Points[i].Rotate(x_angle, y_angle, z_angle, axis);
        }
        public void Moving(double x_move, double y_move, double z_move)
        {
            for (int i = 0; i < 3; i++)
                Points[i].Moving(x_move, y_move, z_move);
            Center.Moving(x_move, y_move, z_move);
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
            for (int i = 0; i < polygons.Length; i++)
                polygons[i] = new Triangle(new Point(center), new Point((int)(center.x + radius * (Math.Cos(Math.PI * (i / (polygons.Length / 2.0))))), (int)(center.y + radius * (Math.Sin(Math.PI * (i / (polygons.Length / 2.0))))), center.z), new Point((int)(center.x + radius * (Math.Cos(Math.PI * ((i + 1.0) / (polygons.Length / 2.0))))), (int)(center.y + radius * (Math.Sin(Math.PI * ((i + 1.0) / (polygons.Length / 2.0))))), center.z), color);
        }
        public void Reset()
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Reset();
        }
        public void Resave()
        {
            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].Resave();
            }
        }
        public void Scale(double x_scale, double y_scale, double z_scale, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Scale(x_scale, y_scale, z_scale, axis);
        }
        public void Slip(double xy, double xz, double yx, double yz, double zx, double zy, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Slip(xy, xz, yx, yz, zx, zy, axis);
        }
        public void Rotate(double x_angle, double y_angle, double z_angle, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Rotate(x_angle, y_angle, z_angle, axis);
        }
        public void Moving(double x_move, double y_move, double z_move)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Moving(x_move, y_move, z_move);
            Center.Moving(x_move, y_move, z_move);
        }
    }
    public class Rectangle
    {
        public Triangle[] polygons = new Triangle[2];
        public double Area;
        public Rectangle(Point pt1, Point pt2, Color color)
        {
            polygons[0] = new Triangle(new Point(pt1), new Point(pt2), new Point(pt1.x, pt2.y, pt1.z), color);
            polygons[1] = new Triangle(new Point(pt1), new Point(pt2), new Point(pt2.x, pt1.y, pt2.z), color);
            if (polygons[0].Area + polygons[1].Area == 0)
            {
                polygons[0] = new Triangle(new Point(pt1), new Point(pt2), new Point(pt1.x, pt2.y, pt2.z), color);
                polygons[1] = new Triangle(new Point(pt1), new Point(pt2), new Point(pt2.x, pt1.y, pt1.z), color); 
            }
            Area = polygons[0].Area + polygons[1].Area;
        }
        public Rectangle(Point pt1, Point pt2, Point pt3, Point pt4, Color color)
        {
            polygons[0] = new Triangle(new Point(pt1), new Point(pt2), new Point(pt3), color);
            polygons[1] = new Triangle(new Point(pt3), new Point(pt4), new Point(pt1), color);
            Area = polygons[0].Area + polygons[1].Area;
        }
        public void Reset()
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Reset();
        }
        public void Resave()
        {
            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].Resave();
            }
        }
        public void Scale(double x_scale, double y_scale, double z_scale, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Scale(x_scale, y_scale, z_scale, axis);
        }
        public void Slip(double xy, double xz, double yx, double yz, double zx, double zy, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Slip(xy, xz, yx, yz, zx, zy, axis);
        }
        public void Rotate(double x_angle, double y_angle, double z_angle, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Rotate(x_angle, y_angle, z_angle, axis);
        }
        public void Moving(double x_move, double y_move, double z_move)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Moving(x_move, y_move, z_move);
        }
    }
    public class Box
    {
        public Triangle[] polygons = new Triangle[12];
        public Box(Point pt1, Point pt2, Color color)
        {
            Rectangle[] faces = new Rectangle[6];
            faces[0] = new Rectangle(new Point(pt1), new Point(pt2.x, pt1.y, pt2.z), color);
            faces[1] = new Rectangle(new Point(pt1), new Point(pt1.x, pt2.y, pt2.z), color);
            faces[2] = new Rectangle(new Point(pt1), new Point(pt2.x, pt2.y, pt1.z), color);
            faces[3] = new Rectangle(new Point(pt2), new Point(pt2.x, pt1.y, pt1.z), color);
            faces[4] = new Rectangle(new Point(pt2), new Point(pt1.x, pt2.y, pt1.z), color);
            faces[5] = new Rectangle(new Point(pt2), new Point(pt1.x, pt1.y, pt2.z), color);
            int k = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = faces[i].polygons[j];
                }
            }
        }
        public void Reset()
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Reset();
        }
        public void Resave()
        {
            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].Resave();
            }
        }
        public void Scale(double x_scale, double y_scale, double z_scale, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Scale(x_scale, y_scale, z_scale, axis);
        }
        public void Slip(double xy, double xz, double yx, double yz, double zx, double zy, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Slip(xy, xz, yx, yz, zx, zy, axis);
        }
        public void Rotate(double x_angle, double y_angle, double z_angle, Point axis)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Rotate(x_angle, y_angle, z_angle, axis);
        }
        public void Moving(double x_move, double y_move, double z_move)
        {
            for (int i = 0; i < polygons.Length; i++)
                polygons[i].Moving(x_move, y_move, z_move);
        }
    }
    public class Cone
    {
        public Triangle[] polygons = new Triangle[80];
        public Circle Bottom;
        public Circle Top;
        public Rectangle[] Sides = new Rectangle[20];
        public Cone(Point bottom_center, double bottom_radius, double top_radius, double height, Color color)
        {
            int k = 0;
            Bottom = new Circle(bottom_center, bottom_radius, color);
            Bottom.Rotate(-90, 0, 0, Bottom.Center);
            Bottom.Resave();
            for (int i = 0; i < 20; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            Top = new Circle(new Point(bottom_center.x, bottom_center.y + height, bottom_center.z), top_radius, color);
            Top.Rotate(-90, 0, 0, Top.Center);
            Top.Resave();
            for (int i = 0; i < 20; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < 20; i++)
            {
                Sides[i] = new Rectangle(new Point(Bottom.polygons[i].Points[1]), new Point(Bottom.polygons[i].Points[2]), new Point(Top.polygons[i].Points[2]), new Point(Top.polygons[i].Points[1]), color);
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
        public void Reset()
        {
            Bottom.Reset();
            Top.Reset();
            for (int i = 0; i < Sides.Length; i++)
                Sides[i].Reset();
            int k = 0;
            for (int i = 0; i < Bottom.polygons.Length; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            for (int i = 0; i < Top.polygons.Length; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < Sides.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
        public void Scale(double x_scale, double y_scale, double z_scale, Point axis)
        {
            Bottom.Scale(x_scale, y_scale, z_scale, axis);
            Top.Scale(x_scale, y_scale, z_scale, axis);
            for (int i = 0; i < Sides.Length; i++)
                Sides[i].Scale(x_scale, y_scale, z_scale, axis);
            int k = 0;
            for (int i = 0; i < Bottom.polygons.Length; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            for (int i = 0; i < Top.polygons.Length; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < Sides.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
        public void Slip(double xy, double xz, double yx, double yz, double zx, double zy, Point axis)
        {
            Bottom.Slip(xy, xz, yx, yz, zx, zy, axis);
            Top.Slip(xy, xz, yx, yz, zx, zy, axis);
            for (int i = 0; i < Sides.Length; i++)
                Sides[i].Slip(xy, xz, yx, yz, zx, zy, axis);
            int k = 0;
            for (int i = 0; i < Bottom.polygons.Length; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            for (int i = 0; i < Top.polygons.Length; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < Sides.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
        public void Rotate(double x_angle, double y_angle, double z_angle, Point axis)
        {
            Bottom.Rotate(x_angle, y_angle, z_angle, axis);
            Top.Rotate(x_angle, y_angle, z_angle, axis);
            for (int i = 0; i < Sides.Length; i++)
                Sides[i].Rotate(x_angle, y_angle, z_angle, axis);
            int k = 0;
            for (int i = 0; i < Bottom.polygons.Length; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            for (int i = 0; i < Top.polygons.Length; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < Sides.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
        public void Moving(double x_move, double y_move, double z_move)
        {
            Bottom.Moving(x_move, y_move, z_move);
            Top.Moving(x_move, y_move, z_move);
            for (int i = 0; i < Sides.Length; i++)
                Sides[i].Moving(x_move, y_move, z_move);
            int k = 0;
            for (int i = 0; i < Bottom.polygons.Length; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            for (int i = 0; i < Top.polygons.Length; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < Sides.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
    }
    public class Cylinder:Cone
    {
        public Cylinder(Point bottom_center, double radius, double height, Color color) : base(bottom_center, radius, radius, height, color) { }
    }
    public class Ring
    {
        public Triangle[] polygons = new Triangle[40];
        public Circle Bottom;
        public Circle Top;
        public Point Center { get; set; }
        public Rectangle[] Sides = new Rectangle[20];
        public Ring(Point center, double first_radius, double second_radius, Color color)
        {
            int k = 0;
            Bottom = new Circle(center, first_radius, color);
            Top = new Circle(center, second_radius, color);
            for (int i = 0; i < Sides.Length; i++)
            {
                Sides[i] = new Rectangle(new Point(Bottom.polygons[i].Points[1]), new Point(Bottom.polygons[i].Points[2]), new Point(Top.polygons[i].Points[2]), new Point(Top.polygons[i].Points[1]), color);
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
            Center = new Point(Bottom.Center);
        }
        public void Reset()
        {
            Bottom.Reset();
            Top.Reset();
            for (int i = 0; i < Sides.Length; i++)
                Sides[i].Reset();
            int k = 0;
            for (int i = 0; i < Bottom.polygons.Length; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            for (int i = 0; i < Top.polygons.Length; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < Sides.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
        public void Scale(double x_scale, double y_scale, double z_scale, Point axis)
        {
            Bottom.Scale(x_scale, y_scale, z_scale, axis);
            Top.Scale(x_scale, y_scale, z_scale, axis);
            for (int i = 0; i < Sides.Length; i++)
                Sides[i].Scale(x_scale, y_scale, z_scale, axis);
            int k = 0;
            for (int i = 0; i < Bottom.polygons.Length; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            for (int i = 0; i < Top.polygons.Length; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < Sides.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
        public void Slip(double xy, double xz, double yx, double yz, double zx, double zy, Point axis)
        {
            Bottom.Slip(xy, xz, yx, yz, zx, zy, axis);
            Top.Slip(xy, xz, yx, yz, zx, zy, axis);
            for (int i = 0; i < Sides.Length; i++)
                Sides[i].Slip(xy, xz, yx, yz, zx, zy, axis);
            int k = 0;
            for (int i = 0; i < Bottom.polygons.Length; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            for (int i = 0; i < Top.polygons.Length; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < Sides.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
        public void Rotate(double x_angle, double y_angle, double z_angle, Point axis)
        {
            Bottom.Rotate(x_angle, y_angle, z_angle, axis);
            Top.Rotate(x_angle, y_angle, z_angle, axis);
            for (int i = 0; i < Sides.Length; i++)
                Sides[i].Rotate(x_angle, y_angle, z_angle, axis);
            int k = 0;
            /*for (int i = 0; i < Bottom.polygons.Length; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            for (int i = 0; i < Top.polygons.Length; i++)
            {
                polygons[k++] = Top.polygons[i];
            }*/
            for (int i = 0; i < Sides.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
        public void Moving(double x_move, double y_move, double z_move)
        {
            Bottom.Moving(x_move, y_move, z_move);
            Top.Moving(x_move, y_move, z_move);
            for (int i = 0; i < Sides.Length; i++)
                Sides[i].Moving(x_move, y_move, z_move);
            int k = 0;
            for (int i = 0; i < Bottom.polygons.Length; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            for (int i = 0; i < Top.polygons.Length; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < Sides.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
        public void Resave()
        {
            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].Resave();
            }
        }
    }
    public class Tube
    {
        public Triangle[] polygons = new Triangle[160];
        public Ring Bottom;
        public Ring Top;
        public Rectangle[] Sides = new Rectangle[40];
        public Tube(Point bottom_center, double first_radius, double second_radius, double height, Color color)
        {
            int k = 0;
            Bottom = new Ring(new Point(bottom_center), first_radius, second_radius, color);
            Bottom.Rotate(-90, 0, 0, Bottom.Center);
            Bottom.Resave();
            for (int i = 0; i < 40; i++)
            {
                polygons[k++] = Bottom.polygons[i];
            }
            Top = new Ring(new Point(bottom_center.x, bottom_center.y + height, bottom_center.z), first_radius, second_radius, color);
            Top.Rotate(-90, 0, 0, Top.Center);
            Top.Resave();
            for (int i = 0; i < 40; i++)
            {
                polygons[k++] = Top.polygons[i];
            }
            for (int i = 0; i < Sides.Length; i++)
            {
                Sides[i] = new Rectangle(new Point(Bottom.polygons[i].Points[2]), new Point(Top.polygons[i].Points[2]), new Point(Bottom.polygons[i].Points[0]), new Point(Top.polygons[i].Points[0]), color);
                for (int j = 0; j < 2; j++)
                {
                    polygons[k++] = Sides[i].polygons[j];
                }
            }
        }
    }
}
