namespace lab6
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDirection = new System.Windows.Forms.Label();
            this.TbPointX = new System.Windows.Forms.TrackBar();
            this.TbPointY = new System.Windows.Forms.TrackBar();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnSwitchPalette = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tbPointRadius = new System.Windows.Forms.TrackBar();
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbPointX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbPointY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPointRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(3, 2);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(794, 360);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(136, 376);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(0, 13);
            this.lblDirection.TabIndex = 2;
            // 
            // TbPointX
            // 
            this.TbPointX.Location = new System.Drawing.Point(12, 368);
            this.TbPointX.Maximum = 50;
            this.TbPointX.Name = "TbPointX";
            this.TbPointX.Size = new System.Drawing.Size(104, 45);
            this.TbPointX.TabIndex = 3;
            this.TbPointX.Scroll += new System.EventHandler(this.TbPointX_Scroll);
            // 
            // TbPointY
            // 
            this.TbPointY.Location = new System.Drawing.Point(178, 368);
            this.TbPointY.Maximum = 50;
            this.TbPointY.Name = "TbPointY";
            this.TbPointY.Size = new System.Drawing.Size(104, 45);
            this.TbPointY.TabIndex = 4;
            this.TbPointY.Scroll += new System.EventHandler(this.TbPointY_Scroll);
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(337, 368);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(131, 23);
            this.BtnReset.TabIndex = 5;
            this.BtnReset.Text = "Сброс";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnSwitchPalette
            // 
            this.BtnSwitchPalette.Location = new System.Drawing.Point(337, 398);
            this.BtnSwitchPalette.Name = "BtnSwitchPalette";
            this.BtnSwitchPalette.Size = new System.Drawing.Size(131, 23);
            this.BtnSwitchPalette.TabIndex = 6;
            this.BtnSwitchPalette.Text = "Переключатель цвета";
            this.BtnSwitchPalette.UseVisualStyleBackColor = true;
            this.BtnSwitchPalette.Click += new System.EventHandler(this.BtnSwitchPalette_Click);
            // 
            // tbPointRadius
            // 
            this.tbPointRadius.Location = new System.Drawing.Point(496, 368);
            this.tbPointRadius.Name = "tbPointRadius";
            this.tbPointRadius.Size = new System.Drawing.Size(104, 45);
            this.tbPointRadius.TabIndex = 7;
            this.tbPointRadius.Scroll += new System.EventHandler(this.tbPointRadius_Scroll);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(659, 368);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(104, 45);
            this.tbDirection.TabIndex = 8;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Перемещение по оси Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Перемещение по оси Х";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Изменение радиусов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(626, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Изменение направления частиц";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 433);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.tbPointRadius);
            this.Controls.Add(this.BtnSwitchPalette);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.TbPointY);
            this.Controls.Add(this.TbPointX);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Система частиц";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbPointX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbPointY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPointRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.TrackBar TbPointX;
        private System.Windows.Forms.TrackBar TbPointY;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnSwitchPalette;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TrackBar tbPointRadius;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

