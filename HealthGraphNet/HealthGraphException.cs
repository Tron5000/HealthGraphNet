﻿using System;
using RestSharp;
using System.Net;

namespace HealthGraphNet
{
    public class HealthGraphException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public IRestResponse Response { get; private set; }

        public HealthGraphException()
        {
        }

        public HealthGraphException(string message) : base(message)
        {
        }

        public HealthGraphException(IRestResponse response) : base(response.ErrorMessage)
        {
            StatusCode = response.StatusCode;
            Response = response;            
        }
    }
}