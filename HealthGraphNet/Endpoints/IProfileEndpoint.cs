using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IProfileEndpoint
    {
        ProfileModel GetProfile();
        void GetProfileAsync(Action<ProfileModel> success, Action<HealthGraphException> failure);    
		ProfileModel UpdateProfile(ProfileModel profileToUpdate);
        ProfileModel UpdateProfile(string athleteType);
		void UpdateProfileAsync(Action<ProfileModel> success, Action<HealthGraphException> failure, ProfileModel profileToUpdate);
        void UpdateProfileAsync(Action<ProfileModel> success, Action<HealthGraphException> failure, string athleteType);
	}
}