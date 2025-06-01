using DAL;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityLayer;

namespace LogicLayer
{
    public class LogicFaturaIslem
    {
        FaturaIslem islem=new FaturaIslem();
        public static List<Fatura> LogicFaturaGetir(Fatura x)
        {
            return FaturaIslem.FaturaListesi(x);
        }
        public int LogicFaturaEkle(Fatura x)
        {
            return islem.FaturaEkle(x);
        }
        public bool LogicFaturaSil(Fatura x)
        {
            return islem.FaturaSil(x);
        }
        public decimal LogicFaturaMiktar(Fatura x)
        {
            return islem.FaturaTutar(x);
        }

        public static List<Fatura> LogicFaturaHatirlatma(Fatura x)
        {
            return FaturaIslem.KullaniciFaturaHatirlatma(x);
        }

    }
}
