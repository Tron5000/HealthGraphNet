using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IProfileEndpoint
    {
        Task<ProfileModel> GetProfile();
	}
}