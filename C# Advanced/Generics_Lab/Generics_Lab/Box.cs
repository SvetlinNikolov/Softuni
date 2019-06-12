using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            boxItems = new List<T>();
        }

        private List<T> boxItems;
        public int Count
        {
            get
            {
                return boxItems.Count;
            }
        }
        public void Add(T element)
        {
            boxItems.Add(element);
        }
        public T Remove()
        {
            if (boxItems.Count > 0)
            {
                T elementToRemove = boxItems[Count - 1];
                return elementToRemove;
            }
            throw new InvalidOperationException();

        }

    }
}
