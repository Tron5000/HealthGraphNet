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
		public AccessTokenModel Token
		{
			get
			{
                return Session["Token"] as AccessTokenModel;
			}
			set
			{
				Session["Token"] = value;
			}
		}

        protected AccessTokenManager TokenManager { get; set; }

        #endregion

		#region Events and Overrides

        protected void Page_Load(object sender, EventArgs e)
        {
			//Setup the auth url
			string authUrl = "https://runkeeper.com/apps/authorize?client_id=" + ClientId + "&redirect_uri=" + HttpUtility.UrlEncode(RequestUri) + "&response_type=code";
			AAuthAnchor.HRef = authUrl;

			//Initialize the healthgraph api - get a token or use an existing one saved to session
			TokenManager = new AccessTokenManager(ClientId, ClientSecret, RequestUri);
			if (string.IsNullOrEmpty(Code) == false)
            {
				//If we set the code in the url string, get a new access token and save it to the session       
                TokenManager.InitAccessToken(Code);
				Token = TokenManager.Token;
            }
			else if (Token != null)
			{
				//Otherwise, if the access code saved in session is present we'll attempt to use that
                TokenManager.Token = Token;
			}

			if (Token != null)
			{
				DisplayHealthGraphSamples();
			}
        }

		#endregion

		#region Helper Methods

		protected void DisplayHealthGraphSamples()
		{
			PnlTokenSamples.Visible = true;
            LblAccessToken.Text = Token.AccessToken;
            LblAccessType.Text = Token.TokenType;

            //User Uri example
            var userRequest = new UsersEndpoint(TokenManager);
            var user = userRequest.GetUser();
            LblUserId.Text = user.UserID.ToString();
            LblUserStrengthTrainingActivities.Text = user.StrengthTrainingActivities;
            LblUserWeight.Text = user.Weight;
            LblUserSettings.Text = user.Settings;
            LblUserDiabetes.Text = user.Diabetes;
            LblUserTeam.Text = user.Team;
            LblUserSleep.Text = user.Sleep;
            LblUserFitnessActivities.Text = user.FitnessActivities;
            LblUserNutrition.Text = user.Nutrition;
            LblUserGeneralMeasurements.Text = user.GeneralMeasurements;
            LblUserBackgroundActivities.Text = user.BackgroundActivities;
            LblUserRecords.Text = user.Records;
            LblUserProfile.Text = user.Profile;

            //Get user profile
            var profileRequest = new ProfileEndpoint(TokenManager, user);
            var profile = profileRequest.GetProfile();
            //Optionally change and update it here
            //profile.AthleteType = "Hiker";
            profile.AthleteType = "Hiker";
            profile = profileRequest.UpdateProfile(profile);
            //Display user profile
            LblProfileName.Text = !string.IsNullOrEmpty(profile.Name) ? profile.Name : "N/A";
            LblProfileLocation.Text = !string.IsNullOrEmpty(profile.Location) ? profile.Location : "N/A";
            LblProfileAthleteType.Text = !string.IsNullOrEmpty(profile.AthleteType) ? profile.AthleteType : "N/A";
            LblProfileGender.Text = !string.IsNullOrEmpty(profile.Gender) ? profile.Gender : "N/A";
            LblProfileBirthday.Text = profile.Birthday.HasValue ? profile.Birthday.Value.ToShortDateString() : "N/A";
            LblProfileElite.Text = profile.Elite.ToString();
            LblProfileProfile.Text = profile.Profile;
            LblProfileSmallPicture.Text = !string.IsNullOrEmpty(profile.SmallPicture) ? profile.SmallPicture : "N/A";
            LblProfileNormalPicture.Text = !string.IsNullOrEmpty(profile.NormalPicture) ? profile.NormalPicture : "N/A";
            LblProfileMediumPicture.Text = !string.IsNullOrEmpty(profile.MediumPicture) ? profile.MediumPicture : "N/A";
            LblProfileLargePicture.Text = !string.IsNullOrEmpty(profile.LargePicture) ? profile.LargePicture : "N/A";

            //var settingsRequest = new SettingsEndpoint(TokenManager, user);
            //var settings = settingsRequest.GetSettings();
            //settings.FirstDayOfWeek = "Monday";
            //settings = settingsRequest.UpdateSettings(settings);

            //var weightRequest = new WeightEndpoint(TokenManager, user);
            //var weightItems =  weightRequest.GetFeedPage(0, 20, new DateTime(2010, 1, 1), new DateTime(2013, 6, 1)).Items; 
            //var weightItem = weightItems.First();
            //int test = 5;
            //var weightDetail = weightRequest.GetWeight(weightItem.Uri);
            //weightDetail.Bmi = 240;
            //weightDetail = weightRequest.UpdateWeight(weightDetail);

            /*
            var weightNew = new WeightNewModel
            {
                Timestamp = DateTime.Now, 
                MassWeight = 55,
                PostToFacebook = false,
                PostToTwitter = false
            };
            weightRequest.CreateWeight(weightNew);
            */
              
            //var test = weightDetail.Timestamp.ToLocalTime();
            //weightRequest.DeleteWeight(weightDetail.Uri);


            var activitiesRequest = new FitnessActivitiesEndpoint(TokenManager, user);
            var activitiesItem = activitiesRequest.GetFeedPage(pageSize: 2, noLaterThan: new DateTime(2013, 6, 1)).Items.FirstOrDefault();
            if (activitiesItem != null)
            {
                //Retrieve and update an activity
                //var activitiesDetail = activitiesRequest.GetActivity(activitiesItem.Uri);               
                //activitiesDetail.Type = "Running";
                //activitiesDetail.Equipment = "None";
                //activitiesDetail.AverageHeartRate = null;
                //activitiesDetail.Notes = "Testing is fun.";                
                //activitiesRequest.UpdateActivity(activitiesDetail);

                //Delete the activity
                //activitiesRequest.DeleteActivity(activitiesDetail.Uri);
            }

            //Create an activity
            
            var newActivity = new FitnessActivitiesNewModel
            {
                Type = "Running",
                StartTime = DateTime.Now,
                Duration = 50,
                Notes = "blah2!"
            };
            var uri = activitiesRequest.CreateActivity(newActivity);
            
        }

		#endregion
    }
}