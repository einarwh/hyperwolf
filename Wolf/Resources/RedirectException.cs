using System;

namespace Wolf
{
    public class RedirectException : Exception
    {
        public RedirectException(string location) 
        {
            Location = location;
        }

        public string Location { get; }
    }

}
