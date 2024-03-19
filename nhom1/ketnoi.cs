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
            String chuoi = @"Data Source=xe;User ID=QL-Thu-Vien;Password=123456;Unicode=True";
            OracleConnection con = new OracleConnection(chuoi);
            return con;
        }

    }
}
