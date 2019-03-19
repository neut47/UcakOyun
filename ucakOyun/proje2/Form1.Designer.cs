namespace proje2
{
    partial class UcakOyun
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcakOyun));
            this.ucak = new System.Windows.Forms.PictureBox();
            this.mHarZmn = new System.Windows.Forms.Timer(this.components);
            this.dHarZmn = new System.Windows.Forms.Timer(this.components);
            this.dOlZmn = new System.Windows.Forms.Timer(this.components);
            this.yokEtZmn = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ucak)).BeginInit();
            this.SuspendLayout();
            // 
            // ucak
            // 
            this.ucak.Image = ((System.Drawing.Image)(resources.GetObject("ucak.Image")));
            this.ucak.Location = new System.Drawing.Point(0, 421);
            this.ucak.Name = "ucak";
            this.ucak.Size = new System.Drawing.Size(40, 41);
            this.ucak.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ucak.TabIndex = 0;
            this.ucak.TabStop = false;
            this.ucak.Click += new System.EventHandler(this.ucak_Click);
            // 
            // mHarZmn
            // 
            this.mHarZmn.Interval = 10;
            this.mHarZmn.Tick += new System.EventHandler(this.mHarZmn_Tick);
            // 
            // dHarZmn
            // 
            this.dHarZmn.Interval = 50;
            this.dHarZmn.Tick += new System.EventHandler(this.dHarZmn_Tick);
            // 
            // dOlZmn
            // 
            this.dOlZmn.Interval = 1000;
            this.dOlZmn.Tick += new System.EventHandler(this.dOlZmn_Tick);
            // 
            // yokEtZmn
            // 
            this.yokEtZmn.Interval = 10;
            this.yokEtZmn.Tick += new System.EventHandler(this.yokEtZmn_Tick);
            // 
            // UcakOyun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(322, 461);
            this.Controls.Add(this.ucak);
            this.MaximizeBox = false;
            this.Name = "UcakOyun";
            this.Text = "UcakOyun";
            this.Load += new System.EventHandler(this.UcakOyun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ucak)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ucak;
        private System.Windows.Forms.Timer mHarZmn;
        private System.Windows.Forms.Timer dHarZmn;
        private System.Windows.Forms.Timer dOlZmn;
        private System.Windows.Forms.Timer yokEtZmn;
    }
}

