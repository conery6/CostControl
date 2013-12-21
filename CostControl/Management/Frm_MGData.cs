using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CostControl.Management
{
    public partial class Frm_MGData : Form
    {
        public Frm_MGData()
        {
            InitializeComponent();
        }
        public string Eno = "";

        public string FNo;
        public string FSNo;
        public string CCNo;
        public string Year;
        public string Reporttype;
        public List<int[]> flaglist = new List<int[]>();
        public float[,] BasicData = new float[5, 13];
        public float[,] ChangedData = new float[5, 13];
        public string mode;
        DataTable dt1 = new DataTable();


        private void Frm_MGData_Load(object sender, EventArgs e)
        {


            string sql = "select distinct Fname from Facility";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
            }

            for (int i = 1; i < 13; i++)
            {
                dgv_MGData.Columns[i].Width = 60;
            }
            dgv_MGData.RowHeadersWidth = 20;

        }


        private bool getPK()//获取四个主键，做了个封装
        {
            if (FNo == "" || CCNo == "" || CCNo == "" || Year == "" || Reporttype == "")
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (getPK())
            {
                DataTable r = new DataTable();
                mode = "search";

                FNo = GetMGData.FNo(comB_Facility.Text);
                CCNo = GetMGData.CCNo(comB_CC.Text);
                Year = comB_Year.Text;

                switch (comB_RpType.Text)
                {
                    case "T1":
                        r = GetMGData.Budget(FNo, CCNo, Year);
                        break;
                    case "RF1":
                        r = GetMGData.MiddleBudget(FNo, CCNo, Year, 3);
                        break;
                    case "RF2":
                        r = GetMGData.MiddleBudget(FNo, CCNo, Year, 6);
                        break;
                    case "E3":
                        r = GetMGData.MiddleBudget(FNo, CCNo, Year, 9);
                        break;
                    case "Actual":
                        r = GetMGData.Actual(FNo, CCNo, Year);
                        break;
                }
                dt1 = r;

                if (r.Rows.Count > 0)
                {

                    dgv_MGData.DataSource = dt1;
                }
                else
                { MessageBox.Show("数据为空！"); }

                BasicData = GetMGData.DTto2DFloat(r);

                btn_update.Visible = true;
                btn_delete.Visible = true;

            }
        }

        private void btn_exceladd_Click(object sender, EventArgs e)
        {
            clm_IName.DataPropertyName = "F1";
            clm_M1.DataPropertyName = "F2";
            clm_M2.DataPropertyName = "F3";
            clm_M3.DataPropertyName = "F4";
            clm_M4.DataPropertyName = "F5";
            clm_M5.DataPropertyName = "F6";
            clm_M6.DataPropertyName = "F7";
            clm_M7.DataPropertyName = "F8";
            clm_M8.DataPropertyName = "F9";
            clm_M9.DataPropertyName = "F10";
            clm_M10.DataPropertyName = "F11";
            clm_M11.DataPropertyName = "F12";
            clm_M12.DataPropertyName = "F13";

            ExcelControl a = new ExcelControl();
            a.ExcelIntodgv(dgv_MGData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelControl a = new ExcelControl();
            a.SaveAsExcel(dgv_MGData);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            mode = "update";
            dgv_MGData.ReadOnly = false;

            btn_Cancel.Visible = true;
 

            //changeclolr（）
            //update（sql）

        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            //delete sheet
            mode = "delete";
            if (getPK())
            {
                try
                {
                    string sql;
                    if (MessageBox.Show("是否确认删除本表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        switch (Reporttype)
                        {
                            case "T1":
                                sql = string.Format("delete from MGBudget where FNo ='{0}' and CCNo='{1}' and Year={2}",
                                    FNo, CCNo, Year);
                                ODbcmd.ExecuteSQLNonquery(sql);
                                MessageBox.Show("删除成功");
                                comB_CC.Text = "";
                                comB_Year.Text = "";
                                break;
                            case "R":
                                sql = string.Format("delete from MGActual where FNo ='{0}' and CCNo='{1}' and Year={2}",
                                FNo, CCNo, Year);
                                ODbcmd.ExecuteSQLNonquery(sql);
                                MessageBox.Show("删除成功");
                                comB_CC.Text = "";
                                comB_Year.Text = "";
                                break;
                            default:
                                MessageBox.Show("只能删除T1及R表");
                                break;
                        }
                    }

                }
                catch { }

            }

        }

        private void dgvinitial()
        {
            for (int i = dgv_MGData.Rows.Count; i > 0; i--)
            {
                dgv_MGData.Rows.RemoveAt(0);
            }
            dgv_MGData.Rows.Add("Entertainment", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_MGData.Rows.Add("IT/IS", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_MGData.Rows.Add("Office", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_MGData.Rows.Add("Other Operation Cost", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_MGData.Rows.Add("Professional service", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_MGData.Rows.Add("Rental", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_MGData.Rows.Add("Safety", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_MGData.Rows.Add("Telecom-Data/Voice", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_MGData.Rows.Add("Transportation", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_MGData.Rows.Add("Travel", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_MGData.RowHeadersVisible = false;
            for (int i = 1; i < 13; i++)
            {
                dgv_MGData.Columns[i].Width = 60;
                dgv_MGData.Columns[i].DefaultCellStyle.BackColor = Color.White;
            }
            for (int j = 0; j < 10; j++)
            {
                dgv_MGData.Rows[j].Height = 60;
                dgv_MGData.Rows[j].ReadOnly = true;
            }
        }

        private void btn_newbudget_Click(object sender, EventArgs e)
        {
            //addnewbudget
            mode = "add";
            comB_Year.DropDownStyle = ComboBoxStyle.DropDown;


            dgvinitial();
            for (int j = 1; j < 13; j++)
            {
                dgv_MGData.Columns[j].ReadOnly = false;
                dgv_MGData.Columns[j].DefaultCellStyle.BackColor = Color.White;
            }
            btn_Save.Visible = true;
            btn_update.Visible = false;
            btn_delete.Visible = false;

 
            btn_delete.Visible = false;
            btn_exceladd.Visible = true;
            btn_update.Visible = false;
            btn_Save.Visible = true;
            btn_newbudget.Enabled = false;
            btn_search.Visible = false;
            btn_Cancel.Visible = true;
        }

        private void comB_CC_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCNo = GetMGData.CCNo(comB_CC.Text);
            comB_Year.Items.Clear();
            string sql = " select distinct Year from MGBudget where CCNo='" + CCNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Year.Items.Add(temp.Rows[i]["Year"].ToString());
            }




        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetMGData.FNo(comB_Facility.Text);
            comB_CC.Items.Clear();
            string sql = "select CCName from CostCenter where  FNo ='" + FNo + "'";
                DataTable temp = ODbcmd.SelectToDataTable(sql);

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    comB_CC.Items.Add(temp.Rows[i]["CCName"].ToString());
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
                        if (Convert.ToSingle(dgv_MGData[a[0], a[1]].Value) != BasicData[a[1], a[0]])//值确实改变了
                        {
                            try
                            {
                                if (Reporttype != "R")
                                {
                                   
                                    for (int i = 0; i < 5; i++)
                                    {
                                        string sql1 = string.Format(" update RMBudget set M{0}={1}"
                                        + " where FNo='{2}'  and CCNo='{3}' and Year={4} and Type='{5}' ",
                                        a[0], Convert.ToSingle(dgv_MGData[a[0], i].Value),
                                        FNo, CCNo, Year, i + 1);
                                        ODbcmd.ExecuteSQLNonquery(sql1);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        string sql1 = string.Format(" update MGActual set M{0}={1}"
                                        + " where FNo='{2}' and CCNo='{3}' and Year={4} and Type='{5}' ",
                                        a[0], Convert.ToSingle(dgv_MGData[a[0], i].Value),
                                        FNo, CCNo, Year, i + 1);
                                        ODbcmd.ExecuteSQLNonquery(sql1);
                                    }
                                }

                            }
                            catch { }
                        }
                    }
                    MessageBox.Show("修改成功");
                    flaglist.Clear();

                }
                btn_update.Enabled = true;
            }

            if (mode == "add")
            {
                if (getPK())
                {
                    DataTable r = GetMGData.Budget(FNo, CCNo, Year);
                    if (r.Rows.Count > 0)
                    {
                        MessageBox.Show("系统监测到已有数据，不能添加！");
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {

                            string sql1 = string.Format(" insert into MGBudget values ('{0}','{1}','{2}',{3},{4},'{5}',{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},'{18}')",
                            dgv_MGData[0, i].Value, FNo, CCNo, Year, i + 1, 
                            Convert.ToSingle(dgv_MGData[1, i].Value),
                            Convert.ToSingle(dgv_MGData[2, i].Value),
                            Convert.ToSingle(dgv_MGData[3, i].Value),
                            Convert.ToSingle(dgv_MGData[4, i].Value),
                            Convert.ToSingle(dgv_MGData[5, i].Value),
                            Convert.ToSingle(dgv_MGData[6, i].Value),
                            Convert.ToSingle(dgv_MGData[7, i].Value),
                            Convert.ToSingle(dgv_MGData[8, i].Value),
                            Convert.ToSingle(dgv_MGData[9, i].Value),
                            Convert.ToSingle(dgv_MGData[10, i].Value),
                            Convert.ToSingle(dgv_MGData[11, i].Value),
                            Convert.ToSingle(dgv_MGData[12, i].Value),
                            System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Eno);
                            ODbcmd.ExecuteSQLNonquery(sql1);
                        }
                        MessageBox.Show("添加成功！");

                    }
                    btn_newbudget.Enabled = true;
                }

            }
            comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
            btn_Save.Visible = false;
            btn_newbudget.Visible = true;
            btn_delete.Visible = true;
            btn_update.Visible = true;
            btn_exceladd.Visible = true;
            dgv_MGData.ReadOnly = true;
            comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            btn_search.Visible = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认不保存操作？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btn_newbudget.Enabled = true;
                btn_update.Enabled = true;
                comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
                flaglist.Clear();
                btn_search_Click(sender, e);

            }
        }
    }
}
