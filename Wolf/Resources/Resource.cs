using Microsoft.AspNetCore.Http;
using System;

namespace Wolf
{
    public class Resource
    {
        public Representation Request(HttpContext context)
        {
            switch (context.Request.Method)
            {
                case "GET":
                    return Get(context);

                case "PUT":
                    return Put(context);

                case "POST":
                    return Post(context);

                case "DELETE":
                    return Delete(context);

                default:
                    throw new NotSupportedException();
            }
        }

        protected virtual Representation Get(HttpContext context)
        {
            throw new NotSupportedException();
        }

        protected virtual Representation Put(HttpContext context)
        {
            throw new NotSupportedException();
        }

        protected virtual Representation Post(HttpContext context)
        {
            throw new NotSupportedException();
        }

        protected virtual Representation Delete(HttpContext context)
        {
            throw new NotSupportedException();
        }
    }
}
