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
            this.prgProperties = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.picParticle)).BeginInit();
            this.SuspendLayout();
            // 
            // picParticle
            // 
            this.picParticle.Location = new System.Drawing.Point(215, 10);
            this.picParticle.Name = "picParticle";
            this.picParticle.Size = new System.Drawing.Size(400, 400);
            this.picParticle.TabIndex = 2;
            this.picParticle.TabStop = false;
            // 
            // prgProperties
            // 
            this.prgProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prgProperties.CategoryForeColor = System.Drawing.Color.Gainsboro;
            this.prgProperties.CategorySplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.prgProperties.CommandsBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.prgProperties.CommandsForeColor = System.Drawing.Color.Gainsboro;
            this.prgProperties.CommandsVisibleIfAvailable = false;
            this.prgProperties.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.prgProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prgProperties.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.prgProperties.HelpBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.prgProperties.HelpForeColor = System.Drawing.Color.Gainsboro;
            this.prgProperties.HelpVisible = false;
            this.prgProperties.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.prgProperties.Location = new System.Drawing.Point(12, 10);
            this.prgProperties.Name = "prgProperties";
            this.prgProperties.Size = new System.Drawing.Size(193, 400);
            this.prgProperties.TabIndex = 115;
            this.prgProperties.ToolbarVisible = false;
            this.prgProperties.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.prgProperties.ViewBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.prgProperties.ViewForeColor = System.Drawing.Color.Gainsboro;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 419);
            this.Controls.Add(this.prgProperties);
            this.Controls.Add(this.picParticle);
            this.MaximizeBox = false;
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Particles Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Editor_FormClosed);
            this.Load += new System.EventHandler(this.Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picParticle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox picParticle;
        private System.Windows.Forms.PropertyGrid prgProperties;
    }
}

