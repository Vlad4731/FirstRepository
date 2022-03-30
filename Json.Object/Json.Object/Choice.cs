namespace Json
{
    public class Choice : IPattern
    {
        private readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new FailedMatch(text);
            }

            bool match = false;

            foreach(char c in text)
            {
                match = false;

                foreach (var pattern in patterns)
                {
                    if (pattern.Match(c.ToString()).Success())
                    {
                        match = true;
                    }
                }

                if(match == false)
                {
                    return new FailedMatch(text);
                }
            }

            return new SuccessMatch(text[1..]);
        }
    }
}