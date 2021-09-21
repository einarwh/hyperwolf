namespace Wolf
{
    public interface IRenderer
    {
        string ContentType { get; }

        string Render(Representation location);
    }
}
