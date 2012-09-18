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
            //profile.AthleteType = "Hiker";
            //profile = profileRequest.UpdateProfile(profile);
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
          
            //var sleepRequest = new SleepEndpoint(TokenManager, user);
            //var sleepNew = new SleepNewModel
            //{
            //    Timestamp = DateTime.Now,
            //    TimesWoken = 3,
            //    PostToTwitter = false,
            //    PostToFacebook = false
            //};
            //var uriOfSleep = sleepRequest.CreateSleep(sleepNew);
            //var sleepPage = sleepRequest.GetFeedPage();
            //var sleepDetail = sleepRequest.GetSleep(uriOfSleep);

            //var uriOfSleep = sleepPage.Items.First().Uri;
            //var sleepDetail = sleepRequest.GetSleep(uriOfSleep);
            //sleepDetail.Rem = 180;
            //sleepDetail = sleepRequest.UpdateSleep(sleepDetail);

            //sleepRequest.DeleteSleep(uriOfSleep);

            //int test = 4;
            //var settingsRequest = new SettingsEndpoint(TokenManager, user);
            //var settings = settingsRequest.GetSettings();
            //settings.FirstDayOfWeek = "Monday";
            //settings = settingsRequest.UpdateSettings(settings);

            //var streetTeamRequest = new StreetTeamEndpoint(TokenManager, user);
            //var streetTeamItems = streetTeamRequest.GetFeedPage(pageIndex: 1, pageSize: 2);
            //var uri = streetTeamRequest.CreateTeamInvitation(new StreetTeamInvitationsModel { UserID = 7072229 });
            //var results = streetTeamRequest.GetStreetTeam(uri);

            //var nutritionNew = new NutritionNewModel
            //{
            //    Timestamp = DateTime.Now,
            //    Fat = 200,
            //    PostToFacebook = false,
            //    PostToTwitter = false
            //};
            //var nutritionRequest = new NutritionEndpoint(TokenManager, user);
            //var uriOfNutrition = nutritionRequest.CreateNutrition(nutritionNew);
            //var uriOfNutrition = nutritionRequest.GetFeedPage().Items.First().Uri;
            //nutritionRequest.DeleteNutrition(uriOfNutrition);

            //var weightRequest = new WeightEndpoint(TokenManager, user);
            /*
            var weightNew = new WeightNewModel
            {
                Timestamp = DateTime.Now,
                Weight = 90,
                PostToFacebook = false,
                PostToTwitter = false
            };
            var test = weightRequest.CreateWeight(weightNew);         
            */
            //var weightItems =  weightRequest.GetFeedPage().Items; 
            //var weightItem = weightItems.First();
            /*
            var weightDetail = weightRequest.GetWeight(weightItem.Uri);
            weightDetail.Bmi = 240;
            weightDetail = weightRequest.UpdateWeight(weightDetail);
            */
            //weightRequest.DeleteWeight(weightItem.Uri);
            
        
            //var activitiesRequest = new FitnessActivitiesEndpoint(TokenManager, user);
            /*
            var newActivity = new FitnessActivitiesNewModel
            {
                Type = "Running",
                StartTime = DateTime.Now,
                Duration = 50,
                Notes = "blah6!"
            };
            var uri = activitiesRequest.CreateActivity(newActivity);                                
            */
            //var activitiesItem = activitiesRequest.GetFeedPage(pageSize: 2, noLaterThan: new DateTime(2013, 6, 1)).Items.FirstOrDefault();
            //if (activitiesItem != null)
            //{
            //    var activitiesDetail = activitiesRequest.GetActivity(activitiesItem.Uri);                 
                
                //Get associated comments
            //    var commentRequest = new CommentThreadsEndpoint(TokenManager);
            //    var commentThread = commentRequest.GetCommentThread(activitiesDetail.Comments);

            //    var newComment = new CommentsNewModel
            //    {
            //        Comment = "Here we go!"
            //    };
            //    commentRequest.CreateComment(newComment, activitiesDetail.Comments);
                //commentRequest.CreateCommentAsync(() => { }, (ex) => { }, newComment, activitiesDetail.Comments);

            //    commentThread = commentRequest.GetCommentThread(activitiesDetail.Comments);

                //Retrieve and update an activity
                //var activitiesDetail = activitiesRequest.GetActivity(activitiesItem.Uri);               
                //activitiesDetail.Type = "Running";
                //activitiesDetail.Equipment = "None";
                //activitiesDetail.AverageHeartRate = null;
                //activitiesDetail.Notes = "Testing is fun.";                
                //activitiesRequest.UpdateActivity(activitiesDetail);

                //Delete the activity
                //activitiesRequest.DeleteActivity(activitiesDetail.Uri);
           // }
            

            //var recordsRequest = new RecordsEndpoint(TokenManager, user);
            //var items = recordsRequest.GetRecordsFeed();
            //int test = 4;
        }

		#endregion
    }
}