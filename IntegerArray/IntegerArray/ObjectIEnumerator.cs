using System;
using System.Collections;

namespace IntegerArray
{
    class ObjectIEnumerator : IEnumerator
    {
        private readonly int count;
        private int index = -1;

        public ObjectIEnumerator(int count)
        {
            this.count = count;
        }

        public bool MoveNext()
        {
            index += 1;
            return count < index;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current { get; }
    }
}
