namespace Json
{
    public class Any : IPattern
    {
        private readonly char[] characters;

        public Any(string accepted)
        {
            characters = accepted.ToCharArray();
        }

        public IMatch Match(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return new FailedMatch(text);
            }

            foreach (char c in characters)
            {
                if(text[0] == c)
                {
                    return new SuccessMatch(text[1..]);
                }
            }

            return new FailedMatch(text);
        }
    }
}