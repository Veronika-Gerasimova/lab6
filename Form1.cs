using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;
        RepaintingPoint pointRed;
        RepaintingPoint pointOrange;
        RepaintingPoint pointYellow;
        RepaintingPoint pointGreen;
        RepaintingPoint pointBlue;
        RepaintingPoint pointNavyBlue;
        RepaintingPoint pointPurple;
        CounterPoint pointCounter;
        TrackBar tbPointX;
        TrackBar tbPointY;
        private int initialRadius = 75;
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            picDisplay.MouseWheel += picDisplay_MouseWheel;

            /*emitter = new TopEmitter
             {
                 Width = picDisplay.Width,
                 GravitationY = 0.25f
             };*/

            int centerX = picDisplay.Width / 2;
            int centerY = picDisplay.Height / 2;
            int radius = Math.Min(picDisplay.Width, picDisplay.Height) / 3;
            int pointsCount = 7;

            for (int i = 0; i < pointsCount; i++)
            {
                double angle = 2 * Math.PI * i / pointsCount;
                int x = (int)(centerX + radius * Math.Cos(angle));
                int y = (int)(centerY + radius * Math.Sin(angle));

                switch (i)
                {
                    case 0:
                        pointRed = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.Red,
                            Diametr = 75
                        };
                        break;
                    case 1:
                        pointOrange = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.Orange,
                            Diametr = 75
                        };
                        break;
                    case 2:
                        pointYellow = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.Yellow,
                            Diametr = 75
                        };
                        break;
                    case 3:
                        pointGreen = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.LawnGreen,
                            Diametr = 75
                        };
                        break;
                    case 4:
                        pointBlue = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.Cyan,
                            Diametr = 75
                        };
                        break;
                    case 5:
                        pointNavyBlue = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.MediumBlue,
                            Diametr = 75
                        };
                        break;
                    case 6:
                        pointPurple = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.BlueViolet,
                            Diametr = 75
                        };
                        break;
                }
            }
            // Создаем экземпляр CounterPoint
            pointCounter = new CounterPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
                Diametr = 100
            };

            // Добавляем pointCounter в список точек воздействия эмиттера
            

            this.emitter = new Emitter
            {
                Direction = 90,
                Spreading = 100,
                SpeedMin = 12,
                SpeedMax = 12,
                ColorFrom = Color.White,
                ColorTo = Color.FromArgb(0, Color.Black),
                ParticlesPerTick = 20,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height * 2 / 7,
                Counter = pointCounter
            };

            emitters.Add(this.emitter);

            emitter.impactPoints.Add(pointRed);
            emitter.impactPoints.Add(pointOrange);
            emitter.impactPoints.Add(pointYellow);
            emitter.impactPoints.Add(pointGreen);
            emitter.impactPoints.Add(pointBlue);
            emitter.impactPoints.Add(pointNavyBlue);
            emitter.impactPoints.Add(pointPurple);
            emitter.impactPoints.Add(pointCounter);


            // Создаем и добавляем трекбары для перемещения точек перекрашивания
            tbPointX = new TrackBar
            {
                Parent = this,
                Width = 100,
                Minimum = 0,
                Maximum = picDisplay.Width,
                Value = (int)pointRed.X,
                Left = 10,
                Top = 10
            };

            tbPointY = new TrackBar
            {
                Parent = this,
                Width = 100,
                Minimum = 0,
                Maximum = picDisplay.Height,
                Value = (int)pointRed.Y,
                Left = 10,
                Top = 30
            };

            tbPointX.Scroll += TbPointX_Scroll;
            tbPointY.Scroll += TbPointY_Scroll;
   
            BtnSwitchPalette.Click += BtnSwitchPalette_Click;


            TrackBar tbPointRadius = new TrackBar
            {
                Parent = this,
                Width = 100,
                Minimum = 10, // Минимальное значение радиуса
                Maximum = initialRadius, // устанавливаем максимальное значение равное начальному размеру кругов
                Value = initialRadius, // начальное значение радиуса
                Left = 200,
                Top = 50
            };

            tbPointRadius.Scroll += tbPointRadius_Scroll;

            TrackBar tbDirection = new TrackBar
            {
                Parent = this,
                Width = 100,
                Minimum = 0,
                Maximum = 360, // Устанавливаем максимальное значение для угла направления
                Value = 90, // Начальное значение угла направления
                Left = 200,
                Top = 100
            };

            tbDirection.Scroll += tbDirection_Scroll;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // тут теперь обновляем эмиттер

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // а тут теперь рендерим через эмиттер
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }


        }

        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                pointCounter.Diametr += 10;
            }
            else if (pointCounter.Diametr != 0)
            {
                pointCounter.Diametr -= 10;
            }
        }

        private void TbPointX_Scroll(object sender, EventArgs e)
        {
            pointRed.X = tbPointX.Value;
            pointOrange.X = tbPointX.Value;
            pointYellow.X = tbPointX.Value;
            pointGreen.X = tbPointX.Value;
            pointBlue.X = tbPointX.Value;
            pointNavyBlue.X = tbPointX.Value;
            pointPurple.X = tbPointX.Value;
        }

        private void TbPointY_Scroll(object sender, EventArgs e)
        {
            pointRed.Y = tbPointY.Value;
            pointOrange.Y = tbPointY.Value;
            pointYellow.Y = tbPointY.Value;
            pointGreen.Y = tbPointY.Value;
            pointBlue.Y = tbPointY.Value;
            pointNavyBlue.Y = tbPointY.Value;
            pointPurple.Y = tbPointY.Value;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetImpactPoints();
            ResetColor();
            ResetTrackbars();
        }
        private void ResetTrackbars()
        {
            // Устанавливаем начальное значение радиуса для трекбара tbPointRadius
            tbPointRadius.Value = initialRadius;

            // Устанавливаем начальное значение направления для трекбара tbDirection
            tbDirection.Value = 90; // Например, снова устанавливаем направление в 90 градусов
        }
        private void ResetImpactPoints()
        {
            int centerX = picDisplay.Width / 2;
            int centerY = picDisplay.Height / 2;
            int radius = Math.Min(picDisplay.Width, picDisplay.Height) / 3;
            int pointsCount = 7;

            for (int i = 0; i < pointsCount; i++)
            {
                double angle = 2 * Math.PI * i / pointsCount;
                int x = (int)(centerX + radius * Math.Cos(angle));
                int y = (int)(centerY + radius * Math.Sin(angle));

                switch (i)
                {
                    case 0:
                        pointRed.X = x;
                        pointRed.Y = y;
                        break;
                    case 1:
                        pointOrange.X = x;
                        pointOrange.Y = y;
                        break;
                    case 2:
                        pointYellow.X = x;
                        pointYellow.Y = y;
                        break;
                    case 3:
                        pointGreen.X = x;
                        pointGreen.Y = y;
                        break;
                    case 4:
                        pointBlue.X = x;
                        pointBlue.Y = y;
                        break;
                    case 5:
                        pointNavyBlue.X = x;
                        pointNavyBlue.Y = y;
                        break;
                    case 6:
                        pointPurple.X = x;
                        pointPurple.Y = y;
                        break;
                }
            }

            // Обновляем значения трекбаров
            tbPointX.Value = (int)pointRed.X;
            tbPointY.Value = (int)pointRed.Y;
        }

        private void ResetColor()
        {
            pointRed.RepaintTo = Color.Red;
            pointOrange.RepaintTo = Color.Orange;
            pointYellow.RepaintTo = Color.Yellow;
            pointGreen.RepaintTo = Color.LawnGreen;
            pointBlue.RepaintTo = Color.Cyan;
            pointNavyBlue.RepaintTo = Color.MediumBlue;
            pointPurple.RepaintTo = Color.BlueViolet;

            // Обновляем отображение
            picDisplay.Invalidate();
        }

        private void BtnSwitchPalette_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Применяем новый цвет к кругам
                pointRed.RepaintTo = colorDialog.Color;
                pointOrange.RepaintTo = colorDialog.Color;
                pointYellow.RepaintTo = colorDialog.Color;
                pointGreen.RepaintTo = colorDialog.Color;
                pointBlue.RepaintTo = colorDialog.Color;
                pointNavyBlue.RepaintTo = colorDialog.Color;
                pointPurple.RepaintTo = colorDialog.Color;

                // Обновляем отображение
                picDisplay.Invalidate();
            }
        }

        private void tbPointRadius_Scroll(object sender, EventArgs e)
        {
            int radius = initialRadius - tbPointRadius.Value; // уменьшаем радиус

            // Обновляем радиус для всех точек перекрашивания
            pointRed.Diametr = radius;
            pointOrange.Diametr = radius;
            pointYellow.Diametr = radius;
            pointGreen.Diametr = radius;
            pointBlue.Diametr = radius;
            pointNavyBlue.Diametr = radius;
            pointPurple.Diametr = radius;

            // Обновляем отображение
            picDisplay.Invalidate();
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
        }
    }
}

