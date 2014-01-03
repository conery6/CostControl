using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace CostControl.Analysis
{
    class GetANAData
    {
        public static DataSet PeriodData(String CostCenterNo, String period, String Year)
        {
            string sql1 = "select  PName,TypeName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMPeriod,Product,CostCenter where CostCenter.CCNo =RMPeriod.CCNo and Product.PNo =RMPeriod.PNo  "
            + "and  year=" + Year + " and  RMPeriod.Type=" + 1 + " and  RMPeriod.Period='" + period + "' and CostCenter.CCNo='" + CostCenterNo + "'";
            DataTable d1 = ODbcmd.SelectToDataTable(sql1);

            string sql2 = "select  IName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MGPeriod,CostCenter where CostCenter.CCNo = MGPeriod.CCNo"
+ " and  year=" + Year + " and MGPeriod.Period='" + period + "' and CostCenter.CCNo='" + CostCenterNo + "'";
            DataTable d2 = ODbcmd.SelectToDataTable(sql2);

            string sql3 = "select  TypeName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod,CostCenter where CostCenter.CCNo = EPeriod.CCNo"
            + " and  year=" + Year + " and EPeriod.Period='" + period + "' and EPeriod.TypeName in ('Total Power cost 总电费','总电费')" + " and CostCenter.CCNo='" + CostCenterNo + "'";
            DataTable d3 = ODbcmd.SelectToDataTable(sql3);

            string sql4 = "select  FSName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MaintianPeriod,FacilitySystem, Equipment,CostCenter where CostCenter.CCNo = Equipment.CCNo and FacilitySystem.FSNo = Equipment.FSNo and MaintianPeriod.EqNo = Equipment.EqNo"
            + " and  year=" + Year + " and MaintianPeriod.Period='" + period + "' and CostCenter.CCNo='" + CostCenterNo + "'";
            DataTable d4 = ODbcmd.SelectToDataTable(sql4);

            DataSet ds = new DataSet();
            ds.Tables.Add(d1);
            ds.Tables.Add(d2);
            ds.Tables.Add(d3);
            ds.Tables.Add(d4);
            return ds;
        }

        public static DataSet Actual(String CostCenterNo, String period, String Year)
        {
            string sql1 = "select  PName,TypeName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from RMActual,Product,CostCenter where CostCenter.CCNo =RMActual.CCNo and Product.PNo =RMActual.PNo  "
            + "and  year=" + Year + "and  RMActual.Type='" + 1 + "' and CostCenter.CCNo='" + CostCenterNo + "'";
            DataTable d1 = ODbcmd.SelectToDataTable(sql1);

            string sql2 = "select  IName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MGActual,CostCenter where CostCenter.CCNo = MGActual.CCNo"
+ " and  year=" + Year + " and CostCenter.CCNo='" + CostCenterNo + "'";
            DataTable d2 = ODbcmd.SelectToDataTable(sql2);

            string sql3 = "select  TypeName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EActual,CostCenter where CostCenter.CCNo = EActual.CCNo"
            + " and  year=" + Year + " and EActual.TypeName in ('Total Power cost 总电费','总电费')" + " and CostCenter.CCNo='" + CostCenterNo + "'";
            DataTable d3 = ODbcmd.SelectToDataTable(sql3);

            string sql4 = "select  FSName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from MaintianActual,FacilitySystem, Equipment,CostCenter where CostCenter.CCNo = Equipment.CCNo and FacilitySystem.FSNo = Equipment.FSNo and MaintianActual.EqNo = Equipment.EqNo"
            + " and  year=" + Year + " and CostCenter.CCNo='" + CostCenterNo + "'";
            DataTable d4 = ODbcmd.SelectToDataTable(sql4);

            DataSet ds = new DataSet();
            ds.Tables.Add(d1);
            ds.Tables.Add(d2);
            ds.Tables.Add(d3);
            ds.Tables.Add(d4);
            return ds;
        }

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

        //Difference comparison
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


        //Average difference comparison
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

        //Sum difference comparison
        public static float[,] FReportTable3(float[,] FDT1, float[,] FDT2)
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
                    FDT1SUM[1, j] = sumdt1 / k1;
                    k1++;
                }
                catch { }
                try
                {
                    sumdt2 += FDT2[1, j];
                    FDT2SUM[1, j] = sumdt2 / k2;
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
                        sumdt1 += FDT1[i, j];
                        FDT1SUM[i, j] = sumdt1;
                    }
                    catch { }
                    try
                    {
                        sumdt2 += FDT2[i, j];
                        FDT2SUM[i, j] = sumdt2;
                    }
                    catch { };
                }
            }

            for (int j = 1; j < 13; j++)
            {
                try
                {
                    FDT1SUM[4, j] = FDT1SUM[2, j] / FDT1SUM[3, j];
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
