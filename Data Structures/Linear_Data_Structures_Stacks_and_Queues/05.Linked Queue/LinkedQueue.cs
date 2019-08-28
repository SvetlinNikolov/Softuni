using System;


namespace _05.Linked_Queue
{
    public class LinkedQueue<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;
        public int Count { get; private set; }
        public void Enqueue(T element)
        {
            QueueNode<T> newNode = new QueueNode<T>(element);
            newNode.NextNode = this.head;
            newNode.PrevNode = null;

            if (this.head != null)
            {
                this.head.PrevNode = newNode;
            }

            this.head = newNode;

            if (this.Count == 0)
            {
                this.tail = this.head;
            }

            this.Count++;
        }
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            T tailValue = this.tail.Value;
            this.tail = this.tail.PrevNode;
            this.Count--;
            return tailValue;

        }
        public T[] ToArray()
        {
            T[] resultArray = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                resultArray[i] = this.head.Value;
                this.head = this.head.NextNode;
            }

            return resultArray;
        }
        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }
            public QueueNode(T value)
            {
                this.Value = value;
            }
        }
    }
}

