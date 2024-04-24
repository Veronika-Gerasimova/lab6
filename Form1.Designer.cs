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
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbPointX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbPointY)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(3, 2);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(798, 360);
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
            this.TbPointX.Name = "TbPointX";
            this.TbPointX.Size = new System.Drawing.Size(104, 45);
            this.TbPointX.TabIndex = 3;
            this.TbPointX.Scroll += new System.EventHandler(this.TbPointX_Scroll);
            // 
            // TbPointY
            // 
            this.TbPointY.Location = new System.Drawing.Point(182, 368);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 433);
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
    }
}

