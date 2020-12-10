using System;
using System.Windows.Forms;
using DarkUI.Forms;

namespace Particles
{
    public partial class Editor : DarkForm
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            prgProperties.SelectedObject = Program.Particles;
        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Working = false;
        }
    }
}