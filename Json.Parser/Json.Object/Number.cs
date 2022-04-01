namespace Json
{
    public class Number
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digit = new Range('0', '9');
            var digits = new OneOrMore(digit);

            var signs = new Any("-+");
            var dot = new Character('.');

            var exponentLetter = new Any("eE");

            var integer = new Choice(
                new Sequence(new Character('-'), digits),
                new Sequence(new Character('-'), digit),
                digit
            );
            var exponent = new Optional(new Sequence(exponentLetter, signs, digits));
            var fraction = new Optional(new Sequence(dot, digits));

            pattern = new Sequence(integer, fraction, exponent);

        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}