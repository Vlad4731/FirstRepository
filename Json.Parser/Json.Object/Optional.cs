namespace Json
{
    public class Optional :IPattern
    {
        private IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new SuccessMatch(text);
            }

            foreach (char c in text)
            {
                if (pattern.Match(c.ToString()).Success())
                {
                    return new SuccessMatch(text[1..]);
                }
            }

            return new SuccessMatch(text);
        }
    }
}