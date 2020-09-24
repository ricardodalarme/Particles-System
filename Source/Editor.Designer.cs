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
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.picParticle = new System.Windows.Forms.PictureBox();
            this.butReset = new DarkUI.Controls.DarkButton();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.numLifeTime = new DarkUI.Controls.DarkNumericUpDown();
            this.numCount = new DarkUI.Controls.DarkNumericUpDown();
            this.numSpeed = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picParticle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLifeTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(9, 10);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(71, 13);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Life time (ms):";
            // 
            // picParticle
            // 
            this.picParticle.Location = new System.Drawing.Point(215, 10);
            this.picParticle.Name = "picParticle";
            this.picParticle.Size = new System.Drawing.Size(400, 400);
            this.picParticle.TabIndex = 2;
            this.picParticle.TabStop = false;
            // 
            // butReset
            // 
            this.butReset.Location = new System.Drawing.Point(12, 384);
            this.butReset.Name = "butReset";
            this.butReset.Padding = new System.Windows.Forms.Padding(5);
            this.butReset.Size = new System.Drawing.Size(193, 23);
            this.butReset.TabIndex = 3;
            this.butReset.Text = "Reset";
            this.butReset.Click += new System.EventHandler(this.butReset_Click);
            // 
            // darkLabel2
            // 
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(9, 53);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(60, 13);
            this.darkLabel2.TabIndex = 4;
            this.darkLabel2.Text = "Count:";
            // 
            // numLifeTime
            // 
            this.numLifeTime.Location = new System.Drawing.Point(12, 26);
            this.numLifeTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLifeTime.Name = "numLifeTime";
            this.numLifeTime.Size = new System.Drawing.Size(193, 20);
            this.numLifeTime.TabIndex = 5;
            this.numLifeTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numCount
            // 
            this.numCount.Location = new System.Drawing.Point(12, 69);
            this.numCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(193, 20);
            this.numCount.TabIndex = 6;
            this.numCount.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // numSpeed
            // 
            this.numSpeed.Location = new System.Drawing.Point(12, 111);
            this.numSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(193, 20);
            this.numSpeed.TabIndex = 8;
            this.numSpeed.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // darkLabel3
            // 
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(9, 95);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(60, 13);
            this.darkLabel3.TabIndex = 7;
            this.darkLabel3.Text = "Speed:";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 419);
            this.Controls.Add(this.numSpeed);
            this.Controls.Add(this.darkLabel3);
            this.Controls.Add(this.numCount);
            this.Controls.Add(this.numLifeTime);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.butReset);
            this.Controls.Add(this.picParticle);
            this.Controls.Add(this.darkLabel1);
            this.MaximizeBox = false;
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Particles Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Editor_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picParticle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLifeTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel darkLabel1;
        public System.Windows.Forms.PictureBox picParticle;
        private DarkUI.Controls.DarkButton butReset;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkLabel darkLabel3;
        public DarkUI.Controls.DarkNumericUpDown numLifeTime;
        public DarkUI.Controls.DarkNumericUpDown numCount;
        public DarkUI.Controls.DarkNumericUpDown numSpeed;
    }
}

