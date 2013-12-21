using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CostControl
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }


        private void Btn_OK_Click(object sender, EventArgs e)
        {
            string id = txtB_id.Text;
            string key = txtB_key.Text;
            //if (key == "") { key = null; }
            string sql = "select * from Employee where Ename='" + id + "' and Ekey ='" + key + "'"
                + " union select * from Employee where Eno='" + id + "' and Ekey ='" + key + "'";
            DataTable login = ODbcmd.SelectToDataTable(sql);
            if (login.Rows.Count > 0)
            {
                Frm_main main = new Frm_main(login .Rows [0]["ENo"].ToString ());
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show ("您的ID或密码错误，不能进入");
            }

        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            txtB_id.Text = "";
            txtB_key.Text = "";
        }

    }
}
