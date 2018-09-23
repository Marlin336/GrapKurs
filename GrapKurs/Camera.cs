using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapKurs
{
    public enum direct
    {
        front, back, right, left, up, down
    }
    public class Camera
    {
        public Point eye;
        public Point target;
        public double near = 50;
        public double far = 5000;
        public double focus;
        public double rotLeftRight = 0;
        public double rotUpDown = 0;
        public double pos_cam_x = 180;
        public double pos_cam_y = 0;
        public double pos_targ_x;
        public double pos_targ_y;
        public Camera(Point eye_pos, Point targ_pos)
        {
            eye = eye_pos;
            target = targ_pos;
        }

        public void MoveCam(direct direction)
        {
            switch (direction)
            {
                case direct.front:
                    eye.Moving(0, 0, 10);
                    break;
                case direct.back:
                    eye.Moving(0, 0, -10);
                    break;
                case direct.right:
                    eye.Moving(10, 0, 0);
                    break;
                case direct.left:
                    eye.Moving(-10, 0, 0);
                    break;
                case direct.up:
                    eye.Moving(0, 10, 0);
                    break;
                case direct.down:
                    eye.Moving(0, -10, 0);
                    break;
                default:
                    break;
            }
        }

        public void MoveTarg(direct direction)
        {
            switch (direction)
            {
                case direct.right:
                    target.Moving(10, 0, 0);
                    break;
                case direct.left:
                    target.Moving(-10, 0, 0);
                    break;
                case direct.up:
                    target.Moving(0, 10, 0);
                    break;
                case direct.down:
                    target.Moving(0, -10, 0);
                    break;
                case direct.front:
                    target.Moving(0, 0, 10);
                    break;
                case direct.back:
                    target.Moving(0, 0, -10);
                    break;
                default:
                    break;
            }
        }

        /*public void MoveCam(direct direction)
        {
            switch (direction)
            {
                case direct.front:
                    if (eye.z < 0)
                        eye.z += 10;
                    else
                        eye.z -= 10;
                    break;
                case direct.back:
                    if (eye.z < 0)
                        eye.z -= 10;
                    else
                        eye.z += 10;
                    break;
                case direct.right:
                    pos_cam_x += 10;
                    break;
                case direct.left:
                    pos_cam_x -= 10;
                    break;
                case direct.up:
                    if (pos_cam_y + 10 < 90)
                        pos_cam_y += 10;
                    break;
                case direct.down:
                    if (pos_cam_y - 10 > -90)
                        pos_cam_y -= 10;
                    break;
                default:
                    break;
            }
            double x = eye.x;
            double y = eye.y;
            double z = eye.z;
            double len = new Line(eye, target).Length;
            double posz = z + len * Math.Cos(pos_cam_x * Math.PI / 180) * Math.Cos(pos_cam_y * Math.PI / 180);
            double posy = y + len * Math.Cos(pos_cam_x * Math.PI / 180) * Math.Sin(pos_cam_y * Math.PI / 180);
            double posx = x + len * Math.Sin(pos_cam_x * Math.PI / 180);
            eye = new Point(posx, posy, posz);
        }*/
        /*public void MoveTarg(direct direction)
        {
            switch (direction)
            {
                case direct.right:
                    pos_targ_x += 10;
                    break;
                case direct.left:
                    pos_targ_x -= 10;
                    break;
                case direct.up:
                    pos_targ_y += 10;
                    break;
                case direct.down:
                    pos_targ_y -= 10;
                    break;
                default:
                    break;
            }
            double x = eye.x;
            double y = eye.y;
            double z = eye.z;
            double len = new Line(eye, target).Length;
            double posz = z + len * Math.Cos(pos_targ_x * Math.PI / 180) * Math.Cos(pos_targ_y * Math.PI / 180);
            double posy = y + len * Math.Cos(pos_targ_x * Math.PI / 180) * Math.Sin(pos_targ_y * Math.PI / 180);
            double posx = x + len * Math.Sin(pos_targ_x * Math.PI / 180);
            target = new Point(posx, posy, posz);
        }*/
    }
}
