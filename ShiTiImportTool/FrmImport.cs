﻿using ShiTiImportTool.Entity;
using ShiTiImportTool.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net.Http;

namespace ShiTiImportTool
{
    public partial class FrmImport : Form
    {
        static HttpClient client = new HttpClient();
        public FrmImport()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 导入Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShiTiImport_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "标签|*.xls;*.xlsx";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = ofd.FileName;
            }
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    //a
                    //DataSet dsq = OfficeTools.GetExcelToDataTableBySheet(path);
                    //if (dsq != null)
                    //{ }

                    //a
                    DataTable excelData = NPOIExeclHelper.RenderFromExcel(path);
                    if (excelData != null && excelData.Rows.Count > 0)
                    {
                        bool bRight = ImportCheck(excelData);
                        if (!bRight)
                        {
                            return;
                        }
                        SaveExcelData(excelData);
                    }
                    else
                    {
                        MessageBox.Show("导入的Excel不存在数据行！");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导入的Excel异常," + ex.Message);
                    return;
                }
            }
        }
        private void SaveExcelData(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("导入的行数不能为0");
            }
                List<ShiTiEntity> listShiTiEntity = new List<ShiTiEntity>();
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        ShiTiEntity shiTiEntity = new ShiTiEntity();
                        int shi_yong_deng_ji = 0;
                        string nan_du = string.Empty;
                        int fen_shu = 0;
                        int shi_jian = 0;
                        string bian_hao = string.Empty;
                        string ti_xing = string.Empty;
                        string zheng_wen = string.Empty;
                        string xuan_xiang = string.Empty;
                        string da_an = string.Empty;
                        string zbcsxx = string.Empty;
                        string csmsjj = string.Empty;
                        string ybcsnr = string.Empty;
                        string da_an_jie_xi = string.Empty;
                        string ping_fen_biao_zhun = string.Empty;
                        string chu_chu = string.Empty;
                        string chu_ti_ren = string.Empty;
                        string bei_zhu = string.Empty;
                        string tiao_mu = string.Empty;
                        string fen_ce_ming_cheng = string.Empty;
                        string tiao_kuan = string.Empty;
                        string zhuan_ye = string.Empty;

                        if (dt.Columns.Contains("适用等级"))
                        {
                            shi_yong_deng_ji = dr["适用等级"] == DBNull.Value ? 0 : Convert.ToInt32(dr["适用等级"].ToString() == string.Empty ? "0" : dr["适用等级"].ToString());
                        }
                        if (dt.Columns.Contains("难度"))
                        {
                            nan_du = dr["难度"] == DBNull.Value ? "" : dr["难度"].ToString();
                        }
                        if (dt.Columns.Contains("答题分数"))
                        {
                            fen_shu = dr["答题分数"] == DBNull.Value ? 0 : Convert.ToInt32(dr["答题分数"].ToString() == string.Empty ? "0" : dr["答题分数"].ToString());
                        }
                        if (dt.Columns.Contains("答题时间"))
                        {
                            shi_jian = dr["答题时间"] == DBNull.Value ? 0 : Convert.ToInt32(dr["答题时间"].ToString() == string.Empty ? "0" : dr["答题时间"].ToString());
                        }
                        if (dt.Columns.Contains("试题编号"))
                        {
                            bian_hao = dr["试题编号"] == DBNull.Value ? "" : dr["试题编号"].ToString();
                        }
                        if (dt.Columns.Contains("题型"))
                        {
                            ti_xing = dr["题型"] == DBNull.Value ? "" : dr["题型"].ToString();
                        }
                        if (dt.Columns.Contains("试题正文"))
                        {
                            zheng_wen = dr["试题正文"] == DBNull.Value ? "" : dr["试题正文"].ToString();
                        }
                        if (ti_xing == "判断题")
                        {
                            xuan_xiang = "A:对   B:错";
                            if (dt.Columns.Contains("试题答案"))
                            {
                                string importDaAn = dr["试题答案"] == DBNull.Value ? "" : dr["试题答案"].ToString();
                                if (importDaAn == "A" || importDaAn == "a" || importDaAn == "1" || importDaAn == "对")
                                {
                                    da_an = "A";
                                }
                                else if (importDaAn == "B" || importDaAn == "b" || importDaAn == "0" || importDaAn == "错")
                                {
                                    da_an = "B";
                                }
                            }
                        }
                        else
                        {
                            if (dt.Columns.Contains("试题选项"))
                            {
                                xuan_xiang = dr["试题选项"] == DBNull.Value ? "" : dr["试题选项"].ToString();
                            }

                            if (dt.Columns.Contains("试题答案"))
                            {
                                da_an = dr["试题答案"] == DBNull.Value ? "" : dr["试题答案"].ToString();
                            }
                        }
                        if (dt.Columns.Contains("自变参数选项"))
                        {
                            zbcsxx = dr["自变参数选项"] == DBNull.Value ? "" : dr["自变参数选项"].ToString();
                        }
                        if (dt.Columns.Contains("参数M数据集"))
                        {
                            csmsjj = dr["参数M数据集"] == DBNull.Value ? "" : dr["参数M数据集"].ToString();
                        }
                        if (dt.Columns.Contains("应变参数内容"))
                        {
                            ybcsnr = dr["应变参数内容"] == DBNull.Value ? "" : dr["应变参数内容"].ToString();
                        }

                        if (dt.Columns.Contains("答案解析"))
                        {
                            da_an_jie_xi = dr["答案解析"] == DBNull.Value ? "" : dr["答案解析"].ToString();
                        }
                        if (dt.Columns.Contains("答案要点及评分标准"))
                        {
                            ping_fen_biao_zhun = dr["答案要点及评分标准"] == DBNull.Value ? "" : dr["答案要点及评分标准"].ToString();
                        }
                        if (dt.Columns.Contains("依据 出处"))
                        {
                            chu_chu = dr["依据 出处"] == DBNull.Value ? "" : dr["依据 出处"].ToString();
                        }
                        if (dt.Columns.Contains("出题人"))
                        {
                            chu_ti_ren = dr["出题人"] == DBNull.Value ? "" : dr["出题人"].ToString();
                        }

                        if (dt.Columns.Contains("备注"))
                        {
                            bei_zhu = dr["备注"] == DBNull.Value ? "" : dr["备注"].ToString();
                        }
                        if (dt.Columns.Contains("条目"))
                        {
                            tiao_mu = dr["条目"] == DBNull.Value ? "" : dr["条目"].ToString();
                        }
                        if (dt.Columns.Contains("分册名称"))
                        {
                            fen_ce_ming_cheng = dr["分册名称"] == DBNull.Value ? "" : dr["分册名称"].ToString();
                        }
                        if (dt.Columns.Contains("条款"))
                        {
                            tiao_kuan = dr["条款"] == DBNull.Value ? "" : dr["条款"].ToString();
                        }

                        if (dt.Columns.Contains("专业"))
                        {
                            zhuan_ye = dr["专业"] == DBNull.Value ? "" : dr["专业"].ToString();
                        }
                        shiTiEntity.shiYongDengJi = shi_yong_deng_ji;
                        shiTiEntity.nanDu = nan_du;
                        shiTiEntity.fenShu = fen_shu;
                        shiTiEntity.shiJian = shi_jian;

                        shiTiEntity.bianHao = bian_hao;
                        shiTiEntity.tiXing = ti_xing;
                        shiTiEntity.zhengWen = zheng_wen;
                        shiTiEntity.xuanXiang = xuan_xiang;

                        shiTiEntity.daAn = da_an;
                        shiTiEntity.zbcsxx = zbcsxx;
                        shiTiEntity.csmsjj = csmsjj;
                        shiTiEntity.ybcsnr = ybcsnr;

                        shiTiEntity.daAnJieXi = da_an_jie_xi;
                        shiTiEntity.pingFenBiaoZhun = ping_fen_biao_zhun;
                        shiTiEntity.chuChu = chu_chu;
                        shiTiEntity.chuTiRen = chu_ti_ren;

                        shiTiEntity.beiZhu = bei_zhu;
                        shiTiEntity.tiaoMu = tiao_mu;
                        shiTiEntity.fenCeMingCheng = fen_ce_ming_cheng;
                        shiTiEntity.tiaoKuan = tiao_kuan;

                        shiTiEntity.zhuanYe = zhuan_ye;
                        listShiTiEntity.Add(shiTiEntity);
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show("数据导入异常，" + a.Message);
                        break;
                    }
                }
                ShiJuanEntity shiJuanEntity = new ShiJuanEntity();
                shiJuanEntity.shiJuanName = "a" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
                shiJuanEntity.cT = DateTime.Now;
                shiJuanEntity.uT = DateTime.Now;
                shiJuanEntity.shiTis = listShiTiEntity;
                string jsonPar = JsonHelper.ToJson(shiJuanEntity);
                string urlPart = "ShiJuan/AddShiJuanAndShiTis";
                string realUrl = ConfigHelper.ConfigHelper.GetApiRootUrl() + urlPart;
                doAddShiJuanAndShiTi(realUrl, jsonPar);
        }

        private async void doAddShiJuanAndShiTi(string strUrl, string strJsonPar)
        {
            try
            {
                var stringContent = new StringContent(strJsonPar, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(strUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    string strJsonRtn = response.Content.ReadAsStringAsync().Result;
                    if (strJsonRtn.ToLower() == "true")
                    {
                        MessageBox.Show("导入试卷成功");
                    }
                    else
                    {
                        MessageBox.Show("导入试卷失败");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Post添加试卷失败，调用WebApi出错了");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Post添加试卷异常，" + ex.Message);
            }
        }

        /// <summary>
        /// 导入的Excel进行校验
        /// </summary>
        /// <param name="dt"></param>
        private bool ImportCheck(DataTable dt)
        {
            if (dt == null)
            {
                MessageBox.Show("Excel 数据读取错误！");
                return false;
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Excel 中没有读取到数据！");
                return false;
            }

            if (dt.Columns.Count != 21)
            {
                MessageBox.Show("Excel 模板列不正确！");
                return false;
            }

            /*
             * 商品编码	
             * 商品名称	
             * 规格	
             * 采购数量
             */

            //克隆结构
            bool status;
            //List<string> skuList = new List<string>();
            DataTable ErrorDataTable = dt.Clone();
            int errorCount = 0;     //失败行数
            int successCount = 0;   //成功行数
            foreach (DataRow row in dt.Rows)
            {
                DataRow rowDetail = row;// ErrorDataTable.NewRow();

                //去掉重复项
                status = true;
                string strTiXing = row[5].ToString().Trim(); //题型
                string strZhengWen = row[6].ToString().Trim(); //正文
                string strXuanXiang = row[7].ToString().Trim(); //试题选项
                string strDaAn = row[8].ToString().Trim(); //试题答案
                if (strTiXing.Length == 0)
                {
                    rowDetail[5] = "@?@必填";
                    status = false;
                }
                if (strZhengWen.Length == 0)
                {
                    rowDetail[6] = "@?@必填";
                    status = false;
                }
                if (strXuanXiang.Length == 0)
                {
                    rowDetail[7] = "@?@必填";
                    status = false;
                }
                if (strDaAn.Length == 0)
                {
                    rowDetail[8] = "@?@必填";
                    status = false;
                }
                if (status == false)
                {
                    errorCount++;
                    ErrorDataTable.Rows.Add(rowDetail.ItemArray);
                }
                else
                {
                    successCount++;
                    ErrorDataTable.Rows.Add(rowDetail.ItemArray);
                }
            }

            //如果有失败的打开失败的Excel
            if (errorCount > 0)
            {
                MessageBox.Show("有" + errorCount + "条记录未通过格式检查,请修改后重写导入！");

                try
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string templatePath = Path.Combine(path, "ErrorFile");
                    if (!Directory.Exists(templatePath))
                        Directory.CreateDirectory(templatePath);

                    string errorPath = templatePath + "\\导入试题错误信息" + String.Format("{0:yyyyMMdd}.xls", DateTime.Now);
                    if (File.Exists(errorPath))
                        File.Delete(errorPath);

                    NPOIExeclHelper.ExportExcelFileContainCss(ErrorDataTable, "错误的试题", errorPath);

                    try
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = errorPath;
                        process.StartInfo.Verb = "Open";
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        process.Start();
                        return false;
                    }
                    catch
                    {
                        MessageBox.Show("找不到此文件类型的默认打开！");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导入试题库错误信息处理失败！" + ex.Message);
                    return false;
                }
            }
            return true;
        }

        private void btnDownloadExcel_Click(object sender, EventArgs e)
        {
            DownloadExcel("题库导入模板.xls");
        }
        /// <summary>
        /// 下载Excel
        /// </summary>
        /// <param name="template"></param>
        private void DownloadExcel(string template)
        {
            if (string.IsNullOrEmpty(template))
            {
                MessageBox.Show("未设置模版，请联系开发人员！");
                return;
            }

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string templatePath = Path.Combine(path, "ImportTemplate");
            var p = Directory.GetFiles(templatePath, template + ".*");
            if (p.Count() > 0)
            {
                SaveFileDialog savefileDialog = new SaveFileDialog();

                savefileDialog.FileName = Path.GetFileName(p[0]);
                savefileDialog.DefaultExt = Path.GetExtension(savefileDialog.FileName);
                string filter = "Excel 文件(*." + savefileDialog.DefaultExt + ")|*." + savefileDialog.DefaultExt + "";

                savefileDialog.Filter = filter;//"Excel 文件(*.xls)|*.xls|Excel 文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";

                if (savefileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filename = savefileDialog.FileName;
                        FileInfo fs = new FileInfo(p[0]);
                        fs.CopyTo(filename, true);

                        //打开Excel
                        OpenFile(filename);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存模版出错！" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("未找到所需的模版，请联系开发人员！");
            }
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="fileName"></param>
        private void OpenFile(string fileName)
        {
            if (MessageBox.Show("要打开获取的Excel文件吗？", "导出到...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    MessageBox.Show("找不到此文件类型的默认打开！");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = ConfigHelper.ConfigHelper.GetApiRootUrl()+"ShiJuan / GetAllEnableShiJuan";
                IDictionary<string, string> dicPar = new Dictionary<string, string>();
                dicPar.Add("a", "1");

                String strJsonRtn = HttpPostHelper.CreatePostHttpResponseByDic(url, dicPar, System.Text.Encoding.UTF8);
                List<ShiJuanEntity> listShiJuan= JsonHelper.FromJson<List<ShiJuanEntity>>(strJsonRtn);
                    
                int a = 3;
            }catch(Exception ex)
            {
                int a = 3;
            }
        }

        private void btnShiJuanManage_Click(object sender, EventArgs e)
        {
            try
            {
                FrmShiJuanManager frmShiJuanManager = new FrmShiJuanManager();
                frmShiJuanManager.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show("打开试卷管理窗口异常，"+ex.Message);
            }
        }
    }
}
