using SFML.Graphics;
using SFML.System;
using System.ComponentModel;
using static Particles.Program;

namespace Particles
{
    internal class ParticlePool 
    {
        // Pool properties
        [Category("Movement"), Description("How fast particle move.")]
        public int Speed { get; set; }

        [Category("Movement"), Description("How fast you want the texture to spin.")]
        public bool RotationSpeed { get; set; }

        [Category("Movement"), Description("Particle emitter follow the mouse.")]
        public bool FollowMouse { get; set; }

        [Category("Size"), DefaultValue(1), Description("Particle size when born.")]
        public int StartSize { get; set; }

        [Category("Size"), DefaultValue(1), Description("Particle size when die.")]
        public int EndSize { get; set; }

        [Category("Color"), Description("Particle color when born.")]
        public System.Drawing.Color StartColor { get; set; }

        [Category("Color"), Description("Particle color when die.")]
        public System.Drawing.Color EndColor { get; set; }

        [Category("General"), Description("The texture of the particles.")]
        public int Texture { get; set; }

        [Category("General"), Description("Maximum amount of particles in a pool.")]
        public int Count
        {
            get => _particles.Length;
            set
            {
                _particles = new Particle[value];
                for (var i = 0; i < Count; i++) _particles[i] = new Particle(this);
            }
        }

        [Category("General"), Description("How many miliseconds an particle lives.")]
        public int LifeTime
        {
            get => _lifeTime.AsMilliseconds();
            set => _lifeTime = Time.FromMilliseconds(value);
        }

        public ParticlePool()
        {
            // Default values
            Speed = 50;
            StartSize = EndSize = 1;
            Count = 1000;
            LifeTime = 500;
            StartColor = EndColor = System.Drawing.Color.White;
        }

        // Pool informations
        private Time _lifeTime;

        internal Vector2f Emitter => FollowMouse ? Window.MapPixelToCoords(SFML.Window.Mouse.GetPosition(Window)) : new Vector2f(Window.Size.X / 2, Window.Size.Y / 2);

        private Particle[] _particles;

        public void Update(Time elapsed)
        {
            foreach (var particle in _particles) particle.Update(elapsed);
        }

        public void Draw(RenderWindow target)
        {
            foreach (var particle in _particles) target.Draw(particle, new RenderStates(BlendMode.Add));
        }
    }
}