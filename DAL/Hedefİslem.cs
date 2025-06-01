using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;



namespace DAL
{
    public class Hedefİslem
    {
       
      public static int HedefEkle(Hedef x)
      {
            SqlBaglanti bgl = new SqlBaglanti();

            SqlCommand cmd = new SqlCommand("insert into Tbl_Hedef (HedefAd,HedefTarih,HedefMiktar,HedefDurum,HedefBirikim,KullanıcıID) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.Baglanti());
            
            cmd.Parameters.AddWithValue("@p1", x.HedefAd);
            cmd.Parameters.AddWithValue("@p2", x.HedefTarih);
            cmd.Parameters.AddWithValue("@p3", x.HedefMiktar);
            cmd.Parameters.AddWithValue("@p4", x.HedefDurum);
            cmd.Parameters.AddWithValue("@p5", x.HedefBirikim);
            cmd.Parameters.AddWithValue("@p6", x.KullaniciID);
            return cmd.ExecuteNonQuery();
      }
      public static (int,int,bool) HedefMiktarGetir(Hedef x)
      {
            SqlBaglanti bgl = new SqlBaglanti();
            SqlCommand cmd1 = new SqlCommand("Select HedefMiktar,HedefBirikim,HedefDurum From Tbl_Hedef where KullanıcıID=@p1", bgl.Baglanti());
            cmd1.Parameters.AddWithValue("@p1", x.KullaniciID);
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                x.HedefMiktar = dr.GetInt32(0);
                x.HedefBirikim = dr.GetInt32(1);
                x.HedefDurum=dr.GetBoolean(2);

            }
            return (x.HedefMiktar,x.HedefBirikim,x.HedefDurum);
      }
      public static bool HedefSil(Hedef x)
      {
            SqlBaglanti bgl = new SqlBaglanti();
            SqlCommand cmd2 = new SqlCommand("Delete From Tbl_Hedef Where KullanıcıID=@p1", bgl.Baglanti());
            cmd2.Parameters.AddWithValue("@p1", x.KullaniciID);
            return cmd2.ExecuteNonQuery() > 0;

      }
      public static bool BirikimGuncelle(Hedef x)
        {
            SqlBaglanti bgl = new SqlBaglanti();
            SqlCommand cmd3 = new SqlCommand("Update Tbl_Hedef set HedefBirikim=@p1 where KullanıcıID=@p2", bgl.Baglanti());
            cmd3.Parameters.AddWithValue("@p1", x.HedefBirikim);
            cmd3.Parameters.AddWithValue("@p2", x.KullaniciID);
            return cmd3.ExecuteNonQuery() > 0;
        }

        public static string HedefAdıGetir(Hedef x)
        {
            SqlBaglanti bgl=new SqlBaglanti();
            SqlCommand cmd = new SqlCommand("Select HedefAd From Tbl_Hedef Where KullanıcıID=@p1",bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.KullaniciID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                x.HedefAd=dr.GetString(0);
            }
                return x.HedefAd;
        }

    }
}
