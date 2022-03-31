namespace Json
{
    public class OneOrMore : IPattern
    {
        private IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = new Sequence(new Many(pattern), new Optional(pattern));        
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}