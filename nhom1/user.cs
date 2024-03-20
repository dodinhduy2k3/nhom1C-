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
    public partial class user : Form
    {
        //Khai báo đối tượng
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataAdapter da;
        DataTable dt;
        string sql = "";
        public user()
        {
            InitializeComponent();
        }
        public void NguonCB()
        {
            sql = "select * from theloai";
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            cb_tls.DataSource = dt;
            cb_tls.DisplayMember = "tenTheLoai";
            cb_tls.ValueMember = "theLoaiID";
        }
        public void NguonSach()
        {
            sql = "select * from sach where theLoaiID='" + cb_tls.SelectedValue.ToString() + "'";
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dg_Sachuser.DataSource = dt;
        }

        private void user_Load(object sender, EventArgs e)
        {
            conn = ketnoi.connnectDB();
            //gọi thủ tục lấy dữ liệu từ bảng
            NguonCB();
            NguonSach();
        }
        private void cb_tls_SelectedIndexChanged(object sender, EventArgs e)
        {
            NguonSach();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void TimKiem()
        {
            string matim = txt_tks.Text;
            sql = "select * from sach where sachID like '%" + txt_tks.Text + "%' or tenSach like '%" + txt_tks.Text + "%' ";
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dg_Sachuser.DataSource = dt;
        }
        private void txt_tks_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }
    }
}
