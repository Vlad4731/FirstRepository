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
                if (!InRange(index, 1, Count - 1)
                    || value.CompareTo(base[index - 1]) != -1
                    || value.CompareTo(base[index + 1]) != 1)
                {
                    return;
                }

                base[index] = value;
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
            if (!InRange(index, 1, Count - 1)
                || element.CompareTo(base[index - 1]) != -1
                || element.CompareTo(base[index + 1]) != 1)
            {
                return;
            }

            base.Insert(index, element);
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

        private bool InRange(int value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = base[firstIndex];
            base[firstIndex] = base[secondIndex];
            base[secondIndex] = temp;
        }
    }
}
