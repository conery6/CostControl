using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System .Data ;
using System.Windows.Forms;

namespace CostControl.RawMaterial
{
    class GetRMData
    {

        public static DataTable Actual(String FNo, String CCNo, String PNo ,String Year)
        {
            string sql = "select TypeName, Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMActual  where year=" + Year
            + " and FNo='" + FNo + "' and CCNo='" + CCNo + "' and PNo ='" + PNo + "' order by Type asc";
            DataTable a = ODbcmd.SelectToDataTable(sql);
            return a;
        }

        public static DataTable Period(String FNo, String CCNo, String Year, string PNo ,String Period)
        {
            if (Period != "Actual")
            {

                string sql = "select TypeName, Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMPeriod  where year=" + Year
                + " and FNo='" + FNo + "' and CCNo='" + CCNo + "' and PNo='" + PNo + "' and   Period = '" + Period + "' order by Type asc";
                DataTable a = ODbcmd.SelectToDataTable(sql);
                return a;
            }
            else
            {
                DataTable a = Actual(FNo, CCNo, PNo, Year);
                return a;  
            }
        }



        public static DataTable MiddleBudget(String FNo, String CCNo, String PNo, String Year, int month)
        {
            DataTable b = new DataTable();
            string sql = "";

            switch (month)
            {
                case 1:
                case 2:
                case 3:
                    sql = "select TypeName, Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMPeriod  where year=" + Year
                        + " and FNo='" + FNo + "'  and CCNo='" + CCNo + "' and  PNo = '" + PNo + "' and Period='T1' order by Type asc";
                    b = ODbcmd.SelectToDataTable(sql);
                    break;
                case 4:
                case 5:
                case 6:
                    sql = "select TypeName, Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMPeriod  where year=" + Year
                        + " and FNo='" + FNo + "'  and CCNo='" + CCNo + "'  and  PNo = '" + PNo + "' and  Period='RF1' order by Type asc";
                    b = ODbcmd.SelectToDataTable(sql);
                    break;
                case 7:
                case 8:
                case 9:
                    sql = "select TypeName, Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMPeriod  where year=" + Year
                        + " and FNo='" + FNo + "'  and CCNo='" + CCNo + "'  and  PNo = '" + PNo + "' and  Period='RF2' order by Type asc";
                    b = ODbcmd.SelectToDataTable(sql);
                    break;
                case 10:
                case 11:
                case 12:
                    sql = "select TypeName, Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMPeriod  where year=" + Year
                        + " and FNo='" + FNo + "'  and CCNo='" + CCNo + "'  and  PNo = '" + PNo + "' and  Period='E3' order by Type asc";
                    b = ODbcmd.SelectToDataTable(sql);
                    break;
            }
            if (b.Rows.Count == 0)
            {
                MessageBox.Show("数据库内缺少数据");
                return b;
            }

            DataTable a = Actual(FNo, CCNo, PNo, Year);

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


        public static  DataTable Budget(String CostCenterNo, String ProductNo, String Year)
        {
            string sql = "select Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMBudget  "
            + "where  year=" + Year + " and PNo='" + ProductNo + "' and CCNo='" + CostCenterNo  + "'";
            DataTable a = ODbcmd.SelectToDataTable(sql);
            return a;
        }


        //public static DataTable MiddleBudget(String CostCenterNo, String ProductNo, String Year, int month)
        //{
        //    string sql = "select Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMBudget "
        //    + "where  year=" + Year + " and PNo='" + ProductNo + "' and CCNo='" + CostCenterNo + "'";
        //    DataTable b = ODbcmd.SelectToDataTable(sql);

        //    sql = "select Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMActual "
        //    + "where  year=" + Year + " and PNo='" + ProductNo + "' and CCNo='" + CostCenterNo + "'";
        //    DataTable a = ODbcmd.SelectToDataTable(sql);

        //    DataTable r = a.Clone();
        //    for (int i = 0; i < a.Rows.Count; i++)
        //    {
        //        DataRow dr = r.NewRow();
        //        for (int j = 0; j <= month; j++)
        //        {
        //            dr[j] = a.Rows[i][j];
        //        }
        //        for (int j = month + 1; j < r.Columns.Count; j++)
        //        {
        //            dr[j] = b.Rows[i][j];
        //        }
        //        r.Rows.Add(dr);
        //    }

        //    return r;
        //}


        public static string FNo(string Facility)
        {
            string sql = "select FNo from Facility where FName='" + Facility + "'";
            DataTable dt = ODbcmd.SelectToDataTable(sql);
            return dt.Rows[0][0].ToString();
        }

        public static string PNo(string Product)
        {
            string sql = "select PNo from Product where PName='" + Product + "'";
            DataTable dt = ODbcmd.SelectToDataTable(sql);
            return dt.Rows[0][0].ToString();
        }

        public static string CCNo(string CostCenter)
        {
            string sql = "select CCNo from CostCenter where CCName='" + CostCenter + "'";
            DataTable dt = ODbcmd.SelectToDataTable(sql);
            return dt.Rows[0][0].ToString();
        }

        public static float[,] FReportTable1(float[,] FDT1, float[,] FDT2)
        {
            float[,] a = new float[5, 13];
            for (int j = 1; j < 13; j++)
            {
                a[0, j] = j + 1;
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        a[i, j] = (FDT2[i, j] - FDT1[i, j]) / FDT1[i, j];
                    }
                    catch
                    { }
                }
            }
            return a;
        }



