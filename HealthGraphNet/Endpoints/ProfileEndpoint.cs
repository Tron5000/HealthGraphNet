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
    public class ProfileEndpoint : EndPointBase, IProfileEndpoint
    {
        #region Fields and Properties

        public static readonly List<string> ValidAthleteType = new List<string> { "Athlete", "Runner", "Marathoner", "Ultra Marathoner", "Cyclist", "Tri-Athlete, Walker", "Hiker", "Skier", "Snowboarder", "Skater", "Swimmer", "Rower", null };

        #endregion

        #region Constructors

        public ProfileEndpoint(Client client, UsersModel user) : base(client, user)
        {
        }

        public ProfileEndpoint(Client client, Func<Task<UsersModel>> functionGetUser) : base(client, functionGetUser)
        {
        }

        #endregion

        #region IProfileEndpoint

        public async Task<ProfileModel> GetProfile()
        {
            var user = await GetUser();
            var request = new RestRequest(user.Profile, Method.GET);
            return await Client.Execute<ProfileModel>(request);
        }

        #endregion
    }
}