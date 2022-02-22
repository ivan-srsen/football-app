using System;
using System.Net;

namespace FootballApp.Exceptions
{
    public class ApiException : Exception
    {
        public string Key { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ApiException()
            : base("An API error has occurred.")
        { }

        public ApiException(string key, HttpStatusCode statusCode)
            : this()
        {
            Key = key;
            StatusCode = statusCode;
        }
    }
}
