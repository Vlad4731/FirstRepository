namespace Json
{
    public class Many : IPattern
    {
        private IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return new SuccessMatch(text);
            }

            foreach (char c in text)
            {
                if (!pattern.Match(c.ToString()).Success())
                {
                    return new SuccessMatch(text);
                }

                text = text[1..];

            }

            return new SuccessMatch(text);
        }
    }
}