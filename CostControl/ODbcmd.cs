using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CostControl
{
    class ODbcmd
    {
        public static OleDbConnection Conn;
		public static string connStr = Properties.Settings.Default.RMCostControlConnectionString1;
        //public static string Dbpath = "D:\\成本控制软件\\RMCostControl.mdb";//数据库地址

        static ODbcmd ()
        {
            Conn = new OleDbConnection(connStr);
        }

        /// <summary>
        /// 打开数据源链接
        /// </summary>
        /// <returns></returns>
        public static OleDbConnection DBConn()
        {
            Conn.Open();
            return Conn;
        }

        #region 数据库基本操作
        /// <summary>
        /// 根据SQL命令返回数据DataTable数据表,
        /// 可直接作为dataGridView的数据源
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static DataTable SelectToDataTable(string SQL)
        {
            OleDbConnection Conn = DBConn();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            DataTable Dt = new DataTable();
            adapter.Fill(Dt);
            Conn.Close();
            return Dt;
        }

        /// <summary>
        /// 根据SQL命令返回数据DataSet数据集，其中的表可直接作为dataGridView的数据源。
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="subtableName">在返回的数据集中所添加的表的名称</param>
        /// <returns></returns>
        public static DataSet SelectToDataSet(string SQL, string subtableName)
        {
            OleDbConnection Conn = DBConn();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            DataSet Ds = new DataSet();
            Ds.Tables.Add(subtableName);
            adapter.Fill(Ds, subtableName);
            Conn.Close();
            return Ds;
        }

        /// <summary>
        /// 在指定的数据集中添加带有指定名称的表，由于存在覆盖已有名称表的危险，返回操作之前的数据集。
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="subtableName">添加的表名</param>
        /// <param name="DataSetName">被添加的数据集名</param>
        /// <returns></returns>
        public static DataSet SelectToDataSet(string SQL, string subtableName, DataSet DataSetName)
        {
            OleDbConnection Conn = DBConn();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            DataTable Dt = new DataTable();
            DataSet Ds = new DataSet();
            Ds = DataSetName;
            adapter.Fill(DataSetName, subtableName);
            Conn.Close();
            return Ds;
        }

        /// <summary>
        /// 根据SQL命令返回OleDbDataAdapter，
        /// 使用前请在主程序中添加命名空间System.Data.OleDb
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static OleDbDataAdapter SelectToOleDbDataAdapter(string SQL)
        {
            OleDbConnection Conn = DBConn();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            Conn.Close();
            return adapter;
        }

        /// <summary>
        /// 执行SQL命令，不需要返回数据的修改，删除可以使用本函数
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static bool ExecuteSQLNonquery(string SQL)
        {
            OleDbConnection Conn = DBConn();
            OleDbCommand cmd = new OleDbCommand(SQL, Conn);
            try
            {
                cmd.ExecuteNonQuery();
                Conn.Close();
                return true;
            }
            catch
            {
                Conn.Close();
                return false;
            }
            
        }
        #endregion


    }
}
