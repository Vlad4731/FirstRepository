using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegerArray
{
    public class ReadonlyList<T> : IList<T>
    {
        private const string InvalidIndexException = "Index was outside the bounds of the list.";
        private const string ReadonlyArrayException = "List cannot be set, for it is readonly.";
        private const string InsufficientLengthException = "Destination array has insufficient capacity.";

        private readonly T[] items;

        public ReadonlyList(T[] items)
        {
            this.items = items;
        }

        public int Count { get; }

        public bool IsReadOnly { get => true; }

        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentException(InvalidIndexException);
                }

                return items[index];
            }

            set
            {
                throw new NotSupportedException(ReadonlyArrayException);
            }
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

        public void Add(T item)
        {
            throw new NotSupportedException(ReadonlyArrayException);
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException(ReadonlyArrayException);
        }

        public void Clear()
        {
            throw new NotSupportedException(ReadonlyArrayException);
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException(ReadonlyArrayException);
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException(ReadonlyArrayException);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > Count)
            {
                throw new ArgumentException(InvalidIndexException);
            }

            if (array.Length < items.Length - arrayIndex)
            {
                throw new OverflowException(InsufficientLengthException);
            }

            if (Count == 0)
            {
                throw new ArgumentException("List cannot be copied, for it is empty.");
            }

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex] = this[i];
                arrayIndex++;
            }
        }
    }
}
