using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    public class Box<T>
    {
        private List<T> boxValues;

        public Box()
        {
            boxValues = new List<T>();
        }
        public void Add(T item)
        {
            boxValues.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in boxValues)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString();

        }
    }
}
