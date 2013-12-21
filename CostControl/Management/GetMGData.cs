using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System .Data ;
using System.Windows.Forms;

namespace CostControl.Management
{
    class GetMGData
    {
        public static DataTable Budget(String FacilityNo, String CostCenterNo, String Year)
        {
            string sql = "select IName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MGBudget  "
            + "where  Year= " + Year + " and FNo='" + FacilityNo + "' and CCNo='" + CostCenterNo + "'";
            DataTable a = ODbcmd.SelectToDataTable(sql);
            return a;
        }

        public static DataTable Actual(String FacilityNo, String CostCenterNo, String Year)
        {
            string sql = "select IName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MGActual  "
            + "where  Year= " + Year + " and FNo='" + FacilityNo + "' and CCNo='" + CostCenterNo + "'";
            DataTable a = ODbcmd.SelectToDataTable(sql);
            return a;
        }


        public static DataTable MiddleBudget(String FacilityNo, String CostCenterNo, String Year, int month)
        {
            string sql = "select IName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MGBudget "
            + "where  Year= " + Year + " and FNo='" + FacilityNo + "' and CCNo='" + CostCenterNo + "'";
            DataTable b = ODbcmd.SelectToDataTable(sql);

            sql = "select IName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MGActual "
            + "where  Year= " + Year + " and FNo='" + FacilityNo + "' and CCNo='" + CostCenterNo + "'";
            DataTable a = ODbcmd.SelectToDataTable(sql);

            DataTable r = a.Clone();
            for (int i = 0; i < a.Rows.Count; i++)
            {
                DataRow dr = r.NewRow();
                for (int j = 0; j <= month; j++)
                {
                    dr[j] = a.Rows[i][j];
                }
                for (int j = month + 1; j < r.Columns.Count; j++)
                {
                    dr[j] = b.Rows[i][j];
                }
                r.Rows.Add(dr);
            }

            return r;
        }


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

        public static float[,] DTto2DFloat(DataTable DT)
        {
            float[,] a = new float[DT .Rows .Count , 12 ];

            for (int i = 1; i < DT.Columns.Count; i++)
            {
                for (int j = 0; j < DT.Rows.Count; j++)
                {
                    try
                    {
                        a[j, i-1] = Convert.ToSingle(DT.Rows[j][i]);
                    }
                    catch { };
                }
            }

            return a;
        }
    }

}
