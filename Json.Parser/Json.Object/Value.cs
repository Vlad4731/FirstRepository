namespace Json
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var ws = new Many(new Any(" \n\t\r"));

            var value = new Choice(
                new String(),
                new Number(),
                new Text("true"),
                new Text("false"),
                new Text("null"));

            var element = new Sequence(ws, value, ws);
            var elements = new List(element, new Character(','));

            var array = new Choice(
                new Sequence(new Character('['), ws, new Character(']')),
                new Sequence(new Character('['), ws, elements, ws, new Character(']'))
                );

            var member = new Sequence(ws, new String(), ws, new Character(':'), element);
            var members = new List(member, new Character(','));

            var valueObject = new Choice(
                new Sequence(new Character('{'), ws, new Character('}')),
                new Sequence(new Character('{'), ws, members, ws, new Character('}'))
                );

            value.Add(array);
            value.Add(valueObject);

            pattern = elements;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}