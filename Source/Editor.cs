using DarkUI.Forms;

namespace Particles
{
    public partial class Editor : DarkForm
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void butReset_Click(object sender, System.EventArgs e)
        {
           Program.Particles = new ParticlePool();
        }

        private void Editor_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Program.Working = false;
        }
    }
}
