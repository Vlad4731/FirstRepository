using System;

namespace IntegerArray
{
	public class IntArray
	{
		private int[] numbers;
		public int Count { get; set; }

		public IntArray()
		{
			numbers = new int[4];
		}

		public int this[int index]
		{
			get => numbers[index];
			set => numbers[index] = value;
		}


		public void Add(int element)
		{
			if ((+1) % 4 == 0)
			{
				Array.Resize(ref numbers, numbers.Length + 4);
			}

			numbers[Count] = element;
			Count += 1;
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
			Array.Resize(ref numbers, 0);
			Array.Resize(ref numbers, 4);
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
