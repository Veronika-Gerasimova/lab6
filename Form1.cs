using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
        private int initialDirection = 90; //движение частицы вверх
        private int totalParticles;
        private int particlesCreatedThisTick = 0;
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            picDisplay.MouseWheel += picDisplay_MouseWheel;

            this.initialDirection = 90;

            int centerX = picDisplay.Width / 2;
            int centerY = picDisplay.Height / 2;
            int radius = Math.Min(picDisplay.Width, picDisplay.Height) / 3; //минимальное значение между шириной и высотой элемента управления, делится на 3
                                                                            //для определения радиуса окружности, которая будет использоваться для расположения
                                                                            //точек вокруг центральной точки
            int pointsCount = 7;

            for (int i = 0; i < pointsCount; i++)
            {
                double angle = 2 * Math.PI * i / pointsCount;  //угол для текущей точки на окружности. Угол вычисляется так, чтобы точки были равномерно распределены по окружности
                int x = (int)(centerX + radius * Math.Cos(angle)); //вычисляет координату X для текущей точки на окружности
                int y = (int)(centerY + radius * Math.Sin(angle));

                switch (i)
                {
                    case 0:
                        pointRed = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.Red, // цвет, в который будет перекрашиваться частица
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

            pointCounter = new CounterPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
                Diametr = 100
            };

            this.emitter = new Emitter
            {
                Direction = 90, //начальное направление частиц
                Spreading = 100, //угол рассеивания частиц относительно начального направления
                SpeedMin = 12,
                SpeedMax = 12,
                ColorFrom = Color.White, //начальный цвет частиц
                ColorTo = Color.FromArgb(0, Color.Black), //конечный цвет частиц
                ParticlesPerTick = 20, //количество частиц, выпускаемых за один tick
                X = picDisplay.Width / 2,
                Y = picDisplay.Height * 2 / 7,
                Counter = pointCounter //для подсчета частиц
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
               Value = 0,
                Left = 10,
                Top = 10
            };

            tbPointY = new TrackBar
            {
                Parent = this,
                Width = 100,
                Minimum = 0,
                Maximum = picDisplay.Height,
                Value = 0,
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
        //Обновление состояния эмиттера и отрисовки частиц
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image)) //объект , который используется для рисования на изображении picDisplay.Image
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }

            picDisplay.Invalidate();
        }


        //Обработка движения мыши 
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;  
        }
        // Обработка колесика мыши для изменения местоположения круга-счетчика
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            pointCounter.X = e.X;
            pointCounter.Y = e.Y;
            picDisplay.Invalidate();
        }
        //Обработка события изменения положения кругов по оси X
        private void TbPointX_Scroll(object sender, EventArgs e)
        {
            pointRed.X = tbPointX.Value;
            pointOrange.X = tbPointX.Value;
            pointYellow.X = tbPointX.Value;
            pointGreen.X = tbPointX.Value;
            pointBlue.X = tbPointX.Value;
            pointNavyBlue.X = tbPointX.Value;
            pointPurple.X = tbPointX.Value;
            picDisplay.Invalidate();
        }
        //Обработка события изменения положения кругов по оси Y
        private void TbPointY_Scroll(object sender, EventArgs e)
        {
            pointRed.Y = tbPointY.Value;
            pointOrange.Y = tbPointY.Value;
            pointYellow.Y = tbPointY.Value;
            pointGreen.Y = tbPointY.Value;
            pointBlue.Y = tbPointY.Value;
            pointNavyBlue.Y = tbPointY.Value;
            pointPurple.Y = tbPointY.Value;
            picDisplay.Invalidate();
        }
        //Обработка нажатия на кнопку «Сброс»
        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetImpactPoints();
            ResetColor();

        }
        //Сброс координат точек перекрашивания
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
            // Обновляем координаты для точки снега
            pointCounter.X = centerX;
            pointCounter.Y = centerY;

            // Восстанавливаем начальное направление снега
            emitter.Direction = initialDirection;
            // Обновляем значения трекбаров
            tbPointX.Value = (int)pointRed.X;
            tbPointY.Value = (int)pointRed.Y;
        }
        //Сброс цвета точек перекрашевания
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
        //Обработка нажатия на кнопку смены палитры
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
        //Обработка изменения радиуса точек перекрашивания
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
        //Обработка изменения направления эмиттера
        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
        }
    }
}
