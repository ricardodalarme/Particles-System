using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SFML.Window;

namespace Particles
{
    static class Program
    {
        // To generate random numbers
        public static Random Randomizer = new Random();

        // Create the particle pool
        public static ParticlePool Particles = new ParticlePool();

        // Create the windows
        public static RenderWindow Window;

        // Application main form
        public static Editor Form;
        public static bool Working = true;

        // Textures
        public static List<Texture> Textures = new List<Texture>();

        [STAThread]
        static void Main()
        {
            Clock clock = new Clock();

            // Open the main form
            Application.EnableVisualStyles();
            Form = new Editor();
            Form.Show();

            Window = new RenderWindow(Form.picParticle.Handle);

            // Load all textures
            int i = 1;
            string directory;
            while (  File.Exists(directory = $"{Application.StartupPath}\\Particles\\{i++}.png"))
                Textures.Add(new Texture(directory));

            // Run the main loop
            while (Working)
            {
                // Update it
                Time elapsed = clock.Restart();
                Particles.Update(elapsed);

                // Draw it
                Window.Clear();
                Particles.Draw(Window);
                Window.Display();
                Application.DoEvents();
            }
        }
    }
}
