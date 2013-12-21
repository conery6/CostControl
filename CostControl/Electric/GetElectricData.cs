using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace CostControl.Electric
{
    class GetElectricData
    {
        public static string FNo(string Facility)
        {
            string sql = "select FNo from Facility where FName='" + Facility + "'";
            DataTable dt = ODbcmd.SelectToDataTable(sql);
            return dt.Rows[0][0].ToString();
        }

        public static string CCNo(string CostCenter)
        {
            string sql = "select CCNo from CostCenter where CCName='" + CostCenter + "'";
            DataTable dt = ODbcmd.SelectToDataTable(sql);
            return dt.Rows[0][0].ToString();
        }

        public static DataTable Budget(String FNo, String Year, String CCNo)
        {
            string sql = "select Itemnum, Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EBudget  where year=" + Year
            + " and FNo='" + FNo + "' and CCNo='" + CCNo + "' order by Itemnum asc";
            DataTable a = ODbcmd.SelectToDataTable(sql);
            return a;
        }

        public static DataTable Actual(String FNo, String Year, String CCNo)
        {
            string sql = "select Itemnum, Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EActual  where year=" + Year
            + " and FNo='" + FNo + "' and CCNo='" + CCNo + "' order by Itemnum asc";
            DataTable a = ODbcmd.SelectToDataTable(sql);
            return a;
        }

        public static DataTable Period(String FNo, String Year, String CCNo, String Period)
        {
            if (Period != "Actual")
            {

                string sql = "select Itemnum, Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod  where year=" + Year
                + " and FNo='" + FNo + "' and CCNo='" + CCNo + "' and Period = '" + Period + "' order by Itemnum asc";
                DataTable a = ODbcmd.SelectToDataTable(sql);
                return a;
            }
            else
            {
                string sql = "select Itemnum, Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EActual  where year=" + Year
                + " and FNo='" + FNo + "' and CCNo='" + CCNo + "' order by Itemnum asc";
                DataTable a = ODbcmd.SelectToDataTable(sql);
                return a;
            }
        }

        public static DataTable MiddleBudget(String FNo, String CCNo, String Year, int month)
        {
            DataTable b = new DataTable();
            string sql = "";
            switch (month)
            {
                case 1 :case 2:case 3:
                    sql = "select Itemnum, Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod  where year=" + Year
                        + " and FNo='" + FNo + "'  and CCNo='" + CCNo + "' and Period='T1' order by Itemnum asc";
                    b = ODbcmd.SelectToDataTable(sql);
                    break;
                case 4:case 5:case 6:
                    sql = "select Itemnum, Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod  where year=" + Year
                        + " and FNo='" + FNo + "'  and CCNo='" + CCNo + "' and Period='RF1' order by Itemnum asc";
                    b = ODbcmd.SelectToDataTable(sql);
                    break;
                case 7:case 8:case 9:
                    sql = "select Itemnum, Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod  where year=" + Year
                        + " and FNo='" + FNo + "'  and CCNo='" + CCNo + "' and Period='RF2' order by Itemnum asc";
                    b = ODbcmd.SelectToDataTable(sql);
                    break;
                case 10:case 11:case 12:
                    sql = "select Itemnum, Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod  where year=" + Year
                        + " and FNo='" + FNo + "'  and CCNo='" + CCNo + "' and Period='E3' order by Itemnum asc";
                    b = ODbcmd.SelectToDataTable(sql);
                    break;
            }
            if (b.Rows.Count == 0)
            {
                MessageBox.Show("数据库内不存在数据");
                return b;
            }

            sql = "select  Itemnum, Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EActual  where year=" + Year
            + " and FNo='" + FNo + "'  and CCNo='" + CCNo + "' order by Itemnum asc";
            DataTable a = ODbcmd.SelectToDataTable(sql);

            DataTable r = a.Clone();
            for (int i = 0; i < a.Rows.Count; i++)
            {
                DataRow dr = r.NewRow();
                for (int j = 0; j <= month + 1; j++)
                {
                    dr[j] = a.Rows[i][j];
                }
                for (int j = month + 2; j < r.Columns.Count; j++)
                {
                    dr[j] = b.Rows[i][j];
                }
                r.Rows.Add(dr);
            }

            return r;
        }


    }
}
