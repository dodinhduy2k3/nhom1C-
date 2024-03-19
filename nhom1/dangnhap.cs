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
    public partial class dangnhap : Form
    {
        OracleConnection conn;
        public dangnhap()
        {
            InitializeComponent();
        }

        private void dangnhap_Load(object sender, EventArgs e)
        {
            try
            {
                conn = ketnoi.connnectDB();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Không thể đọc chuỗi kết nối " + ex.Message);
                Application.Exit();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnloign_Click(object sender, EventArgs e)
        {
            string tenNguoiDung = txtus.Text;
            string pass = txtpass.Text;
            string vaitro = layvaitro(tenNguoiDung, pass);

            if (vaitro == "admin")
            {

                MessageBox.Show("Đăng Nhập Thành Công với cài trò Admin");
                admin1 formAdmin = new admin1();
                formAdmin.Show();

            }
            else if (vaitro == "user")
            {
                // Đăng nhập thành công với vai trò người dùng, chuyển hướng đến FormUser

                MessageBox.Show("Đăng nhập thành công với vai trò Người dùng!");
                user formUser = new user();
                formUser.Show();

            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
            }

        }
        private string layvaitro(string tenNguoiDung, string pass)
        {
            if (tenNguoiDung == "admin")
            {
                return "admin";
            }
            else
            {
                return "user";
            }

        }
    }
}
