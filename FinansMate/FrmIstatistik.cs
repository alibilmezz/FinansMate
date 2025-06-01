using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LogicLayer;
using EntityLayer;
using DAL;

namespace FinansMate
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        public static int ID;
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            //BURADA GÜNLÜK HARCAMAYI ÇEKTİK 
            var manager = new LogicGiderIslem(); 
            var harcamalar = manager.GetGunlukHarcamalar(ID);

            chart1.Series.Clear();
            var series = new Series("Günlük Harcamalar");
            series.ChartType = SeriesChartType.Column;

            foreach (var item in harcamalar)
            {
                series.Points.AddXY(item.Gun.ToString("yyyy-MM-dd"), item.ToplamHarcama);
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisY.Interval = 1000;
            //BURADA KATEGORİ BAZLI ARAMAYI ÇEKTİK


            var manager1=new LogicGiderIslem();
            var harcamalar1 = manager1.GetKategoriBazliHarcamalar(ID);

            chart2.Series.Clear();
            var series1 = new Series("Kategori Harcamaları");
            series1.ChartType = SeriesChartType.Pie;
            series1.IsValueShownAsLabel = false;
            series1.LabelForeColor = Color.Transparent;

            foreach (var item in harcamalar1)
            {
                series1.Points.AddXY(item.KategoriAd, item.ToplamHarcama);
              
            }

            chart2.Series.Add(series1);
            //
            Gider x = new Gider();
            x.KullaniciID = ID;
            var gunlukHarcamalar = Giderİslem.GetGunlukHarcamalarSon30Gun(x);
            var kategoriHarcamalari = Giderİslem.GetKategoriHarcamalariSon30Gun(x);

            // Analiz ve önerileri hesapla
            string gunlukAnaliz = LogicGiderAnaliz.GetGunlukHarcamaAnalizi(gunlukHarcamalar);
            string kategoriAnaliz = LogicGiderAnaliz.GetKategoriHarcamaAnalizi(kategoriHarcamalari);
            string oneriler = LogicGiderAnaliz.GetOneriler(gunlukHarcamalar, kategoriHarcamalari);

            // UI'ya yazdır (örneğin, RichTextBox'a)
            RctAnaliz.Text = gunlukAnaliz + "\n" + kategoriAnaliz;
            RctÖneri.Text = oneriler;

        }

        private void BtnGunluk_Click(object sender, EventArgs e)
        {
            chart1.Visible=true;
            chart2.Visible=false;
        }

        private void BtnKategori_Click(object sender, EventArgs e)
        {
            chart2.Visible = true;
            chart1.Visible=false;
        }
    }
}
