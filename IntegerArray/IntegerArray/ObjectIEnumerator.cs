using System;
using System.Collections;

namespace IntegerArray
{
    public class ObjectIEnumerator : IEnumerator
    {
        private readonly ObjectArrayCollection items;
        private int position = -1;

        public ObjectIEnumerator(ObjectArrayCollection items)
        {
            this.items = items;
        }

        public object Current
        {
            get
            {
                if (position < 0 || position >= items.Count)
                {
                    throw new InvalidOperationException();
                }

                return items[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return position < items.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
