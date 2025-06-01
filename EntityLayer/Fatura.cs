using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Fatura
    {
        public int FaturaID { get; set; }
        public string FaturaAd { get; set; }
        public decimal FaturaMiktar { get; set; }
        public DateTime FaturaTarih { get; set; }
        public bool FaturaDurum { get; set; }

        public int KullaniciID { get; set; }

        public Kullanici Kullanici { get; set; }
    }
}
