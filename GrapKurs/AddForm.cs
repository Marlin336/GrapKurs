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
    public partial class AddForm : Form
    {
        MainForm parent;
        Color color;
        public AddForm(MainForm main)
        {
            InitializeComponent();
            parent = main;
            bColor.BackColor = CD.Color;
            color = CD.Color;
        }

        private void bCencel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bColor_Click(object sender, EventArgs e)
        {
            if(CD.ShowDialog() == DialogResult.OK)
            {
                color = CD.Color;
                bColor.BackColor = color;
            }

        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            Point axis;
            try
            {
                char[] sep = new char[] { ',' };
                string[] axis_str = tbState.Text.Split(sep);
                axis = new Point(double.Parse(axis_str[0]), double.Parse(axis_str[1]), double.Parse(axis_str[2]));
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно заданы координаты");
                throw;
            }
            parent.AddObj(new Point(axis), (double)udScale.Value, color);
            parent.scene.ClearzBuf();
            parent.Redraw();
            Close();
        }
    }
}
