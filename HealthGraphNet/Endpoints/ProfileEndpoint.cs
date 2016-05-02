using System;
using System.Collections.Generic;
using RestSharp.Portable;
using RestSharp.Portable.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        #endregion
    }
}