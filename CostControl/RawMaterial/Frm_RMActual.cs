using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CostControl.RawMaterial
{
    public partial class Frm_RMActual : Form
    {
        public string Eno = "";
        public string FNo = "";
        public string CCNo = "";
        public string PNo = "";
        public string Year = "";

        public List<int[]> flaglist = new List<int[]>();
        public float[,] BasicData = new float[5, 13];
        public float[,] ChangedData = new float[5, 13];
        public string mode;
        DataTable dt1 = new DataTable();

        public Frm_RMActual()
        {
            InitializeComponent();
            Eno = "E1";
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetRMData.FNo(comB_Facility.Text);
            comB_CC.Items.Clear();
            string sql = "select CCName from CostCenter where  FNo ='" + FNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_CC.Items.Add(temp.Rows[i]["CCName"].ToString());
            }
        }

        private void comB_CC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mode == "search" || mode == "update")
            {
                CCNo = GetRMData.CCNo(comB_CC.Text);
                comB_Product.Items.Clear();
                string sql = " select distinct PName from RMBudget, Product,CostCenter where CostCenter.CCNo =RMBudget.CCNo and Product.PNo =RMBudget.PNo and CCName='" + comB_CC.Text + "' ";
                DataTable temp = ODbcmd.SelectToDataTable(sql);
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    comB_Product.Items.Add(temp.Rows[i]["PName"].ToString());
                }
            }
        }

        private void dgvinitial()
        {
            for (int i = dgv_rmdata.Rows.Count; i > 0; i--)
            {
                dgv_rmdata.Rows.RemoveAt(0);
            }
            dgv_rmdata.Rows.Add("PurchaseCost", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata.Rows.Add("PurchasePrice", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata.Rows.Add("PurchaseQuantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata.Rows.Add("SalesQuantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata.Rows.Add("Availability", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata.RowHeadersVisible = false;
            for (int i = 1; i < 13; i++)
            {
                dgv_rmdata.Columns[i].Width = 60;
                dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
            }
            for (int j = 0; j < 5; j++)
            {
                dgv_rmdata.Rows[j].Height = 60;
                dgv_rmdata.Rows[j].ReadOnly = true;
            }
            dgv_rmdata.Rows[0].DefaultCellStyle.Format = "N2";
            dgv_rmdata.Rows[1].DefaultCellStyle.Format = "N2";
            dgv_rmdata.Rows[2].DefaultCellStyle.Format = "N0";
            dgv_rmdata.Rows[3].DefaultCellStyle.Format = "N0";
            dgv_rmdata.Rows[4].DefaultCellStyle.Format = "N2";

        }

        private void Frm_RMActual_Load(object sender, EventArgs e)
        {
            string sql = "select distinct Fname from Facility";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
            }

            dgvinitial();
            mode = "search";
        }

        private void comB_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mode == "search" || mode == "update")
            {
                PNo = GetRMData.PNo(comB_Product.Text);
                comB_Year.Items.Clear();
                string sql = " select distinct Year from RMBudget where CCNo='" + CCNo + "' and PNo ='" + PNo + "'";
                DataTable temp = ODbcmd.SelectToDataTable(sql);
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    comB_Year.Items.Add(temp.Rows[i]["Year"].ToString());
                }
            }
        }

        private void comB_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year = comB_Year.Text;
        }

        private void btn_Exceladd_Click(object sender, EventArgs e)
        {
            OpenFileDialog xlsDileDialog = new OpenFileDialog();
            xlsDileDialog.Filter = "xls文件|*.xlsx|所有文件|*.*";
            xlsDileDialog.FilterIndex = 1;

            if (xlsDileDialog.ShowDialog() == DialogResult.OK)
            {
                string sExcelFile = xlsDileDialog.FileName;

            }
        }

        private void btn_ExcelOut_Click(object sender, EventArgs e)
        {
            ExcelControl a = new ExcelControl();
            a.SaveAsExcel(dgv_rmdata);
        }

        private bool getPK()//获取四个主键，做了个封装
        {
            if (FNo == "" || CCNo == "" || PNo == "" || Year == "" )
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            if (getPK())
            {
                DataTable r = new DataTable();
                mode = "search";
                r = GetRMData.Actual(CCNo, PNo, Year);

                if (r.Rows.Count > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (r.Rows[j][0].ToString() == (i + 1).ToString())
                            {
                                for (int k = 0; k < 12; k++)
                                {
                                    dgv_rmdata[k + 1, i].Value = r.Rows[j]["M" + (k + 1).ToString()];
                                }
                            }
                        }
                    }
                    for (int i = 1; i < 13; i++)
                    {
                        dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
                else
                { MessageBox.Show("数据为空！"); }

                BasicData = GetRMData.DTto2DFloat(r);
                dgv_rmdata.Rows[0].DefaultCellStyle.Format = "N2";
                dgv_rmdata.Rows[1].DefaultCellStyle.Format = "N2";
                dgv_rmdata.Rows[2].DefaultCellStyle.Format = "N0";
                dgv_rmdata.Rows[3].DefaultCellStyle.Format = "N0";
                dgv_rmdata.Rows[4].DefaultCellStyle.Format = "N2";

                btn_update.Visible = true;
                btn_delete.Visible = true;

            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            mode = "update";
            btn_Cancel.Visible = true;

            dgv_rmdata.Rows[0].ReadOnly = true;
            dgv_rmdata.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
            dgv_rmdata.Rows[1].ReadOnly = false;
            dgv_rmdata.Rows[2].ReadOnly = false;
            dgv_rmdata.Rows[3].ReadOnly = false;
            dgv_rmdata.Rows[4].ReadOnly = true;
            dgv_rmdata.Rows[4].DefaultCellStyle.BackColor = Color.Gray;
            dgv_rmdata.Columns[0].DefaultCellStyle.BackColor = Color.White;
            for (int i = 1; i < 13; i++)
            {
                dgv_rmdata.Columns[i].ReadOnly = false;
                dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            mode = "del";
            if (getPK())
            {
                try
                {
                    string sql;
                    if (MessageBox.Show("是否确认删除本表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        sql = string.Format("delete from RMActual where FNo ='{0}' and PNo ='{1}' and CCNo='{2}' and Year={3}",
                                FNo, PNo, CCNo, Year);
                        ODbcmd.ExecuteSQLNonquery(sql);
                        MessageBox.Show("删除成功");
                        comB_CC.Text = "";
                        comB_Product.Text = "";
                        comB_Year.Text = "";
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btn_newbudget_Click(object sender, EventArgs e)
        {
            mode = "add";
            comB_Year.DropDownStyle = ComboBoxStyle.DropDown;

            dgvinitial();
            for (int j = 1; j < 13; j++)
            {
                dgv_rmdata.Columns[j].ReadOnly = false;
                dgv_rmdata.Columns[j].DefaultCellStyle.BackColor = Color.White;
            }
            btn_Save.Visible = true;
            btn_update.Visible = false;
            btn_delete.Visible = false;

            comB_Product.Items.Clear();
            string sql = "select distinct Pname from Product";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Product.Items.Add(temp.Rows[i]["PName"].ToString());
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (mode == "update")
            {
                if (flaglist.Count != 0)
                {
                    foreach (int[] a in flaglist)
                    {
                        if (Convert.ToSingle(dgv_rmdata[a[0], a[1]].Value) != BasicData[a[1], a[0]])//值确实改变了
                        {
                            try
                            {
                                    //string sql = string.Format(" insert into RMBudgetEdit values('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},'{10}','{11}') ",
                                    //    FNo, PNo, CCNo, Year, a[0], BasicData[0, a[0]], BasicData[1, a[0]], BasicData[2, a[0]], BasicData[3, a[0]],
                                    //    BasicData[4, a[0]], System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Eno);
                                    //ODbcmd.ExecuteSQLNonquery(sql);
                                    for (int i = 0; i < 5; i++)
                                    {
                                        string sql1 = string.Format(" update RMActual set M{0}={1}"
                                        + " where FNo='{2}' and PNO='{3}' and CCNo='{4}' and Year={5} and Type='{6}' ",
                                        a[0], Convert.ToSingle(dgv_rmdata[a[0], i].Value),
                                        FNo, PNo, CCNo, Year, i + 1);
                                        ODbcmd.ExecuteSQLNonquery(sql1);
                                    }
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                    MessageBox.Show("修改成功");
                    flaglist.Clear();

                }
            }

            if (mode == "add")
            {
                if (getPK())
                {
                    DataTable r = GetRMData.Budget(CCNo, PNo, Year);
                    if (r.Rows.Count > 0)
                    {
                        MessageBox.Show("系统监测到已有数据，不能添加！");
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {

                            string sql1 = string.Format(" insert into RMBudget values ('{0}','{1}','{2}',{3},{4},'{5}',{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},'{18}','{19}')",
                            FNo, PNo, CCNo, Year, i + 1, dgv_rmdata[0, i].Value,
                            Convert.ToSingle(dgv_rmdata[1, i].Value),
                            Convert.ToSingle(dgv_rmdata[2, i].Value),
                            Convert.ToSingle(dgv_rmdata[3, i].Value),
                            Convert.ToSingle(dgv_rmdata[4, i].Value),
                            Convert.ToSingle(dgv_rmdata[5, i].Value),
                            Convert.ToSingle(dgv_rmdata[6, i].Value),
                            Convert.ToSingle(dgv_rmdata[7, i].Value),
                            Convert.ToSingle(dgv_rmdata[8, i].Value),
                            Convert.ToSingle(dgv_rmdata[9, i].Value),
                            Convert.ToSingle(dgv_rmdata[10, i].Value),
                            Convert.ToSingle(dgv_rmdata[11, i].Value),
                            Convert.ToSingle(dgv_rmdata[12, i].Value),
                            System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Eno);
                            ODbcmd.ExecuteSQLNonquery(sql1);
                        }
                        MessageBox.Show("添加成功！");

                    }
                }

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认不保存操作？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btn_newActual.Enabled = true;
                btn_update.Enabled = true;
                comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
                flaglist.Clear();
                Frm_RMActual_Load(sender, e);

            }
        }


    }

}
