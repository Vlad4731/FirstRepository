using System;

namespace IntegerArray
{
    public class IntArray
    {
		private int[] numbers = { 0, 0, 0, 0 };
		private int arrayIndex = 0;

		public IntArray(int[] numbers)
		{
			this.numbers = numbers;
		}

		public void Add(int element)
		{
			if ((arrayIndex + 1) % 4 == 0)
			{
				Array.Resize(ref numbers, numbers.Length + 4);
			}

			numbers[arrayIndex] = element;
			arrayIndex += 1;
		}

		public int Count()
		{
			return arrayIndex;
		}

		public int Element(int index)
		{
			return numbers[index];
		}

		public void SetElement(int index, int element)
		{
			numbers[index] = element;
		}

		public bool Contains(int element)
		{
			foreach (int n in numbers)
			{
				if (n == element)
				{
					return true;
				}
			}

			return false;
		}

		public int IndexOf(int element)
		{
			for (int i = 0; i < numbers.Length; i++)
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
			if ((arrayIndex + 1) % 4 == 0)
			{
				Array.Resize(ref numbers, numbers.Length + 4);
			}

			for (int i = numbers.Length - 1; i >= 0; i--)
            {
				if(i == index)
                {
					numbers[i] = element;
					break;
                }
				numbers[i] = numbers[i - 1];
            }
		}

		public void Clear()
		{
			Array.Resize(ref numbers, 0);
			Array.Resize(ref numbers, 4);
			arrayIndex = 0;
		}

		public void Remove(int element)
		{
			for(int i = 1; i < numbers.Length; i++)
            {
				bool match = false;

				if (numbers[i] == element)
                {
					match = true;
					arrayIndex -= 1;
				}
				
				if (match == true)
                {
					numbers[i] = numbers[i + 1];
                }
			}

			if (arrayIndex <= numbers.Length - 1)
			{
				numbers[arrayIndex + 1] = 0;
			}
		}

		public void RemoveAt(int index)
		{
			Remove(numbers[index]);
		}
	}
}
