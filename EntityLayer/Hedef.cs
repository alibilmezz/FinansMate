using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Hedef
    {
        public int HedefID { get; set; }
        public string HedefAd { get; set; }
        public DateTime HedefTarih { get; set; }
        public int HedefMiktar { get; set; }
        public bool HedefDurum { get; set; }
        public int HedefBirikim { get; set; }

        public int KullaniciID { get; set; }

        public Kullanici kullanici { get; set; }    
    }
}
