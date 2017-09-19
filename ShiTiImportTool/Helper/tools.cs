using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using System.IO;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ShiTiImportTool.Helper
{
    public class OfficeTools
    {

        public static DataSet GetExcelToDataTableBySheet(string FileFullPath, string SheetName = null)
        {
            //获取文件扩展名
            string strExtension = System.IO.Path.GetExtension(FileFullPath);
            string strFileName = System.IO.Path.GetFileName(FileFullPath);
            OleDbConnection conn = null;
            switch (strExtension)
            {
                case ".xls":
                    conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileFullPath + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"");
                    break;
                case ".xlsx":
                    conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileFullPath + ";" + "Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1;\"");
                    break;
                default:
                    conn = null;
                    break;
            }
            if (conn == null)
            {
                return null;
            }

            conn.Open();
            DataSet ds = new DataSet();
            if (SheetName == null)
            {
                List<string> sheetNames = new List<string>();
                System.Data.DataTable sheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "table" });
                foreach (DataRow var in sheetName.Rows)
                {
                    OleDbDataAdapter odda = new OleDbDataAdapter(string.Format("SELECT  * FROM [{0}]", var[2].ToString()), conn);
                    DataSet dsItem = new DataSet();
                    try
                    {
                        odda.Fill(dsItem, var[2].ToString());
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt = dsItem.Tables[0].Copy();
                        ds.Tables.Add(dt);


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                System.Data.DataTable sheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "table" });
                OleDbDataAdapter odda = new OleDbDataAdapter(string.Format("SELECT  * FROM [{0}]", SheetName), conn);  //("select  * from [Sheet1$]", conn);
                odda.Fill(ds.Tables[ds.Tables.Count], SheetName);
            }
            conn.Close();
            conn.Dispose();
            return ds;
        }
    }
    public class TXTRead
    {
        public static Dictionary<int, string> ReadByPathGetTitle(string path)
        {
            Dictionary<int, string> str = new Dictionary<int, string>();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line = sr.ReadLine();
            sr.Close();
            sr.Dispose();
            //[head,-,time]邮箱-密码
            if (line.Contains("[head,"))
            {
                string sa = line.Split(']')[1];
                //var lies = sa.Split('');
            }
            return str;
        }
        public static string[] ReadByPath(string path)
        {
             
            string[] strs = File.ReadAllLines(path, Encoding.Default);
            return strs;
        }
    }
}
