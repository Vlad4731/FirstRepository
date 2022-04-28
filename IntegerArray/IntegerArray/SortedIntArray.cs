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
                if ((index - 1 > -1 && base[index - 1].CompareTo(value) != -1)
                    || (base[index + 1].CompareTo(value) != 1 && (index + 1) < Count))
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
            if (!CheckCondition(index, element))
            {
                return;
            }

            base.Insert(index, element);
        }

        private bool CheckCondition(int index, int element)
        {
            if (!InRange(index, 0, Count - 1))
            {
                return false;
            }

            if ((index - 1 > -1 && base[index - 1].CompareTo(element) != -1)
                || (base[index].CompareTo(element) < 1 && (index + 1) < Count))
            {
                return false;
            }

            return true;
        }

        private bool InRange(int value, int minimum, int maximum)
        {
            return value >= minimum && value <= maximum;
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
