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
        Point st = new Point(325, 225, 0);
        MainForm main;
        bool edit;
        int select;
        public ParamForm(MainForm parrent)
        {
            edit = false;
            main = parrent;
            InitializeComponent();
        }

        public ParamForm(MainForm parrent, Point start_point, double bar_len, double bar_diam, double mag_len, double box_width, double cev_len, double targ_ang, int nas, int rings, double sp_ang, double dist)
        {
            edit = true;
            main = parrent;
            st = new Point(start_point);
            select = main.lboxObj.SelectedIndex;
            InitializeComponent();
            numericUpDown1.Value = (int)bar_len;
            numericUpDown2.Value = (int)bar_diam;
            numericUpDown3.Value = (int)mag_len;
            numericUpDown4.Value = (int)box_width;
            numericUpDown5.Value = (int)cev_len;
            numericUpDown6.Value = (int)targ_ang;
            numericUpDown7.Value = nas;
            numericUpDown8.Value = rings;
            numericUpDown9.Value = (int)sp_ang;
            numericUpDown10.Value = (int)dist;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                try
                {
                    ParamObj obj = new ParamObj(st, (double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value, (double)numericUpDown4.Value, (double)numericUpDown5.Value, (double)numericUpDown6.Value, (int)numericUpDown7.Value, (int)numericUpDown8.Value, (double)numericUpDown9.Value, (double)numericUpDown10.Value);
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
            else
            {
                try
                {
                    ParamObj obj = new ParamObj(st, (double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value, (double)numericUpDown4.Value, (double)numericUpDown5.Value, (double)numericUpDown6.Value, (int)numericUpDown7.Value, (int)numericUpDown8.Value, (double)numericUpDown9.Value, (double)numericUpDown10.Value);
                    main.scene.objs.Insert(main.lboxObj.SelectedIndex, obj);
                    main.scene.objs.RemoveAt(main.lboxObj.SelectedIndex + 1);
                    main.lboxObj.Items.Clear();
                    foreach (ParamObj item in main.scene.objs)
                    {
                        main.lboxObj.Items.Add(item);
                    }
                    main.lboxObj.SelectedIndex = select;
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
}
