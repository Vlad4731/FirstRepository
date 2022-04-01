namespace Json
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            pattern = new Optional(new Sequence(element, separator));

        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}