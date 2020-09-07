using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

namespace Particles
{
    class ParticleSystem : Drawable
    {
        public ParticleSystem(int count)
        {
            m_lifetime = Time.FromMilliseconds(500);
            m_emitter = new Vector2f(0f, 0f);
            m_vertices = new VertexArray(PrimitiveType.Points, (uint)count);
            for (var i = 0; i < count; i++)
            {
                m_particles.Add(new Particle
                {
                    LifeTime = Time.Zero
                });
                
            }
        }

        public List<Particle> m_particles = new List<Particle>();
        public VertexArray m_vertices;
        public Time m_lifetime;
        public Vector2f m_emitter;
        public Random random = new Random();

        public void setEmitter(Vector2f position)
        {
            m_emitter = position;
        }

        public void update(Time elapsed)
        {
            for (int i = 0; i < m_particles.Count; ++i)
            {
                // update the particle lifetime
                Particle p = m_particles[i];
                p.LifeTime -= elapsed;

                // if the particle is dead, respawn it
                if (p.LifeTime <= Time.Zero)
                    resetParticle(i);

                // update the alpha (transparency) of the particle according to its lifetime
                float ratio = p.LifeTime.AsSeconds() / m_lifetime.AsSeconds();
                m_vertices[(uint)i] = new Vertex(
                    m_vertices[(uint)i].Position + p.Velocity * elapsed.AsSeconds(),
                    new Color(220, 255, 255, (byte)(ratio * 255))
                    );
            }
        }

        public void resetParticle(int index)
        {
            // give a random velocity and lifetime to the particle
            double angle = (random.Next(0, 360)) * 3.14f / 180.0;
            double speed = random.Next(0, 50) + 50.0;
            m_particles[index].Velocity = new Vector2f((float)(Math.Cos(angle) * speed), (float)(Math.Sin(angle) * speed));
            m_particles[index].LifeTime = Time.FromMilliseconds((random.Next(0, m_lifetime.AsMilliseconds())) + 1000);

            // reset the position of the corresponding vertex
            m_vertices[(uint)index] = new Vertex(m_emitter);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {

            // draw the vertex array
            target.Draw(m_vertices, states);
        }
    }
}
