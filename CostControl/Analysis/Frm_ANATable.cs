﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CostControl.Electric;
using CostControl.Maintain;
using CostControl.Management;
using CostControl.RawMaterial;

namespace CostControl.Analysis
{
    public partial class Frm_ANATable : Form
    {
        public string ENo;
        public string FNo;
        public string PNo;
        public string Year1;
        public string Year2;
        public string Reporttype1;
        public string Reporttype2;
        public string CCNo;
        DataTable DT1;
        DataTable DT2;
        float[,] FDT1 = new float[5, 13];
        float[,] FDT2 = new float[5, 13];
        float[,] f1 = new float[5, 13];
        float[,] f2 = new float[5, 13];
        float[,] f3 = new float[5, 13];

        public Frm_ANATable(string ENo1)
        {
            InitializeComponent();
            ENo = ENo1;
        }

        private void RMTable_Load(object sender, EventArgs e)
        {
            string sql = "select distinct Fname from Facility";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
            }

            comB_report1.Text = "T1";
            comB_report2.Text = "T1";


        }

        private bool getPK1()//获取四个主键，做了个封装
        {
            if (FNo == "" || CCNo == "" || Year1 == "" || Reporttype1 == "" || FNo == null || CCNo == null || Year1 == null || Reporttype1 == null)
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool getPK2()//获取四个主键，做了个封装
        {
            if (FNo == "" || CCNo == "" || Year2 == "" || Reporttype2 == "" || FNo == null || CCNo == null || Year2 == null || Reporttype2 == null)
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_dataok1_Click(object sender, EventArgs e)
        {
            string data = null;
            if (getPK1())
            {
                DataSet r = new DataSet();
                
                r = GetANAData.PeriodData(CCNo, Reporttype1, Year1);

                if (r.Tables.Count > 0)
                {
                    for (int y = 0; y < r.Tables.Count; y++)
                    {
                        if (y == 0)
                        {
                            dgv_rmdata1.Rows.Clear();
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_rmdata1.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 14; k++)
                                    {
                                        dgv_rmdata1[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_rmdata1[14, i].Value = sum;
                                }
                                //汇总
                                dgv_rmdata1[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_rmdata1[14, m].Value.ToString());
                                }
                                dgv_rmdata1[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                        }
                        else if (y == 1)
                        {
                            dgv_mgdata1.Rows.Clear();
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_mgdata1.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_mgdata1[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_mgdata1[13, i].Value = sum;
                                }
                                //汇总
                                dgv_mgdata1[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_mgdata1[13, m].Value.ToString());
                                }
                                dgv_mgdata1[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                        }
                        else if (y == 2)
                        {
                            dgv_edata1.Rows.Clear();
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_edata1.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_edata1[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_edata1[13, i].Value = sum;
                                }
                                //汇总
                                dgv_edata1[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_edata1[13, m].Value.ToString());
                                }
                                dgv_edata1[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                        }
                        else if (y == 3)
                        {
                            dgv_mtdata1.Rows.Clear();
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_mtdata1.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_mtdata1[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_mtdata1[13, i].Value = sum;
                                }
                                //汇总
                                dgv_mtdata1[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_mtdata1[13, m].Value.ToString());
                                }
                                dgv_mtdata1[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                        }
                    }
                }
            }
        }

        private void btn_dataok2_Click(object sender, EventArgs e)
        {
            string data = null;
            if (getPK2())
            {
                DataSet r = new DataSet();

                r = GetANAData.PeriodData(CCNo, Reporttype2, Year2);
                  
                if (r.Tables.Count > 0)
                {
                    for (int y = 0; y < r.Tables.Count; y++)
                    {
                        if (y == 0)
                        {
                            dgv_rmdata2.Rows.Clear();
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_rmdata2.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 14; k++)
                                    {
                                        dgv_rmdata2[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_rmdata2[14, i].Value = sum;
                                }
                                //汇总
                                dgv_rmdata2[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_rmdata2[14, m].Value.ToString());
                                }
                                dgv_rmdata2[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                        }
                        else if (y == 1)
                        {
                            dgv_mgdata2.Rows.Clear();
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_mgdata2.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_mgdata2[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_mgdata2[13, i].Value = sum;
                                }
                                //汇总
                                dgv_mgdata2[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_mgdata2[13, m].Value.ToString());
                                }
                                dgv_mgdata2[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                        }
                        else if (y == 2)
                        {
                            dgv_edata2.Rows.Clear();
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_edata2.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_edata2[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_edata2[13, i].Value = sum;
                                }
                                //汇总
                                dgv_edata2[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_edata2[13, m].Value.ToString());
                                }
                                dgv_edata2[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                        }
                        else if (y == 3)
                        {
                            dgv_mtdata2.Rows.Clear();
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_mtdata2.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_mtdata2[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_mtdata2[13, i].Value = sum;
                                }
                                //汇总
                                dgv_mtdata2[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_mtdata2[13, m].Value.ToString());
                                }
                                dgv_mtdata2[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                        }
                    }
                }
            }
        }

        private void chkB_T1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB_T1.Checked == true)
            {
                //总表统计分析
                
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("Year1");
                dt.Columns.Add("Year2");
                dt.Columns.Add("sub");
                dt.Columns.Add("percent");

                //原料管理
                DataRow dr = dt.NewRow();
                dr[0] = "原料管理";
                if (dgv_rmdata2.Rows.Count > 0 && dgv_rmdata1.Rows.Count > 0)
                {
                    dr[1] = float.Parse(dgv_rmdata1[1, dgv_rmdata1.Rows.Count - 1].Value.ToString());
                    dr[2] = float.Parse(dgv_rmdata2[1, dgv_rmdata2.Rows.Count - 1].Value.ToString());
                    dr[3] = float.Parse(dgv_rmdata2[1, dgv_rmdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_rmdata1[1, dgv_rmdata1.Rows.Count - 1].Value.ToString());
                    if (float.Parse(dr[3].ToString()) == 0f)
                    {
                        dr[4] = "∞";
                    }
                    else
                    {
                        dr[4] = ((float.Parse(dgv_rmdata2[1, dgv_rmdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_rmdata1[1, dgv_rmdata1.Rows.Count - 1].Value.ToString())) / float.Parse(dgv_rmdata2[1, dgv_rmdata2.Rows.Count - 1].Value.ToString())).ToString("0.00%");
                    }
                }
                dt.Rows.Add(dr);

                //管理控制
                DataRow dr1 = dt.NewRow();
                dr1[0] = "管理控制";
                if (dgv_mgdata2.Rows.Count > 0 && dgv_mgdata1.Rows.Count > 0)
                {
                    dr1[1] = float.Parse(dgv_mgdata1[1, dgv_mgdata1.Rows.Count - 1].Value.ToString());
                    dr1[2] = float.Parse(dgv_mgdata2[1, dgv_mgdata2.Rows.Count - 1].Value.ToString());
                    dr1[3] = float.Parse(dgv_mgdata2[1, dgv_mgdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_mgdata1[1, dgv_mgdata1.Rows.Count - 1].Value.ToString());
                    if (float.Parse(dr1[3].ToString()) == 0f)
                    {
                        dr1[4] = "∞";
                    }
                    else
                    {
                        dr1[4] = ((float.Parse(dgv_mgdata2[1, dgv_mgdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_mgdata1[1, dgv_mgdata1.Rows.Count - 1].Value.ToString())) / float.Parse(dgv_mgdata2[1, dgv_mgdata2.Rows.Count - 1].Value.ToString())).ToString("0.00%");
                    }
                }
                dt.Rows.Add(dr1);

                //电费控制
                DataRow dr2 = dt.NewRow();
                dr2[0] = "电费控制";
                if (dgv_edata2.Rows.Count > 0 && dgv_edata1.Rows.Count > 0)
                {
                    dr2[1] = float.Parse(dgv_edata1[1, dgv_edata1.Rows.Count - 1].Value.ToString());
                    dr2[2] = float.Parse(dgv_edata2[1, dgv_edata2.Rows.Count - 1].Value.ToString());
                    dr2[3] = float.Parse(dgv_edata2[1, dgv_edata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_edata1[1, dgv_edata1.Rows.Count - 1].Value.ToString());
                    if (float.Parse(dr2[3].ToString()) == 0f)
                    {
                        dr2[4] = "∞";
                    }
                    else
                    {
                        dr2[4] = ((float.Parse(dgv_edata2[1, dgv_edata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_edata1[1, dgv_edata1.Rows.Count - 1].Value.ToString())) / float.Parse(dgv_edata2[1, dgv_edata2.Rows.Count - 1].Value.ToString())).ToString("0.00%");
                    }
                }
                dt.Rows.Add(dr2);

                //维修管理
                DataRow dr3 = dt.NewRow();
                dr3[0] = "维修管理";
                if (dgv_mtdata2.Rows.Count > 0 && dgv_mtdata1.Rows.Count > 0)
                {
                    dr3[1] = float.Parse(dgv_mtdata1[1, dgv_mtdata1.Rows.Count - 1].Value.ToString());
                    dr3[2] = float.Parse(dgv_mtdata2[1, dgv_mtdata2.Rows.Count - 1].Value.ToString());
                    dr3[3] = float.Parse(dgv_mtdata2[1, dgv_mtdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_mtdata1[1, dgv_mtdata1.Rows.Count - 1].Value.ToString());
                    if (float.Parse(dr3[3].ToString()) == 0f)
                    {
                        dr3[4] = "∞";
                    }
                    else
                    {
                        dr3[4] = ((float.Parse(dgv_mtdata2[1, dgv_mtdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_mtdata1[1, dgv_mtdata1.Rows.Count - 1].Value.ToString())) / float.Parse(dgv_mtdata2[1, dgv_mtdata2.Rows.Count - 1].Value.ToString())).ToString("0.00%");
                    }
                }
                dt.Rows.Add(dr3);

                //bind datasource
                dgv_totaldata3.DataSource = dt;

                //dgv_rmdata4
                DataTable dt4 = new DataTable();
                dt4.Columns.Add("Year1");
                dt4.Columns.Add("Year2");
                dt4.Columns.Add("sub");
                dt4.Columns.Add("percent");
                for (int i = 0; i < dgv_rmdata1.Rows.Count && i < dgv_rmdata2.Rows.Count; i++)
                {
                    DataRow dr4 = dt4.NewRow();
                    string data1 = dgv_rmdata1[14, i].Value == null ? "0" : dgv_rmdata1[14, i].Value.ToString();
                    string data2 = dgv_rmdata2[14, i].Value == null ? "0" : dgv_rmdata2[14, i].Value.ToString();
                    dr4[0] = float.Parse(data1);
                    dr4[1] = float.Parse(data2);
                    dr4[2] = float.Parse(data2) - float.Parse(data1);
                    if (data2 == "0")
                    {
                        dr4[3] = "∞";
                    }
                    else
                    {
                        dr4[3] = (float.Parse(data2) - float.Parse(data1)) / float.Parse(data2);
                    }
                    dt4.Rows.Add(dr4);
                }
                //2
                DataTable dt22 = new DataTable();
                dt22.Columns.Add("Year1");
                dt22.Columns.Add("Year2");
                dt22.Columns.Add("sub");
                dt22.Columns.Add("percent");
                for (int i = 0; i < dgv_mgdata1.Rows.Count && i < dgv_mgdata2.Rows.Count; i++)
                {
                    DataRow dr4 = dt22.NewRow();
                    string data1 = dgv_mgdata1[13, i].Value == null ? "0" : dgv_mgdata1[13, i].Value.ToString();
                    string data2 = dgv_mgdata2[13, i].Value == null ? "0" : dgv_mgdata2[13, i].Value.ToString();
                    dr4[0] = float.Parse(data1);
                    dr4[1] = float.Parse(data2);
                    dr4[2] = float.Parse(data2) - float.Parse(data1);
                    if (data2 == "0")
                    {
                        dr4[3] = "∞";
                    }
                    else
                    {
                        dr4[3] = (float.Parse(data2) - float.Parse(data1)) / float.Parse(data2);
                    }
                    dt22.Rows.Add(dr4);
                }
                //3
                DataTable dt33 = new DataTable();
                dt33.Columns.Add("Year1");
                dt33.Columns.Add("Year2");
                dt33.Columns.Add("sub");
                dt33.Columns.Add("percent");
                for (int i = 0; i < dgv_edata1.Rows.Count && i<dgv_edata2.Rows.Count; i++)
                {
                    DataRow dr4 = dt33.NewRow();
                    string data1 = dgv_edata1[13, i].Value == null ? "0" : dgv_edata1[13, i].Value.ToString();
                    string data2 = dgv_edata2[13, i].Value == null ? "0" : dgv_edata2[13, i].Value.ToString();
                    dr4[0] = float.Parse(data1);
                    dr4[1] = float.Parse(data2);
                    dr4[2] = float.Parse(data2) - float.Parse(data1);
                    if (data2 == "0")
                    {
                        dr4[3] = "∞";
                    }
                    else
                    {
                        dr4[3] = (float.Parse(data2) - float.Parse(data1)) / float.Parse(data2);
                    }
                    dt33.Rows.Add(dr4);
                }
                //4
                DataTable dt44 = new DataTable();
                dt44.Columns.Add("Year1");
                dt44.Columns.Add("Year2");
                dt44.Columns.Add("sub");
                dt44.Columns.Add("percent");
                for (int i = 0; i < dgv_mtdata1.Rows.Count && i < dgv_mtdata2.Rows.Count; i++)
                {
                    DataRow dr4 = dt44.NewRow();
                    string data1 = dgv_mtdata1[13, i].Value == null ? "0" : dgv_mtdata1[13, i].Value.ToString();
                    string data2 = dgv_mtdata2[13, i].Value == null ? "0" : dgv_mtdata2[13, i].Value.ToString();
                    dr4[0] = float.Parse(data1);
                    dr4[1] = float.Parse(data2);
                    dr4[2] = float.Parse(data2) - float.Parse(data1);
                    if (data2 == "0")
                    {
                        dr4[3] = "∞";
                    }
                    else
                    {
                        dr4[3] = (float.Parse(data2) - float.Parse(data1)) / float.Parse(data2);
                    }
                    dt44.Rows.Add(dr4);
                }
                //bind datasource
                dgv_rmdata3.DataSource = dt4;
                dgv_mgdata3.DataSource = dt22;
                dgv_edata3.DataSource = dt33;
                dgv_mtdata3.DataSource = dt44;
            }
            else
            {
            }
        }

        private void btn_TP1_Click(object sender, EventArgs e)
        {
            Frm_ANAChart M_Chart = new Frm_ANAChart(f1, 1, -1);
            M_Chart.Show();
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetANAData.FNo(comB_Facility.Text);
            comB_CC.Items.Clear();
            CCNo = "";
            string sql = "select CCName from CostCenter where  FNo ='" + FNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_CC.Items.Add(temp.Rows[i]["CCName"].ToString());
            }
        }



        private void comB_report1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype1 = comB_report1.Text;
        }

        private void comB_report2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype2 = comB_report2.Text;
        }

        private void comB_Year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year1 = comB_Year1.Text;
        }

        private void comB_Year2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year2 = comB_Year2.Text;
        }



        private void btn_data1_Click(object sender, EventArgs e)
        {
            Frm_ANAChart M_Chart = new Frm_ANAChart(FDT1, 100, 0);
            M_Chart.Show();
        }

        private void btn_data2_Click(object sender, EventArgs e)
        {
            Frm_ANAChart M_Chart = new Frm_ANAChart(FDT2, 100, 0);
            M_Chart.Show();
        }

        private void btn_tp2_Click(object sender, EventArgs e)
        {
            Frm_ANAChart M_Chart = new Frm_ANAChart(f2, 1, -1);
            M_Chart.Show();
        }

        private void btn_tp3_Click(object sender, EventArgs e)
        {
            Frm_ANAChart M_Chart = new Frm_ANAChart(f3, 1, -1);
            M_Chart.Show();
        }

        private void comB_CC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //原料管理
            CCNo = GetRMData.CCNo(comB_CC.Text);
            clb_Product.Items.Clear();
            PNo = "";
            string sqlrma = " select distinct PName from RMPeriod, Product,CostCenter where CostCenter.CCNo =RMPeriod.CCNo and Product.PNo =RMPeriod.PNo and CCName='" + comB_CC.Text + "' ";
            DataTable temprma = ODbcmd.SelectToDataTable(sqlrma);
            for (int i = 0; i < temprma.Rows.Count; i++)
            {
                clb_Product.Items.Add(temprma.Rows[i]["PName"].ToString());
            }

            //管理控制
            CCNo = GetMGData.CCNo(comB_CC.Text);
            clb_Manage.Items.Clear();
            string sqlm = " select distinct IName from MGPeriod where CCNo='" + CCNo + "'";
            DataTable tempm = ODbcmd.SelectToDataTable(sqlm);
            for (int i = 0; i < tempm.Rows.Count; i++)
            {
                clb_Manage.Items.Add(tempm.Rows[i]["IName"].ToString());
            }

            //电费控制
            CCNo = GetElectricData.CCNo(comB_CC.Text);
            clb_Electric.Items.Clear();
            string sqle = "select distinct TypeName,year from EPeriod where CCNo ='" + CCNo + "'";
            DataTable tempe = ODbcmd.SelectToDataTable(sqle);
            for (int i = 0; i < tempe.Rows.Count; i++)
            {
                clb_Electric.Items.Add(tempe.Rows[i]["TypeName"].ToString());
            }

            //维修管理
            clb_Maintain.Items.Clear();

            CCNo = GetMaintainData.CCNo(comB_CC.Text);

            string sql = " select distinct FSName from FacilitySystem, Equipment where FacilitySystem.FSNo =Equipment.FSNo and CCNo='" + CCNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int j = 0; j < temp.Rows.Count; j++)
            {
                clb_Maintain.Items.Add(temp.Rows[j]["FSName"].ToString());
            }
          
            //load year
            comB_Year1.Items.Clear();
            comB_Year2.Items.Clear();
            Year1 = "";
            Year2 = "";
            string sqly = " select distinct Year from RMPeriod";
            DataTable tempy = ODbcmd.SelectToDataTable(sqly);
            for (int i = 0; i < tempy.Rows.Count; i++)
            {
                comB_Year1.Items.Add(tempy.Rows[i]["Year"].ToString());
                comB_Year2.Items.Add(tempy.Rows[i]["Year"].ToString());
            }
        }

        //private void btn_ExcelOut_Click(object sender, EventArgs e)
        //{
        //    //原料管理
        //    string sql1 = "select Year,Period,FName,CCName,PName,TypeName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMPeriod,Facility,CostCenter,Product where RMPeriod.FNo = Facility.Fno and RMPeriod.CCNo = CostCenter.CCNo and RMPeriod.PNo = Product.PNo";
        //    DataTable dt1 = ODbcmd.SelectToDataTable(sql1);

        //    //管理控制
        //    string sql2 = "select Year,Period,FName,CCName,IName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MGPeriod,Facility,CostCenter where MGPeriod.FNo = Facility.Fno and MGPeriod.CCNo = CostCenter.CCNo";
        //    DataTable dt2 = ODbcmd.SelectToDataTable(sql2);

        //    //电费控制
        //    string sql3 = "select Year,Period,FName,CCName,TypeName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod,Facility,CostCenter where EPeriod.FNo = Facility.Fno and EPeriod.CCNo = CostCenter.CCNo";
        //    DataTable dt3 = ODbcmd.SelectToDataTable(sql3);

        //    //维修管理
        //    string sql4 = "select Year,Period,FName,CCName,FSName,FName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from Facility,CostCenter,MaintianPeriod,FacilitySystem,Equipment where Equipment.FNo = Facility.Fno and Equipment.CCNo = CostCenter.CCNo and  FacilitySystem.FSNo = Equipment.FSNo and MaintianPeriod.EqNo = Equipment.EqNo";
        //    DataTable dt4 = ODbcmd.SelectToDataTable(sql4);


        //    ExcelHelper exhlp = new ExcelHelper();
        //    exhlp.ShowSaveFileDialog();
        //    exhlp.SetTitle("原料管理统计", dt1.Columns.Count - 1);
        //    exhlp.DataTableToExcel(dt1, 2, 0, true);
        //    exhlp.NewSheet();
        //    exhlp.SetTitle("管理控制统计", dt2.Columns.Count - 1);
        //    exhlp.DataTableToExcel(dt2, 2, 0, true);
        //    exhlp.NewSheet();
        //    exhlp.SetTitle("电费控制统计", dt3.Columns.Count - 1);
        //    exhlp.DataTableToExcel(dt3, 2, 0, true);
        //    exhlp.NewSheet();
        //    exhlp.SetTitle("维修管理统计", dt4.Columns.Count - 1);
        //    exhlp.DataTableToExcel(dt4, 2, 0, true);
        //    exhlp.SaveToExcel();
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (getPK1())
        //    {
        //        string[] header = { "工厂", "成本中心", "年份", "报表类型" };
        //        object[] cells = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_report1.Text };
        //        ExcelHelper excelHelp = new ExcelHelper();
        //        excelHelp.ShowSaveFileDialog();
        //        excelHelp.AppendHeader(header);
        //        excelHelp.AppendContent(cells);
        //        DataTable dt = ExcelHelper.GridViewToDataTable(dgv_rmdata1);
        //        excelHelp.AppendToExcel(dt, true);
        //        excelHelp.SaveToExcel();
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (getPK1())
            {
                string Period = comB_report1.Text;
                if (Period == "R")
                {
                    Period = "A12";
                }
                //原料管理
                string sql1 = "select PName,TypeName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMPeriod,Facility,CostCenter,Product where RMPeriod.FNo = Facility.Fno and RMPeriod.CCNo = CostCenter.CCNo and RMPeriod.PNo = Product.PNo" + " and  year=" + comB_Year1.Text + " and  RMPeriod.Period='" + Period + "' and CostCenter.CCName='" + comB_CC.Text + "' order by PName,Type";
                DataTable dt1 = ODbcmd.SelectToDataTable(sql1);

                //管理控制
                string sql2 = "select IName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MGPeriod,Facility,CostCenter where MGPeriod.FNo = Facility.Fno and MGPeriod.CCNo = CostCenter.CCNo" + " and  year=" + comB_Year1.Text + " and  MGPeriod.Period='" + Period + "' and CostCenter.CCName='" + comB_CC.Text + "' order by IName,Type"; ;
                DataTable dt2 = ODbcmd.SelectToDataTable(sql2);

                //电费控制
                string sql3 = "select TypeName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod,Facility,CostCenter where EPeriod.FNo = Facility.Fno and EPeriod.CCNo = CostCenter.CCNo" + " and  year=" + comB_Year1.Text + " and  EPeriod.Period='" + Period + "' and CostCenter.CCName='" + comB_CC.Text + "' order by TypeName,Type"; ;
                DataTable dt3 = ODbcmd.SelectToDataTable(sql3);

                //维修管理
                string sql4 = "select FSName,EqName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from Facility,CostCenter,MaintianPeriod,FacilitySystem,Equipment where Equipment.FNo = Facility.Fno and Equipment.CCNo = CostCenter.CCNo and  FacilitySystem.FSNo = Equipment.FSNo and MaintianPeriod.EqNo = Equipment.EqNo" + " and  year=" + comB_Year1.Text + " and  MaintianPeriod.Period='" + Period + "' and CostCenter.CCName='" + comB_CC.Text + "' order by FSName,EqName,Type"; ;
                DataTable dt4 = ODbcmd.SelectToDataTable(sql4);

                //1
                string[] header = { "工厂", "成本中心", "年份", "报表类型" };
                object[] cells = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_report1.Text };
                ExcelHelper excelHelp = new ExcelHelper();
                if (excelHelp.ShowSaveFileDialog())
                {
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    excelHelp.DataTableToExcelForTotal(dt1, 3, 0, true);

                    //2
                    excelHelp.NewSheet();
                    string[] header2 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells2 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_report1.Text };
                    excelHelp.AppendHeader(header2);
                    excelHelp.AppendContent(cells2);
                    excelHelp.DataTableToExcelForTotal(dt2, 3, 0, true);

                    //3
                    excelHelp.NewSheet();
                    string[] header3 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells3 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_report1.Text };
                    excelHelp.AppendHeader(header3);
                    excelHelp.AppendContent(cells3);
                    excelHelp.DataTableToExcelForTotal(dt3, 3, 0, true);

