namespace Json
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            bool match = false;

            foreach(char c in text)
            {
                match = false;

                foreach (var pattern in patterns)
                {
                    if (pattern.Match(c.ToString()))
                    {
                        match = true;
                    }
                }

                if(match == false)
                {
                    return false;
                }
            }

            return match;
        }
    }
}