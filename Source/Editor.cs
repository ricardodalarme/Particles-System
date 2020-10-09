using DarkUI.Forms;

namespace Particles
{
    public partial class Editor : DarkForm
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void Editor_Load(object sender, System.EventArgs e)
        {
            prgProperties.SelectedObject = Program.Particles;
        }

        private void Editor_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Program.Working = false;
        }
    }
}
