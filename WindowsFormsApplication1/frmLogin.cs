using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ReaLTaiizor.Forms;
using Flurl;
using Flurl.Http;
using SapflowApplication.Models;
using System.Net;
using SapflowApplication.Helpers;
using Newtonsoft.Json;
using System.Configuration;

namespace SapflowApplication
{
    public partial class frmLogin : MaterialForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //public string ID
        //{
        //    get
        //    {
        //        return (txbID.Text);
        //    }
        //}

        //public string Password
        //{
        //    get
        //    {
        //        return (txbPassword.Text);
        //    }
        //}

        private async void btnOK_Click(object sender, EventArgs e)
        {
            AuthenticationResponse response;
            try
            {
                response = await ApiPaths.BaseUrl
                    .AppendPathSegment(ApiPaths.Authenticate)
                    .PostJsonAsync(new AuthenticationQuery
                    {
                        Id = txbID.Text.Trim(),
                        Password = txbPassword.Text.Trim()
                    }).ReceiveJson<AuthenticationResponse>();

                AppConfiguration.SetAppConfig("accessToken", response.Token);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (FlurlHttpException ex) when (ex.Call.HttpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                MessageBox.Show("invalid token");
            }
            catch (FlurlHttpException ex) when (ex.Call.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                var error = await ex.GetResponseJsonAsync<BaseException>();
                var description = JsonConvert.DeserializeObject<Dictionary<string, string>>(error.Description);
                MessageBox.Show($"{error.Message} (id: {description["Id"]})");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //if (ID == "real")
            //{
            //    if(Password=="real")
            //    {
            //        Debug.WriteLine("118");
            //    }
            //    string passwd ="";

            //    bool fgPasswordMatched = true;
            //    if (Password.Length >= 6)
            //    {
            //        for (int i = 0; i < 6; i++)
            //        {
            //            if (Password.Substring(i, 1) != (i + 1).ToString())
            //            {
            //                fgPasswordMatched = false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        fgPasswordMatched = false;
            //    }

            //    if (fgPasswordMatched)
            //    {
            //        SF_Test.fgActivateFactorySetup = true;
            //    }
            //    if (Password == "address")
            //    {
            //        Debug.WriteLine("08826");
            //    }

            //}

            try
            {
                this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txbID.Select();
        }

        private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '\r')
            //{
            //    if (txbPassword.Text != "")
            //    {
            //        try
            //        {
            //            btnOK_Click(sender, e);
            //        }
            //        catch (Exception ex) { Debug.WriteLine(ex.Message.ToString()); }
            //    }
            //}

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            //AuthenticationResponse response;
            //try
            //{
            //    response = await ApiPaths.BaseUrl
            //        .AppendPathSegment(ApiPaths.Authenticate)
            //        .PostJsonAsync(new AuthenticationQuery
            //        {
            //            Id = txbID.Text.Trim(),
            //            Password = txbPassword.Text.Trim()
            //        }).ReceiveJson<AuthenticationResponse>();

            //    AppConfiguration.SetAppConfig("accessToken", response.Token);
            //    //ConfigurationManager.RefreshSection("appSettings");
            //}
            //catch (FlurlHttpException ex) when (ex.Call.HttpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            //{
            //    MessageBox.Show("invalid token");
            //}
            //catch (FlurlHttpException ex) when (ex.Call.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            //{
            //    var error = await ex.GetResponseJsonAsync<BaseException>();
            //    var description = JsonConvert.DeserializeObject<Dictionary<string, string>>(error.Description);
            //    MessageBox.Show($"{error.Message} (id: {description["Id"]})");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            this.DialogResult = DialogResult.OK;
        }
    }
}
