using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAd { get; set; }
        public string KullaniciSoyad { get; set; }
        public string KullaniciSifre{ get; set; }
        public decimal KullaniciGelir { get; set; }
        public decimal KullaniciBakiye { get; set; }    
        public int MaasGunu {  get; set; }  
       
    }
}
