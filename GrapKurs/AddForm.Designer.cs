namespace GrapKurs
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.udScale = new System.Windows.Forms.NumericUpDown();
            this.bCencel = new System.Windows.Forms.Button();
            this.bCreate = new System.Windows.Forms.Button();
            this.CD = new System.Windows.Forms.ColorDialog();
            this.bColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.udScale)).BeginInit();
            this.SuspendLayout();
            // 
            // tbState
            // 
            this.tbState.Location = new System.Drawing.Point(119, 20);
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(100, 20);
            this.tbState.TabIndex = 0;
            this.tbState.Text = "0,0,0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Положение (X,Y,Z)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Масштаб";
            // 
            // udScale
            // 
            this.udScale.DecimalPlaces = 2;
            this.udScale.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.udScale.Location = new System.Drawing.Point(119, 48);
            this.udScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udScale.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.udScale.Name = "udScale";
            this.udScale.Size = new System.Drawing.Size(100, 20);
            this.udScale.TabIndex = 3;
            this.udScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bCencel
            // 
            this.bCencel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCencel.Location = new System.Drawing.Point(119, 103);
            this.bCencel.Name = "bCencel";
            this.bCencel.Size = new System.Drawing.Size(101, 23);
            this.bCencel.TabIndex = 4;
            this.bCencel.Text = "Отмена";
            this.bCencel.UseVisualStyleBackColor = true;
            this.bCencel.Click += new System.EventHandler(this.bCencel_Click);
            // 
            // bCreate
            // 
            this.bCreate.Location = new System.Drawing.Point(15, 103);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(100, 23);
            this.bCreate.TabIndex = 5;
            this.bCreate.Text = "Создать";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // CD
            // 
            this.CD.Color = System.Drawing.Color.DarkGray;
            // 
            // bColor
            // 
            this.bColor.Location = new System.Drawing.Point(15, 74);
            this.bColor.Name = "bColor";
            this.bColor.Size = new System.Drawing.Size(204, 23);
            this.bColor.TabIndex = 6;
            this.bColor.Text = "Цвет";
            this.bColor.UseVisualStyleBackColor = true;
            this.bColor.Click += new System.EventHandler(this.bColor_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCencel;
            this.ClientSize = new System.Drawing.Size(239, 134);
            this.Controls.Add(this.bColor);
            this.Controls.Add(this.bCreate);
            this.Controls.Add(this.bCencel);
            this.Controls.Add(this.udScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbState);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddForm";
            this.Text = "Добавить объект";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.udScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udScale;
        private System.Windows.Forms.Button bCencel;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.ColorDialog CD;
        private System.Windows.Forms.Button bColor;
    }
}