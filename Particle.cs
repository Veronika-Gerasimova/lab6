using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab6
{
    public class Particle
    {
        public int Radius; // радиус частицы
        public float X; // X координата положения частицы в пространстве
        public float Y;  // Y координата положения частицы в пространстве

        public float SpeedX;
        public float SpeedY;
        public float Life;

        public static Random rand = new Random();

        //Виртуальный метод, отрисовывающий частицу на графическом контексте g
        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            int alpha = (int)(k * 255);
            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color); //для отрисовки частицы

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            b.Dispose();
        }
    }

    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;
        public bool IsInCounterPoint = false;

        //Создания плавного перехода цвета частицы от FromColor к ToColor
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb((int)(color2.A * k + color1.A * (1 - k)),
                                  (int)(color2.R * k + color1.R * (1 - k)),
                                  (int)(color2.G * k + color1.G * (1 - k)),
                                  (int)(color2.B * k + color1.B * (1 - k)));
        }
        //Переопределенный метод, отрисовывающий частицу на графическом контексте g
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(IsInCounterPoint ? Color.Salmon : color); //метод представляет конструктор класса SolidBrush,
                                                                             //который создает объект SolidBrush с указанным цветом

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }
}
