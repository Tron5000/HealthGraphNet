using System;
using System.Collections.Generic;
using RestSharp.Portable;
using RestSharp.Portable.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    /// <summary>
    /// Endpoint for retrieving and updating a user's profile. http://runkeeper.com/developer/healthgraph/profile
    /// </summary>
    public class ProfileEndpoint : IProfileEndpoint
    {
        #region Fields and Properties

        public static readonly List<string> ValidAthleteType = new List<string> { "Athlete", "Runner", "Marathoner", "Ultra Marathoner", "Cyclist", "Tri-Athlete, Walker", "Hiker", "Skier", "Snowboarder", "Skater", "Swimmer", "Rower", null };
        
        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion        
        
        #region Constructors

        public ProfileEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion        
        
        #region IProfileEndpoint

        public async Task<ProfileModel> GetProfile()
        {
            var request = new RestRequest(_user.Profile, Method.GET);
            return await _tokenManager.Execute<ProfileModel>(request);
        }

		public async Task<ProfileModel> UpdateProfile(ProfileModel profileToUpdate)
		{
            var request = PrepareUpdateRequest(profileToUpdate);
            return await _tokenManager.Execute<ProfileModel>(request);
		}

        public Task<ProfileModel> UpdateProfile(string athleteType)
        {
            return UpdateProfile(new ProfileModel { AthleteType = athleteType });
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
            var request = new RestRequest(_user.Profile, Method.PUT);
            ValidateHelper.IsValueValid<string>(profileToUpdate.AthleteType, ValidAthleteType, "AthleteType");
            request.AddParameter(ProfileModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new 
            { 
                athlete_type = profileToUpdate.AthleteType 
            }), ParameterType.RequestBody);          
            return request;
        }

        #endregion
    }
}