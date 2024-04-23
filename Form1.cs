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
        Emitter emitter; // добавим поле для эмиттера
        RepaintingPoint pointRed;
        RepaintingPoint pointOrange;
        RepaintingPoint pointYellow;
        RepaintingPoint pointGreen;
        RepaintingPoint pointBlue;
        RepaintingPoint pointNavyBlue;
        RepaintingPoint pointPurple;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // а тут теперь вручную создаем
            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };

            //расположим по кругу 
            int centerX = picDisplay.Width / 2;
            int centerY = picDisplay.Height / 2;
            int radius = Math.Min(picDisplay.Width, picDisplay.Height) / 3;
            int pointsCount = 7; // количество точек

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
                            RepaintTo = Color.Red
                        };
                        break;
                    case 1:
                        pointOrange = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.Orange
                        };
                        break;
                    case 2:
                        pointYellow = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.Yellow
                        };
                        break;
                    case 3:
                        pointGreen = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.LawnGreen
                        };
                        break;
                    case 4:
                        pointBlue = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.Cyan
                        };
                        break;
                    case 5:
                        pointNavyBlue = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.MediumBlue
                        };
                        break;
                    case 6:
                        pointPurple = new RepaintingPoint
                        {
                            X = x,
                            Y = y,
                            RepaintTo = Color.BlueViolet
                        };
                        break;
                }
            }

            emitter.impactPoints.Add(pointRed);
            emitter.impactPoints.Add(pointOrange);
            emitter.impactPoints.Add(pointYellow);
            emitter.impactPoints.Add(pointGreen);
            emitter.impactPoints.Add(pointBlue);
            emitter.impactPoints.Add(pointNavyBlue);
            emitter.impactPoints.Add(pointPurple);
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

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }
    }
}
