using System;

namespace IntegerArray
{
	public class IntArray
	{
		private int[] numbers;
		public int Count { get; set; } = 0;

		public IntArray()
		{
			numbers = new int[4];
		}

		public int this[int index]
		{
			get => numbers[index];
			set => numbers[index] = value;
		}


		public virtual void Add(int element)
		{
			ResizeArray();
			numbers[Count] = element;
			Count += 1;
		}

		internal void ResizeArray()
        {
			if ((Count + 1) % 4 == 0)
			{
				Array.Resize(ref numbers, numbers.Length + 4);
			}
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
			if ((Count + 1) % 4 == 0)
			{
				Array.Resize(ref numbers, numbers.Length + 4);
			}

			for (int i = numbers.Length - 1; i >= 0; i--)
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
			for (int i = 1; i < numbers.Length; i++)
			{
				bool match = false;

				if (numbers[i] == element)
				{
					match = true;
					Count -= 1;
				}

				if (match == true)
				{
					numbers[i] = numbers[i + 1];
				}
			}

			if (Count <= numbers.Length - 1)
			{
				numbers[Count + 1] = 0;
			}
		}

		public void RemoveAt(int index)
		{
			Remove(numbers[index]);
		}
	}
}
