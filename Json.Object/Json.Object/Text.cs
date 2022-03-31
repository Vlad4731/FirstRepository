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
            if(text == null || text.Length < prefix.Length)
            {
                return new FailedMatch(text);
            }

            string matchedText = "";

            foreach(char c in prefix)
            {
                if(c != text[0])
                {
                    return new FailedMatch(matchedText + text);
                }

                matchedText += c;
                text = text[1..];
            }

            return new SuccessMatch(text);
        }
    }
}