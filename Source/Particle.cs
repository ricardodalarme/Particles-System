using SFML.Graphics;
using SFML.System;
using System;
using static Particles.Program;

namespace Particles
{
    class Particle
    {
        private Vector2f _velocity;
        private Time _lifeTime = Time.Zero;
        private readonly ParticlePool _pool;
        internal Vertex Vertices;

        private Color Color
        {
            get
            {
                Color final;
                System.Drawing.Color start = _pool.StartColor, end = _pool.EndColor;
                final.R = RgbInterpolation(start.R, end.R);
                final.G = RgbInterpolation(start.G, end.G);
                final.B = RgbInterpolation(start.B, end.B);
                final.A = RgbInterpolation(start.A, end.A);
                return final;
            }
        }

        public Particle(ParticlePool pool)
        {
            _pool = pool;
        }

        private double TimeStep => _lifeTime.AsMilliseconds() / (double)_pool.LifeTime;

        private byte RgbInterpolation(byte start, byte end)=> (byte)(start + (end - start) * TimeStep);

        public void Update(Time elapsed)
        {
            _lifeTime -= elapsed;

            // if the particle is dead, respawn it
            if (_lifeTime <= Time.Zero)
                Reset();

            // update the alpha (transparency) of the particle according to its lifetime
            Vertices = new Vertex(Vertices.Position + _velocity * elapsed.AsSeconds(), Color);
        }

        private void Reset()
        {
            // give a random velocity and lifetime to the particle
            double angle = (Randomizer.Next(0, 360)) * 3.14f / 180.0;
            double speed = Randomizer.Next(0, 50) + _pool.Speed;
            _velocity = new Vector2f((float)(Math.Cos(angle) * speed), (float)(Math.Sin(angle) * speed));
            _lifeTime = Time.FromMilliseconds((Randomizer.Next(0, _pool.LifeTime)) + 1000);

            // reset the position of the corresponding vertex
            Vertices = new Vertex(_pool.Emitter);
        }
    }
}
