using System;
using System.Collections;

namespace IntegerArray
{
    class ObjectIEnumerator : IEnumerator
    {
        public bool MoveNext();

        public void Reset();

        public object Current { get; }
    }
}
