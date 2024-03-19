using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace nhom1
{
    public partial class sach : Form
    {
        //Khai báo đối tượng
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataAdapter da;
        DataTable dt;
        string sql = "";
        public sach()
        {
            InitializeComponent();
        }

        private void sach_Load(object sender, EventArgs e)
        {
            conn = ketnoi.connnectDB();
            //gọi thủ tục lấy dữ liệu từ bảng
            NguonSach();
        }
        public void NguonSach()
        {
            sql = "select * from sach";

            //Khởi tạo đối tượng4e
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            // đẩy dữ liệu từ bảng lên datagripview
            dg_sach.DataSource = dt;
        }
    }
}
