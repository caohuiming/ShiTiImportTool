using ShiTiImportTool.Entity;
using ShiTiImportTool.Entity.Result;
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
    public partial class FrmShiJuanEdit : Form
    {
        public int CurrentShiJuanId { get; set; }//接收传递过来的试卷编号
        public string CurrentShiJuanName { get; set; }//接收传递过来的试卷名称

        string urlPart_Update = "ShiJuanNew/UpdateShiJuan";
        static HttpClient client = new HttpClient();
        public FrmShiJuanEdit()
        {
            InitializeComponent();
            //req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
        }

        private void FrmShiJuanEdit_Load(object sender, EventArgs e)
        {
            try
            {
                txtShiJuanName.Text = CurrentShiJuanName;
            }
            catch(Exception ex)
            {
                MessageBox.Show("加载修改试卷异常," + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string strShiJuanName = txtShiJuanName.Text.Trim();
                if (strShiJuanName == string.Empty)
                {
                    MessageBox.Show("试卷名称不能为空！");
                    txtShiJuanName.Focus();
                    return;
                }
                string realUrl = ConfigHelper.ConfigHelper.GetApiRootUrl() + urlPart_Update;
                ShiJuanEntity shiJuanEntity = new ShiJuanEntity();
                shiJuanEntity.id = CurrentShiJuanId;
                shiJuanEntity.shiJuanName = strShiJuanName;
                string jsonPar = JsonHelper.ToJson(shiJuanEntity);
                doEdit(realUrl, jsonPar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改试卷异常," + ex.Message);
            }
        }

        #region 异步post
        private async void doEdit(string strUrl, string strJsonPar)
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
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("修改试卷失败," + returnResultEntity.errorMsg);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Post修改试卷失败，调用WebApi出错了");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改试卷异常，" + ex.Message);
            }
        }
        #endregion 异步post

        private void FrmShiJuanEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                FrmShiJuanManager frmShiJuanManager = null;
                frmShiJuanManager = (FrmShiJuanManager)this.Owner;
                frmShiJuanManager.doBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("关闭试卷修改窗台异常，" + ex.Message);
            }
        }
    }
}
