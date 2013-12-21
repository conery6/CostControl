using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CostControl.Electric
{
    public partial class Frm_ETable : Form
    {
        string FNo;
        string CCNo;
        string Year1;
        string Year2;
        string Reporttype1;
        string Reporttype2;


        public Frm_ETable()
        {
            InitializeComponent();
        }

        private void Frm_ETable_Load(object sender, EventArgs e)
        {
            
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetElectricData.FNo(comB_Facility.Text);
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
            CCNo = GetElectricData.CCNo(comB_CC.Text);
            clb_CCItem.Items.Clear();
            string sql = "select distinct Item,year from EBudget where CCNo ='" + CCNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                clb_CCItem.Items.Add(temp.Rows[i]["Item"].ToString());
            }

            comB_Year1.Items.Clear();
            comB_Year2.Items.Clear();

            string sql1 = "select distinct Year from EBudget where CCNo ='" + CCNo + "'";
            DataTable tmp2 = ODbcmd.SelectToDataTable(sql1);
            for (int i = 0; i < tmp2.Rows.Count; i++)
            {
                comB_Year1.Items.Add(temp.Rows[i]["Year"].ToString());
                comB_Year2.Items.Add(temp.Rows[i]["Year"].ToString());

            }
        }

        private void btn_addalll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clb_CCItem.Items.Count; i++)
            {
                clb_CCItem.SetItemChecked(i, true);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clb_CCItem.Items.Count; i++)
            {
                clb_CCItem.SetItemChecked(i, false);
            }
        }

        private void comB_Year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year2 = comB_Year1.Text;
        }

        private void comB_Year2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year2 = comB_Year2.Text;
        }

        private void comB_RpType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype1 = comB_RpType1.Text;
        }

        private void comB_RpType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype2 = comB_RpType2.Text;
        }


    }
}
