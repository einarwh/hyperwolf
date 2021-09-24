namespace Wolf
{
    public class Status
    {
        private string _s;

        public Status(string s)
        {
            _s = s;
        }

        public override string ToString()
        {
            return _s;
        }
    }
}
