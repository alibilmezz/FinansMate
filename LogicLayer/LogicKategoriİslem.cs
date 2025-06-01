using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityLayer;

namespace LogicLayer
{
    public class LogicKategori
    {
        public static List<Kategori> LogicKategoriIslem()
        {
            return DAL.Kategoriİslem.KategoriListesi();
        }
    }
}
