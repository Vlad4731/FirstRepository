namespace Json
{
    public class SuccessMatch : IMatch
    {
        readonly string text;

        public SuccessMatch(string match)
        {
            text = match;
        }

        public bool Success()
        {
            return true;
        }

        public string RemainingText()
        {
            return text;
        }

    }

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