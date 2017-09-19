using ShiTiImportTool.Entity;
using ShiTiImportTool.Entity.Result;
using ShiTiImportTool.Entity.ShiTi;
using ShiTiImportTool.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiTiImportTool
{
    public partial class FrmShiTiManager : Form
    {
        public int CurrentShiJuanId { get; set; }//接收传递过来的试卷编号
        public string CurrentShiJuanName { get; set;}//接收传递过来的试卷名称
        static HttpClient client = new HttpClient();
        int nPageSize = 20;
        int nPageIndex = 0;
        int nPageCount = 0;
        string urlPart_SearchTiXing = "ShiTi/GetAllTiXing";
        string urlPart_Search = "ShiTi/GetEnableShiTiByCondition";
        string urlPart_Delete = "ShiTi/DeleteShiTi";
        public FrmShiTiManager()
        {
            InitializeComponent();
        }

        private void FrmShiTiManager_Load(object sender, EventArgs e)
        {
            //DataGridView不能选择
            this.dgvShiTi.RowHeadersVisible = false;

            //DataGridView 去除未绑定的字段
            this.dgvShiTi.AutoGenerateColumns = false;
            try
            {
                lblShiJuanName.Text = CurrentShiJuanName;
                ShiTiSearchEntity shiTiSearchEntity = new ShiTiSearchEntity();
                shiTiSearchEntity.shiJuanId = CurrentShiJuanId;
                string jsonPar = JsonHelper.ToJson(shiTiSearchEntity);
                string realUrl = ConfigHelper.ConfigHelper.GetApiRootUrl() + urlPart_SearchTiXing;
                doSearchTiXing(realUrl, jsonPar);

                btnSearch_Click(sender,e);
            }
            catch(Exception ex)
            {
                MessageBox.Show("加载试题窗体异常," + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            binSearch();
        }

        #region 查询方法
        private void binSearch()
        {
            try
            {
                nPageIndex = 0;
                string tiXing = cmbTiXing.SelectedValue != null ? cmbTiXing.SelectedValue.ToString() : string.Empty;
                string zhengWen = txtZhengWen.Text.Trim();
                ShiTiSearchEntity shiTiSearchEntity = new ShiTiSearchEntity();
                shiTiSearchEntity.pageIndex = nPageIndex;
                shiTiSearchEntity.pageSize = nPageSize;
                shiTiSearchEntity.shiJuanId = CurrentShiJuanId;
                if (tiXing != string.Empty && tiXing != "全部")
                {
                    shiTiSearchEntity.tiXing = tiXing;
                }
                if (zhengWen != string.Empty)
                {
                    shiTiSearchEntity.zhengWen = zhengWen;
                }
                string jsonPar = JsonHelper.ToJson(shiTiSearchEntity);
                string realUrl = ConfigHelper.ConfigHelper.GetApiRootUrl() + urlPart_Search;
                doSearch(realUrl, jsonPar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询试题异常," + ex.Message);
            }
        }

        private async void doSearchTiXing(string strUrl, string strJsonPar)
        {
            try
            {
                List<TiXingEntity> listTiXing = new List<TiXingEntity>();
                var stringContent = new StringContent(strJsonPar, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(strUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    string strJsonRtn = response.Content.ReadAsStringAsync().Result;
                    ReturnResultEntity<List<TiXingEntity>> returnResultEntity = JsonHelper.FromJson<ReturnResultEntity<List<TiXingEntity>>>(strJsonRtn);
                    if (returnResultEntity != null)
                    {
                        if (returnResultEntity.success)
                        {
                            listTiXing = returnResultEntity.data;
                        }
                        else
                        {
                            MessageBox.Show("查询失败," + returnResultEntity.errorMsg);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Post查询全部题型失败，调用WebApi出错了");
                }
                TiXingEntity tiXingRoot = new TiXingEntity();
                tiXingRoot.tiXingName = "全部";
                tiXingRoot.tiXingValue = "全部";

                listTiXing.Insert(0, tiXingRoot);
                cmbTiXing.DataSource = listTiXing;
                cmbTiXing.DisplayMember = "tiXingName";
                cmbTiXing.ValueMember = "tiXingValue";
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询全部题型异常，" + ex.Message);
            }
        }
        private async void doSearch(string strUrl, string strJsonPar)
        {
            try
            {
                List<ShiTiEntity> listShiTi = new List<ShiTiEntity>();
                int nRowCount = 0;
                var stringContent = new StringContent(strJsonPar, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(strUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    string strJsonRtn = response.Content.ReadAsStringAsync().Result;
                    //List < ShiJuanEntity > listShiJuan
                    ReturnResultEntity<PageResultEntity<ShiTiEntity>> returnResultEntity = JsonHelper.FromJson<ReturnResultEntity<PageResultEntity<ShiTiEntity>>>(strJsonRtn);
                    if (returnResultEntity != null)
                    {
                        if (returnResultEntity.success)
                        {
                            PageResultEntity<ShiTiEntity> pageResultEntity = returnResultEntity.data;
                            listShiTi = pageResultEntity.dataList;
                            nRowCount = pageResultEntity.rowCount;
                        }
                        else
                        {
                            MessageBox.Show("查询失败," + returnResultEntity.errorMsg);
                        }

                    }
                    #region 初始化
                    dgvShiTi.DataSource = null;
                    lblAllPageNum.Text = "共0页";
                    lblRowNums.Text = "0道试题";
                    txtCurrentPage.Text = "1";
                    #endregion 初始化


                    dgvShiTi.DataSource = listShiTi.ToArray();
                    nPageCount = (nRowCount + (nPageSize - 1)) / nPageSize;
                    lblAllPageNum.Text = "共" + nPageCount.ToString() + "页";
                    lblRowNums.Text = nRowCount.ToString() + "道试题";
                    txtCurrentPage.Text = (nPageIndex + 1).ToString();
                }
                else
                {
                    MessageBox.Show("Post查询全部试题失败，调用WebApi出错了");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询全部试题异常，" + ex.Message);
            }
        }
        private async void doDelete(string strUrl, string strJsonPar)
        {
            try
            {
                var stringContent = new StringContent(strJsonPar, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(strUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    string strJsonRtn = response.Content.ReadAsStringAsync().Result;
                    ReturnResultEntity<object> returnResultEntity = JsonHelper.FromJson<ReturnResultEntity<object>>(strJsonRtn);
                    if (returnResultEntity != null)
                    {
                        if (returnResultEntity.success)
                        {
                            #region 重新查询
                            binSearch();
                            #endregion 重新查询
                        }
                        else
                        {
                            MessageBox.Show("删除试卷失败," + returnResultEntity.errorMsg);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Post删除试卷失败，调用WebApi出错了");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除试卷异常，" + ex.Message);
            }
        }
        #endregion 查询


        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                if (nPageIndex == 0)
                {
                    MessageBox.Show("已经是第一页了");
                    return;
                }
                nPageIndex = nPageIndex - 1;
                string tiXing = cmbTiXing.SelectedValue != null ? cmbTiXing.SelectedValue.ToString() : string.Empty;
                string zhengWen = txtZhengWen.Text.Trim();
                ShiTiSearchEntity shiTiSearchEntity = new ShiTiSearchEntity();
                shiTiSearchEntity.pageIndex = nPageIndex;
                shiTiSearchEntity.pageSize = nPageSize;
                shiTiSearchEntity.shiJuanId = CurrentShiJuanId;
                if (tiXing != string.Empty && tiXing != "全部")
                {
                    shiTiSearchEntity.tiXing = tiXing;
                }
                if (zhengWen != string.Empty)
                {
                    shiTiSearchEntity.zhengWen = zhengWen;
                }
                string jsonPar = JsonHelper.ToJson(shiTiSearchEntity);
                string realUrl = ConfigHelper.ConfigHelper.GetApiRootUrl() + urlPart_Search;
                doSearch(realUrl, jsonPar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询前一页失败," + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if ((nPageIndex + 1) >= nPageCount)
                {
                    MessageBox.Show("已经是最后一页了");
                    return;
                }
                nPageIndex = nPageIndex + 1;
                string tiXing = cmbTiXing.SelectedValue != null ? cmbTiXing.SelectedValue.ToString() : string.Empty;
                string zhengWen = txtZhengWen.Text.Trim();
                ShiTiSearchEntity shiTiSearchEntity = new ShiTiSearchEntity();
                shiTiSearchEntity.pageIndex = nPageIndex;
                shiTiSearchEntity.pageSize = nPageSize;
                shiTiSearchEntity.shiJuanId = CurrentShiJuanId;
                if (tiXing != string.Empty && tiXing != "全部")
                {
                    shiTiSearchEntity.tiXing = tiXing;
                }
                if (zhengWen != string.Empty)
                {
                    shiTiSearchEntity.zhengWen = zhengWen;
                }
                string jsonPar = JsonHelper.ToJson(shiTiSearchEntity);
                string realUrl = ConfigHelper.ConfigHelper.GetApiRootUrl() + urlPart_Search;
                doSearch(realUrl, jsonPar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询后一页失败," + ex.Message);
            }
        }


        private void txtCurrentPage_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string strCurrentPage = txtCurrentPage.Text.Trim();
                    int nCurrentPage = 0;
                    if (!int.TryParse(strCurrentPage, out nCurrentPage))
                    {
                        return;
                    }
                    if ((nCurrentPage - 1) < 0)
                    {
                        return;
                    }
                    if (nCurrentPage > nPageCount)
                    {
                        return;
                    }
                    nPageIndex = nCurrentPage - 1;
                    string tiXing = cmbTiXing.SelectedValue != null ? cmbTiXing.SelectedValue.ToString() : string.Empty;
                    string zhengWen = txtZhengWen.Text.Trim();
                    ShiTiSearchEntity shiTiSearchEntity = new ShiTiSearchEntity();
                    shiTiSearchEntity.pageIndex = nPageIndex;
                    shiTiSearchEntity.pageSize = nPageSize;
                    shiTiSearchEntity.shiJuanId = CurrentShiJuanId;
                    if (tiXing != string.Empty && tiXing != "全部")
                    {
                        shiTiSearchEntity.tiXing = tiXing;
                    }
                    if (zhengWen != string.Empty)
                    {
                        shiTiSearchEntity.zhengWen = zhengWen;
                    }
                    string jsonPar = JsonHelper.ToJson(shiTiSearchEntity);
                    string realUrl = ConfigHelper.ConfigHelper.GetApiRootUrl() + urlPart_Search;
                    doSearch(realUrl, jsonPar);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("试题导航异常，" + ex.Message);
            }
        }

        private void dgvShiTi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int shiTiId = Convert.ToInt32(this.dgvShiTi.CurrentRow.Cells["id"].Value);
                string action = dgvShiTi.Columns[e.ColumnIndex].Name;//操作类型

                switch (action)
                {
                    case "delete":
                        if (MessageBox.Show("确定删除吗?", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            string realUrl = ConfigHelper.ConfigHelper.GetApiRootUrl() + urlPart_Delete;
                            ShiTiSearchEntity shiTiSearchEntity = new ShiTiSearchEntity();
                            shiTiSearchEntity.shiTiId = shiTiId;
                            string jsonPar = JsonHelper.ToJson(shiTiSearchEntity);
                            doDelete(realUrl, jsonPar);
                        }
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("点击异常，" + ex.Message);
            }
        }
    }
}
