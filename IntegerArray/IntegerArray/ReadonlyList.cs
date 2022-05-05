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

        public int Count => list.Count;

        public bool IsReadOnly { get => true; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentException(InvalidIndexException);
                }

                return list[index];
            }

            set
            {
                throw new NotSupportedException(ReadonlyArrayException);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)list).GetEnumerator();

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        public bool Contains(T item) => list.Contains(item);

        public int IndexOf(T item) => list.IndexOf(item);

        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

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
