using Newtonsoft.Json;
using ShiTiImportTool.Entity;
using ShiTiImportTool.Entity.Result;
using ShiTiImportTool.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiTiImportTool
{
    public partial class FrmLogin : Form
    {
        static HttpClient client = new HttpClient();
        string urlPart = "UserInfo/Login";
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string strUserName = txtUserName.Text.Trim();
                string strPwd = txtPwd.Text.Trim();
                if (strUserName == string.Empty)
                {
                    MessageBox.Show("用户名不能为空！");
                    return;
                }
                if (strPwd == string.Empty)
                {
                    MessageBox.Show("密码不能为空！");
                    return;
                }

                string strEpwd = DES.Encrypt3DES(strPwd);
                MyUserEntity myUser = new MyUserEntity();
                myUser.userName = strUserName;
                myUser.userPwd = strEpwd;
                string jsonPar = JsonHelper.ToJson(myUser);
                
                string realUrl = ConfigHelper.ConfigHelper.GetApiRootUrl() + urlPart;
                doLogin(realUrl, jsonPar);
            }catch(Exception ex)
            {
                MessageBox.Show("登录失败，" + ex.Message);
            }
        }
        private async void doLogin(string strUrl,string strJsonPar)
        {
            try
            {
                var stringContent = new StringContent(strJsonPar, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(strUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    string strJsonRtn = response.Content.ReadAsStringAsync().Result;
                    ReturnResultEntity<MyUserEntity> returnResultEntity = JsonHelper.FromJson<ReturnResultEntity<MyUserEntity>>(strJsonRtn);
                    if (returnResultEntity.success)
                    {
                        MyUserEntity myUserEntity = returnResultEntity.data;
                        if (myUserEntity != null)
                        {
                            FrmShiJuanManager frmShiJuanManager = new FrmShiJuanManager();
                            frmShiJuanManager.UserId = myUserEntity.userId;
                            frmShiJuanManager.UserName = myUserEntity.userName;
                            frmShiJuanManager.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码不正确");
                    }
                }
                else
                {
                    MessageBox.Show("Post登录失败，调用WebApi出错了");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Post登录异常，" +ex.Message);
            }
        }
    }
}
