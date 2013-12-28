using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CostControl
{
	//using namespace CostControl.RawMaterial;
	public partial class Frm_main : Form
	{
		public String Eno;
		public Frm_main(string Eno)
		{
			InitializeComponent();
			this.Eno = Eno;
		}

		private void MenuItem_RMData_Click(object sender, EventArgs e)
		{
			RawMaterial.Frm_RMData frm_RMD = new RawMaterial.Frm_RMData(Eno);
			frm_RMD.MdiParent = this;
			frm_RMD.Show();
		}

		private void Frm_main_Load(object sender, EventArgs e)
		{

		}

		private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void MenuItem_RMAnlys_Click(object sender, EventArgs e)
		{
			RawMaterial.Frm_RMTable Frm_RMT = new RawMaterial.Frm_RMTable(Eno);
			Frm_RMT.MdiParent = this;
			Frm_RMT.Show();
		}

		private void MenuItem_MBudget_Click(object sender, EventArgs e)
		{
			Maintain.Frm_MData Frm_MD = new Maintain.Frm_MData();
			Frm_MD.MdiParent = this;
			Frm_MD.Show();
		}

		private void MenuItem_MAnlys_Click(object sender, EventArgs e)
		{
			Maintain.Frm_MTable Frm_MT = new Maintain.Frm_MTable();
			Frm_MT.MdiParent = this;
			Frm_MT.Show();
		}

		private void MenuItem_MNBudget_Click(object sender, EventArgs e)
		{
			Management.Frm_MGData Frm_MG = new Management.Frm_MGData();
			Frm_MG.MdiParent = this;
			Frm_MG.Show();
		}

		private void MenuItem_MNAnlys_Click(object sender, EventArgs e)
		{
			Management.Frm_MGTable Frm_MGT = new Management.Frm_MGTable();
			Frm_MGT.MdiParent = this;
			Frm_MGT.Show();
		}

		private void MenuItem_MActual_Click(object sender, EventArgs e)
		{
			Maintain.Frm_MActual m_Frm_MActual = new Maintain.Frm_MActual("ACE");
			m_Frm_MActual.Show();
		}

		private void MenuItem_MAcnt_Click(object sender, EventArgs e)
		{
			Maintain.Frm_MActual m_Frm_MActual = new Maintain.Frm_MActual("FIN");
			m_Frm_MActual.Show();
		}


		private void MenuItem_EBudget_Click(object sender, EventArgs e)
		{
			Electric.Frm_EData m_Frm_EData = new Electric.Frm_EData();
			m_Frm_EData.Show();
		}

		private void MenuItem_EActual_Click(object sender, EventArgs e)
		{
			Electric.Frm_EActual m_Frm_EActual = new Electric.Frm_EActual();
			m_Frm_EActual.Show();
		}

		private void 电费分析ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Electric.Frm_ETable m_Frm_ETable = new Electric.Frm_ETable();
			m_Frm_ETable.Show();
		}

		private void MenuItem_RMActual_Click(object sender, EventArgs e)
		{
			RawMaterial.Frm_RMActual Frm_RMA = new RawMaterial.Frm_RMActual();
			Frm_RMA.MdiParent = this;
			Frm_RMA.Show();
		}

		private void MenuItem_MNActual_Click(object sender, EventArgs e)
		{
			Management.Frm_MGActual Frm_MGA = new Management.Frm_MGActual();
			Frm_MGA.MdiParent = this;
			Frm_MGA.Show();
		}

        private void MenuItem_Analy_Click(object sender, EventArgs e)
        {
            Analysis.Frm_ANATable Frm_RMT = new Analysis.Frm_ANATable(Eno);
            Frm_RMT.MdiParent = this;
            Frm_RMT.Show();
        }

        private void Frm_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
	}
}
