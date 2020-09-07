namespace Particles
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picParticle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picParticle)).BeginInit();
            this.SuspendLayout();
            // 
            // picParticle
            // 
            this.picParticle.Location = new System.Drawing.Point(381, 12);
            this.picParticle.Name = "picParticle";
            this.picParticle.Size = new System.Drawing.Size(352, 374);
            this.picParticle.TabIndex = 0;
            this.picParticle.TabStop = false;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picParticle);
            this.Name = "Editor";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picParticle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picParticle;
    }
}

