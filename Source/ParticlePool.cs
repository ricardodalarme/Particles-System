using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Particles
{
    class ParticlePool : Drawable
    {
        // Pool properties
        public int Speed { get; set; }
        public int Count
        {
            get => Particles.Length;
            set
            {
                Particles = new Particle[value];
                for (var i = 0; i < Count; i++) Particles[i] = new Particle(this);
            }
        }

        // Particle RGB color
        [Category("Color")]
        public byte R { get; set; }
        [Category("Color")]
        public byte G { get; set; }
        [Category("Color")]
        public byte B { get; set; }

        public int LifeTime
        {
            get => lifeTime.AsMilliseconds();
            set => lifeTime = Time.FromMilliseconds(value);
        }

        public ParticlePool()
        {
            // Default values
            Speed = 50;
            Count = 1000;
            LifeTime = 100;
            R = G = B=255;
        }

        // Pool informations
        internal Time lifeTime;
        internal Vector2f Emitter = new Vector2f(0f, 0f);
        internal Particle[] Particles;

        public void Update(Time elapsed)
        {
            foreach (var particle in Particles)
                particle.Update(elapsed);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            var array = new VertexArray(PrimitiveType.Points, (uint)Count);
            for (int i = 0; i < Count; i++) array[(uint)i] = Particles[i].Vertices;
            target.Draw(array, states);
        }
    }
}
