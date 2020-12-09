using SFML.Graphics;
using SFML.System;
using System.ComponentModel;
using static Particles.Program;

namespace Particles
{
    class ParticlePool : Drawable
    {
        // Pool properties
        public int Speed { get; set; }
        public bool FollowMouse { get; set; }
        public int Count
        {
            get => _particles.Length;
            set
            {
                _particles = new Particle[value];
                for (var i = 0; i < Count; i++) _particles[i] = new Particle(this);
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
            get => _lifeTime.AsMilliseconds();
            set => _lifeTime = Time.FromMilliseconds(value);
        }

        public ParticlePool()
        {
            // Default values
            Speed = 50;
            Count = 1000;
            LifeTime = 500;
            R = G = B = 255;
        }

        // Pool informations
        private Time _lifeTime;

        internal Vector2f Emitter => FollowMouse ? Window.MapPixelToCoords(SFML.Window.Mouse.GetPosition(Window)) : new Vector2f(Window.Size.X / 2, Window.Size.Y / 2);

        private Particle[] _particles;

        public void Update(Time elapsed)
        {
            foreach (var particle in _particles)
                particle.Update(elapsed);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            var array = new VertexArray(PrimitiveType.Points, (uint)Count);
            for (var i = 0; i < Count; i++) array[(uint)i] = _particles[i].Vertices;
            target.Draw(array, states);
        }
    }
}
