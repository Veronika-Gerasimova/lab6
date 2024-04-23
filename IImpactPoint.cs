using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;
        public abstract void ImpactParticle(Particle particle);
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red), X - 5, Y - 5, 10, 10);
        }
    }

    public class GravityPoint : IImpactPoint
    {
        public int Power = 100;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius / 2 < Power / 2)
            {
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
        }
    }
    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= gX * Power / r2;
            particle.SpeedY -= gY * Power / r2;
        }
    }

    public class CounterPoint : IImpactPoint
    {
        public int Diametr = 100;
        public int Counter = 0;
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius / 2 < Diametr / 2) // если частица оказалось внутри окружности
            {
                Counter++;
                if (particle is ParticleColorful particleColorful)
                {
                    particleColorful.IsInCounterPoint = true;
                }
            }
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Salmon), X - Diametr / 2, Y - Diametr / 2, Diametr, Diametr);

            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            var text = $"{Counter}";
            var font = new Font("Verdana", 12);

            g.DrawString(text, font, new SolidBrush(Color.White), X, Y, stringFormat);
        }
    }
    public interface IRepaintable
    {
        Color RepaintTo { get; set; }
        
    }
    public class RepaintingPoint : IImpactPoint, IRepaintable
    {
        public Color RepaintTo { get; set; }

        public int Diametr = 75;
        public override void ImpactParticle(Particle particle)
        {
            var gX = X - particle.X;
            var gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius / 2 < Diametr / 2)
            {
                if (particle is ParticleColorful particleСolorful)
                {
                    particleСolorful.FromColor = RepaintTo;
                    particleСolorful.ToColor = Color.FromArgb(1, RepaintTo);
                }
            }
        }
        public override void Render(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(RepaintTo), X - Diametr / 2, Y - Diametr / 2, Diametr, Diametr);
        }
    }
}
