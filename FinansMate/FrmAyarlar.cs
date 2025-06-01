using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;
using EntityLayer;

namespace FinansMate
{
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        public static int ID;
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ekonomikultur.com/kisisel-finans-ve-para-yonetiminde-basarili-olmak-icin-14-kitap-onerisi/");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAd.Text) || string.IsNullOrWhiteSpace(TxtSoyad.Text))
            {
                MessageBox.Show("⚠️Kullanıcı adı ve soyadı boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (TxtAd.Text.Any(char.IsDigit) || TxtSoyad.Text.Any(char.IsDigit))
            {
                MessageBox.Show("⚠️Kullanıcı adı ve soyadı sayısal karakterler içeremez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Kullanici ent = new Kullanici();
                LogicKullanıcıIslem islem = new LogicKullanıcıIslem();
                ent.KullaniciAd = TxtAd.Text;
                ent.KullaniciSoyad = TxtSoyad.Text;
                ent.KullaniciID = ID;
                islem.LogicProfilGüncelle(ent);
                MessageBox.Show("Kullanıcı Bilgileri Başarıyla Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAd.Text = string.Empty;
                TxtSoyad.Text = string.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
        }

        private void BtnSifreGüncelle_Click(object sender, EventArgs e)
        {
            Kullanici ent = new Kullanici();
            LogicKullanıcıIslem islem = new LogicKullanıcıIslem();
            ent.KullaniciSifre = TxtMevcutSifre.Text;
            ent.KullaniciID = ID;
            if (string.IsNullOrWhiteSpace(TxtMevcutSifre.Text) || string.IsNullOrWhiteSpace(TxtYeniSifre.Text) || string.IsNullOrWhiteSpace(TxtYeniSifre1.Text))
            {
                MessageBox.Show("⚠️Tüm şifre alanlarını doldurduğunuzdan emin olun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!islem.LogicKullaniciGiris(ent)) // Bu metodu LogicKullanıcıIslem içinde yazmanız gerekebilir
            {
                MessageBox.Show("⚠️Mevcut şifreniz yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TxtYeniSifre.Text != TxtYeniSifre1.Text)
            {
                MessageBox.Show("⚠️Yeni şifreler eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TxtYeniSifre.Text.Length != 8)
            {
                MessageBox.Show("⚠️Şifre 8 haneli olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Kullanici ent1 = new Kullanici();
                LogicKullanıcıIslem islem1 = new LogicKullanıcıIslem();
                ent.KullaniciSifre = TxtYeniSifre.Text;
                ent.KullaniciID = ID;
                islem1.LogicSifreGüncelle(ent1);
                MessageBox.Show("Kullanıcı Bilgileri Başarıyla Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtMevcutSifre.Text = string.Empty;
                TxtYeniSifre.Text = string.Empty;
                TxtYeniSifre1.Text = string.Empty;
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanici ent = new Kullanici();
            LogicKullanıcıIslem logicKullanıcıIslem = new LogicKullanıcıIslem();
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("⚠️Maas günü boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(textBox1.Text, out int maasGunu))
            {
                MessageBox.Show("⚠️Lütfen geçerli bir sayı girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (maasGunu < 1 || maasGunu > 31)
            {
                MessageBox.Show("⚠️Maaş günü 1 ile 31 arasında olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                ent.MaasGunu = int.Parse(textBox1.Text);
                ent.KullaniciID = ID;
                logicKullanıcıIslem.MaasGunuGuncel(ent);
                MessageBox.Show("Kullanıcı Bilgileri Başarıyla Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {

        }
    }
}