                    //4
                    excelHelp.NewSheet();
                    string[] header4 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells4 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_report1.Text };
                    excelHelp.AppendHeader(header4);
                    excelHelp.AppendContent(cells4);
                    excelHelp.DataTableToExcelForTotal(dt4, 3, 0, true);

                    excelHelp.SaveToExcel();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (getPK2())
            {
                string Period = comB_report2.Text;
                if (Period == "R")
                {
                    Period = "A12";
                }

                //原料管理
                string sql1 = "select PName,TypeName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMPeriod,Facility,CostCenter,Product where RMPeriod.FNo = Facility.Fno and RMPeriod.CCNo = CostCenter.CCNo and RMPeriod.PNo = Product.PNo" + " and  year=" + comB_Year2.Text + " and  RMPeriod.Period='" + Period + "' and CostCenter.CCName='" + comB_CC.Text + "' order by PName,Type";
                DataTable dt1 = ODbcmd.SelectToDataTable(sql1);

                //管理控制
                string sql2 = "select IName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MGPeriod,Facility,CostCenter where MGPeriod.FNo = Facility.Fno and MGPeriod.CCNo = CostCenter.CCNo" + " and  year=" + comB_Year2.Text + " and  MGPeriod.Period='" + Period + "' and CostCenter.CCName='" + comB_CC.Text + "' order by IName,Type"; ;
                DataTable dt2 = ODbcmd.SelectToDataTable(sql2);

                //电费控制
                string sql3 = "select TypeName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod,Facility,CostCenter where EPeriod.FNo = Facility.Fno and EPeriod.CCNo = CostCenter.CCNo" + " and  year=" + comB_Year2.Text + " and  EPeriod.Period='" + Period + "' and CostCenter.CCName='" + comB_CC.Text + "' order by TypeName,Type"; ;
                DataTable dt3 = ODbcmd.SelectToDataTable(sql3);

                //维修管理
                string sql4 = "select FSName,EqName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from Facility,CostCenter,MaintianPeriod,FacilitySystem,Equipment where Equipment.FNo = Facility.Fno and Equipment.CCNo = CostCenter.CCNo and  FacilitySystem.FSNo = Equipment.FSNo and MaintianPeriod.EqNo = Equipment.EqNo" + " and  year=" + comB_Year2.Text + " and  MaintianPeriod.Period='" + Period + "' and CostCenter.CCName='" + comB_CC.Text + "' order by FSName,EqName,Type"; ;
                DataTable dt4 = ODbcmd.SelectToDataTable(sql4);

                //1
                string[] header = { "工厂", "成本中心", "年份", "报表类型" };
                object[] cells = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), comB_report2.Text };
                ExcelHelper excelHelp = new ExcelHelper();
                if (excelHelp.ShowSaveFileDialog())
                {
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    excelHelp.DataTableToExcelForTotal(dt1, 3, 0, true);

                    //2
                    excelHelp.NewSheet();
                    string[] header2 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells2 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), comB_report2.Text };
                    excelHelp.AppendHeader(header2);
                    excelHelp.AppendContent(cells2);
                    excelHelp.DataTableToExcelForTotal(dt2, 3, 0, true);

                    //3
                    excelHelp.NewSheet();
                    string[] header3 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells3 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), comB_report2.Text };
                    excelHelp.AppendHeader(header3);
                    excelHelp.AppendContent(cells3);
                    excelHelp.DataTableToExcelForTotal(dt3, 3, 0, true);

                    //4
                    excelHelp.NewSheet();
                    string[] header4 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells4 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), comB_report2.Text };
                    excelHelp.AppendHeader(header4);
                    excelHelp.AppendContent(cells4);
                    excelHelp.DataTableToExcelForTotal(dt4, 3, 0, true);

                    excelHelp.SaveToExcel();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (getPK1())
            {
                //1
                string[] header = { "工厂", "成本中心", "年份", "报表类型" };
                object[] cells = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_report1.Text };
                ExcelHelper excelHelp = new ExcelHelper();
                if (excelHelp.ShowSaveFileDialog())
                {
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt = ExcelHelper.GridViewToDataTable(dgv_rmdata1);
                    excelHelp.AppendToExcel(dt, true);

                    //2
                    excelHelp.NewSheet();
                    string[] header2 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells2 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_report1.Text };
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt2 = ExcelHelper.GridViewToDataTable(dgv_mgdata1);
                    excelHelp.AppendToExcel(dt2, true);

                    //3
                    excelHelp.NewSheet();
                    string[] header3 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells3 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_report1.Text };
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt3 = ExcelHelper.GridViewToDataTable(dgv_edata1);
                    excelHelp.AppendToExcel(dt3, true);

                    //4
                    excelHelp.NewSheet();
                    string[] header4 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells4 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_report1.Text };
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt4 = ExcelHelper.GridViewToDataTable(dgv_mtdata1);
                    excelHelp.AppendToExcel(dt4, true);

                    excelHelp.SaveToExcel();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (getPK2())
            {
                //1
                string[] header = { "工厂", "成本中心", "年份", "报表类型" };
                object[] cells = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), comB_report2.Text };
                ExcelHelper excelHelp = new ExcelHelper();
                if (excelHelp.ShowSaveFileDialog())
                {
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt = ExcelHelper.GridViewToDataTable(dgv_rmdata2);
                    excelHelp.AppendToExcel(dt, true);

                    //2
                    excelHelp.NewSheet();
                    string[] header2 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells2 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), comB_report2.Text };
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt2 = ExcelHelper.GridViewToDataTable(dgv_mgdata2);
                    excelHelp.AppendToExcel(dt2, true);

                    //3
                    excelHelp.NewSheet();
                    string[] header3 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells3 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), comB_report2.Text };
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt3 = ExcelHelper.GridViewToDataTable(dgv_edata2);
                    excelHelp.AppendToExcel(dt3, true);

                    //4
                    excelHelp.NewSheet();
                    string[] header4 = { "工厂", "成本中心", "年份", "报表类型" };
                    object[] cells4 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), comB_report2.Text };
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt4 = ExcelHelper.GridViewToDataTable(dgv_mtdata2);
                    excelHelp.AppendToExcel(dt4, true);

                    excelHelp.SaveToExcel();
                }
            }
        }
    }
}
