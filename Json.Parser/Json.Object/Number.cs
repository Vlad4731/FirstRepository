namespace Json
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var onenine = new Range('1', '9');

            var digit = new Choice(
                new Character('0'),
                onenine);

            var digits = new OneOrMore(digit);

            var integer = new Choice(
                new Sequence(new Optional(new Character('-')), digit),
                new Sequence(new Optional(new Character('-')), onenine, digits)
            );

            var fraction = new Optional(new Sequence(new Character('.'), digits));
            var exponent = new Optional(new Sequence(new Any("eE"), new Any("-+"), digits));

            pattern = new Sequence(integer, fraction, exponent);

        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}