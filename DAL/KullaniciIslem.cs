using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Migrations.Design;


namespace DAL
{
    public class KullaniciIslem
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public int KullaniciEkle(Kullanici x)
        {

            int yeniKullaniciID = 0;
            SqlCommand cmd = new SqlCommand("insert into Tbl_Kullanici (KullaniciAd,KullaniciSoyad,KullaniciSifre,KullaniciGelir,KullaniciBakiye,KullaniciMaasGunu) values (@p1,@p2,@p3,@p4,@p5,@p6);SELECT SCOPE_IDENTITY();", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.KullaniciAd);
            cmd.Parameters.AddWithValue("@p2", x.KullaniciSoyad);
            cmd.Parameters.AddWithValue("@p3", x.KullaniciSifre);
            cmd.Parameters.AddWithValue("@p4", x.KullaniciGelir);
            cmd.Parameters.AddWithValue("@p5", x.KullaniciBakiye);
            cmd.Parameters.AddWithValue("@p6", x.MaasGunu);
            
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                yeniKullaniciID = Convert.ToInt32(result);
            }

            return yeniKullaniciID;
        }
        public bool KullaniciGiris(Kullanici x)
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Kullanici Where KullaniciID=@p1 and KullaniciSifre=@p2", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.KullaniciID);
            cmd.Parameters.AddWithValue("@p2", x.KullaniciSifre);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               
                return true;
            }
            else
            {
                return false;
            }  
        }
        public string KullaniciAd(Kullanici x)
        {
            SqlCommand cmd = new SqlCommand("Select KullaniciAd From Tbl_Kullanici Where KullaniciID=@p1", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.KullaniciID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                x.KullaniciAd = dr[0] + "";
            }
            return x.KullaniciAd;

        }
        public (decimal,decimal) KullaniciGelir(Kullanici x)
        {
            SqlCommand cmd = new SqlCommand("Select KullaniciGelir,KullaniciBakiye From Tbl_Kullanici Where KullaniciID=@p1", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.KullaniciID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                x.KullaniciGelir = dr.GetDecimal(0);
                x.KullaniciBakiye = dr.GetDecimal(1);
            }
            return (x.KullaniciGelir, x.KullaniciBakiye);
        }
        public bool ProfilGüncelle(Kullanici x)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Kullanici set KullaniciAd=@p1,KullaniciSoyad=@p2 Where KullaniciID=@p3", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.KullaniciAd);
            cmd.Parameters.AddWithValue("@p2", x.KullaniciSoyad);
            cmd.Parameters.AddWithValue("@p3", x.KullaniciID);
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool GelirGüncelle(Kullanici x)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Kullanici set KullaniciGelir=@p1 Where KullaniciID=@p2", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.KullaniciGelir);
            cmd.Parameters.AddWithValue("@p2", x.KullaniciID);
            
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool SifreGüncelle(Kullanici x)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Kullanici set KullaniciSifre=@p1 Where KullaniciID=@p2", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.KullaniciSifre);
            cmd.Parameters.AddWithValue("@p2", x.KullaniciID);

            return cmd.ExecuteNonQuery() > 0;
        }
        public void MaasGunuBakiye(Kullanici x)
        {
            string query = @"
             UPDATE Tbl_Kullanici
             SET KullaniciBakiye = KullaniciBakiye + KullaniciGelir,
             SonMaasGunu = CAST(GETDATE() AS DATE)
             WHERE KullaniciID = @kullaniciID
             AND KullaniciMaasGunu = DAY(GETDATE()) 
             AND (SonMaasGunu IS NULL OR SonMaasGunu <> CAST(GETDATE() AS DATE));";

            SqlCommand cmd = new SqlCommand(query, bgl.Baglanti());
            cmd.Parameters.AddWithValue("@kullaniciID", x.KullaniciID);

           
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
        }
        public bool MaasGunuGuncelle(Kullanici x)
        {
            SqlCommand cmd=new SqlCommand("Update Tbl_Kullanici set KullaniciMaasGunu=@p1 where KullaniciID=@p2",bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.MaasGunu);
            cmd.Parameters.AddWithValue("@p2", x.KullaniciID);
            return cmd.ExecuteNonQuery() > 0;
        }
        
        



    }
   
}
