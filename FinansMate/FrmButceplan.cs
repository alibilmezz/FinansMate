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
using DAL;

namespace FinansMate
{
    public partial class FrmButceplan : Form
    {
        public static int ID;
        public FrmButceplan()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.encazip.com/bilgi/finans/kisisel-butce-planlamasi-nasil-yapilir");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dPk6_dEbYxk");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ekonomikultur.com/kisisel-finans-ve-para-yonetiminde-basarili-olmak-icin-14-kitap-onerisi/");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmButceplan_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            string url = "https://hasanadiguzel.com.tr/api/kurgetir";
            //Döviz apisi ile güncel kurlar alınıp listelendi
 using (HttpClient client = new HttpClient())
 {
     try
     {
         string json = await client.GetStringAsync(url);
         JObject data = JObject.Parse(json);
         var usdToTry = data["TCMB_AnlikKurBilgileri"]
             .FirstOrDefault(c => c["CurrencyName"]?.ToString() == "US DOLLAR")?["ForexBuying"]?.ToString();
         LblDolar.Text = $"₺{usdToTry}";
         var eurToTry = data["TCMB_AnlikKurBilgileri"]
            .FirstOrDefault(c => c["CurrencyName"]?.ToString() == "EURO")?["ForexBuying"]?.ToString();
         LblEuro.Text = $"₺{eurToTry}";
         var strToTry = data["TCMB_AnlikKurBilgileri"]
           .FirstOrDefault(c => c["CurrencyName"]?.ToString() == "POUND STERLING")?["ForexBuying"]?.ToString();
         LblGramAltın.Text = $"₺{strToTry}";

     }
     catch (Exception ex)
     {
         MessageBox.Show("Veri çekme hatası: " + ex.Message);
     }
 }
            

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnHedefEkle_Click(object sender, EventArgs e)
        {
            Hedef hedef = new Hedef();
            hedef.KullaniciID = ID;
            LogicHedefIslem logicHedefIslem = new LogicHedefIslem();
            var sonuc = logicHedefIslem.LogicHedefMiktar(hedef);

            if (string.IsNullOrWhiteSpace(TxtHedefad.Text)||
                string.IsNullOrWhiteSpace(TxtHedeftutar.Text))
            {
                MessageBox.Show("Hedef adı ve miktarı boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(sonuc.Item3==true)
            {
                MessageBox.Show("Şuanda geçerli bir hedefiniz var!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            if (!int.TryParse(TxtHedeftutar.Text, out int hedefMiktar) || hedefMiktar <= 0)
            {
                MessageBox.Show("Hedef miktarı geçerli bir sayısal değer olmalı ve 0'dan büyük olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            if (dateTimePicker1.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Hedef tarihi geçmiş bir tarih olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Hedef ent = new Hedef();
                ent.KullaniciID = ID;
                ent.HedefAd = TxtHedefad.Text;
                ent.HedefMiktar = int.Parse(TxtHedeftutar.Text);
                ent.HedefTarih = dateTimePicker1.Value;
                ent.HedefDurum = true;
                LogicHedefIslem islem = new LogicHedefIslem();
                islem.LogicHedefEkle(ent);
                MessageBox.Show("Hedef Başarıyla Eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtHedefad.Text=string.Empty;
                TxtHedeftutar.Text=string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void BtnFaturekle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtFaturaad.Text)||
                string.IsNullOrWhiteSpace(TxtFaturatutar.Text))
            {
                MessageBox.Show("Fatura adı boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            if (!decimal.TryParse(TxtFaturatutar.Text, out decimal faturaMiktar) || faturaMiktar <= 0)
            {
                MessageBox.Show("Fatura miktarı geçerli bir sayısal değer olmalı ve 0'dan büyük olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (dateTimePicker2.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Fatura tarihi geçmiş bir tarih olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Fatura fat = new Fatura();
                fat.FaturaAd = TxtFaturaad.Text;
                fat.FaturaMiktar = decimal.Parse(TxtFaturatutar.Text);
                fat.FaturaTarih = dateTimePicker2.Value;
                fat.FaturaDurum = true;
                fat.KullaniciID = ID;
                LogicFaturaIslem logicFaturaIslem = new LogicFaturaIslem();
                logicFaturaIslem.LogicFaturaEkle(fat);
                MessageBox.Show("Fatura Başarıyla Eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFaturaad.Text=string.Empty;
                TxtFaturatutar.Text=string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
