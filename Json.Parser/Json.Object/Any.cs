namespace Json
{
    public class Any : IPattern
    {
        private readonly string characters;

        public Any(string accepted)
        {
            characters = accepted;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && characters.Contains(text[0])
                ? new SuccessMatch(text[1..])
                : new FailedMatch(text);
        }
    }
}