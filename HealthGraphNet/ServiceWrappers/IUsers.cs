using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface IUsers
    {
        UserModel GetUser();
        void GetUserAsync(Action<UserModel> success, Action<HealthGraphException> failure);
    }
}