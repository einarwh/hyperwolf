using System;

namespace Wolf
{
    public class JsonRenderer : IRenderer
    {
        public string ContentType => "application/json";

        public string Render(Representation location)
        {
            throw new NotImplementedException();
        }
    }
}
