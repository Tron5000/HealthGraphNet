using System;
using RestSharp;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    /// <summary>
    /// Wrapper for retrieving and updating a user's profile. http://runkeeper.com/developer/healthgraph/profile
    /// </summary>
    public class Profile : IProfile
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;
        private UserModel _user;

        #endregion        
        
        #region Constructors

        public Profile(AccessTokenManagerBase tokenManager, UserModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion        
        
        #region IProfile

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
			var request = new RestRequest(Method.PUT);
			request.Resource = _user.Profile;
			request.AddParameter("athlete_type", profileToUpdate.AthleteType);
			return _tokenManager.Execute<ProfileModel>(request);
		}

		public void UpdateProfileAsync(Action<ProfileModel> success, Action<HealthGraphException> failure, ProfileModel profileToUpdate)
		{

		}

        #endregion
    }
}