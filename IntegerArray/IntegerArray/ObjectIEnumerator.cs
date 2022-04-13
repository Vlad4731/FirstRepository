using System;
using System.Collections;

namespace IntegerArray
{
    public class ObjectIEnumerator : IEnumerator
    {
        public object[] objects;
        private int position = -1;
        private int count;

        public ObjectIEnumerator(object[] objects, int count)
        {
            this.objects = objects;
            this.count = count;
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

        public object Current
        {
            get
            {
                try
                {
                    return objects[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
