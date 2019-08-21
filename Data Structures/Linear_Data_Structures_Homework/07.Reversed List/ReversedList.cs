using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseList
{
    public class ReversedList<T>
    {
        private T[] array;
        private const int Initial_Capacity = 2;

        public ReversedList()
        {
            this.array = new T[Initial_Capacity];
        }
        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index > this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }
                return this.array[this.Count - index - 1];
            }

            set
            {
                if (index > this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }
                this.array[this.Count - index - 1] = value;
            }
        }

        public void Add(T item)
        {
            if (this.Count == this.array.Length)
            {
                this.Resize();
            }
            this.array[this.Count++] = item;
        }

        private void Resize()
        {
            T[] copy = new T[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                copy[i] = this.array[i];
            }

            this.array = copy;
        }

        public T RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            T element = this.array[this.Count - index - 1];
            this.array[index] = default(T);
            this.Shift(index);
            this.Count--;

            if (this.Count <= this.array.Length / 4)
            {
                this.Shrink();
            }
            return element;
        }

        private void Shrink()
        {
            T[] copy = new T[this.array.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.array[i];
            }
            this.array = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count-1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
        }
    }
}