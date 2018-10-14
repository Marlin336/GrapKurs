namespace GrapKurs
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lboxObj = new System.Windows.Forms.ListBox();
            this.bDel = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.PBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.отрисовкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.визуализацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.реалистичныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каркасныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.ScaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Rotate_x = new System.Windows.Forms.NumericUpDown();
            this.Rotate_y = new System.Windows.Forms.NumericUpDown();
            this.Rotate_z = new System.Windows.Forms.NumericUpDown();
            this.bRotate = new System.Windows.Forms.Button();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bEdit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bMoveCam_m = new System.Windows.Forms.Button();
            this.bMoveCam_p = new System.Windows.Forms.Button();
            this.rbZ = new System.Windows.Forms.RadioButton();
            this.rbY = new System.Windows.Forms.RadioButton();
            this.rbX = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bCen_m = new System.Windows.Forms.Button();
            this.bCen_p = new System.Windows.Forms.Button();
            this.rbCZ = new System.Windows.Forms.RadioButton();
            this.rbCY = new System.Windows.Forms.RadioButton();
            this.rbCX = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bObj_m = new System.Windows.Forms.Button();
            this.bObj_p = new System.Windows.Forms.Button();
            this.rbObjZ = new System.Windows.Forms.RadioButton();
            this.rbObjY = new System.Windows.Forms.RadioButton();
            this.rbObjX = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.PBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate_z)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lboxObj
            // 
            this.lboxObj.FormattingEnabled = true;
            this.lboxObj.Location = new System.Drawing.Point(668, 27);
            this.lboxObj.Name = "lboxObj";
            this.lboxObj.Size = new System.Drawing.Size(203, 420);
            this.lboxObj.TabIndex = 1;
            this.lboxObj.SelectedIndexChanged += new System.EventHandler(this.lboxObj_SelectedIndexChanged);
            this.lboxObj.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lboxObj_MouseDown);
            // 
            // bDel
            // 
            this.bDel.Enabled = false;
            this.bDel.Location = new System.Drawing.Point(778, 454);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(93, 23);
            this.bDel.TabIndex = 3;
            this.bDel.Text = "Удалить";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(668, 454);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(93, 23);
            this.bAdd.TabIndex = 4;
            this.bAdd.Text = "Добавить";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // PBox
            // 
            this.PBox.BackColor = System.Drawing.Color.Gray;
            this.PBox.Location = new System.Drawing.Point(12, 27);
            this.PBox.Name = "PBox";
            this.PBox.Size = new System.Drawing.Size(650, 450);
            this.PBox.TabIndex = 0;
            this.PBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отрисовкаToolStripMenuItem,
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // отрисовкаToolStripMenuItem
            // 
            this.отрисовкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.визуализацияToolStripMenuItem});
            this.отрисовкаToolStripMenuItem.Name = "отрисовкаToolStripMenuItem";
            this.отрисовкаToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.отрисовкаToolStripMenuItem.Text = "Отрисовка";
            // 
            // визуализацияToolStripMenuItem
            // 
            this.визуализацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.реалистичныйToolStripMenuItem,
            this.каркасныйToolStripMenuItem});
            this.визуализацияToolStripMenuItem.Name = "визуализацияToolStripMenuItem";
            this.визуализацияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.визуализацияToolStripMenuItem.Text = "Визуализация";
            // 
            // реалистичныйToolStripMenuItem
            // 
            this.реалистичныйToolStripMenuItem.Name = "реалистичныйToolStripMenuItem";
            this.реалистичныйToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.реалистичныйToolStripMenuItem.Text = "Реалистичный";
            this.реалистичныйToolStripMenuItem.Click += new System.EventHandler(this.РеалистичныйToolStripMenuItem_Click);
            // 
            // каркасныйToolStripMenuItem
            // 
            this.каркасныйToolStripMenuItem.Name = "каркасныйToolStripMenuItem";
            this.каркасныйToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.каркасныйToolStripMenuItem.Text = "Каркасный";
            this.каркасныйToolStripMenuItem.Click += new System.EventHandler(this.КаркасныйToolStripMenuItem_Click);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.СохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.ЗагрузитьToolStripMenuItem_Click);
            // 
            // openFD
            // 
            this.openFD.FileName = "openFileDialog";
            this.openFD.Filter = "Scene save|*.scn";
            // 
            // ScaleUpDown
            // 
            this.ScaleUpDown.DecimalPlaces = 2;
            this.ScaleUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.ScaleUpDown.Location = new System.Drawing.Point(391, 529);
            this.ScaleUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ScaleUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.ScaleUpDown.Name = "ScaleUpDown";
            this.ScaleUpDown.Size = new System.Drawing.Size(77, 20);
            this.ScaleUpDown.TabIndex = 12;
            this.ScaleUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ScaleUpDown.ValueChanged += new System.EventHandler(this.ScaleUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 508);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Масштабирование";
            // 
            // Rotate_x
            // 
            this.Rotate_x.DecimalPlaces = 1;
            this.Rotate_x.Location = new System.Drawing.Point(540, 529);
            this.Rotate_x.Maximum = new decimal(new int[] {
            3599,
            0,
            0,
            65536});
            this.Rotate_x.Minimum = new decimal(new int[] {
            3599,
            0,
            0,
            -2147418112});
            this.Rotate_x.Name = "Rotate_x";
            this.Rotate_x.Size = new System.Drawing.Size(55, 20);
            this.Rotate_x.TabIndex = 15;
            // 
            // Rotate_y
            // 
            this.Rotate_y.DecimalPlaces = 1;
            this.Rotate_y.Location = new System.Drawing.Point(540, 555);
            this.Rotate_y.Maximum = new decimal(new int[] {
            3599,
            0,
            0,
            65536});
            this.Rotate_y.Minimum = new decimal(new int[] {
            3599,
            0,
            0,
            -2147418112});
            this.Rotate_y.Name = "Rotate_y";
            this.Rotate_y.Size = new System.Drawing.Size(55, 20);
            this.Rotate_y.TabIndex = 16;
            // 
            // Rotate_z
            // 
            this.Rotate_z.DecimalPlaces = 1;
            this.Rotate_z.Location = new System.Drawing.Point(540, 579);
            this.Rotate_z.Maximum = new decimal(new int[] {
            3599,
            0,
            0,
            65536});
            this.Rotate_z.Minimum = new decimal(new int[] {
            3599,
            0,
            0,
            -2147418112});
            this.Rotate_z.Name = "Rotate_z";
            this.Rotate_z.Size = new System.Drawing.Size(55, 20);
            this.Rotate_z.TabIndex = 17;
            // 
            // bRotate
            // 
            this.bRotate.Location = new System.Drawing.Point(601, 547);
            this.bRotate.Name = "bRotate";
            this.bRotate.Size = new System.Drawing.Size(61, 35);
            this.bRotate.TabIndex = 18;
            this.bRotate.Text = "Вращать";
            this.bRotate.UseVisualStyleBackColor = true;
            this.bRotate.Click += new System.EventHandler(this.bRotate_Click);
            // 
            // saveFD
            // 
            this.saveFD.Filter = "Scene save|*.scn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(517, 557);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(517, 581);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Z:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(536, 508);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Вращение";
            // 
            // bEdit
            // 
            this.bEdit.Enabled = false;
            this.bEdit.Location = new System.Drawing.Point(668, 484);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(93, 23);
            this.bEdit.TabIndex = 25;
            this.bEdit.Text = "Редактировать";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bMoveCam_m);
            this.groupBox1.Controls.Add(this.bMoveCam_p);
            this.groupBox1.Controls.Add(this.rbZ);
            this.groupBox1.Controls.Add(this.rbY);
            this.groupBox1.Controls.Add(this.rbX);
            this.groupBox1.Location = new System.Drawing.Point(12, 494);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 121);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Перемещение камеры";
            // 
            // bMoveCam_m
            // 
            this.bMoveCam_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bMoveCam_m.Location = new System.Drawing.Point(7, 85);
            this.bMoveCam_m.Name = "bMoveCam_m";
            this.bMoveCam_m.Size = new System.Drawing.Size(35, 30);
            this.bMoveCam_m.TabIndex = 4;
            this.bMoveCam_m.Text = "-";
            this.bMoveCam_m.UseVisualStyleBackColor = true;
            this.bMoveCam_m.Click += new System.EventHandler(this.bMoveCam_m_Click);
            // 
            // bMoveCam_p
            // 
            this.bMoveCam_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bMoveCam_p.Location = new System.Drawing.Point(48, 85);
            this.bMoveCam_p.Name = "bMoveCam_p";
            this.bMoveCam_p.Size = new System.Drawing.Size(35, 30);
            this.bMoveCam_p.TabIndex = 3;
            this.bMoveCam_p.Text = "+";
            this.bMoveCam_p.UseVisualStyleBackColor = true;
            this.bMoveCam_p.Click += new System.EventHandler(this.bMoveCam_p_Click);
            // 
            // rbZ
            // 
            this.rbZ.AutoSize = true;
            this.rbZ.Location = new System.Drawing.Point(7, 62);
            this.rbZ.Name = "rbZ";
            this.rbZ.Size = new System.Drawing.Size(32, 17);
            this.rbZ.TabIndex = 2;
            this.rbZ.Text = "Z";
            this.rbZ.UseVisualStyleBackColor = true;
            // 
            // rbY
            // 
            this.rbY.AutoSize = true;
            this.rbY.Location = new System.Drawing.Point(7, 45);
            this.rbY.Name = "rbY";
            this.rbY.Size = new System.Drawing.Size(32, 17);
            this.rbY.TabIndex = 1;
            this.rbY.Text = "Y";
            this.rbY.UseVisualStyleBackColor = true;
            // 
            // rbX
            // 
            this.rbX.AutoSize = true;
            this.rbX.Checked = true;
            this.rbX.Location = new System.Drawing.Point(7, 27);
            this.rbX.Name = "rbX";
            this.rbX.Size = new System.Drawing.Size(32, 17);
            this.rbX.TabIndex = 0;
            this.rbX.TabStop = true;
            this.rbX.Text = "X";
            this.rbX.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bCen_m);
            this.groupBox2.Controls.Add(this.bCen_p);
            this.groupBox2.Controls.Add(this.rbCZ);
            this.groupBox2.Controls.Add(this.rbCY);
            this.groupBox2.Controls.Add(this.rbCX);
            this.groupBox2.Location = new System.Drawing.Point(136, 494);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(95, 121);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Перемещение точки центра";
            // 
            // bCen_m
            // 
            this.bCen_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCen_m.Location = new System.Drawing.Point(7, 85);
            this.bCen_m.Name = "bCen_m";
            this.bCen_m.Size = new System.Drawing.Size(35, 30);
            this.bCen_m.TabIndex = 4;
            this.bCen_m.Text = "-";
            this.bCen_m.UseVisualStyleBackColor = true;
            this.bCen_m.Click += new System.EventHandler(this.bCen_m_Click);
            // 
            // bCen_p
            // 
            this.bCen_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCen_p.Location = new System.Drawing.Point(48, 85);
            this.bCen_p.Name = "bCen_p";
            this.bCen_p.Size = new System.Drawing.Size(35, 30);
            this.bCen_p.TabIndex = 3;
            this.bCen_p.Text = "+";
            this.bCen_p.UseVisualStyleBackColor = true;
            this.bCen_p.Click += new System.EventHandler(this.bCen_p_Click);
            // 
            // rbCZ
            // 
            this.rbCZ.AutoSize = true;
            this.rbCZ.Location = new System.Drawing.Point(7, 62);
            this.rbCZ.Name = "rbCZ";
            this.rbCZ.Size = new System.Drawing.Size(32, 17);
            this.rbCZ.TabIndex = 2;
            this.rbCZ.Text = "Z";
            this.rbCZ.UseVisualStyleBackColor = true;
            // 
            // rbCY
            // 
            this.rbCY.AutoSize = true;
            this.rbCY.Location = new System.Drawing.Point(7, 45);
            this.rbCY.Name = "rbCY";
            this.rbCY.Size = new System.Drawing.Size(32, 17);
            this.rbCY.TabIndex = 1;
            this.rbCY.Text = "Y";
            this.rbCY.UseVisualStyleBackColor = true;
            // 
            // rbCX
            // 
            this.rbCX.AutoSize = true;
            this.rbCX.Checked = true;
            this.rbCX.Location = new System.Drawing.Point(7, 27);
            this.rbCX.Name = "rbCX";
            this.rbCX.Size = new System.Drawing.Size(32, 17);
            this.rbCX.TabIndex = 0;
            this.rbCX.TabStop = true;
            this.rbCX.Text = "X";
            this.rbCX.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bObj_m);
            this.groupBox3.Controls.Add(this.bObj_p);
            this.groupBox3.Controls.Add(this.rbObjZ);
            this.groupBox3.Controls.Add(this.rbObjY);
            this.groupBox3.Controls.Add(this.rbObjX);
            this.groupBox3.Location = new System.Drawing.Point(260, 494);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(95, 121);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Перемещение объектов";
            // 
            // bObj_m
            // 
            this.bObj_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bObj_m.Location = new System.Drawing.Point(7, 85);
            this.bObj_m.Name = "bObj_m";
            this.bObj_m.Size = new System.Drawing.Size(35, 30);
            this.bObj_m.TabIndex = 4;
            this.bObj_m.Text = "-";
            this.bObj_m.UseVisualStyleBackColor = true;
            this.bObj_m.Click += new System.EventHandler(this.bObj_m_Click);
            // 
            // bObj_p
            // 
            this.bObj_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bObj_p.Location = new System.Drawing.Point(48, 85);
            this.bObj_p.Name = "bObj_p";
            this.bObj_p.Size = new System.Drawing.Size(35, 30);
            this.bObj_p.TabIndex = 3;
            this.bObj_p.Text = "+";
            this.bObj_p.UseVisualStyleBackColor = true;
            this.bObj_p.Click += new System.EventHandler(this.bObj_p_Click);
            // 
            // rbObjZ
            // 
            this.rbObjZ.AutoSize = true;
            this.rbObjZ.Location = new System.Drawing.Point(7, 62);
            this.rbObjZ.Name = "rbObjZ";
            this.rbObjZ.Size = new System.Drawing.Size(32, 17);
            this.rbObjZ.TabIndex = 2;
            this.rbObjZ.Text = "Z";
            this.rbObjZ.UseVisualStyleBackColor = true;
            // 
            // rbObjY
            // 
            this.rbObjY.AutoSize = true;
            this.rbObjY.Location = new System.Drawing.Point(7, 45);
            this.rbObjY.Name = "rbObjY";
            this.rbObjY.Size = new System.Drawing.Size(32, 17);
            this.rbObjY.TabIndex = 1;
            this.rbObjY.Text = "Y";
            this.rbObjY.UseVisualStyleBackColor = true;
            // 
            // rbObjX
            // 
            this.rbObjX.AutoSize = true;
            this.rbObjX.Checked = true;
            this.rbObjX.Location = new System.Drawing.Point(7, 27);
            this.rbObjX.Name = "rbObjX";
            this.rbObjX.Size = new System.Drawing.Size(32, 17);
            this.rbObjX.TabIndex = 0;
            this.rbObjX.TabStop = true;
            this.rbObjX.Text = "X";
            this.rbObjX.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 651);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bRotate);
            this.Controls.Add(this.Rotate_z);
            this.Controls.Add(this.Rotate_y);
            this.Controls.Add(this.Rotate_x);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ScaleUpDown);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.lboxObj);
            this.Controls.Add(this.PBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MarlinGraph";
            ((System.ComponentModel.ISupportInitialize)(this.PBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate_z)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.PictureBox PBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem отрисовкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem визуализацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem реалистичныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каркасныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.NumericUpDown ScaleUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Rotate_x;
        private System.Windows.Forms.NumericUpDown Rotate_y;
        private System.Windows.Forms.NumericUpDown Rotate_z;
        private System.Windows.Forms.Button bRotate;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ListBox lboxObj;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bMoveCam_m;
        private System.Windows.Forms.Button bMoveCam_p;
        private System.Windows.Forms.RadioButton rbZ;
        private System.Windows.Forms.RadioButton rbY;
        private System.Windows.Forms.RadioButton rbX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bCen_m;
        private System.Windows.Forms.Button bCen_p;
        private System.Windows.Forms.RadioButton rbCZ;
        private System.Windows.Forms.RadioButton rbCY;
        private System.Windows.Forms.RadioButton rbCX;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bObj_m;
        private System.Windows.Forms.Button bObj_p;
        private System.Windows.Forms.RadioButton rbObjZ;
        private System.Windows.Forms.RadioButton rbObjY;
        private System.Windows.Forms.RadioButton rbObjX;
    }
}

