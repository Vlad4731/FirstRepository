using System;

namespace IntegerArray
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override int this[int index]
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

        public override void Add(int element)
        {
            EnsureCapacity();
            base[Count] = element;
            Count++;
            Sort();
        }

        public override void Insert(int index, int element)
        {
            if (ElementOrDefault(index - 1, element).CompareTo(element) > 0
                || ElementOrDefault(index, element).CompareTo(element) < 0)
            {
                return;
            }

            base.Insert(index, element);
        }

        private int ElementOrDefault(int index, int defaultValue)
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
            int temp = base[firstIndex];
            base[firstIndex] = base[secondIndex];
            base[secondIndex] = temp;
        }
    }
}
