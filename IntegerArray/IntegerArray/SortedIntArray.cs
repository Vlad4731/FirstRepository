using System;

namespace IntegerArray
{
	public class SortedIntArray : IntArray
	{
		public SortedIntArray() : base()
		{
		}

        public override int this[int index]
        {
            get => base[index];
            set => base[index] = value;
        }

    }
}
