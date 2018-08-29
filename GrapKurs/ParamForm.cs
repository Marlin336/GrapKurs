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
    public partial class ParamForm : Form
    {
        private MainForm main;
        public ParamForm(MainForm parrent)
        {
            main = parrent;
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            try
            {
                ParamObj obj = new ParamObj(new Point(325, 225, 0), (double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value, (double)numericUpDown4.Value, (double)numericUpDown5.Value, (double)numericUpDown6.Value, (int)numericUpDown7.Value, (int)numericUpDown8.Value, (double)numericUpDown9.Value, (double)numericUpDown10.Value);
                main.scene.AddObj(obj);
                main.lboxObj.Items.Add(obj);
                main.Redraw();
            }
            catch
            {
                MessageBox.Show("Не удалось создать объект");
            }
            finally
            {
                Close();
            }
        }
    }
}
