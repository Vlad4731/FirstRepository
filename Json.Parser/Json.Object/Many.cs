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
            while (pattern.Match(text).Success())
            {
                text = pattern.Match(text).RemainingText();
            }

            return new SuccessMatch(pattern.Match(text).RemainingText());
        }
    }
}