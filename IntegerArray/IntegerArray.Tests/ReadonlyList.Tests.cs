using Xunit;
using System;

namespace IntegerArray.Tests
{
    public class ReadonlyListTests
    {
        static List<int> array = new List<int>();

        [Fact]
        public void Set_ReadonlyArrayException_IsCought()
        {
            array.Add(1);
            array.Add(2);

            ReadonlyList<int> readonlyArray = new ReadonlyList<int>(array);

            Assert.Throws<NotSupportedException>(() => readonlyArray[1] = 5);
        }

        [Fact]
        public void Insert_ReadonlyArrayException_IsCought()
        {

            array.Add(1);
            array.Add(2);

            ReadonlyList<int> readonlyArray = new ReadonlyList<int>(array);

            Assert.Throws<NotSupportedException>(() => readonlyArray.Insert(1, 3));
        }

        [Fact]
        public void RemoveAt_ReadonlyArrayException_IsCought()
        {
            array.Add(1);
            array.Add(2);

            ReadonlyList<int> readonlyArray = new ReadonlyList<int>(array);

            Assert.Throws<NotSupportedException>(() => readonlyArray.RemoveAt(0));
        }
    }
}
