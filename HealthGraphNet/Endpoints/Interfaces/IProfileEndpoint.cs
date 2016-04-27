using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IProfileEndpoint
    {
        Task<ProfileModel> GetProfile();
		Task<ProfileModel> UpdateProfile(ProfileModel profileToUpdate);
        Task<ProfileModel> UpdateProfile(string athleteType);
	}
}