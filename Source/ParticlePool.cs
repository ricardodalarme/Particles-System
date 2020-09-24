using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using static Particles.Program;

namespace Particles
{
    class ParticlePool : Drawable
    {
        public ParticlePool()
        {
            LifeTime = Time.FromMilliseconds((int)Form.numLifeTime.Value);
            Speed = (int)Form.numSpeed.Value;
            Vertices = new VertexArray(PrimitiveType.Points, (uint)Form.numCount.Value);
            for (var i = 0; i < Vertices.VertexCount; i++) Particles.Add(new Particle());
        }

        // Pool informations
        public Vector2f Emitter { get; set; } = new Vector2f(0f, 0f);
        public List<Particle> Particles = new List<Particle>();
        public VertexArray Vertices;

        // Pool properties
        public Time LifeTime { get; set; }
        public int Speed { get; set; }

        public void Update(Time elapsed)
        {
            for (int i = 0; i < Particles.Count; ++i)
            {
                // update the particle lifetime
                Particle p = Particles[i];
                p.LifeTime -= elapsed;

                // if the particle is dead, respawn it
                if (p.LifeTime <= Time.Zero)
                    ResetParticle(i);

                // update the alpha (transparency) of the particle according to its lifetime
                float ratio = p.LifeTime.AsSeconds() / LifeTime.AsSeconds();
                Vertices[(uint)i] = new Vertex(
                    Vertices[
                        (uint)i].Position + p.Velocity * elapsed.AsSeconds(),
                        new Color(220, 255, 255, (byte)(ratio * 255))
                    );
            }
        }

        public void ResetParticle(int index)
        {
            // give a random velocity and lifetime to the particle
            double angle = (Randomizer.Next(0, 360)) * 3.14f / 180.0;
            double speed = Randomizer.Next(0, 50) + Speed;
            Particles[index].Velocity = new Vector2f((float)(Math.Cos(angle) * speed), (float)(Math.Sin(angle) * speed));
            Particles[index].LifeTime = Time.FromMilliseconds((Randomizer.Next(0, LifeTime.AsMilliseconds())) + 1000);

            // reset the position of the corresponding vertex
            Vertices[(uint)index] = new Vertex(Emitter);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            // draw the vertex array
            target.Draw(Vertices, states);
        }
    }
}
