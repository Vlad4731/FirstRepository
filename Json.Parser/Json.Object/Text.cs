namespace Json
{
    public class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return text != null && text.StartsWith(prefix)
                ? new SuccessMatch(text[prefix.Length..])
                : new FailedMatch(text);
        }
    }
}