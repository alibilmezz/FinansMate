using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;

namespace DAL
{
   public class Giderİslem
   {
        SqlBaglanti bgl = new SqlBaglanti();
        public int GiderEkle(Gider k)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Gider (GiderMiktar,GiderTarih,KategoriID,KullanıcıID) VALUES(@p1,@p2,@p3,@p4) ", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", k.GiderMiktar);
            cmd.Parameters.AddWithValue("@p2", k.GiderTarih);
            cmd.Parameters.AddWithValue("@p3", k.KategoriID);
            cmd.Parameters.AddWithValue("@p4", k.KullaniciID);
            return cmd.ExecuteNonQuery();
        }
       
        public bool BakiyeGüncelle(Kullanici k)
        {

            SqlCommand cmd = new SqlCommand("Update Tbl_Kullanici set KullaniciBakiye=@p1 where KullaniciID=@p2", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", k.KullaniciBakiye);
            cmd.Parameters.AddWithValue("@p2", k.KullaniciID);
            return cmd.ExecuteNonQuery() > 0;
        }
        public List<GunlukHarcamaDTO> GetGunlukHarcamalar(int kullaniciID)
        {
            List<GunlukHarcamaDTO> harcamalar = new List<GunlukHarcamaDTO>();

           
            
                string query = @"
                SELECT 
                CAST(GiderTarih AS DATE) AS Gun, 
                SUM(GiderMiktar) AS ToplamHarcama
                FROM Tbl_Gider
                WHERE KullanıcıID = @KullaniciID 
                AND GiderTarih >= DATEADD(DAY, -30, GETDATE())
                GROUP BY CAST(GiderTarih AS DATE)
                ORDER BY Gun ASC";

                SqlCommand cmd = new SqlCommand(query,bgl.Baglanti());
                cmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GunlukHarcamaDTO harcama = new GunlukHarcamaDTO
                    {
                        Gun = Convert.ToDateTime(reader["Gun"]),
                        ToplamHarcama = Convert.ToDecimal(reader["ToplamHarcama"])
                    };
                    harcamalar.Add(harcama);
                }

                reader.Close();
            

            return harcamalar;
        }
        public List<KategoriHarcamaDTO> GetKategoriBazliHarcamalar(int kullaniciID)
        {
            List<KategoriHarcamaDTO> liste = new List<KategoriHarcamaDTO>();

     
            
                string query = @"SELECT k.KategoriAd, SUM(g.GiderMiktar) AS ToplamHarcama
                         FROM Tbl_Gider g
                         JOIN Tbl_Kategori k ON g.KategoriID = k.KategoriID
                         WHERE g.KullanıcıID = @KullaniciID 
                         AND g.GiderTarih >= DATEADD(DAY, -30, GETDATE())
                         GROUP BY k.KategoriAd";

                SqlCommand cmd = new SqlCommand(query, bgl.Baglanti());
                cmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);

             
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    liste.Add(new KategoriHarcamaDTO
                    {
                        KategoriAd= dr["KategoriAd"].ToString(),
                        ToplamHarcama = Convert.ToDecimal(dr["ToplamHarcama"])
                    });
                }
               bgl.Baglanti().Close();
            

            return liste;
        }
        public static List<GunlukHarcamaDTO> GetGunlukHarcamalarSon30Gun(Gider x)
        {
            SqlBaglanti bgl = new SqlBaglanti();
            List<GunlukHarcamaDTO> harcamalar = new List<GunlukHarcamaDTO>();
           
            
                string query = @"
                SELECT CAST(GiderTarih AS DATE) AS Gun, SUM(GiderMiktar) AS ToplamHarcama
                FROM Tbl_Gider
                WHERE KullanıcıID = @KullaniciID AND GiderTarih >= DATEADD(DAY, -30, GETDATE())
                GROUP BY CAST(GiderTarih AS DATE)
                ORDER BY Gun ASC";

                SqlCommand cmd = new SqlCommand(query, bgl.Baglanti());
                cmd.Parameters.AddWithValue("@KullaniciID", x.KullaniciID);
                

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        harcamalar.Add(new GunlukHarcamaDTO
                        {
                            Gun = Convert.ToDateTime(dr["Gun"]),
                            ToplamHarcama = Convert.ToDecimal(dr["ToplamHarcama"])
                        });
                    }
                }
            
            return harcamalar;
        }
        public static List<KategoriHarcamaDTO> GetKategoriHarcamalariSon30Gun(Gider x)
        {
            SqlBaglanti bgl = new SqlBaglanti();
            List<KategoriHarcamaDTO> harcamalar = new List<KategoriHarcamaDTO>();
            
            
                string query = @"
            SELECT k.KategoriAd, SUM(g.GiderMiktar) AS ToplamHarcama
            FROM Tbl_Gider g
            INNER JOIN Tbl_Kategori k ON g.KategoriID = k.KategoriID
            WHERE g.KullanıcıID = @KullaniciID AND g.GiderTarih >= DATEADD(DAY, -30, GETDATE())
            GROUP BY k.KategoriAd
            ORDER BY ToplamHarcama DESC";

                SqlCommand cmd = new SqlCommand(query, bgl.Baglanti());
                cmd.Parameters.AddWithValue("@KullaniciID", x.KullaniciID);
               

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        harcamalar.Add(new KategoriHarcamaDTO
                        {
                            KategoriAd = dr["KategoriAd"].ToString(),
                            ToplamHarcama = Convert.ToDecimal(dr["ToplamHarcama"])
                        });
                    }
                }
            
            return harcamalar;
        }



    }
}
