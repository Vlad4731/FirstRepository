using System;
using System.Collections;

namespace IntegerArray
{
    public class ObjectIEnumerator : IEnumerator
    {
        public object[] Objects;
        private readonly int count;
        private int position = -1;

        public ObjectIEnumerator(object[] objects, int count)
        {
            this.Objects = objects;
            this.count = count;
        }

        public object Current
        {
            get
            {
                try
                {
                    return Objects[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return position < count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
