using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;
using SapflowApplication.Helpers;
using SapflowApplication.Models;

namespace SapflowApplication
{
    static class Program
    {
        static async Task<List<UserCompanyResponse>> GetCompanySites(string accessToken)
        {
            //토큰 검증
            try
            {
                var response = await ApiPaths.BaseUrl
                    .AppendPathSegment(ApiPaths.GetCompanySites)
                    .AppendPathSegment(accessToken)
                    //.AllowHttpStatus("4xx")
                    .GetJsonAsync<List<UserCompanyResponse>>();

                return response;
            }
            catch (FlurlHttpException ex) when (ex.Call.HttpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                MessageBox.Show("invalid token");
                return null;
            }
            catch (FlurlHttpException ex) when (ex.Call.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                var error = await ex.GetResponseJsonAsync<BaseException>();
                var description = JsonConvert.DeserializeObject<Dictionary<string, string>>(error.Description);
                MessageBox.Show($"{error.Message} (id: {description["Id"]})");
                return null;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var accessToken = AppConfiguration.GetAppConfig("accessToken");

            DialogResult result;
            if (string.IsNullOrEmpty(accessToken))
            {
                bool loggedIn;
                using (var login = new frmLogin())
                {
                    loggedIn = login.ShowDialog() == DialogResult.OK;
                }

                if (!loggedIn)
                {
                    return;
                }
            }

            var task = Task.Run<List<UserCompanyResponse>>(async () => await GetCompanySites(accessToken));

            if (task.Result == null) return;

            //현재는 하나의 유저가 하나의 company만 가지고 있는것으로 가정
            var companySites = task.Result.First();
            Global.CompanyId = companySites.CompanyId;
            Global.SiteIds = companySites.SiteIds;
            Run();            
        }

        static void Run()
        {
            try
            {
                Application.Run(new SF_Test());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}