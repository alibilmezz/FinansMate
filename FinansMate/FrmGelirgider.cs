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
    public partial class FrmGelirgider : Form
    {
        private FrmAnasayfa fr;
        public FrmGelirgider(FrmAnasayfa fr1)
        {
            InitializeComponent();
            fr = fr1;
        }
        public static int ID;
       
        public void Güncelle()
        {
            LogicKullanıcıIslem islem = new LogicKullanıcıIslem();


            Kullanici x = new Kullanici();
            x.KullaniciID = ID;// Static değişkenden al
            var sonuc = islem.LogicKullaniciGelir(x);
            LblGelir.Text = sonuc.Item1.ToString();
            LblBakiye.Text = sonuc.Item2.ToString();
            //kategorileri comboboxa çektik
            
        }
       

        private void FrmGelirgider_Load(object sender, EventArgs e)
        {
            Güncelle();
            CmbKategori.DataSource = LogicKategori.LogicKategoriIslem();
            CmbKategori.DisplayMember = "KategoriAd";
            CmbKategori.ValueMember = "KategoriID";
            LogicHedefIslem islem1 = new LogicHedefIslem();
            Hedef hedef = new Hedef();
            hedef.KullaniciID = ID;
            var sonuc = islem1.LogicHedefMiktar(hedef);
            birikim = sonuc.Item2;
            //faturaları diğer comboboxa çektik
            Fatura fatura = new Fatura();
            fatura.KullaniciID = ID;
            CmbFatura.DataSource = LogicFaturaIslem.LogicFaturaGetir(fatura);
            CmbFatura.DisplayMember = "FaturaAd";
            CmbFatura.ValueMember = "FaturaID";
            //burada bakiyeyi maaş gününde güncelledik
                 
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtGelir.Text))
               
            {
                MessageBox.Show("Gelir Tutarı Boş Olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(TxtGelir.Text, out int GelirMiktar) || GelirMiktar <= 3000)
            {
                MessageBox.Show("Hedef miktarı geçerli bir sayısal değer olmalı ve 0'dan büyük olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                Kullanici ent = new Kullanici();
                LogicKullanıcıIslem islem = new LogicKullanıcıIslem();
                ent.KullaniciGelir = decimal.Parse(TxtGelir.Text);
                ent.KullaniciID = ID;
                islem.LogicGelirGüncelle(ent);
                MessageBox.Show("Gelir başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtGelir.Text =string.Empty;
                Güncelle();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtGidertutar.Text)||
                string.IsNullOrWhiteSpace(CmbKategori.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(TxtGidertutar.Text, out decimal giderMiktar) || giderMiktar <= 0)
            {
                MessageBox.Show("Geçerli bir gider tutarı girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CmbKategori.SelectedValue == null || !int.TryParse(CmbKategori.SelectedValue.ToString(), out int kategoriID) || kategoriID <= 0)
            {
                MessageBox.Show("Geçerli bir kategori seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                //Gider Kayıt Altına alındı
                Gider x = new Gider();
                Kullanici k = new Kullanici();
                x.GiderMiktar = decimal.Parse(TxtGidertutar.Text);
                x.KullaniciID = ID;
                x.KategoriID = int.Parse(CmbKategori.SelectedValue.ToString());
                x.GiderTarih = DateTime.Now;
                LogicGiderIslem islem = new LogicGiderIslem();
                islem.LogicGiderEkle(x);
                //Aşşağıda bakiye güncellendi
                k.KullaniciID = ID;
                k.KullaniciBakiye = (decimal.Parse(LblBakiye.Text)) - (decimal.Parse(TxtGidertutar.Text));
                islem.LogicBakiyeGuncelle(k);
                MessageBox.Show("Gider Başarıyla Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Güncelle();
                TxtGidertutar.Text=string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        int birikim = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtBirikim.Text))
            {
                MessageBox.Show("Lütfen birikim için değer girin!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(TxtBirikim.Text, out decimal Birikim) || Birikim <= 0)
            {
                MessageBox.Show("Geçerli bir tutar girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                birikim += Convert.ToInt32(TxtBirikim.Text);
                LogicHedefIslem islem1 = new LogicHedefIslem();
                Hedef ent = new Hedef();
                ent.KullaniciID = ID;
                ent.HedefBirikim = birikim;

                islem1.LogicBirikimGuncelle(ent);
                MessageBox.Show("Birikiminiz Kumbaraya Başarıyla Eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtBirikim.Text=string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kullanici kullanici = new Kullanici();
            Fatura fatura = new Fatura();
            LogicFaturaIslem logicFaturaIslem = new LogicFaturaIslem();
            LogicGiderIslem log = new LogicGiderIslem();
            fatura.FaturaID = int.Parse(CmbFatura.SelectedValue.ToString());
           
            

            if (CmbFatura.SelectedValue == null || !int.TryParse(CmbFatura.SelectedValue.ToString(), out int faturaID) || faturaID <= 0)
            {
                MessageBox.Show("⚠️Geçerli bir fatura seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(LblBakiye.Text, out decimal bakiye) || bakiye <= 0)
            {
                MessageBox.Show("⚠️Bakiye geçersiz veya yetersiz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal faturaMiktar = logicFaturaIslem.LogicFaturaMiktar(fatura);

            // Yeterli bakiye olup olmadığını kontrol et
            if (bakiye < faturaMiktar)
            {
                MessageBox.Show("⚠️Bakiye yetersiz, fatura ödemesi yapılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                kullanici.KullaniciID = ID;
                kullanici.KullaniciBakiye = (decimal.Parse(LblBakiye.Text)) - (logicFaturaIslem.LogicFaturaMiktar(fatura));
                log.LogicBakiyeGuncelle(kullanici);
                logicFaturaIslem.LogicFaturaSil(fatura);
                MessageBox.Show("Fatura Ödemeniz Başarıyla Gerçekleşti.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Güncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
