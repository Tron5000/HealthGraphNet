using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HealthGraphNet.Models
{
    /// <summary>
    /// The access token model used in conjunction with the AccessTokenManager.
    /// </summary>
    public class AccessTokenModel
    {
        /// <summary>
        /// The OAuth2 access token.
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
        
        /// <summary>
        /// The type of OAuth2 access token.
        /// </summary>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
    }
}