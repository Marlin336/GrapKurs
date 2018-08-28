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
            this.перспективаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параллельнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.центральнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.bRight = new System.Windows.Forms.Button();
            this.bLeft = new System.Windows.Forms.Button();
            this.ScaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Rotate_x = new System.Windows.Forms.NumericUpDown();
            this.Rotate_y = new System.Windows.Forms.NumericUpDown();
            this.Rotate_z = new System.Windows.Forms.NumericUpDown();
            this.bRotate = new System.Windows.Forms.Button();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radNC = new System.Windows.Forms.RadioButton();
            this.radObjCen = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.PBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate_z)).BeginInit();
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
            this.визуализацияToolStripMenuItem,
            this.перспективаToolStripMenuItem});
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
            this.визуализацияToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.визуализацияToolStripMenuItem.Text = "Визуализация";
            // 
            // реалистичныйToolStripMenuItem
            // 
            this.реалистичныйToolStripMenuItem.Name = "реалистичныйToolStripMenuItem";
            this.реалистичныйToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.реалистичныйToolStripMenuItem.Text = "Реалистичный";
            this.реалистичныйToolStripMenuItem.Click += new System.EventHandler(this.РеалистичныйToolStripMenuItem_Click);
            // 
            // каркасныйToolStripMenuItem
            // 
            this.каркасныйToolStripMenuItem.Name = "каркасныйToolStripMenuItem";
            this.каркасныйToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.каркасныйToolStripMenuItem.Text = "Каркасный";
            this.каркасныйToolStripMenuItem.Click += new System.EventHandler(this.КаркасныйToolStripMenuItem_Click);
            // 
            // перспективаToolStripMenuItem
            // 
            this.перспективаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параллельнаяToolStripMenuItem,
            this.центральнаяToolStripMenuItem});
            this.перспективаToolStripMenuItem.Name = "перспективаToolStripMenuItem";
            this.перспективаToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.перспективаToolStripMenuItem.Text = "Перспектива";
            // 
            // параллельнаяToolStripMenuItem
            // 
            this.параллельнаяToolStripMenuItem.Name = "параллельнаяToolStripMenuItem";
            this.параллельнаяToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.параллельнаяToolStripMenuItem.Text = "Параллельная";
            this.параллельнаяToolStripMenuItem.Click += new System.EventHandler(this.ПараллельнаяToolStripMenuItem_Click);
            // 
            // центральнаяToolStripMenuItem
            // 
            this.центральнаяToolStripMenuItem.Name = "центральнаяToolStripMenuItem";
            this.центральнаяToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.центральнаяToolStripMenuItem.Text = "Центральная";
            this.центральнаяToolStripMenuItem.Click += new System.EventHandler(this.ЦентральнаяToolStripMenuItem_Click);
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
            this.openFD.Filter = "3D model format|*.obj|Scene save|*.scn";
            // 
            // bUp
            // 
            this.bUp.Location = new System.Drawing.Point(45, 514);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(30, 30);
            this.bUp.TabIndex = 8;
            this.bUp.Text = "↑";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bDown
            // 
            this.bDown.Location = new System.Drawing.Point(45, 550);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(30, 30);
            this.bDown.TabIndex = 9;
            this.bDown.Text = "↓";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // bRight
            // 
            this.bRight.Location = new System.Drawing.Point(81, 533);
            this.bRight.Name = "bRight";
            this.bRight.Size = new System.Drawing.Size(30, 30);
            this.bRight.TabIndex = 10;
            this.bRight.Text = "→";
            this.bRight.UseVisualStyleBackColor = true;
            this.bRight.Click += new System.EventHandler(this.bRight_Click);
            // 
            // bLeft
            // 
            this.bLeft.Location = new System.Drawing.Point(12, 533);
            this.bLeft.Name = "bLeft";
            this.bLeft.Size = new System.Drawing.Size(30, 30);
            this.bLeft.TabIndex = 11;
            this.bLeft.Text = "←";
            this.bLeft.UseVisualStyleBackColor = true;
            this.bLeft.Click += new System.EventHandler(this.bLeft_Click);
            // 
            // ScaleUpDown
            // 
            this.ScaleUpDown.DecimalPlaces = 2;
            this.ScaleUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.ScaleUpDown.Location = new System.Drawing.Point(328, 514);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Перемещение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Масштабирование";
            // 
            // Rotate_x
            // 
            this.Rotate_x.DecimalPlaces = 1;
            this.Rotate_x.Location = new System.Drawing.Point(477, 514);
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
            this.Rotate_y.Location = new System.Drawing.Point(477, 540);
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
            this.Rotate_z.Location = new System.Drawing.Point(477, 564);
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
            this.bRotate.Location = new System.Drawing.Point(538, 513);
            this.bRotate.Name = "bRotate";
            this.bRotate.Size = new System.Drawing.Size(61, 71);
            this.bRotate.TabIndex = 18;
            this.bRotate.Text = "Вращать";
            this.bRotate.UseVisualStyleBackColor = true;
            this.bRotate.Click += new System.EventHandler(this.bRotate_Click);
            // 
            // saveFD
            // 
            this.saveFD.Filter = "Scene save|*.scn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Задание осевой точки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 516);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 542);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 566);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Z:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(473, 493);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Вращение";
            // 
            // radNC
            // 
            this.radNC.AutoSize = true;
            this.radNC.Checked = true;
            this.radNC.Location = new System.Drawing.Point(162, 516);
            this.radNC.Name = "radNC";
            this.radNC.Size = new System.Drawing.Size(118, 17);
            this.radNC.TabIndex = 25;
            this.radNC.TabStop = true;
            this.radNC.Text = "Начало координат";
            this.radNC.UseVisualStyleBackColor = true;
            // 
            // radObjCen
            // 
            this.radObjCen.AutoSize = true;
            this.radObjCen.Enabled = false;
            this.radObjCen.Location = new System.Drawing.Point(162, 538);
            this.radObjCen.Name = "radObjCen";
            this.radObjCen.Size = new System.Drawing.Size(101, 17);
            this.radObjCen.TabIndex = 26;
            this.radObjCen.Text = "Центр объекта";
            this.radObjCen.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 591);
            this.Controls.Add(this.radObjCen);
            this.Controls.Add(this.radNC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bRotate);
            this.Controls.Add(this.Rotate_z);
            this.Controls.Add(this.Rotate_y);
            this.Controls.Add(this.Rotate_x);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScaleUpDown);
            this.Controls.Add(this.bLeft);
            this.Controls.Add(this.bRight);
            this.Controls.Add(this.bDown);
            this.Controls.Add(this.bUp);
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
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.Button bRight;
        private System.Windows.Forms.Button bLeft;
        private System.Windows.Forms.NumericUpDown ScaleUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Rotate_x;
        private System.Windows.Forms.NumericUpDown Rotate_y;
        private System.Windows.Forms.NumericUpDown Rotate_z;
        private System.Windows.Forms.Button bRotate;
        private System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem перспективаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параллельнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem центральнаяToolStripMenuItem;
        private System.Windows.Forms.RadioButton radNC;
        private System.Windows.Forms.RadioButton radObjCen;
        public System.Windows.Forms.ListBox lboxObj;
    }
}

