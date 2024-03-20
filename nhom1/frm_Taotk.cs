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
    public partial class frm_Taotk : Form
    {
        //Khai báo đối tượng
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataAdapter da;
        DataTable dt;
        string sql = "";
        public frm_Taotk()
        {
            InitializeComponent();
        }

       
        public void NguonTK()
        {
            sql = "select * from nguoiDung";

            //Khởi tạo đối tượng4e
            da = new OracleDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            // đẩy dữ liệu từ bảng lên datagripview
            dg_tk.DataSource = dt;
        }

        private void frm_Taotk_Load(object sender, EventArgs e)
        {
            conn = ketnoi.connnectDB();
            //gọi thủ tục lấy dữ liệu từ bảng
            NguonTK();
        }

        public void Xoatrang()
        {
            txt_idNg.Text = "";
            txt_tNg.Text = "";
            txt_pass.Text = "";

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
            string id = txt_idNg.Text;
            string ten = txt_tNg.Text;
            string pass = txt_pass.Text;
            if (TrungThem(txt_idNg.Text) == true)
            {
                MessageBox.Show("Trùng mã sinh viên yêu cầu nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //thêm dữ liệu
            sql = "insert into nguoiDung (nguoiDungID, tennguoidung, pass) values ('" + txt_idNg.Text + "', '" + txt_tNg.Text + "','" + txt_pass.Text +"')";
            //Thực hiện kiểm tra kết nối

            if (conn.State != ConnectionState.Open) conn.Open();

            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonTK();
            Xoatrang();
        }

        private void dg_tk_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int dong = e.RowIndex;
            //gán dữ liệu từ ô lên txtbox
            txt_idNg.Text = dg_tk.Rows[dong].Cells[0].Value.ToString();
            txt_tNg.Text = dg_tk.Rows[dong].Cells[1].Value.ToString();
            txt_pass.Text = dg_tk.Rows[dong].Cells[2].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            sql = "update nguoiDung" + " set tennguoidung ='" + txt_tNg.Text + "', pass='" + txt_pass.Text + "' where  nguoiDungID = '" + txt_idNg.Text + "'";

            if (conn.State != ConnectionState.Open) conn.Open();

            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonTK();
            Xoatrang();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            sql = "delete from nguoiDung where  nguoiDungID = '" + txt_idNg.Text + "'";
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd = new OracleCommand(sql, conn);
            cmd.ExecuteNonQuery();
            NguonTK();
            Xoatrang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin1 ad = new admin1();
            ad.Show();
        }

    }
}
