using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IUsers
    {
        UserModel GetUser();
        void GetUserAsync(Action<UserModel> success, Action<HealthGraphException> failure);
    }
}