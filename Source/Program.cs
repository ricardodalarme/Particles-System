using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Particles
{
    

    static class Program
    {



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Editor();
            form.Show();
            //  new Editor();

            // create the window
            RenderWindow window = new RenderWindow(form.picParticle.Handle);

            // create the particle system
            ParticleSystem particles = new ParticleSystem(10000);

            // create a clock to track the elapsed time
            Clock clock = new Clock();

            // run the main loop
            while (window.IsOpen)
            {
                // make the particle system emitter follow the mouse
                particles.setEmitter(new Vector2f(150, 150));

                // update it
                Time elapsed = clock.Restart();
                particles.update(elapsed);

                // draw it
                window.Clear();
                window.Draw(particles);
                window.Display();
                Application.DoEvents();
            }

        }
    }
}
