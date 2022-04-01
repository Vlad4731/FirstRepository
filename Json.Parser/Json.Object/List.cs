namespace Json
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            pattern = new Optional(
                new Sequence(
                    element, 
                    new Many(new Sequence(separator, element))
                    )
                );
            //Oare nu ar putea fi folosit un OneOrMany aici?
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}