using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansMate
{
    public partial class FrmKayıt: Form
    {
        public FrmKayıt()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAd.Text) || string.IsNullOrWhiteSpace(TxtSoyad.Text) ||
            string.IsNullOrWhiteSpace(TxtSifre.Text) || string.IsNullOrWhiteSpace(TxtGelir.Text) ||
            string.IsNullOrWhiteSpace(TxtMaasGunu.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maasGunu;
            if (!int.TryParse(TxtMaasGunu.Text, out maasGunu) || maasGunu < 1 || maasGunu > 31)
            {
                MessageBox.Show("Maaş günü 1 ile 31 arasında olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TxtSifre.Text.Length != 8)
            {
                MessageBox.Show("Şifre 8 haneli olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal gelir, bakiye;
            if (!decimal.TryParse(TxtGelir.Text, out gelir) || !decimal.TryParse(TxtGelir.Text, out bakiye))
            {
                MessageBox.Show("Gelir ve bakiye geçerli bir sayı olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (int.Parse(TxtGelir.Text)<= 3000)
            {
                MessageBox.Show("Gelir 0 ile 3000 arasında olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                LogicKullanıcıIslem logic = new LogicKullanıcıIslem();
                Kullanici ent = new Kullanici();
                ent.KullaniciAd = TxtAd.Text;
                ent.KullaniciSoyad = TxtSoyad.Text;
                ent.KullaniciSifre = TxtSifre.Text;
                ent.KullaniciGelir = decimal.Parse(TxtGelir.Text);
                ent.KullaniciBakiye = decimal.Parse(TxtGelir.Text);
                ent.MaasGunu = int.Parse(TxtMaasGunu.Text);

                MessageBox.Show("Kullanıcı Başarıyla Eklendi\nLütfen ID'nizi not edin! Giriş için gerekli.\nKullanıcı ID:" + logic.LogicKullanicekle(ent), "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmKayıt_Load(object sender, EventArgs e)
        {

        }
    }
}
