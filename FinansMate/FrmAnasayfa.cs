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
using CircularProgressBar;  


namespace FinansMate
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
            
        }
        public CircularProgressBar.CircularProgressBar CircularProgressBar => circularProgressBar1;
        public static int ID;
        public int Birikim1;
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            //tarihi yaklaşan faturaları çektik
            Fatura ent1 = new Fatura();
            ent1.KullaniciID = ID;

            List<Fatura> hatirlatmalar = LogicFaturaIslem.LogicFaturaHatirlatma(ent1);

            

            foreach (var fatura in hatirlatmalar)
            {
               richTextBox1.AppendText(fatura.FaturaAd+" faturasının son ödeme tarihi yaklaşıyor.."+Environment.NewLine);
            }
            //bakiye ve gelir bilgilerini çektik
            LogicKullanıcıIslem islem = new LogicKullanıcıIslem();
            Form1 fr = new Form1();
            Kullanici x = new Kullanici();
            x.KullaniciID = ID;// Static değişkenden al
            var sonuc = islem.LogicKullaniciGelir(x); 
            LblGelir.Text = sonuc.Item1.ToString();
            LblBakiye.Text = sonuc.Item2.ToString();
            //Hedef miktar getirme
            
            Hedef ent = new Hedef();
            LogicHedefIslem islem1 = new LogicHedefIslem();
            ent.KullaniciID = ID;
            var sonuc2 = islem1.LogicHedefMiktar(ent);
            
                if (sonuc2.Item2 <= sonuc2.Item1)
                {

                    circularProgressBar1.Maximum = sonuc2.Item1;
                    circularProgressBar1.Value = sonuc2.Item2;
                  if (sonuc2.Item1 > 0)
                  {
                    circularProgressBar1.Text = (sonuc2.Item2 * 100) / sonuc2.Item1 + "%";
                  }
                    

                }
                else if (sonuc2.Item1 <= sonuc2.Item2)
                {
                    MessageBox.Show("Tebrik ederiz! Belirlediğiniz hedefe ulaşarak büyük bir başarıya imza attınız. Azminiz, disiplininiz ve emeğiniz bu sonucun en büyük göstergesidir. Başarılarınızın devamını dileriz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    circularProgressBar1.Value = 1;
                    Hedef hedef = new Hedef();
                    hedef.KullaniciID = ID;
                    LogicHedefIslem islem4 = new LogicHedefIslem();
                    islem4.LogicHedefSil(hedef);
                }
            //hedef adı getirme 
            Hedef hedef1=new Hedef();
            hedef1.KullaniciID=ID;
            LogicHedefIslem logicHedefIslem = new LogicHedefIslem();
            HedefAdı.Text= logicHedefIslem.LogicHedefAd(hedef1);
            //burada grafiği çektik
            var manager1 = new LogicGiderIslem();
            var harcamalar1 = manager1.GetKategoriBazliHarcamalar(ID);

            chart2.Series.Clear();
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series("Kategori Harcamaları");
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = false;
            series1.LabelForeColor = Color.Transparent;

            foreach (var item in harcamalar1)
            {
                series1.Points.AddXY(item.KategoriAd, item.ToplamHarcama);

            }

            chart2.Series.Add(series1);
          
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
