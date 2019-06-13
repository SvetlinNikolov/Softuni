using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Tuple<T, V, W>
    {
        public T item1 { get; set; }
        public V item2 { get; set; }
        public W item3 { get; set; }
        public Tuple(T item1, V item2, W item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }
        public string GetInfo()
        {
            return $"{this.item1} -> {this.item2} -> {this.item3}";
        }


    }
}
