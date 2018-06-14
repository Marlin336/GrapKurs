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
            this.проецированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.центральноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параллельноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.визуализацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.реалистичныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каркасныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сверхуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.снизуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слеваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tbAxis = new System.Windows.Forms.TextBox();
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
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
            this.lboxObj.Size = new System.Drawing.Size(203, 212);
            this.lboxObj.TabIndex = 1;
            this.lboxObj.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lboxObj_MouseDown);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(778, 245);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(93, 23);
            this.bDel.TabIndex = 3;
            this.bDel.Text = "Удалить";
            this.bDel.UseVisualStyleBackColor = true;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(668, 245);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(93, 23);
            this.bAdd.TabIndex = 4;
            this.bAdd.Text = "Добавить";
            this.bAdd.UseVisualStyleBackColor = true;
            // 
            // PBox
            // 
            this.PBox.BackColor = System.Drawing.Color.Gray;
            this.PBox.Location = new System.Drawing.Point(12, 27);
            this.PBox.Name = "PBox";
            this.PBox.Size = new System.Drawing.Size(650, 450);
            this.PBox.TabIndex = 0;
            this.PBox.TabStop = false;
            this.PBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBox_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отрисовкаToolStripMenuItem,
            this.файлToolStripMenuItem,
            this.видыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(997, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // отрисовкаToolStripMenuItem
            // 
            this.отрисовкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проецированиеToolStripMenuItem,
            this.визуализацияToolStripMenuItem});
            this.отрисовкаToolStripMenuItem.Name = "отрисовкаToolStripMenuItem";
            this.отрисовкаToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.отрисовкаToolStripMenuItem.Text = "Отрисовка";
            // 
            // проецированиеToolStripMenuItem
            // 
            this.проецированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.центральноеToolStripMenuItem,
            this.параллельноеToolStripMenuItem});
            this.проецированиеToolStripMenuItem.Name = "проецированиеToolStripMenuItem";
            this.проецированиеToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.проецированиеToolStripMenuItem.Text = "Проецирование";
            // 
            // центральноеToolStripMenuItem
            // 
            this.центральноеToolStripMenuItem.Name = "центральноеToolStripMenuItem";
            this.центральноеToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.центральноеToolStripMenuItem.Text = "Центральное";
            // 
            // параллельноеToolStripMenuItem
            // 
            this.параллельноеToolStripMenuItem.Name = "параллельноеToolStripMenuItem";
            this.параллельноеToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.параллельноеToolStripMenuItem.Text = "Параллельное";
            // 
            // визуализацияToolStripMenuItem
            // 
            this.визуализацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.реалистичныйToolStripMenuItem,
            this.каркасныйToolStripMenuItem});
            this.визуализацияToolStripMenuItem.Name = "визуализацияToolStripMenuItem";
            this.визуализацияToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
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
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.СохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.ЗагрузитьToolStripMenuItem_Click);
            // 
            // видыToolStripMenuItem
            // 
            this.видыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сверхуToolStripMenuItem,
            this.снизуToolStripMenuItem,
            this.слеваToolStripMenuItem,
            this.справаToolStripMenuItem});
            this.видыToolStripMenuItem.Name = "видыToolStripMenuItem";
            this.видыToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.видыToolStripMenuItem.Text = "Виды";
            // 
            // сверхуToolStripMenuItem
            // 
            this.сверхуToolStripMenuItem.Name = "сверхуToolStripMenuItem";
            this.сверхуToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.сверхуToolStripMenuItem.Text = "Сверху";
            // 
            // снизуToolStripMenuItem
            // 
            this.снизуToolStripMenuItem.Name = "снизуToolStripMenuItem";
            this.снизуToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.снизуToolStripMenuItem.Text = "Снизу";
            // 
            // слеваToolStripMenuItem
            // 
            this.слеваToolStripMenuItem.Name = "слеваToolStripMenuItem";
            this.слеваToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.слеваToolStripMenuItem.Text = "Слева";
            // 
            // справаToolStripMenuItem
            // 
            this.справаToolStripMenuItem.Name = "справаToolStripMenuItem";
            this.справаToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.справаToolStripMenuItem.Text = "Справа";
            // 
            // openFD
            // 
            this.openFD.FileName = "openFileDialog";
            this.openFD.Filter = "3D model format|*.obj|Scene save|*.scn";
            // 
            // bUp
            // 
            this.bUp.Location = new System.Drawing.Point(729, 406);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(30, 30);
            this.bUp.TabIndex = 8;
            this.bUp.Text = "↑";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bDown
            // 
            this.bDown.Location = new System.Drawing.Point(729, 442);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(30, 30);
            this.bDown.TabIndex = 9;
            this.bDown.Text = "↓";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // bRight
            // 
            this.bRight.Location = new System.Drawing.Point(765, 425);
            this.bRight.Name = "bRight";
            this.bRight.Size = new System.Drawing.Size(30, 30);
            this.bRight.TabIndex = 10;
            this.bRight.Text = "→";
            this.bRight.UseVisualStyleBackColor = true;
            this.bRight.Click += new System.EventHandler(this.bRight_Click);
            // 
            // bLeft
            // 
            this.bLeft.Location = new System.Drawing.Point(693, 425);
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
            this.ScaleUpDown.Location = new System.Drawing.Point(709, 367);
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
            this.label1.Location = new System.Drawing.Point(706, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Перемещение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(718, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Масштаб";
            // 
            // Rotate_x
            // 
            this.Rotate_x.DecimalPlaces = 1;
            this.Rotate_x.Location = new System.Drawing.Point(818, 362);
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
            this.Rotate_y.Location = new System.Drawing.Point(818, 388);
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
            this.Rotate_z.Location = new System.Drawing.Point(818, 414);
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
            this.bRotate.Location = new System.Drawing.Point(818, 442);
            this.bRotate.Name = "bRotate";
            this.bRotate.Size = new System.Drawing.Size(75, 23);
            this.bRotate.TabIndex = 18;
            this.bRotate.Text = "Вращать";
            this.bRotate.UseVisualStyleBackColor = true;
            this.bRotate.Click += new System.EventHandler(this.bRotate_Click);
            // 
            // tbAxis
            // 
            this.tbAxis.Location = new System.Drawing.Point(885, 361);
            this.tbAxis.Name = "tbAxis";
            this.tbAxis.Size = new System.Drawing.Size(100, 20);
            this.tbAxis.TabIndex = 19;
            this.tbAxis.Text = "0,0,0";
            // 
            // saveFD
            // 
            this.saveFD.Filter = "Scene save|*.scn";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 481);
            this.Controls.Add(this.tbAxis);
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

        private System.Windows.Forms.ListBox lboxObj;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.PictureBox PBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem отрисовкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проецированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem центральноеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параллельноеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem визуализацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem реалистичныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каркасныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сверхуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снизуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слеваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справаToolStripMenuItem;
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
        private System.Windows.Forms.TextBox tbAxis;
        private System.Windows.Forms.SaveFileDialog saveFD;
    }
}

