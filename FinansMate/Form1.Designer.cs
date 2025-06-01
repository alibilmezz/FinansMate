namespace FinansMate
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.BtnAyarlar = new System.Windows.Forms.Button();
            this.BtnButce = new System.Windows.Forms.Button();
            this.BtnIstatistik = new System.Windows.Forms.Button();
            this.BtnGider = new System.Windows.Forms.Button();
            this.BtnAnasayfa = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LblKullaniciID = new System.Windows.Forms.Label();
            this.LblKullaniciAd = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblTitle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PnlFormyukleyici = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LblTarih = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.BtnAyarlar);
            this.panel1.Controls.Add(this.BtnButce);
            this.panel1.Controls.Add(this.BtnIstatistik);
            this.panel1.Controls.Add(this.BtnGider);
            this.panel1.Controls.Add(this.BtnAnasayfa);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 577);
            this.panel1.TabIndex = 0;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 193);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(4, 100);
            this.pnlNav.TabIndex = 3;
            // 
            // BtnAyarlar
            // 
            this.BtnAyarlar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAyarlar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnAyarlar.FlatAppearance.BorderSize = 0;
            this.BtnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAyarlar.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAyarlar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnAyarlar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAyarlar.Image")));
            this.BtnAyarlar.Location = new System.Drawing.Point(0, 535);
            this.BtnAyarlar.Name = "BtnAyarlar";
            this.BtnAyarlar.Size = new System.Drawing.Size(186, 42);
            this.BtnAyarlar.TabIndex = 5;
            this.BtnAyarlar.Text = "Ayarlar";
            this.BtnAyarlar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnAyarlar.UseVisualStyleBackColor = true;
            this.BtnAyarlar.Click += new System.EventHandler(this.BtnAyarlar_Click);
            // 
            // BtnButce
            // 
            this.BtnButce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnButce.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnButce.FlatAppearance.BorderSize = 0;
            this.BtnButce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnButce.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnButce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnButce.Image = ((System.Drawing.Image)(resources.GetObject("BtnButce.Image")));
            this.BtnButce.Location = new System.Drawing.Point(0, 277);
            this.BtnButce.Name = "BtnButce";
            this.BtnButce.Size = new System.Drawing.Size(186, 42);
            this.BtnButce.TabIndex = 4;
            this.BtnButce.Text = "Planlama";
            this.BtnButce.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnButce.UseVisualStyleBackColor = true;
            this.BtnButce.Click += new System.EventHandler(this.BtnBütçe_Click);
            // 
            // BtnIstatistik
            // 
            this.BtnIstatistik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIstatistik.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnIstatistik.FlatAppearance.BorderSize = 0;
            this.BtnIstatistik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIstatistik.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIstatistik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnIstatistik.Image = ((System.Drawing.Image)(resources.GetObject("BtnIstatistik.Image")));
            this.BtnIstatistik.Location = new System.Drawing.Point(0, 235);
            this.BtnIstatistik.Name = "BtnIstatistik";
            this.BtnIstatistik.Size = new System.Drawing.Size(186, 42);
            this.BtnIstatistik.TabIndex = 3;
            this.BtnIstatistik.Text = "İstatistik";
            this.BtnIstatistik.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnIstatistik.UseVisualStyleBackColor = true;
            this.BtnIstatistik.Click += new System.EventHandler(this.Btnİstatistikler_Click);
            // 
            // BtnGider
            // 
            this.BtnGider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGider.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnGider.FlatAppearance.BorderSize = 0;
            this.BtnGider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGider.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnGider.Image = ((System.Drawing.Image)(resources.GetObject("BtnGider.Image")));
            this.BtnGider.Location = new System.Drawing.Point(0, 193);
            this.BtnGider.Name = "BtnGider";
            this.BtnGider.Size = new System.Drawing.Size(186, 42);
            this.BtnGider.TabIndex = 2;
            this.BtnGider.Text = "Gelir Gider";
            this.BtnGider.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnGider.UseVisualStyleBackColor = true;
            this.BtnGider.Click += new System.EventHandler(this.BtnGider_Click);
            // 
            // BtnAnasayfa
            // 
            this.BtnAnasayfa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAnasayfa.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAnasayfa.FlatAppearance.BorderSize = 0;
            this.BtnAnasayfa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAnasayfa.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAnasayfa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnAnasayfa.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnasayfa.Image")));
            this.BtnAnasayfa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAnasayfa.Location = new System.Drawing.Point(0, 151);
            this.BtnAnasayfa.Name = "BtnAnasayfa";
            this.BtnAnasayfa.Size = new System.Drawing.Size(186, 42);
            this.BtnAnasayfa.TabIndex = 1;
            this.BtnAnasayfa.Text = "Ana Sayfa";
            this.BtnAnasayfa.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnAnasayfa.UseVisualStyleBackColor = true;
            this.BtnAnasayfa.Click += new System.EventHandler(this.BtnAnasayfa_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.LblKullaniciID);
            this.panel2.Controls.Add(this.LblKullaniciAd);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 151);
            this.panel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(161)))), ((int)(((byte)(178)))));
            this.label3.Location = new System.Drawing.Point(51, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kullanıcı ID:";
            // 
            // LblKullaniciID
            // 
            this.LblKullaniciID.AutoSize = true;
            this.LblKullaniciID.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblKullaniciID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(161)))), ((int)(((byte)(178)))));
            this.LblKullaniciID.Location = new System.Drawing.Point(116, 126);
            this.LblKullaniciID.Name = "LblKullaniciID";
            this.LblKullaniciID.Size = new System.Drawing.Size(11, 12);
            this.LblKullaniciID.TabIndex = 2;
            this.LblKullaniciID.Text = "0";
            // 
            // LblKullaniciAd
            // 
            this.LblKullaniciAd.AutoSize = true;
            this.LblKullaniciAd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.LblKullaniciAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblKullaniciAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.LblKullaniciAd.Location = new System.Drawing.Point(54, 98);
            this.LblKullaniciAd.Name = "LblKullaniciAd";
            this.LblKullaniciAd.Size = new System.Drawing.Size(31, 18);
            this.LblKullaniciAd.TabIndex = 1;
            this.LblKullaniciAd.Text = "Adı";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(37, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.LblTitle.Location = new System.Drawing.Point(209, 28);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(157, 33);
            this.LblTitle.TabIndex = 1;
            this.LblTitle.Text = "Ana Sayfa";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Uighur", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.textBox1.Location = new System.Drawing.Point(601, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "   Search for something...";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(925, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PnlFormyukleyici
            // 
            this.PnlFormyukleyici.Location = new System.Drawing.Point(202, 98);
            this.PnlFormyukleyici.Name = "PnlFormyukleyici";
            this.PnlFormyukleyici.Size = new System.Drawing.Size(748, 471);
            this.PnlFormyukleyici.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LblTarih
            // 
            this.LblTarih.AutoSize = true;
            this.LblTarih.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTarih.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(151)))), ((int)(((byte)(176)))));
            this.LblTarih.Location = new System.Drawing.Point(212, 61);
            this.LblTarih.Name = "LblTarih";
            this.LblTarih.Size = new System.Drawing.Size(11, 17);
            this.LblTarih.TabIndex = 7;
            this.LblTarih.Text = ".";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(899, -3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 25);
            this.button3.TabIndex = 41;
            this.button3.Text = "_";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.LblTarih);
            this.Controls.Add(this.PnlFormyukleyici);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblKullaniciAd;
        private System.Windows.Forms.Button BtnAnasayfa;
        private System.Windows.Forms.Label LblKullaniciID;
        private System.Windows.Forms.Button BtnAyarlar;
        private System.Windows.Forms.Button BtnButce;
        private System.Windows.Forms.Button BtnIstatistik;
        private System.Windows.Forms.Button BtnGider;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel PnlFormyukleyici;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LblTarih;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
    }
}