        public static float[,] FReportTable2(float[,] FDT1, float[,] FDT2)
        {
            float[,] a = new float[5, 13];

            float[] ave = new float[5];
            int k;

            for (int i = 0; i < 5; i++)
            {
                ave[i] = 0; k = 0;
                for (int j = 1; j < 13; j++)
                {
                    try
                    {
                        ave[i] = ave[i] + FDT1[i, j];
                        k += 1;
                    }
                    catch { };
                }
                ave[i] = ave[i] / k;
            }

            for (int j = 1; j < 13; j++)
            {
                a[0, j] = j + 1;
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        a[i, j] = (FDT2[i, j] - ave[i]) / ave[i];
                    }
                    catch
                    { }
                }
            }
            return a;
        }


        public static float[,] DTto2DFloat(DataTable DT)
        {
            float[,] a = new float[6, 13];

            for (int i = 0; i <= DT.Columns.Count; i++)
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

        public static float[,] FReportTable3(float [,] FDT1, float[,] FDT2)
        {
            float[,] a = new float[5, 13];
            float[,] FDT1SUM = new float[5, 13];
            float[,] FDT2SUM = new float[5, 13];


            float sumdt1 = 0;
            float sumdt2 = 0;
            for (int j = 1; j < 13; j++)
            {
                try
                {
                    sumdt1 += FDT1[0, j];
                    FDT1SUM[0, j] = sumdt1;
                }
                catch { }
                try
                {
                    sumdt2 += FDT2[0, j];
                    FDT2SUM[0, j] = sumdt2;
                }
                catch { };
            }


            sumdt1 = 0;
            sumdt2 = 0;
            int k1 = 1; int k2 = 1;
            for (int j = 1; j < 13; j++)
            {
                try
                {
                    sumdt1 += FDT1[1, j];
                    FDT1SUM[1, j] = sumdt1/k1;
                    k1++;
                }
                catch { }
                try
                {
                    sumdt2 += FDT2[1, j];
                    FDT2SUM[1, j] = sumdt2/k2;
                    k2++;
                }
                catch { };
            }


            for (int i = 2; i < 4; i++)
            {
                sumdt1 = 0;
                sumdt2 = 0;
                for (int j = 1; j < 13; j++)
                {
                    try
                    {
                        sumdt1 += FDT1[i,j];
                        FDT1SUM  [i,j] = sumdt1;
                    }
                    catch { }
                    try
                    {
                        sumdt2 += FDT2[i, j];
                        FDT2SUM[i,j] = sumdt2;
                    }
                    catch { };
                }
            }

            for (int j = 1; j < 13; j++)
            {
                try
                {
                    FDT1SUM[4, j] = FDT1SUM[2, j]/FDT1SUM[3, j];
                }
                catch { }
                try
                {
                    FDT2SUM[4, j] = FDT2SUM[2, j] / FDT2SUM[3, j];
                }
                catch { };
            }

            //两表比较
            for (int j = 1; j < 13; j++)
            {
                //a[0, j] = j + 1;
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        a[i, j] = (FDT2SUM[i, j] - FDT1SUM[i, j]) / FDT1SUM[i, j];
                    }
                    catch
                    { }
                }
            }
            return a;
        }


    }
}
