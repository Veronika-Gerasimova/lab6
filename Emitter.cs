﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Emitter
    {
        List<Particle> particles = new List<Particle>();
        public int MousePositionX;
        public int MousePositionY;
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();
        public float GravitationX = 0;
        public float GravitationY = 1;
        public int ParticlesCount = 500;
        public int X;
        public int Y;
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1;
        public int SpeedMax = 10;
        public int RadiusMin = 2;
        public int RadiusMax = 10;
        public int LifeMin = 50;
        public int LifeMax = 100;
        public int ParticlesPerTick = 1;
        public Color ColorFrom = Color.White;
        public Color ColorTo = Color.FromArgb(0, Color.Black);
        public CounterPoint Counter;

        //Метод для сброса параметров частицы перед ее повторным использованием
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;

            if (particle is ParticleColorful particleColorful)
            {
                particleColorful.FromColor = ColorFrom;
                particleColorful.ToColor = ColorTo;
            }

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
            Counter.ImpactParticle(particle);
        }
        //Виртуальный метод для создания новой частицы
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
        //Метод для обновления состояния эмиттера и его частиц
        public void UpdateState()
        {
            Counter.Counter = 0;
            int particlesToCreate = ParticlesPerTick;

            foreach (var particle in particles)
            {
                if (particle is ParticleColorful particleColorful)
                {
                    particleColorful.IsInCounterPoint = false;
                }
                if (particle.Life <= 0)
                {
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle);
                    }
                }
                else
                {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                    particle.Life -= 1;

                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }

            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }
        //Метод для отрисовки всех частиц и точек воздействия эмиттера на графическом объекте g
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }
    }
}
