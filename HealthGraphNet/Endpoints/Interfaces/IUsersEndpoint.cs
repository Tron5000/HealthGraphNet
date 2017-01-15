using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface IUsersEndpoint
    {
        Task<UsersModel> GetUser();
    }
}