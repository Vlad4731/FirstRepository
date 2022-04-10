using System;

namespace IntegerArray
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }
		public override void Add(int element)
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
            int temp = base[firstIndex];
            base[firstIndex] = base[secondIndex];
            base[secondIndex] = temp;
        }
    }
}
