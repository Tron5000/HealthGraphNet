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

		/// <summary>
		/// Gets the auth code from the url string.
		/// </summary>
		/// <value>
		/// The code.
		/// </value>
        public string Code 
        {
            get 
            {
                return Request.QueryString["Code"];
            }
        }

		/// <summary>
		/// Gets or sets the access token as a session variable.
		/// </summary>
		/// <value>
		/// The access token.
		/// </value>
		public string AssignedAccessToken
		{
			get
			{
				return Session["AccessToken"] as string;
			}
			set
			{
				Session["AccessToken"] = value;
			}
		}

        protected HealthGraphClient HealthGraph { get; set; }

        #endregion

		#region Events and Overrides

        protected void Page_Load(object sender, EventArgs e)
        {
			//Setup the auth url
			string authUrl = "https://runkeeper.com/apps/authorize?client_id=" + ClientId + "&redirect_uri=" + HttpUtility.UrlEncode(RequestUri) + "&response_type=code";
			AAuthAnchor.HRef = authUrl;
			AAuthAnchor.InnerText = "HealthGraph Authorization Endpoint";

			//Initialize the healthgraph api - get a token or use an existing one saved to session
			HealthGraph = new HealthGraphClient(ClientId, ClientSecret, RequestUri);
			if (string.IsNullOrEmpty(Code) == false)
            {
				//If we set the code in the url string, get a new access token and save it to the session       
                HealthGraph.InitAccessToken(Code);
				AssignedAccessToken = HealthGraph.Token.AccessToken;
            }
			else if (string.IsNullOrEmpty(AssignedAccessToken) == false)
			{
				//Otherwise, if the access code saved in session is present we'll attempt to use that
				HealthGraph.Token = new AccessTokenModel { AccessToken = AssignedAccessToken };
			}

			if (string.IsNullOrEmpty(AssignedAccessToken) == false)
			{
				DisplayHealthGraphSamples();
			}
        }

		#endregion

		#region Helper Methods

		protected void DisplayHealthGraphSamples()
		{
			PnlTokenSamples.Visible = true;
			LblAccessToken.Text = AssignedAccessToken;
		}

		#endregion
    }
}