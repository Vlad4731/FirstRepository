using System;

namespace IntegerArray
{
    public class SortedList<T> : List<T> where T: IComparable<T>
    {
        public SortedList() : base()
        {
        }

        public override void Add(T element)
        {
            ResizeArray();
            base[Count] = element;
            Count += 1;
            Sort();
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
            T temp = (T)base[firstIndex];
            base[firstIndex] = base[secondIndex];
            base[secondIndex] = temp;
        }
    }
}
