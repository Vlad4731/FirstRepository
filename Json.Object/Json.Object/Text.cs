namespace Json
{
    public class Text : IPattern
    {
        private string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            throw new System.NotImplementedException();
        }
    }
}