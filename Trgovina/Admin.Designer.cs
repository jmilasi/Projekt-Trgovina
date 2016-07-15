namespace Trgovina
{
    partial class Admin
    {  /// <summary>
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.skladišteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nađiArtiklToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stanjeNaSkladištuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upozorenjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaposleniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaSvihZaposlenikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pronađiZaposlenikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promijenaKorisnickiPodatakaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.početnaStranicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.završiSRadomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.spremi = new System.Windows.Forms.Button();
            this.napomena = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skladišteToolStripMenuItem,
            this.zaposleniciToolStripMenuItem,
            this.postavkeToolStripMenuItem,
            this.završiSRadomToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // skladišteToolStripMenuItem
            // 
            this.skladišteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nađiArtiklToolStripMenuItem,
            this.stanjeNaSkladištuToolStripMenuItem,
            this.popustToolStripMenuItem,
            this.upozorenjaToolStripMenuItem});
            this.skladišteToolStripMenuItem.Name = "skladišteToolStripMenuItem";
            this.skladišteToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.skladišteToolStripMenuItem.Text = "Skladište";
            // 
            // nađiArtiklToolStripMenuItem
            // 
            this.nađiArtiklToolStripMenuItem.Name = "nađiArtiklToolStripMenuItem";
            this.nađiArtiklToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.nađiArtiklToolStripMenuItem.Text = "Nađi artikl";
            this.nađiArtiklToolStripMenuItem.Click += new System.EventHandler(this.nađiArtiklToolStripMenuItem_Click);
            // 
            // stanjeNaSkladištuToolStripMenuItem
            // 
            this.stanjeNaSkladištuToolStripMenuItem.Name = "stanjeNaSkladištuToolStripMenuItem";
            this.stanjeNaSkladištuToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.stanjeNaSkladištuToolStripMenuItem.Text = "Stanje na skladištu";
            this.stanjeNaSkladištuToolStripMenuItem.Click += new System.EventHandler(this.stanjeNaSkladištuToolStripMenuItem_Click);
            // 
            // popustToolStripMenuItem
            // 
            this.popustToolStripMenuItem.Name = "popustToolStripMenuItem";
            this.popustToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.popustToolStripMenuItem.Text = "Artikli s popustom";
            this.popustToolStripMenuItem.Click += new System.EventHandler(this.popustToolStripMenuItem_Click);
            // 
            // upozorenjaToolStripMenuItem
            // 
            this.upozorenjaToolStripMenuItem.Name = "upozorenjaToolStripMenuItem";
            this.upozorenjaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.upozorenjaToolStripMenuItem.Text = "Upozorenja";
            this.upozorenjaToolStripMenuItem.Click += new System.EventHandler(this.upozorenjaToolStripMenuItem_Click);
            // 
            // zaposleniciToolStripMenuItem
            // 
            this.zaposleniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaSvihZaposlenikaToolStripMenuItem,
            this.pronađiZaposlenikaToolStripMenuItem});
            this.zaposleniciToolStripMenuItem.Name = "zaposleniciToolStripMenuItem";
            this.zaposleniciToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.zaposleniciToolStripMenuItem.Text = "Zaposlenici";
            // 
            // listaSvihZaposlenikaToolStripMenuItem
            // 
            this.listaSvihZaposlenikaToolStripMenuItem.Name = "listaSvihZaposlenikaToolStripMenuItem";
            this.listaSvihZaposlenikaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.listaSvihZaposlenikaToolStripMenuItem.Text = "Lista zaposlenika";
            this.listaSvihZaposlenikaToolStripMenuItem.Click += new System.EventHandler(this.listaSvihZaposlenikaToolStripMenuItem_Click);
            // 
            // pronađiZaposlenikaToolStripMenuItem
            // 
            this.pronađiZaposlenikaToolStripMenuItem.Name = "pronađiZaposlenikaToolStripMenuItem";
            this.pronađiZaposlenikaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.pronađiZaposlenikaToolStripMenuItem.Text = "Pronađi zaposlenika";
            this.pronađiZaposlenikaToolStripMenuItem.Click += new System.EventHandler(this.pronađiZaposlenikaToolStripMenuItem_Click);
            // 
            // postavkeToolStripMenuItem
            // 
            this.postavkeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.promijenaKorisnickiPodatakaToolStripMenuItem,
            this.početnaStranicaToolStripMenuItem});
            this.postavkeToolStripMenuItem.Name = "postavkeToolStripMenuItem";
            this.postavkeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.postavkeToolStripMenuItem.Text = "Postavke";
            // 
            // promijenaKorisnickiPodatakaToolStripMenuItem
            // 
            this.promijenaKorisnickiPodatakaToolStripMenuItem.Name = "promijenaKorisnickiPodatakaToolStripMenuItem";
            this.promijenaKorisnickiPodatakaToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.promijenaKorisnickiPodatakaToolStripMenuItem.Text = "Izmjena administratorskih podataka";
            this.promijenaKorisnickiPodatakaToolStripMenuItem.Click += new System.EventHandler(this.promijenaKorisnickiPodatakaToolStripMenuItem_Click);
            // 
            // početnaStranicaToolStripMenuItem
            // 
            this.početnaStranicaToolStripMenuItem.Name = "početnaStranicaToolStripMenuItem";
            this.početnaStranicaToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.početnaStranicaToolStripMenuItem.Text = "Početna stranica";
            this.početnaStranicaToolStripMenuItem.Click += new System.EventHandler(this.početnaStranicaToolStripMenuItem_Click);
            // 
            // završiSRadomToolStripMenuItem
            // 
            this.završiSRadomToolStripMenuItem.Name = "završiSRadomToolStripMenuItem";
            this.završiSRadomToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.završiSRadomToolStripMenuItem.Text = "Završi s radom";
            this.završiSRadomToolStripMenuItem.Click += new System.EventHandler(this.zavrsiSRadomToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(9, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Dobro došli, ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(412, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "datum";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Trgovina d.o.o Šverc Komerc";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // spremi
            // 
            this.spremi.Location = new System.Drawing.Point(165, 219);
            this.spremi.Name = "spremi";
            this.spremi.Size = new System.Drawing.Size(75, 23);
            this.spremi.TabIndex = 4;
            this.spremi.Text = "Spremi";
            this.spremi.UseVisualStyleBackColor = true;
            this.spremi.Visible = false;
            this.spremi.Click += new System.EventHandler(this.spremiPromjene);
            // 
            // napomena
            // 
            this.napomena.AutoSize = true;
            this.napomena.Location = new System.Drawing.Point(20, 311);
            this.napomena.Name = "napomena";
            this.napomena.Size = new System.Drawing.Size(448, 13);
            this.napomena.TabIndex = 5;
            this.napomena.Text = "Napomena: Potrebno je kliknuti na neki drugi redak prije nego želimo spremiti pro" +
    "mjenu u bazi.";
            this.napomena.Visible = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.napomena);
            this.Controls.Add(this.spremi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "Admin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Admin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Admin_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem skladišteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaposleniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nađiArtiklToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stanjeNaSkladištuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upozorenjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaSvihZaposlenikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pronađiZaposlenikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem popustToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postavkeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promijenaKorisnickiPodatakaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem završiSRadomToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem početnaStranicaToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button spremi;
        private System.Windows.Forms.Label napomena;
    }
}