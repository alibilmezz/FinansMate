using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Kategoriİslem
    {
        
        public static List<Kategori> KategoriListesi()
        {
            SqlBaglanti bgl = new SqlBaglanti();
            List<Kategori> degerler = new List<Kategori>();
            SqlCommand cmd = new SqlCommand("select * from Tbl_Kategori",bgl.Baglanti());
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Kategori ent = new Kategori();
                ent.KategoriID = int.Parse(dr["KategoriID"].ToString());
                ent.KategoriAd = dr["KategoriAd"].ToString();
               
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }
       
    }
}
