using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegerArray
{
    public class List<T> : IList<T>
    {
        private const string InvalidIndexException = "Index was outside the bounds of the list.";
        private const byte ArraySizeFactor = 2;

        private T[] items;

        public List()
        {
            items = new T[ArraySizeFactor * ArraySizeFactor];
        }

        public int Count { get; set; }

        public bool IsReadOnly { get; }

        public virtual T this[int index]
        {
            get
            {
                CheckIndexOutOfBoundsException(index);
                return items[index];
            }

            set
            {
                CheckIndexOutOfBoundsException(index);
                items[index] = value;
            }
        }

        public virtual void Add(T item)
        {
            EnsureCapacity();
            items[Count] = item;
            Count++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T item)
        {
            CheckIndexOutOfBoundsException(index);
            EnsureCapacity();

            ShiftRight(index);
            items[index] = item;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Remove(T item)
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

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex + Count > array.Length)
            {
                throw new OverflowException("Destination array has insufficient capacity.");
            }

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex] = this[i];
                arrayIndex++;
            }
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

        private void CheckIndexOutOfBoundsException(int index)
        {
            if (index >= 0 && index <= Count)
            {
                return;
            }

            throw new ArgumentException(InvalidIndexException);
        }
    }
}
