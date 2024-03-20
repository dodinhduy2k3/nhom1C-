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

        public void NguonCB()
        {
            sql = "select * from theloai";
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            cb_tl.DataSource = dt;
            cb_tl.DisplayMember = "tenTheLoai";
            cb_tl.ValueMember = "theLoaiID";
        }
        public void NguonSach()
        {
            sql = "select * from sach where theLoaiID='" + cb_tl.SelectedValue.ToString() + "'";
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dg_sach.DataSource = dt;
            lb_tb.Text = "Có " + (dg_sach.RowCount - 1)  + " sách";
        }
        private void sach_Load(object sender, EventArgs e)
        {
            conn = ketnoi.connnectDB();
            //gọi thủ tục lấy dữ liệu từ bảng
            NguonCB();
            NguonSach();
        }

        private void dg_sach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int dong = e.RowIndex;
            //gán dữ liệu từ ô lên txtbox
            txt_ids.Text = dg_sach.Rows[dong].Cells[0].Value.ToString();
            txt_ts.Text = dg_sach.Rows[dong].Cells[1].Value.ToString();
            txt_nds.Text = dg_sach.Rows[dong].Cells[2].Value.ToString();
            txt_idtg.Text = dg_sach.Rows[dong].Cells[3].Value.ToString();
        }
        public void Xoatrang()
        {
            txt_ids.Text = "";
            txt_ts.Text = "";
            txt_nds.Text = "";
            txt_idtg.Text = "";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string Ids = txt_ids.Text;
            string Ts = txt_ts.Text;
            string nds = txt_nds.Text;
            string idtg = txt_idtg.Text;
            //thêm dữ liệu
            sql = "insert into sach(sachID, tenSach,noiDung,tacgiaID,theLoaiID) values ('" + txt_ids.Text + "', '" + txt_ts.Text
                + "', '" + txt_nds.Text + "', '" + txt_idtg.Text + "', '" + cb_tl.SelectedValue.ToString() + "')";
            //Thực hiện kiểm tra kết nối

            if (conn.State != ConnectionState.Open) conn.Open();

            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonSach();
            Xoatrang();
        }

        private void cb_tl_SelectedIndexChanged(object sender, EventArgs e)
        {
            NguonSach();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            sql = "update sach" + " set tenSach ='" + txt_ts.Text + "', noiDung ='" + txt_nds.Text +"', tacgiaID ='"
               + txt_idtg.Text + "', theLoaiID ='" + cb_tl.SelectedValue.ToString() + "' where sachID = '" + txt_ids.Text + "'";
            if (conn.State != ConnectionState.Open) conn.Open();

            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonSach();
            Xoatrang();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            sql = "delete from sach where  sachID = '" + txt_ids.Text + "'";
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonSach();
            Xoatrang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void TimKiem()
        {
            string matim = txt_tk.Text;
            sql = "select * from sach where sachID like '%" + txt_tk.Text + "%' or tenSach like '%" + txt_tk.Text + "%' ";
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dg_sach.DataSource = dt;
        }

        private void txt_tk_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
            Xoatrang();
        }
    }
}
