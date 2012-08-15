using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IProfile
    {
        ProfileModel GetProfile();
        void GetProfileAsync(Action<ProfileModel> success, Action<HealthGraphException> failure);    
    }
}