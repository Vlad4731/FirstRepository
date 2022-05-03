using System;
using System.Collections;

namespace IntegerArray
{
    public class ObjectIEnumerator : IEnumerator
    {
        public ObjectArrayCollection Items;
        private int position = -1;

        public ObjectIEnumerator(ObjectArrayCollection items)
        {
            Items = items;
        }

        public object Current
        {
            get
            {
                if (position < 0 || position >= Items.Count)
                {
                    throw new InvalidOperationException();
                }

                return Items[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return position < Items.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
