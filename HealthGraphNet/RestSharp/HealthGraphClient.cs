using RestSharp.Portable;
using RestSharp.Portable.Authenticators.OAuth2;
using RestSharp.Portable.Authenticators.OAuth2.Configuration;
using RestSharp.Portable.Authenticators.OAuth2.Infrastructure;
using RestSharp.Portable.Authenticators.OAuth2.Models;

namespace HealthGraphNet.RestSharp
{
    /// <summary>
    /// OAuth2 client for Health Graph
    /// </summary>
    public class HealthGraphClient : OAuth2Client
    {
        public const string ApiBaseUrl = "https://api.runkeeper.com";

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
                    BaseUri =  ApiBaseUrl,
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
                    BaseUri = ApiBaseUrl,
                    Resource = "/apps/token"
                };
            }
        }

        public override string Name
        {
            get { return "runkeeper"; }
        }

        protected override global::RestSharp.Portable.Authenticators.OAuth2.Models.UserInfo ParseUserInfo(string content)
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
            args.Request.Parameters.Add(new Parameter { Name = "access_token", Value = AccessToken, Type = ParameterType.GetOrPost });
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
