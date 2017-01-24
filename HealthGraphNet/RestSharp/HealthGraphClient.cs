using System;
using RestSharp.Portable;
using RestSharp.Portable.OAuth2;
using RestSharp.Portable.OAuth2.Configuration;
using RestSharp.Portable.OAuth2.Infrastructure;
using RestSharp.Portable.OAuth2.Models;
using HealthGraphNet.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// OAuth2 client for Health Graph
    /// </summary>
    public class HealthGraphClient : OAuth2Client
    {
        protected const string BaseUrl = "https://runkeeper.com";
        protected const string ApiBaseUrl = "https://api.runkeeper.com";

        public HealthGraphClient(IRequestFactory factory, IClientConfiguration configuration)
            : base(factory, configuration)
        {
        }

        protected override Endpoint AccessCodeServiceEndpoint
        {
            get
            {
                return new Endpoint
                {
                    BaseUri =  BaseUrl,
                    Resource = "apps/authorize"
                };
            }
        }

        protected override Endpoint AccessTokenServiceEndpoint
        {
            get
            {
                return new Endpoint
                {
                    BaseUri = BaseUrl,
                    Resource = "/apps/token"
                };
            }
        }

        public override string Name
        {
            get { return "runkeeper"; }
        }

        protected override UserInfo ParseUserInfo(IRestResponse response)
        {
            return ParseUserInfo(response.Content);
        }

        protected UserInfo ParseUserInfo(string content) // make visible for other classes
        {
            var user = JsonConvert.DeserializeObject<UsersModel>(content);
            return new HealthGraphUserInfo { User = user };
        }

        protected virtual void AfterGetUserInfo(AfterGetUserInfoArgs args)
        {
        }

        protected override async Task<UserInfo> GetUserInfo()
        {
            var userInfo = await base.GetUserInfo() as HealthGraphUserInfo;
            var profileEndPoint = new Endpoint { BaseUri = ApiBaseUrl, Resource = userInfo.User.Profile };
            var client = Factory.CreateClient(profileEndPoint);
            var request = Factory.CreateRequest(profileEndPoint);
            AddAuthorizationHeaderToRequest(request);
            var response = await client.Execute<ProfileModel>(request);
            var profile = JsonConvert.DeserializeObject<ProfileModel>(response.Content);
            AfterGetUserInfo(new AfterGetUserInfoArgs { UserInfo = userInfo, Profile = profile });
            return userInfo;
        }

        protected override void BeforeGetUserInfo(BeforeAfterRequestArgs args)
        {
            AddAuthorizationHeaderToRequest(args.Request);
            base.BeforeGetUserInfo(args);
        }

        protected void AddAuthorizationHeaderToRequest(IRestRequest request)
        {
            request.AddHeader("Authorization", "Bearer " + AccessToken);
            request.AddHeader("Accept", "application/vnd.com.runkeeper.User+json");
        }

        protected override Endpoint UserInfoServiceEndpoint
        {
            get
            {
                return new Endpoint
                {
                    BaseUri = ApiBaseUrl,
                    Resource = "/user"
                };
            }
        }

        protected class HealthGraphUserInfo : UserInfo
        {
            public UsersModel User { get; set; }
        }
        public class AfterGetUserInfoArgs
        {
            public UserInfo UserInfo { get; internal set; }
            public ProfileModel Profile { get; internal set; }
        }
    }

}
