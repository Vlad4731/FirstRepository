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
            if(!(text == null) && (text.Length >= prefix.Length))
            {
                if (prefix == text[..prefix.Length])
                {
                    return new SuccessMatch(text[prefix.Length..]);
                }
            }

            return new FailedMatch(text);
        }
    }
}