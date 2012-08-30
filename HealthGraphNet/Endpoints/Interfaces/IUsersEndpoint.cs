using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IUsersEndpoint
    {
        UsersModel GetUser();
        void GetUserAsync(Action<UsersModel> success, Action<HealthGraphException> failure);
    }
}