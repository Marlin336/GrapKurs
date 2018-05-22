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
            //DrawLine(20, 100, 150, 120, scene.bmp);
            DrawCircleBrez(100, 100, 45, scene.bmp);
            PBox.Image = scene.bmp;
        }
        private void DrawLine(int x0, int y0, int x1, int y1, Bitmap bitmap)
        {
            int delx = Math.Abs(x1 - x0);
            int dely = Math.Abs(y1 - y0);
            int err = 0;
            int delerr = dely;
            int y = y0;
            int diry = y1 - y0;
            if (diry > 0)
                diry = 1;
            if (diry < 0)
                diry = -1;
            for (int x = x0; x < x1; x++)
            {
                bitmap.SetPixel(x, y, Color.Red);
                err += delerr;
                if (2 * err >= delx)
                {
                    y += diry;
                    err -= delx;
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
            int sect = 36;

        }
    }
}
