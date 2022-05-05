using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegerArray
{
    public class ReadonlyList<T> : IList<T>
    {
        private const string InvalidIndexException = "Index was outside the bounds of the list.";
        private const string ReadonlyArrayException = "List cannot be set, for it is readonly.";

        private readonly List<T> list;

        public ReadonlyList(List<T> list)
        {
            this.list = list;
        }

        public int Count { get; set; }

        public bool IsReadOnly { get; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentException(InvalidIndexException);
                }

                return this[index];
            }

            set
            {
                throw new NotSupportedException(ReadonlyArrayException);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[i];
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
                if (list[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
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
    }
}
