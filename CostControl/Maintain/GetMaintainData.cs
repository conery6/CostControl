using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CostControl.Maintain
{
    class GetMaintainData
    {
        public static DataTable Budget(String FNo, String FSNo, String Year , String CCNo)
        {
            string sql = "select EqName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MaintianPeriod,Equipment where MaintianPeriod.EqNo=Equipment.EqNo and year=" + Year
            + " and FNo='" + FNo  + "' and FSNo='" + FSNo  + "' and CCNo='"+ CCNo +"'";
            DataTable a = ODbcmd.SelectToDataTable(sql);
            return a;
        }

        public static DataTable Actual_FIN(String FNo, String FSNo, String Year, String CCNo)
        {
            string sql = "select EqName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MaintianFin,Equipment where MaintianFin.EqNo=Equipment.EqNo and year=" + Year
            + " and FNo='" + FNo + "' and FSNo='" + FSNo + "' and CCNo='" + CCNo + "'";
            DataTable a = ODbcmd.SelectToDataTable(sql);
            return a;
        }

        public static DataTable Actual_ACE(String FNo, String FSNo, String Year, String CCNo)
        {
            string sql = "select EqName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MaintianActual,Equipment where MaintianActual.EqNo=Equipment.EqNo and year=" + Year
            + " and FNo='" + FNo + "' and FSNo='" + FSNo + "' and CCNo='" + CCNo + "'";
            DataTable a = ODbcmd.SelectToDataTable(sql);
            return a;
        }

        public static DataTable Withhold(String FNo, String FSNo, String Year, String CCNo)
        {
            string sql = "select EqName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MaintianWithhold,Equipment where MaintianWithhold.EqNo=Equipment.EqNo and year=" + Year
            + " and FNo='" + FNo + "' and FSNo='" + FSNo + "' and CCNo='" + CCNo + "'";
            DataTable a = ODbcmd.SelectToDataTable(sql);
            return a;
        }

        public static DataTable newBudget(String FNo, String FSNo, String CCNo)
        {
            string sql = "select EqName from Equipment where FNo='" + FNo + "' and FSNo='" + FSNo + "' and CCNo='" + CCNo + "'";
            DataTable b = ODbcmd.SelectToDataTable(sql);
            return b;
        }

        public static DataTable MiddleBudget(String FNo, String FSNo, String CCNo, String Year, int month)
        {
            string sql = "select EqName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MaintianPeriod,Equipment where MaintianPeriod.EqNo=Equipment.EqNo and year=" + Year
            + " and FNo='" + FNo + "' and FSNo='" + FSNo + "' and CCNo='" + CCNo + "'";
            DataTable b = ODbcmd.SelectToDataTable(sql);

            sql = "select EqName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MaintianFin,Equipment where MaintianFin.EqNo=Equipment.EqNo and year=" + Year
            + " and FNo='" + FNo + "' and FSNo='" + FSNo + "' and CCNo='" + CCNo + "'";
            DataTable a = ODbcmd.SelectToDataTable(sql);

            DataTable r = a.Clone();
            for (int i = 0; i < a.Rows.Count; i++)
            {
                DataRow dr = r.NewRow();
                for (int j = 0; j <= month+1; j++)
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

        public static string FNo(string Facility)
        {
            string sql = "select FNo from Facility where FName='" + Facility + "'";
            DataTable dt = ODbcmd.SelectToDataTable(sql);
            return dt.Rows[0][0].ToString();
        }

        public static string FSNo(string FSName)
        {
            string sql = "select FSNo from FacilitySystem where FSName='" + FSName  + "'";
            DataTable dt = ODbcmd.SelectToDataTable(sql);
            return dt.Rows[0][0].ToString();
        }

        public static string CCNo(string CostCenter)
        {
            string sql = "select CCNo from CostCenter where CCName='" + CostCenter + "'";
            DataTable dt = ODbcmd.SelectToDataTable(sql);
            return dt.Rows[0][0].ToString();
        }

        public static string EqNo(string EqName)
        {
            string sql = "select EqNo from Equipment where EqName='" + EqName + "'";
            DataTable dt = ODbcmd.SelectToDataTable(sql);
            return dt.Rows[0][0].ToString();
        }

        public static float[,] DTto2DFloat(DataTable DT)
        {
            float[,] a = new float[DT.Rows.Count, DT.Columns.Count-2];

            for (int i = 2; i <= DT.Columns.Count; i++)
            {
                for (int j = 0; j <= DT.Rows.Count; j++)
                {
                    try
                    {
                        a[j, i] = Convert.ToSingle(DT.Rows[j][i]);
                    }
                    catch { };
                }
            }

            return a;
        }

        public static float sumdt(DataTable DT)
        {
            float sum =0;

            for (int i = 2; i <= DT.Columns.Count; i++)
            {
                for (int j = 0; j <= DT.Rows.Count; j++)
                {
                    try
                    {
                        sum =sum + Convert.ToSingle(DT.Rows[j][i]);

                    }
                    catch { };
                }
            }

            return sum;
        }


        public static DataTable sumall(DataTable dt,string FSName)
        {
            DataTable final = new DataTable ();
            final =dt.Clone ();

            List<float > spa = new List<float >();

            float sumspa=0;
            for (int i =2; i < dt.Columns .Count  ; i++)
            {
                float sum = 0;
                for (int j = 0; j < dt.Rows .Count ; j+=2)
                {
                    try
                    {
                        sum += Convert.ToSingle(dt.Rows[j][i]);
                    }
                    catch { }
                }
                spa .Add (sum );
                sumspa += sum;
            }

            List<float> sub = new List<float>();

            float sumsub = 0;
            for (int i = 2; i < dt.Columns.Count; i ++)
            {
                float sum = 0;
                for (int j = 1; j < dt.Rows.Count; j+=2)
                {
                    try
                    {
                        sum += Convert.ToSingle(dt.Rows[j][i]);
                    }
                    catch { }
                }
                sub.Add(sum);
                sumsub += sum;
            }

            final.Columns.Add("sum");
            final .Rows .Add (FSName ,"spa",spa[0],spa[1],spa[2],spa[3],spa[4],spa[5],spa[6],spa[7],spa[8],spa[9],spa[10],spa[11],sumspa );
            final.Rows.Add(FSName, "sub", sub[0], sub[1], sub[2], sub[3], sub[4], sub[5], sub[6], sub[7], sub[8], sub[9], sub[10], sub[11],sumsub );
            final .Rows .Add (FSName ,"sum",spa[0]+sub[0],spa[1]+sub[1],spa[2]+sub[2],spa[3]+sub[3],spa[4]+sub[4],
                spa[5]+sub[5],spa[6]+sub[6],spa[7]+sub[7],spa[8]+sub[8],spa[9]+sub[9],spa[10]+sub[10],spa[11]+sub[11],sumspa +sumsub );

            
            return final;
        }

    }
}
