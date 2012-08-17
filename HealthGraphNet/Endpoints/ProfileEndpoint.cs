using System;
using System.Dynamic;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Serializers;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    /// <summary>
    /// Endpoint for retrieving and updating a user's profile. http://runkeeper.com/developer/healthgraph/profile
    /// </summary>
    public class ProfileEndpoint : IProfileEndpoint
    {
        #region Fields and Properties

        private const string ContentType = "application/vnd.com.runkeeper.Profile+json";
        private readonly List<string> ValidAthleteType = new List<string> { "Athlete", "Runner", "Marathoner", "Ultra Marathoner", "Cyclist", "Tri-Athlete, Walker", "Hiker", "Skier", "Snowboarder", "Skater", "Swimmer", "Rower" };
        private AccessTokenManagerBase _tokenManager;
        private UserModel _user;

        #endregion        
        
        #region Constructors

        public ProfileEndpoint(AccessTokenManagerBase tokenManager, UserModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion        
        
        #region IProfileEndpoint

        public ProfileModel GetProfile()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = _user.Profile;
            return _tokenManager.Execute<ProfileModel>(request);
        }

        public void GetProfileAsync(Action<ProfileModel> success, Action<HealthGraphException> failure)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = _user.Profile;
            _tokenManager.ExecuteAsync<ProfileModel>(request, success, failure);
        }

		public ProfileModel UpdateProfile(ProfileModel profileToUpdate)
		{
            var request = PrepareUpdateRequest(profileToUpdate);
            return _tokenManager.Execute<ProfileModel>(request);
		}

        public ProfileModel UpdateProfile(string athleteType)
        {
            return UpdateProfile(new ProfileModel { AthleteType = athleteType });
        }

		public void UpdateProfileAsync(Action<ProfileModel> success, Action<HealthGraphException> failure, ProfileModel profileToUpdate)
		{
            var request = PrepareUpdateRequest(profileToUpdate);
            _tokenManager.ExecuteAsync<ProfileModel>(request, success, failure);
		}

        public void UpdateProfileAsync(Action<ProfileModel> success, Action<HealthGraphException> failure, string athleteType)
        {
            UpdateProfileAsync(success, failure, new ProfileModel { AthleteType = athleteType });
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Prepares the request object to be updated.
        /// </summary>
        /// <param name="profileToUpdate"></param>
        /// <returns></returns>
        private IRestRequest PrepareUpdateRequest(ProfileModel profileToUpdate)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = _user.Profile;

            //Validate AthleteType
            if (ValidAthleteType.Contains(profileToUpdate.AthleteType) == false)
            {
                string exMsg = "The AthleteType is not valid. Valid values are as follows: ";
                bool first = true;
                foreach (var validAthleteType in ValidAthleteType)
                {
                    if (!first)
                    {
                        exMsg += ", ";
                    }
                    exMsg += "\"" + validAthleteType + "\"";
                    first = false;
                }
                throw new ArgumentException(exMsg);
            }
            request.AddParameter(ContentType, new { athlete_type = profileToUpdate.AthleteType }, ParameterType.RequestBody);          
            return request;
        }

        #endregion
    }
}