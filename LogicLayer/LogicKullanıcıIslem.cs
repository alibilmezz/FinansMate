using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityLayer;


namespace LogicLayer
{
    
    public class LogicKullanıcıIslem
    {
        KullaniciIslem islem = new KullaniciIslem();
        public int LogicKullanicekle(Kullanici k)
        {
            
            return islem.KullaniciEkle(k);
        }
        public bool LogicKullaniciGiris(Kullanici k)
        {
            return islem.KullaniciGiris(k);
        }
        public string LogicKullaniciAd(Kullanici k)
        {
            return islem.KullaniciAd(k);
        }
        public (decimal,decimal) LogicKullaniciGelir(Kullanici k)
        {
            return islem.KullaniciGelir(k);
        }
        public bool LogicProfilGüncelle(Kullanici k)
        {
            return islem.ProfilGüncelle(k);
        }
        public bool LogicGelirGüncelle(Kullanici k)
        {
            return islem.GelirGüncelle(k);
        }
        public bool LogicSifreGüncelle(Kullanici k)
        {
            return islem.SifreGüncelle(k);
        }
        public void MaasGunuGuncelleme(Kullanici k)
        {
            islem.MaasGunuBakiye(k);
        }
        public bool MaasGunuGuncel(Kullanici k)
        {
            return islem.MaasGunuGuncelle(k);
        }
    }
}
