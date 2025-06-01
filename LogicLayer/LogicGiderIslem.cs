using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityLayer;


namespace LogicLayer
{
    public class LogicGiderIslem
    {
        Giderİslem islem = new Giderİslem();
        public int LogicGiderEkle(Gider x)
        {
            return islem.GiderEkle(x);
        }
        public bool LogicBakiyeGuncelle(Kullanici k)
        {
            return islem.BakiyeGüncelle(k);
        }
        public List<GunlukHarcamaDTO> GetGunlukHarcamalar(int kullaniciID)
        {
            return islem.GetGunlukHarcamalar(kullaniciID);
        }

        public List<KategoriHarcamaDTO> GetKategoriBazliHarcamalar(int kullaniciID)
        {
            return islem.GetKategoriBazliHarcamalar(kullaniciID);
        }
      

    }
}
