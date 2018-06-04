using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrapKurs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            WorkScene scene = new WorkScene(PBox.Width, PBox.Height);
            DrawLine(0, 0, 100, 100, scene.bmp, Color.Red);
            DrawLine(100, 0, 0, 100, scene.bmp, Color.Red);
            PBox.Image = scene.bmp;
        }

        void Swap(ref int a, ref int b)
        {
            int swap = a;
            a = b;
            b = swap;
        }
        void DrawLine(int x0, int y0, int x1, int y1, Bitmap bitmap, Color color)//Улучшеный алг. Брезенхэма
        {
            bool steep = false;
            if (Math.Abs(x0 - x1) < Math.Abs(y0 - y1))
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
                steep = true;
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            int dx = x1 - x0;
            int dy = y1 - y0;
            double derror = Math.Abs(dy / (double)dx);
            double error = 0;
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                if (steep)
                {
                    bitmap.SetPixel(y, x, color);
                }
                else
                {
                    bitmap.SetPixel(x, y, color);
                }
                error += derror;

                if (error > .5)
                {
                    y += (y1 > y0 ? 1 : -1);
                    error -= 1.0;
                }
            }
        }
        private void DrawCircleBrez(int x0, int y0, int rad, Bitmap bitmap)//Алгоритм Брезенхэма
        {
            int x = 0;
            int y = rad;
            int del = 1 - 2 * rad;
            int err = 0;
            while (y >= 0)
            {
                bitmap.SetPixel(x0 + x, y0 + y, Color.Red);
                bitmap.SetPixel(x0 + x, y0 - y, Color.Red);
                bitmap.SetPixel(x0 - x, y0 + y, Color.Red);
                bitmap.SetPixel(x0 - x, y0 - y, Color.Red);
                err = 2 * (del + y) - 1;
                if ((del < 0) && (err <= 0))
                {
                    del += 2 * ++x + 1;
                    continue;
                }
                err = 2 * (del - x) - 1;
                if ((del > 0) && (err > 0))
                {
                    del += 1 - 2 * --y;
                    continue;
                }
                x++;
                del += 2 * (x - y);
                y--;
            }
        }
        private void DrawCircle(int x0, int y0, int rad, Bitmap bitmap)//Рисование отрезками
        {
            int sect = 12;

        }
    }
}
