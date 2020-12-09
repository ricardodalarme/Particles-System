using SFML.Graphics;
using SFML.System;
using System;
using System.Drawing;
using static Particles.Program;
using Color = SFML.Graphics.Color;

namespace Particles
{
    internal class Particle: Sprite
    {
        private Vector2f _velocity;
        private Time _lifeTime = Time.Zero;
        private readonly ParticlePool _pool;

        private Color CurrentColor
        {
            get
            {
                Color final;
                System.Drawing.Color start = _pool.StartColor, end = _pool.EndColor;
                final.R = Interpolation(start.R, end.R);
                final.G = Interpolation(start.G, end.G);
                final.B = Interpolation(start.B, end.B);
                final.A = Interpolation(start.A, end.A);
                return final;
            }
        }

        public Particle(ParticlePool pool)
        {
            _pool = pool;
        }

        private double TimeStep => _lifeTime.AsMilliseconds() / (double)_pool.LifeTime;

        private byte Interpolation(byte start, byte end) => (byte)(start + (end - start) * TimeStep);

        public void Update(Time elapsed)
        {
            _lifeTime -= elapsed;

            // if the particle is dead, respawn it
            if (_lifeTime <= Time.Zero) Reset();

            // update the alpha (transparency) of the particle according to its lifetime
            Texture = Textures[_pool.Texture];
            Position += _velocity * elapsed.AsSeconds();
            Color = CurrentColor;
            Scale = new Vector2f((float)_pool.StartSize / Textures[_pool.Texture].Size.X, (float)_pool.StartSize / Textures[_pool.Texture].Size.Y);
            TextureRect = new IntRect(0, 0, (int)Textures[_pool.Texture].Size.X, (int)Textures[_pool.Texture].Size.Y);
        }

        private void Reset()
        {
            // give a random velocity and lifetime to the particle
            double angle = (Randomizer.Next(0, 360)) * 3.14f / 180.0;
            double speed = Randomizer.Next(0, 50) + _pool.Speed;
            _velocity = new Vector2f((float)(Math.Cos(angle) * speed), (float)(Math.Sin(angle) * speed));
            _lifeTime = Time.FromMilliseconds((Randomizer.Next(0, _pool.LifeTime)) + 1000);

            // reset the position of the corresponding vertex
            Position = _pool.Emitter;
        }
    }
}
