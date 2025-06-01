using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityLayer;

namespace LogicLayer
{
    public class LogicHedefIslem
    {
        public int LogicHedefEkle(Hedef x)
        {
            return Hedefİslem.HedefEkle(x);
        }
        public (int, int, bool)  LogicHedefMiktar(Hedef x)
        {
            return Hedefİslem.HedefMiktarGetir(x);
        }
        public bool LogicHedefSil(Hedef x)
        {
            return Hedefİslem.HedefSil(x);
        }
        public bool LogicBirikimGuncelle(Hedef x)
        {
            return Hedefİslem.BirikimGuncelle(x);
        }
        public string LogicHedefAd(Hedef x)
        {
            return Hedefİslem.HedefAdıGetir(x);
        }
    }
}
