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
			throw new NotImplementedException();
			// întoarce elementul de la indexul dat
		}

		public void SetElement(int index, int element)
		{
			throw new NotImplementedException();
			// modifică valoarea elementului de la indexul dat
		}

		public bool Contains(int element)
		{
			throw new NotImplementedException();
			// întoarce true dacă elementul dat există în șir
		}

		public int IndexOf(int element)
		{
			throw new NotImplementedException();
			// întoarce indexul elementului sau -1 dacă elementul nu se
			// regăsește în șir
		}

		public void Insert(int index, int element)
		{
			throw new NotImplementedException();
			// adaugă un nou element pe poziția dată
		}

		public void Clear()
		{
			throw new NotImplementedException();
			// șterge toate elementele din șir
		}

		public void Remove(int element)
		{
			throw new NotImplementedException();
			// șterge prima apariție a elementului din șir	
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
			// șterge elementul de pe poziția dată
		}
	}
}
