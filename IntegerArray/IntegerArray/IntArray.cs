using System;

namespace IntegerArray
{
    public class IntArray
    {
		public int[] numbers;

		public IntArray(int[] numbers)
		{
			this.numbers = numbers;
		}

		public void Add(int element)
		{
			Array.Resize(ref numbers, numbers.Length + 1);
			numbers[^1] = element;
		}

		public int Count()
		{
			return numbers.Length;
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
			Array.Resize(ref numbers, numbers.Length + 1);

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
		}

		public void Remove(int element)
		{
			for(int i = 1; i < numbers.Length; i++)
            {
				bool match = false;

				if(numbers[i] == element)
                {
					match = true;
                }
				
				if(match == true && i < numbers.Length - 1)
                {
					numbers[i] = numbers[i + 1];
                }
            }

			Array.Resize(ref numbers, numbers.Length - 1);
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
			// șterge elementul de pe poziția dată
		}
	}
}
