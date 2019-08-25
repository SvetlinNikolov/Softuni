using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Implement_an_Array_Based_Stack
{
    public class ArrayStack<T>
    {
        private T[] elements;
        public int Count { get; private set; }
        private const int InitialCapacity = 16;

        private int endIndex = 0;

        public ArrayStack()
        {
            this.elements = new T[InitialCapacity];
        }
        public ArrayStack(int initialCapacity)
        {
            this.elements = new T[initialCapacity];
        }
        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }
        public T Pop()
        {
            if (this.elements.Length == 0)
            {
                throw new InvalidOperationException("Stack empty!");
            }
            T element = this.elements[endIndex-1];
            this.Count--;
            return element;
        }
        public T[] ToArray()
        {
            T[] resultArray = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                resultArray[i] = this.elements[i];
            }

            return resultArray;
        }
        private void Grow()
        {
            T[] newElements = new T[this.elements.Length * 2];

            for (int i = 0; i < this.elements.Length; i++)
            {
                newElements[i] = this.elements[i];
            }
            this.elements = newElements;

            //dunno
            this.endIndex = this.Count ;
        }
    }
}
