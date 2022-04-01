namespace Json
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var quotes = new Character('\"');

            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var unicodeSequence = new Sequence(
                new Character('u'),
                hex, hex, hex, hex);

            var escape = new Choice(
                new Any("bfnrt\"\\/"),
                unicodeSequence
                );

            var validCharacter = new Choice(
                new Range(' ', '\uFFFF'),
                new Sequence(new Character('\\'), escape)
                );

            pattern = new Sequence(quotes, new OneOrMore(validCharacter), quotes);

        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}