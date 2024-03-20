using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
namespace nhom1
{
    class ketnoi
    {
        public static OracleConnection connnectDB()
        {
            String chuoi = @"Data Source=DESKTOP-QDJTG4V;User ID=QLTV2;Password=12345;Unicode=True";
            OracleConnection conn = new OracleConnection(chuoi);
            return conn;
        }

    }
}
