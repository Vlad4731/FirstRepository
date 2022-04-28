using System;
using System.Collections;

namespace IntegerArray
{
    public class ObjectArrayCollection : IEnumerable
    {
        private const int ArraySizeFactor = 2;
        private object[] items;

        public ObjectArrayCollection()
        {
            items = new object[ArraySizeFactor * ArraySizeFactor];
        }

        public int Count { get; set; }

        public object this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }

        public virtual void Add(object element)
        {
            EnsureCapacity();
            items[Count] = element;
            Count++;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
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
                if (items[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, object item)
        {
            EnsureCapacity();

            ShiftRight(index);
            items[index] = item;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Remove(object item)
        {
            int initialCount = Count;
            RemoveAt(IndexOf(item));

            return Count < initialCount;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        internal void EnsureCapacity()
        {
            if (Count + 1 < items.Length)
            {
                return;
            }

            Array.Resize(ref items, items.Length * ArraySizeFactor);
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                this[i] = this[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = Count - 1; i > index; i--)
            {
                this[i] = this[i - 1];
            }
        }
    }
}
