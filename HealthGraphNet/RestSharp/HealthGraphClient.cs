using System;
using RestSharp.Portable;
using RestSharp.Portable.OAuth2;
using RestSharp.Portable.OAuth2.Configuration;
using RestSharp.Portable.OAuth2.Infrastructure;
using RestSharp.Portable.OAuth2.Models;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// OAuth2 client for Health Graph
    /// </summary>
    public class HealthGraphClient : OAuth2Client
    {
        private const string BaseUrl = "https://runkeeper.com";
        private const string ApiBaseUrl = "https://api.runkeeper.com";

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
            // cannot return null
            return new UserInfo();
        }

        protected override void BeforeGetAccessToken(BeforeAfterRequestArgs args)
        {
            base.BeforeGetAccessToken(args);
        }

        protected override void BeforeGetUserInfo(BeforeAfterRequestArgs args)
        {
            args.Request.AddHeader("Authorization", "Bearer " + AccessToken);
            args.Request.AddHeader("Accept", "application/vnd.com.runkeeper.User+json");
            base.BeforeGetUserInfo(args);
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
    }
}
