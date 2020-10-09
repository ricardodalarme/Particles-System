using SFML.Graphics;
using SFML.System;
using System;
using System.Windows.Forms;

namespace Particles
{
    static class Program
    {
        // To generate random numbers
        public static Random Randomizer = new Random();

        // Create the particle pool
        public static ParticlePool Particles = new ParticlePool();

        // Application main form
        public static Editor Form;
        public static bool Working = true;

        [STAThread]
        static void Main()
        {
            Clock clock = new Clock();

            // Open the main form
            Application.EnableVisualStyles();
            Form = new Editor();
            Form.Show();

            // Create the windows
            RenderWindow window = new RenderWindow(Form.picParticle.Handle);

            // Run the main loop
            while (Working)
            {
                // Make the particle system emitter follow the mouse
                Particles.Emitter = new Vector2f(window.Size.X / 2, window.Size.Y / 2);

                // Update it
                Time elapsed = clock.Restart();
                Particles.Update(elapsed);

                // Draw it
                window.Clear();
                window.Draw(Particles);
                window.Display();
                Application.DoEvents();
            }
        }
    }
}
