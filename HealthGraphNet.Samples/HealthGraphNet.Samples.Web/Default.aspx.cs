using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using HealthGraphNet;
using HealthGraphNet.Models;

namespace HealthGraphNet.Samples.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        #region Fields and Properties

        public string ClientId 
        { 
            get 
            {
                return ConfigurationManager.AppSettings["ClientId"];
            }
        }

        public string ClientSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["ClientSecret"];
            }
        }

        public string RequestUri
        {
            get
            {
            
                return ConfigurationManager.AppSettings["RequestUri"];
            }
        }

        public string Code 
        {
            get 
            {
                return Request.QueryString["Code"];
            }
        }

        protected HealthGraphClient HealthGraph { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Code) == false)
            {
                HealthGraph = new HealthGraphClient(ClientId, ClientSecret, RequestUri);
                HealthGraph.InitAccessToken(Code);
                LblAccessToken.Text = HealthGraph.Token.AccessToken;
            }
        }
    }
}