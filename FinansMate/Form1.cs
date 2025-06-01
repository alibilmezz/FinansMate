using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LogicLayer;
using EntityLayer;


namespace FinansMate
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll",EntryPoint ="CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,int nTopRect,int nRightRect,int nBottomRect,int nWidthEllipse,int nHeigtEllipse);
        public static int KullaniciID;




        public Form1()
        {
            InitializeComponent();
          
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            FrmİlkSayfa.ID = KullaniciID;
            FrmGelirgider.ID = KullaniciID;
            FrmAnasayfa.ID = KullaniciID;
            FrmAyarlar.ID = KullaniciID;
            FrmButceplan.ID = KullaniciID;
            FrmIstatistik.ID = KullaniciID;
            LblKullaniciID.Text = KullaniciID.ToString();
            
            //Kullanıcı adı çektik
            Kullanici ent = new Kullanici();
            ent.KullaniciID = int.Parse(LblKullaniciID.Text);
            LogicKullanıcıIslem islem = new LogicKullanıcıIslem();
            LblKullaniciAd.Text= islem.LogicKullaniciAd(ent);

            timer1.Interval = 1000; // 1 saniyede bir çalışacak
            timer1.Tick += timer1_Tick;
            timer1.Start();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            pnlNav.Height = BtnAnasayfa.Height;
            pnlNav.Top = BtnAnasayfa.Top;
            pnlNav.Left = BtnAnasayfa.Left;

            LblTitle.Text = "Hoşgeldiniz..";
            this.PnlFormyukleyici.Controls.Clear();
            FrmİlkSayfa frmAnasayfa = new FrmİlkSayfa() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmAnasayfa.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormyukleyici.Controls.Add(frmAnasayfa);
            frmAnasayfa.Show();
        }

        private void BtnAnasayfa_Click(object sender, EventArgs e)
        {
            pnlNav.Height=BtnAnasayfa.Height;   
            pnlNav.Top=BtnAnasayfa.Top;
            pnlNav.Left=BtnAnasayfa.Left;
            
            LblTitle.Text = "Ana Sayfa";
            this.PnlFormyukleyici.Controls.Clear();
            FrmAnasayfa frmAnasayfa = new FrmAnasayfa() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmAnasayfa.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormyukleyici.Controls.Add(frmAnasayfa);
            frmAnasayfa.Show();

        }

        private void BtnGider_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnGider.Height;
            pnlNav.Top = BtnGider.Top;           
           
            LblTitle.Text = "Gelir Ve Harcamalar";
            this.PnlFormyukleyici.Controls.Clear();
            FrmAnasayfa fr1 = new FrmAnasayfa();
            FrmGelirgider frmgelir = new FrmGelirgider(fr1) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmgelir.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormyukleyici.Controls.Add(frmgelir);
            frmgelir.Show();
        }

        private void Btnİstatistikler_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnIstatistik.Height;
            pnlNav.Top = BtnIstatistik.Top;
            
            LblTitle.Text = "İstatistikler";
            this.PnlFormyukleyici.Controls.Clear();
            FrmIstatistik frmist = new FrmIstatistik() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmist.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormyukleyici.Controls.Add(frmist);
            frmist.Show();
        }

        private void BtnBütçe_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnButce.Height;
            pnlNav.Top = BtnButce.Top;
            
            LblTitle.Text = "Bütçe Planlama";
            this.PnlFormyukleyici.Controls.Clear();
            FrmButceplan frmplan = new FrmButceplan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmplan.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormyukleyici.Controls.Add(frmplan);
            frmplan.Show();


        }

        private void BtnAyarlar_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnAyarlar.Height;
            pnlNav.Top = BtnAyarlar.Top;
            
            LblTitle.Text = "Ayarlar";
            this.PnlFormyukleyici.Controls.Clear();
            FrmAyarlar frmayar = new FrmAyarlar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmayar.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormyukleyici.Controls.Add(frmayar);
            frmayar.Show();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            LblTarih.Text = DateTime.Now.ToString("dd MMMM yyyy, dddd HH:mm:ss");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
