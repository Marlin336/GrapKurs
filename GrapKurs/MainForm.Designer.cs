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
            ((System.ComponentModel.ISupportInitialize)(this.PBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lboxObj
            // 
            this.lboxObj.FormattingEnabled = true;
            this.lboxObj.Location = new System.Drawing.Point(668, 27);
            this.lboxObj.Name = "lboxObj";
            this.lboxObj.Size = new System.Drawing.Size(203, 212);
            this.lboxObj.TabIndex = 1;
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
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отрисовкаToolStripMenuItem,
            this.файлToolStripMenuItem,
            this.видыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
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
            // 
            // каркасныйToolStripMenuItem
            // 
            this.каркасныйToolStripMenuItem.Name = "каркасныйToolStripMenuItem";
            this.каркасныйToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.каркасныйToolStripMenuItem.Text = "Каркасный";
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
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 481);
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
    }
}

