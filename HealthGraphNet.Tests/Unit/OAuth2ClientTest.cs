using HealthGraphNet.RestSharp;
using Moq;
using NUnit.Framework;
using RestSharp.Portable.OAuth2.Configuration;
using RestSharp.Portable.OAuth2.Infrastructure;
using RestSharp.Portable.OAuth2.Models;
using System;
using System.Threading.Tasks;

namespace HealthGraphNet.Tests.Unit
{
    [TestFixture]
    public class OAuth2ClientTest
    {
        IRequestFactory _requestFactory = new Mock<IRequestFactory>().Object;

        [Test]
        public void ParseUserInfo_Valid()
        {
            var client = new HealthGraphClientForTest(_requestFactory, new Mock<IClientConfiguration>().Object);
            var userInfo = client.ParseUserInfo(Resource.GetText(Resource.UserInfoJson));
            Assert.NotNull(userInfo);
        }

        class HealthGraphClientForTest : HealthGraphClient
        {
            public HealthGraphClientForTest(IRequestFactory factory, IClientConfiguration configuration)
                    : base(factory, configuration)
            {
            }

            public new UserInfo ParseUserInfo(string content) // make visible for other classes
            {
                return base.ParseUserInfo(content);
            }

            public new Task< UserInfo> GetUserInfo()
            {
                return base.GetUserInfo();
            }

        }
    }
}
