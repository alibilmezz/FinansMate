using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Gider
    {
        public int GiderID { get; set; }
        public decimal GiderMiktar { get; set; }
        public DateTime GiderTarih { get; set; }


        public int KategoriID { get; set; }
        public int KullaniciID { get; set; }

        public Kategori Kategori { get; set; }
        public Kullanici Kullanici { get; set; }

    }
}
