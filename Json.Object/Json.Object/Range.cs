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

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text[0] >= starChar && text[0] <= endChar
                ? new SuccessMatch(text[1..])
                : new FailedMatch(text);
        }
    }
}