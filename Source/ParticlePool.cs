using System.ComponentModel;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Color = System.Drawing.Color;

namespace Particles
{
    internal class ParticlePool
    {
        private Particle[] _particles;

        public ParticlePool()
        {
            // Default values
            Speed = 50;
            StartSize = EndSize = 1;
            Count = 1000;
            LifeTime = 500;
            StartColor = EndColor = Color.White;
            AngleRangeMin = 0;
            AngleRangeMax = 360;
            SpeedMinRand = 0;
            SpeedMaxRand = 50;
            LifeTimeMinRand = 0;
            LifeTimeMaxRand = 150;
        }

        // Pool properties
        [Category("Speed")]
        [DisplayName("Value")]
        [Description("How fast particle move.")]
        public int Speed { get; set; }

        [Category("Speed")]
        [DisplayName("Minimum rand")]
        [Description("Minimum value that the particle speed changes.")]
        public int SpeedMinRand { get; set; }

        [Category("Speed")]
        [DisplayName("Maximum rand")]
        [Description("Maximum value that the particle speed changes.")]
        public int SpeedMaxRand { get; set; }

        [Category("Angle Range")]
        [DisplayName("Minimum")]
        [Description("Minimum angle range of the particle flow.")]
        public int AngleRangeMin { get; set; }

        [Category("Angle Range")]
        [DisplayName("Maximum")]
        [Description("Maximum angle range of the particle flow.")]
        public int AngleRangeMax { get; set; }

        [Category("Size")]
        [DisplayName("Start")]
        [DefaultValue(1)]
        [Description("Particle size when born.")]
        public int StartSize { get; set; }

        [Category("Size")]
        [DefaultValue(1)]
        [DisplayName("End")]
        [Description("Particle size when die.")]
        public int EndSize { get; set; }

        [Category("Color")]
        [DisplayName("Start")]
        [Description("Particle color when born.")]
        public Color StartColor { get; set; }

        [Category("Color")]
        [DisplayName("End")]
        [Description("Particle color when die.")]
        public Color EndColor { get; set; }

        [Category("General")]
        [Description("The texture of the particles.")]
        public int Texture { get; set; }

        [Category("General")]
        [Description("Particle emitter follow the mouse.")]
        [DisplayName("Follow Mouse")]
        public bool FollowMouse { get; set; }

        [Category("General")]
        [Description("Maximum amount of particles in a pool.")]
        public int Count
        {
            get => _particles.Length;
            set
            {
                _particles = new Particle[value];
                for (var i = 0; i < Count; i++) _particles[i] = new Particle(this);
            }
        }

        [Category("Life Time")]
        [DisplayName("Value")]
        [Description("How many miliseconds an particle lives.")]
        public int LifeTime { get; set; }


        [Category("Life Time")]
        [DisplayName("Minimum rand")]
        [Description("Minimum value that the particle lifetime changes.")]
        public int LifeTimeMinRand { get; set; }

        [Category("Life Time")]
        [DisplayName("Maximum rand")]
        [Description("Maximum value that the particle lifetime changes.")]
        public int LifeTimeMaxRand { get; set; }

        internal Vector2f Emitter => FollowMouse ? Program.Window.MapPixelToCoords(Mouse.GetPosition(Program.Window)) : new Vector2f(Program.Window.Size.X / 2, Program.Window.Size.Y / 2);

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