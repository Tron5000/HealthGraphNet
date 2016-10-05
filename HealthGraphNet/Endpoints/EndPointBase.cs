using HealthGraphNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    /// <summary>
    /// Base class for endpoints
    /// </summary>
    public class EndPointBase
    {
        private Client _client;
        private Func<Task<UsersModel>> _functionGetUser;

        protected Client Client
        {
            get
            {
                return _client;
            }
        }

        public EndPointBase(Client client, UsersModel user) : this(client, () => Task.Run(() => user))
        {
        }

        public EndPointBase(Client client, Func<Task<UsersModel>> functionGetUser)
        {
            _client = client;
            _functionGetUser = functionGetUser;
        }

        protected Task<UsersModel> GetUser()
        {
            return _functionGetUser.Invoke();
        }
    }
}
