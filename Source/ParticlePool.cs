﻿using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Particles
{
    class ParticlePool : Drawable
    {
        // Pool propertiess
        public int Speed { get; set; }

        // Cor da partícula
        [Category("Color")]
        public byte R { get; set; }
        [Category("Color")]
        public byte G { get; set; }
        [Category("Color")]
        public byte B { get; set; }

        public int Count
        {
            get => Particles.Capacity; 
            set
            {
                Particles.Clear();
                Particles.Capacity = value;
                for (var i = 0; i < Count; i++) Particles.Add(new Particle(this));
            }
        }

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
        }

        // Pool informations
        public Time lifeTime;
        public Vector2f Emitter = new Vector2f(0f, 0f);
        public List<Particle> Particles = new List<Particle>();

        public void Update(Time elapsed)
        {
            Particles.ForEach(p => p.Update(elapsed));
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            var array = new VertexArray(PrimitiveType.Points, (uint)Count);
            for (int i = 0; i < Count; i++) array[(uint)i] = Particles[i].Vertices;
            target.Draw(array, states);
        }
    }
}
