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
            Bitmap bitmap = new Bitmap(PBox.Width, PBox.Height);
            PBox.BackColor = Color.FromArgb(70, 70, 70);
            bitmap.SetPixel(100, 100, Color.Red);
            PBox.Image = bitmap;
        }
    }
}
