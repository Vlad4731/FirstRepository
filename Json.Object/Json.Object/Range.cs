namespace Json
{
    public class Range : IPattern
    {
        readonly char starChar;
        readonly char endChar;

        public Range(char start, char end)
        {
            starChar = start;
            endChar = end;
        }

        public bool Match(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return false;
            }

            foreach(char c in text)
            {
                if (c < starChar || c > endChar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}