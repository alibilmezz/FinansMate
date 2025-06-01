using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityLayer;

namespace LogicLayer
{
    public class LogicGiderAnaliz
    {
        public static string GetGunlukHarcamaAnalizi(List<GunlukHarcamaDTO> gunlukHarcamalar)
        {
            if (gunlukHarcamalar.Count == 0) return "Son 30 gün içinde herhangi bir harcama kaydı bulunamadı.";

            decimal toplamHarcama = gunlukHarcamalar.Sum(x => x.ToplamHarcama);
            decimal ortalamaHarcama = toplamHarcama / gunlukHarcamalar.Count;
            var enFazlaHarcama = gunlukHarcamalar.OrderByDescending(x => x.ToplamHarcama).First();
            var enAzHarcama = gunlukHarcamalar.OrderBy(x => x.ToplamHarcama).First();

            StringBuilder analiz = new StringBuilder();
            analiz.AppendLine($"Son 30 günde toplam harcaman: {toplamHarcama:C}");
            analiz.AppendLine($"Günlük ortalama harcaman: {ortalamaHarcama:C}");
            analiz.AppendLine($"En fazla harcama yaptığın gün: {enFazlaHarcama.Gun.ToShortDateString()} - {enFazlaHarcama.ToplamHarcama:C}");
            analiz.AppendLine($"En az harcama yaptığın gün: {enAzHarcama.Gun.ToShortDateString()} - {enAzHarcama.ToplamHarcama:C}");
            return analiz.ToString();
        }
        public static string GetKategoriHarcamaAnalizi(List<KategoriHarcamaDTO> kategoriHarcamalari)
        {
            if (kategoriHarcamalari.Count == 0) return "Son 30 gün içinde kategori bazlı herhangi bir harcama bulunamadı.";

            var enFazlaHarcamaKategori = kategoriHarcamalari.First();
            var enAzHarcamaKategori = kategoriHarcamalari.Last();

            StringBuilder analiz = new StringBuilder();
            analiz.AppendLine($"En çok harcama yaptığın kategori: {enFazlaHarcamaKategori.KategoriAd} - {enFazlaHarcamaKategori.ToplamHarcama:C}");
            analiz.AppendLine($"En az harcama yaptığın kategori: {enAzHarcamaKategori.KategoriAd} - {enAzHarcamaKategori.ToplamHarcama:C}");
            return analiz.ToString();
        }
        public static string GetOneriler(List<GunlukHarcamaDTO> gunlukHarcamalar, List<KategoriHarcamaDTO> kategoriHarcamalari)
        {
            if (gunlukHarcamalar.Count == 0) return "Öneri oluşturmak için yeterli veri bulunamadı.";

            decimal ortalamaHarcama = gunlukHarcamalar.Average(x => x.ToplamHarcama);
            var enFazlaHarcama = gunlukHarcamalar.OrderByDescending(x => x.ToplamHarcama).First();

            StringBuilder oneriler = new StringBuilder();
            if (enFazlaHarcama.ToplamHarcama > ortalamaHarcama * 2)
            {
                oneriler.AppendLine($"Dikkat! {enFazlaHarcama.Gun.ToShortDateString()} tarihinde ortalamadan çok fazla harcama yaptın. Büyük harcamalarını planlı yapabilirsin.");
            }

            var lüksKategoriler = kategoriHarcamalari.Where(x => x.ToplamHarcama > ortalamaHarcama * 5/10).ToList();
            if (lüksKategoriler.Count > 0)
            {
                oneriler.AppendLine("Aşağıdaki kategorilerde fazla harcama yapıyorsun, gözden geçirebilirsin:");
                foreach (var kategori in lüksKategoriler)
                {
                    oneriler.AppendLine($"- {kategori.KategoriAd}: {kategori.ToplamHarcama:C}");
                }
            }

            return oneriler.ToString();
        }


    }
}
