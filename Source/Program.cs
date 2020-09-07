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

        [STAThread]
        static void Main()
        {
            // Open the main form
            var form = new Editor();
            form.Show();

            // create the window
            RenderWindow window = new RenderWindow(form.picParticle.Handle);

            // Create the particle pool
            ParticlePool particles = new ParticlePool(100, 5000);

            // create a clock to track the elapsed time
            Clock clock = new Clock();

            // run the main loop
            while (window.IsOpen)
            {
                // make the particle system emitter follow the mouse
                particles.Emitter = new Vector2f(150, 150);

                // update it
                Time elapsed = clock.Restart();
                particles.Update(elapsed);

                // draw it
                window.Clear();
                window.Draw(particles);
                window.Display();
                Application.DoEvents();
            }
        }
    }
}
