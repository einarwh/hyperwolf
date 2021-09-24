using System;

namespace Wolf
{
    public class RedirectException : Exception
    {
        public RedirectException(int statusCode, string location) 
        {
            StatusCode = statusCode;
            Location = location;
        }

        public int StatusCode { get; }

        public string Location { get; }
    }

}
