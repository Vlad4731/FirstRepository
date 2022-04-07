using System;

namespace IntegerArray
{
    public class IntArray
    {
		public readonly int[] numbers;

		public IntArray(int[] numbers)
		{
			this.numbers = numbers;
		}

		public void Add(int element)
		{
			// adaugă un nou element la sfârșitul șirului
		}

		public int Count()
		{
			throw new NotImplementedException();
			// întorce numărul de elemente din șir
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
