using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegerArray
{
    public class ReadonlyList<T> : IList<T>
    {
        private const string ReadonlyArrayException = "List cannot be set, for it is readonly.";

        private readonly IList<T> list;

        public ReadonlyList(IList<T> list)
        {
            this.list = list;
        }

        public int Count => list.Count;

        public bool IsReadOnly { get => true; }

        public T this[int index]
        {
            get => list[index];

            set => throw new NotSupportedException(ReadonlyArrayException);
        }

        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

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
