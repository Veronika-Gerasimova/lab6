﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;
        public bool IsInCounterPoint = false;

        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb((int)(color2.A * k + color1.A * (1 - k)),
                                  (int)(color2.R * k + color1.R * (1 - k)),
                                  (int)(color2.G * k + color1.G * (1 - k)),
                                  (int)(color2.B * k + color1.B * (1 - k)));
        }

        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(IsInCounterPoint ? Color.Salmon : color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }
}
