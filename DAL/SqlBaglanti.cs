using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class SqlBaglanti
    {
        public SqlConnection Baglanti() 
        {
            
            SqlConnection baglan = new SqlConnection(@"Data Source=MAMIMONSTER\SQLEXPRESS;Initial Catalog=FinansMate;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            baglan.Open();
            return baglan;
        }
        
    }
}
