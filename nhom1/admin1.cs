using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nhom1
{
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            tacgia tg = new tacgia();
            tg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sach s = new sach();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_theloai tl = new frm_theloai();
            tl.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_Taotk tk = new frm_Taotk();
            tk.Show();
        }
    }
}
