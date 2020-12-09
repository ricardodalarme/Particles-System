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

        public Particle(ParticlePool pool)
        {
            _pool = pool;
        }

        public void Update(Time elapsed)
        {
            _lifeTime -= elapsed;

            // if the particle is dead, respawn it
            if (_lifeTime <= Time.Zero)
                Reset();

            // update the alpha (transparency) of the particle according to its lifetime
            double ratio = _lifeTime.AsMilliseconds() / _pool.LifeTime;
            Vertices = new Vertex(
                Vertices.Position + _velocity * elapsed.AsSeconds(),
                    new Color(_pool.R, _pool.G, _pool.B, (byte)(ratio * 255))
                );
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
