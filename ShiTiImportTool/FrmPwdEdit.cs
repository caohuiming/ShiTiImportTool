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
    public partial class FrmPwdEdit : Form
    {
        static HttpClient client = new HttpClient();
        public int UserId { get; set; }//用户编号
        string urlPart = "UserInfo/UpdateUser"; 
        public FrmPwdEdit()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string strOldPwd = txtOldPwd.Text.Trim();
                string strNewPwd = txtNewPwd.Text.Trim();
                string strConfrmNewPwd = txtConfirmNewPwd.Text.Trim();
                if (strOldPwd == string.Empty)
                {
                    MessageBox.Show("请输入旧密码");
                    txtOldPwd.Focus();
                    return;
                }
                if (strNewPwd == string.Empty)
                {
                    MessageBox.Show("请输入新密码");
                    txtNewPwd.Focus();
                    return;
                }
                if ( strNewPwd != strConfrmNewPwd )
                {
                    MessageBox.Show("两次输入的新密码不一致");
                    txtConfirmNewPwd.Focus();
                    return;
                }
                string strEOldPwd = DES.Encrypt3DES(strOldPwd);
                string strENewPwd = DES.Encrypt3DES(strNewPwd);
                MyUserEntity myUserEntity = new MyUserEntity();
                myUserEntity.userId = UserId;
                myUserEntity.userPwd = strEOldPwd;
                myUserEntity.userPwdNew = strENewPwd;
                string jsonPar = JsonHelper.ToJson(myUserEntity);
                string realUrl = ConfigHelper.ConfigHelper.GetApiRootUrl() + urlPart;
                doEdit(realUrl, jsonPar);
            }
            catch(Exception ex)
            {
                MessageBox.Show("修改密码异常,"+ex.Message);
            }
        }

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
                    if (returnResultEntity.success)
                    {
                        MessageBox.Show("修改密码成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(returnResultEntity.errorMsg);
                    }
                }
                else
                {
                    MessageBox.Show("Post修改密码失败，调用WebApi出错了");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Post修改密码异常，" + ex.Message);
            }
        }
    }
}
