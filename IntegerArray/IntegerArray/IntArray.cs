using System;

namespace IntegerArray
{
    public class IntArray
    {
        private const byte ArraySizeFactor = 2;
        private int[] numbers;

        public IntArray()
        {
            numbers = new int[ArraySizeFactor * ArraySizeFactor];
        }

        public int Count { get; set; }

        public int this[int index]
        {
            get => numbers[index];
            set => numbers[index] = value;
        }

        public virtual void Add(int element)
        {
            EnsureCapacity();
            numbers[Count] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (numbers[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            EnsureCapacity();

            for (int i = Count - 1; i >= 0; i--)
            {
                if (i == index)
                {
                    numbers[i] = element;
                    break;
                }

                numbers[i] = numbers[i - 1];
            }
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                this[i] = this[i + 1];
            }

            Count--;
        }

        internal void EnsureCapacity()
        {
            if ((Count + 1) % ArraySizeFactor * ArraySizeFactor != 0)
            {
                return;
            }

            Array.Resize(ref numbers, numbers.Length * ArraySizeFactor);
        }
    }
}