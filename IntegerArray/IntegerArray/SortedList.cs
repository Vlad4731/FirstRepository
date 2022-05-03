using System;

namespace IntegerArray
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public SortedList() : base()
        {
        }

        public override T this[int index]
        {
            get => base[index];
            set
            {
                if (ElementOrDefault(index - 1, value).CompareTo(value) > 0
                    || ElementOrDefault(index + 1, value).CompareTo(value) < 0)
                {
                    return;
                }

                Insert(index, value);
            }
        }

        public override void Add(T item)
        {
            EnsureCapacity();
            base[Count] = item;
            Count++;
            Sort();
        }

        public override void Insert(int index, T item)
        {
            if (ElementOrDefault(index - 1, item).CompareTo(item) > 0
                || ElementOrDefault(index, item).CompareTo(item) < 0)
            {
                return;
            }

            base.Insert(index, item);
        }

        private T ElementOrDefault(int index, T defaultValue)
        {
            return index >= 0 && index < Count ? base[index] : defaultValue;
        }

        private void Sort()
        {
            bool match = true;
            while (match)
            {
                match = false;
                for (int i = 0; i < Count - 1; i++)
                {
                    if (base[i].CompareTo(base[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                        match = true;
                    }
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            T temp = base[firstIndex];
            base[firstIndex] = base[secondIndex];
            base[secondIndex] = temp;
        }
    }
}
