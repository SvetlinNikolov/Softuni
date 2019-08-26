using System;
using System.Collections.Generic;
using System.Text;

namespace _04.LinkedStack
{
    public class LinkedStack<T>
    {

        private Node<T> firstNode;

        public int Count { get; private set; }
        public void Push(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = new Node<T>(element, null);
            }
            else
            {
                Node<T> newFirstNode = new Node<T>(element, firstNode);

                this.firstNode = newFirstNode;
            }

            this.Count++;
        }
        public T Pop()
        {
            if (this.firstNode == null)
            {
                throw new InvalidOperationException("Stack Empty!");
            }

            T firstNodeValue = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;
            return firstNodeValue;

        }
        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            int counter = 0;

            Node<T> currentNode = this.firstNode;

            while (currentNode != null)
            {
                result[counter] = currentNode.Value;
                counter++;
                currentNode = currentNode.NextNode;
            }

            return result;
        }
        private class Node<T>
        {
            public T Value;
            public Node<T> NextNode { get; set; }
            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
        }

    }

}
