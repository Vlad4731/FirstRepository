﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegerArray
{
    public class List<T> : IList<T>
    {
        private T[] objects;

        public List()
        {
            objects = new T[4];
        }

        public int Count { get; set; }

        public bool IsReadOnly { get; }

        public T this[int index]
        {
            get => objects[index];
            set => objects[index] = value;
        }

        public virtual void Add(T item)
        {
            EnsureCapacity();
            objects[Count] = item;
            Count++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return objects.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return objects[i];
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (objects[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if ((Count + 1) % 4 == 0)
            {
                Array.Resize(ref objects, objects.Length + 4);
            }

            for (int i = objects.Length - 1; i >= 0; i--)
            {
                if (i == index)
                {
                    objects[i] = item;
                    break;
                }

                objects[i] = objects[i - 1];
            }
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Remove(T item)
        {
            bool match = false;

            for (int i = 1; i < Count; i++)
            {

                if (objects[i].Equals(item))
                {
                    match = true;
                    Count--;
                }

                if (match)
                {
                    objects[i] = objects[i + 1];
                }
            }

            if (Count <= objects.Length - 1)
            {
                objects[Count + 1] = default;
            }

            return match;
        }

        public void RemoveAt(int index)
        {
            Remove(objects[index]);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex] = this[i];
                arrayIndex++;
            }
        }

        internal void EnsureCapacity()
        {
            if ((Count + 1) % 4 != 0)
            {
                return;
            }

            Array.Resize(ref objects, objects.Length + 4);
        }
    }
}