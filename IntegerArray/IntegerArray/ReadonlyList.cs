using System;

namespace IntegerArray
{
    public class ReadonlyList<T> : List<T>
    {
        private const string InvalidIndexException = "Index was outside the bounds of the list.";
        private const string ReadonlyArrayException = "List cannot be set, for it is readonly.";

        public ReadonlyList(T[] items) : base()
        {
            this.Items = items;
        }

        public override T this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentException(InvalidIndexException);
                }

                return base[index];
            }

            set
            {
                throw new NotSupportedException(ReadonlyArrayException);
            }
        }

        public override void Add(T item)
        {
            throw new NotSupportedException(ReadonlyArrayException);
        }

        public override void Insert(int index, T item)
        {
            throw new NotSupportedException(ReadonlyArrayException);
        }

        public override void Clear()
        {
            throw new NotSupportedException(ReadonlyArrayException);
        }

        public override bool Remove(T item)
        {
            throw new NotSupportedException(ReadonlyArrayException);
        }

        public override void RemoveAt(int index)
        {
            throw new NotSupportedException(ReadonlyArrayException);
        }
    }
}
