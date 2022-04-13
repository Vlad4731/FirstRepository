using System;
using System.Collections;

namespace IntegerArray
{
	public class ObjectArray : IEnumerable
	{
		private object[] objects;
		public int Count { get; set; } = 0;

		public ObjectArray()
		{
			objects = new object[4];
		}

		public int this[int index]
		{
			get => (int)objects[index];
			set => objects[index] = value;
		}


		public virtual void Add(int element)
		{
			ResizeArray();
			objects[Count] = element;
			Count += 1;
		}

		public IEnumerator GetEnumerator();

		internal void ResizeArray()
        {
			if ((Count + 1) % 4 == 0)
			{
				Array.Resize(ref objects, objects.Length + 4);
			}
		}

		public bool Contains(object element)
		{
			return IndexOf(element) != -1;
		}

		public int IndexOf(object element)
		{
			for (int i = 0; i < Count; i++)
			{
				if (objects[i].Equals(element))
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
				Array.Resize(ref objects, objects.Length + 4);
			}

			for (int i = objects.Length - 1; i >= 0; i--)
			{
				if (i == index)
				{
					objects[i] = element;
					break;
				}

				objects[i] = objects[i - 1];
			}
		}

		public void Clear()
		{
			Count = 0;
		}

		public void Remove(object element)
		{
			for (int i = 1; i < Count; i++)
			{
				bool match = false;

				if (objects[i].Equals(element))
				{
					match = true;
					Count -= 1;
				}

				if (match == true)
				{
					objects[i] = objects[i + 1];
				}
			}

			if (Count <= objects.Length - 1)
			{
				objects[Count + 1] = 0;
			}
		}

		public void RemoveAt(int index)
		{
			Remove(objects[index]);
		}
	}
}
