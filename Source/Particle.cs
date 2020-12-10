﻿using System;
using SFML.Graphics;
using SFML.System;
using static Particles.Program;

namespace Particles
{
    internal class Particle : Sprite
    {
        private readonly ParticlePool _pool;
        private Time _lifeTime = Time.Zero;
        private Vector2f _velocity;

        public Particle(ParticlePool pool)
        {
            _pool = pool;
            Texture = Textures[_pool.Texture];
            TextureRect = new IntRect(0, 0, (int)Textures[_pool.Texture].Size.X, (int)Textures[_pool.Texture].Size.Y);
        }

        private Color CurrentColor
        {
            get
            {
                Color final;
                System.Drawing.Color start = _pool.StartColor, end = _pool.EndColor;
                final.R = (byte)Interpolation(start.R, end.R);
                final.G = (byte)Interpolation(start.G, end.G);
                final.B = (byte)Interpolation(start.B, end.B);
                final.A = (byte)Interpolation(start.A, end.A);
                return final;
            }
        }

        private float CurrentSize => (float)Interpolation(_pool.StartSize, _pool.EndSize);

        private double TimeStep => _lifeTime.AsMilliseconds() / (double)_pool.LifeTime;

        private double Interpolation(int start, int end) => start + (end - start) * TimeStep;

        public void Update(Time elapsed)
        {
            _lifeTime -= elapsed;

            // if the particle is dead, respawn it
            if (_lifeTime <= Time.Zero) Reset();

            // update the alpha (transparency) of the particle according to its lifetime
            Position += _velocity * elapsed.AsSeconds();
            Color = CurrentColor;
            Scale = new Vector2f(CurrentSize / Textures[_pool.Texture].Size.X, CurrentSize / Textures[_pool.Texture].Size.Y);
        }

        private void Reset()
        {
            // give a random velocity and lifetime to the particle
            var angle = Randomizer.Next(0, 360) * 3.14f / 180.0;
            double speed = Randomizer.Next(0, 50) + _pool.Speed;
            _velocity = new Vector2f((float)(Math.Cos(angle) * speed), (float)(Math.Sin(angle) * speed));
            _lifeTime = Time.FromMilliseconds(Randomizer.Next(0, _pool.LifeTime) + 1000);

            // reset the position of the corresponding vertex
            Position = _pool.Emitter;
        }
    }
}