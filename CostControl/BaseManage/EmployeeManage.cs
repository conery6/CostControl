using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CostControl.BaseManage
{
    public partial class EmployeeManage : Form
    {
        public EmployeeManage()
        {
            InitializeComponent();
        }

        private void EmployeeManage_Load(object sender, EventArgs e)
        {
            string sql = "select distinct Fname from Facility";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
            }

            sql = "select distinct CCName from CostCenter";
            temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_CC .Items.Add(temp.Rows[i]["CCName"].ToString());
            }

            sql = "select distinct FSName from FacilitySystem";
            temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_FSystem.Items.Add(temp.Rows[i]["FSName"].ToString());
            }
        }
        //    string sql = "select * from Employee";
        //    DataTable temp = ODbcmd.SelectToDataTable(sql);
        //    for (int i = 0; i < temp.Rows.Count; i++)
        //    {
        //        DGW_Employee.Rows.Add(temp.Rows[i]["ENo"].ToString(), temp.Rows[i]["EName"].ToString(), temp.Rows[i]["Ekey"].ToString(), temp.Rows[i]["Authrity"].ToString());
        //    }
        //}

        //private void DGW_Employee_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    foreach (DataGridViewRow r in DGW_Employee.SelectedRows)
        //    {
        //        string ENo = DGW_Employee[0, r.Index].Value.ToString();
        //        if (MessageBox.Show("确认要删除 " + ENo + " 的数据吗？", "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
        //        {
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            string sql = "delete from Employee where ENo='" + ENo + "'";
        //            ODbcmd.ExecuteSQLNonquery(sql);
        //            MessageBox.Show("数据 " + ENo + " 删除成功！");
        //        }
            }

            
}
