using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace nhom1
{
    public partial class tacgia : Form
    {
        //Khai báo đối tượng
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataAdapter da;
        DataTable dt;
        string sql = "";
        public tacgia()
        {
            InitializeComponent();
        }

        private void tacgia_Load(object sender, EventArgs e)
        {
            conn = ketnoi.connnectDB();
            //gọi thủ tục lấy dữ liệu từ bảng
            NguonTG();
        }
        public void NguonTG()
        {
            sql = "select * from tacgia";

            //Khởi tạo đối tượng4e
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            // đẩy dữ liệu từ bảng lên datagripview
            dg_tg.DataSource = dt;
        }
        public void Xoatrang()
        {
            txt_id.Text = "";
            txt_t.Text = "";
        }
        public bool TrungThem(string manhap)
        {
            sql = "select * from tacgia where tacgiaID= '" + manhap + "'";
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
            string id = txt_id.Text;
            string ten = txt_t.Text;
            if (TrungThem(txt_id.Text) == true)
            {
                MessageBox.Show("Trùng mã sinh viên yêu cầu nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //thêm dữ liệu
            sql = "insert into tacgia(tacgiaID, tenTacGia ) values ('" + txt_id.Text + "', '" + txt_t.Text +  "')";
            //Thực hiện kiểm tra kết nối

            if (conn.State != ConnectionState.Open) conn.Open();

            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonTG();
            Xoatrang();
        }

        private void dg_tg_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int dong = e.RowIndex;
            //gán dữ liệu từ ô lên txtbox
            txt_id.Text = dg_tg.Rows[dong].Cells[0].Value.ToString();
            txt_t.Text = dg_tg.Rows[dong].Cells[1].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            sql = "update tacgia" + " set tenTacGia ='" + txt_t.Text + "' where  tacgiaID = '" + txt_id.Text + "'";

            if (conn.State != ConnectionState.Open) conn.Open();

            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonTG();
            Xoatrang();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            sql = "delete from tacgia where  tacgiaID = '" + txt_id.Text + "'";
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonTG();
            Xoatrang();
        }

    }
}
