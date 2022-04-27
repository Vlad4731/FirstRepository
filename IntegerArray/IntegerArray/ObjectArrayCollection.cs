using System;
using System.Collections;

namespace IntegerArray
{
    public class ObjectArrayCollection : IEnumerable
    {
        private object[] objects;

        public ObjectArrayCollection()
        {
            objects = new object[4];
        }

        public int Count { get; set; }

        public object this[int index]
        {
            get => objects[index];
            set => objects[index] = value;
        }

        public virtual void Add(object element)
        {
            EnsureCapacity();
            objects[Count] = element;
            Count++;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return objects[i];
            }
        }

        public bool Contains(object element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (objects[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, object element)
        {
            if ((Count + 1) % 4 == 0)
            {
                Array.Resize(ref objects, objects.Length + 4);
            }

            for (int i = objects.Length - 1; i >= 0; i--)
            {
                if (i == index)
                {
                    objects[i] = element;
                    break;
                }

                objects[i] = objects[i - 1];
            }
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(object element)
            {
            for (int i = 1; i < Count; i++)
            {
                bool match = false;

                if (objects[i].Equals(element))
                {
                    match = true;
                    Count--;
                }

                if (match)
                {
                    objects[i] = objects[i + 1];
                }
            }

            if (Count > objects.Length - 1)
            {
                return;
            }

            objects[Count + 1] = 0;
        }

        public void RemoveAt(int index)
        {
            Remove(objects[index]);
        }

        internal void EnsureCapacity()
        {
            if ((Count + 1) % 4 != 0)
            {
                return;
            }

            Array.Resize(ref objects, objects.Length + 4);
        }
    }
}
