namespace Json
{
    public class FailedMatch : IMatch
    {
        readonly string text;

        public FailedMatch(string match)
        {
            text = match;
        }

        public bool Success()
        {
            return false;
        }

        public string RemainingText()
        {
            return text;
        }

    }
}