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
        List<Particle> particles = new List<Particle>(); //список частиц, которые создает и управляет эмиттер
        public int MousePositionX;
        public int MousePositionY;
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();  //список точек(кругов), которые могут повлиять на поведение частиц
        public float GravitationX = 0; //гравитационное ускорение по оси X. Ее значение добавляется к текущей скорости частицы по оси X (particle.SpeedX) в каждой итерации обновления состояния частиц
        public float GravitationY = 1;
      
        public int X;
        public int Y;
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // Угол, в пределах которого частицы могут распространяться относительно основного направления
        public int SpeedMin = 1; //Частицы будут двигаться со случайной скоростью в диапазоне от SpeedMin до SpeedMax
        public int SpeedMax = 10;
        public int RadiusMin = 2; //Частицы будут иметь случайный радиус в диапазоне от RadiusMin до RadiusMax.
        public int RadiusMax = 10;
        public int LifeMin = 50;  //Частица исчезнет через случайное количество тиков
        public int LifeMax = 100;
        public int ParticlesPerTick = 20;
        public Color ColorFrom = Color.White;  //Используется для создания эффекта плавного перехода цвета у частицы.
        public Color ColorTo = Color.FromArgb(0, Color.Black);
        public CounterPoint Counter;

        public event EventHandler ParticleCreated;

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

            foreach (var point in impactPoints)
            {
                point.ImpactParticle(particle);
            }
        }

        //Виртуальный метод для создания новой частицы
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;
            OnParticleCreated();

            return particle;

        }
        protected virtual void OnParticleCreated()
        {
            ParticleCreated?.Invoke(this, EventArgs.Empty);
        }

        //Метод для обновления логики эмиттера и его частиц
        public void UpdateState()
        {
            Counter.Counter = 0;
            int particlesToCreate = ParticlesPerTick; //сколько частиц нужно создать на каждой итерации обновления

            foreach (var particle in particles)
            {
                if (particle is ParticleColorful particleColorful)
                {
                    particleColorful.IsInCounterPoint = false; //не находится в точке счетчика
                }
                if (particle.Life <= 0)
                {
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle); //чтобы сбросить параметры частицы перед ее повторным использованием
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

            while (particlesToCreate >= 1) //Пока остаются еще частицы для создания
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
            particles.RemoveAll(p => p.Life <= 0);
        }
        //Метод для отрисовки всех частиц и точек воздействия эмиттера на графическом объекте g
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g); //для каждой частицы вызывается метод для отрисовки частицы
            }
            foreach (var point in impactPoints) //цикл проходит по всем кругам, которые влияют на отображение частицы
            {
                point.Render(g); //отрисовывает круг
            }
        }
    }
}