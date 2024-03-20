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
    public partial class frm_theloai : Form
    {

        //Khai báo đối tượng
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataAdapter da;
        DataTable dt;
        string sql = "";
        public frm_theloai()
        {
            InitializeComponent();
        }

        private void frm_theloai_Load(object sender, EventArgs e)
        {
            conn = ketnoi.connnectDB();
            //gọi thủ tục lấy dữ liệu từ bảng
            NguonTL();
        }
        public void NguonTL()
        {
            sql = "select * from theloai";

            //Khởi tạo đối tượng4e
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            // đẩy dữ liệu từ bảng lên datagripview
            dg_tl.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_tl_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int dong = e.RowIndex;
            //gán dữ liệu từ ô lên txtbox
            txt_idtl.Text = dg_tl.Rows[dong].Cells[0].Value.ToString();
            txt_ttl.Text = dg_tl.Rows[dong].Cells[1].Value.ToString();
        }

        public void Xoatrang()
        {
            txt_idtl.Text = "";
            txt_ttl.Text = "";
        }
        public bool TrungThem(string manhap)
        {
            sql = "select * from theloai where theLoaiID= '" + manhap + "'";
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            //Khai báo các tham số
            string id = txt_idtl.Text;
            string ten = txt_ttl.Text;
            if (TrungThem(txt_idtl.Text) == true)
            {
                MessageBox.Show("Trùng mã sinh viên yêu cầu nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //thêm dữ liệu
            sql = "insert into theloai (theLoaiID,tenTheLoai) values ('" + txt_idtl.Text + "', '" + txt_ttl.Text + "')";
            //Thực hiện kiểm tra kết nối

            if (conn.State != ConnectionState.Open) conn.Open();

            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonTL();
            Xoatrang();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            sql = "update theloai" + " set tenTheLoai ='" + txt_ttl.Text + "' where  theLoaiID = '" + txt_idtl.Text + "'";

            if (conn.State != ConnectionState.Open) conn.Open();

            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonTL();
            Xoatrang();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            sql = "delete from theloai where  theLoaiID = '" + txt_idtl.Text + "'";
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonTL();
            Xoatrang();
        }

    }
}
