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
    public class FaturaIslem
    {
        SqlBaglanti bgl= new SqlBaglanti();
        public int FaturaEkle(Fatura x)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Fatura (FaturaAd,FaturaMiktar,FaturaTarih,KullanıcıID,FaturaDurum)values(@p1,@p2,@p3,@p4,@p5)",bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.FaturaAd);
            cmd.Parameters.AddWithValue("@p2", x.FaturaMiktar);
            cmd.Parameters.AddWithValue("@p3", x.FaturaTarih);
            cmd.Parameters.AddWithValue("@p4", x.KullaniciID);
            cmd.Parameters.AddWithValue("@p5", x.FaturaDurum);
            return cmd.ExecuteNonQuery();
        }
        public bool FaturaSil(Fatura x)
        {
            SqlCommand cmd = new SqlCommand("Delete From Tbl_Fatura Where FaturaID=@p1", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.FaturaID);
            return cmd.ExecuteNonQuery() > 0;
        }
        public static List<Fatura> FaturaListesi(Fatura x)
        {
            SqlBaglanti bgl = new SqlBaglanti();
            List<Fatura> degerler = new List<Fatura>();
            SqlCommand cmd = new SqlCommand("select * from Tbl_Fatura Where KullanıcıID=@p1", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.KullaniciID);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Fatura ent = new Fatura();
                ent.FaturaID= int.Parse(dr["FaturaID"].ToString());
                ent.FaturaAd = dr["FaturaAd"].ToString();

                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }
        decimal faturamiktar;
        public decimal FaturaTutar(Fatura x)
        {
           
            SqlCommand cmd = new SqlCommand("Select FaturaMiktar From Tbl_Fatura Where FaturaID=@p1", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1",x.FaturaID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                faturamiktar=dr.GetDecimal(0);
            }
            return faturamiktar;
        }
        public static List<Fatura> KullaniciFaturaHatirlatma(Fatura x)
        {
            SqlBaglanti bgl = new SqlBaglanti();
            List<Fatura> degerler = new List<Fatura>();
            SqlCommand cmd = new SqlCommand("Select FaturaAd From Tbl_Fatura Where DATEDIFF(DAY, GETDATE(),FaturaTarih)<=3 AND KullanıcıID=@p1",bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", x.KullaniciID);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Fatura fatura=new Fatura();
                fatura.FaturaAd = dataReader["FaturaAd"].ToString();
                degerler.Add(fatura);
            }
           
            return degerler;
        }
       

      
    }
}

    

