using SFML.Graphics;
using SFML.System;
using System;
using static Particles.Program;

namespace Particles
{
    class Particle 
    {
        private Vector2f Velocity;
        private Time LifeTime = Time.Zero;
        private readonly ParticlePool Pool;
        internal Vertex Vertices;

        public Particle(ParticlePool pool)
        {
            Pool = pool;
        }

        public void Update(Time elapsed)
        {
            LifeTime -= elapsed;

            // if the particle is dead, respawn it
            if (LifeTime <= Time.Zero)
                Reset();

            // update the alpha (transparency) of the particle according to its lifetime
            float ratio = LifeTime.AsMilliseconds() / Pool.LifeTime;
            Vertices = new Vertex(
                Vertices.Position + Velocity * elapsed.AsSeconds(),
                    new Color(Pool.R, Pool.G, Pool.B, (byte)(ratio * 255))
                );
        }

        public void Reset()
        {
            // give a random velocity and lifetime to the particle
            double angle = (Randomizer.Next(0, 360)) * 3.14f / 180.0;
            double speed = Randomizer.Next(0, 50) + Pool.Speed;
            Velocity = new Vector2f((float)(Math.Cos(angle) * speed), (float)(Math.Sin(angle) * speed));
            LifeTime = Time.FromMilliseconds((Randomizer.Next(0, Pool.LifeTime)) + 1000);

            // reset the position of the corresponding vertex
            Vertices = new Vertex(Pool.Emitter);
        }
    }
}
