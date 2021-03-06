﻿using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 16;
    private T[] elements;

    private int startIndex = 0;
    private int endIndex = 0;

    public int Count { get; private set; }

    public CircularQueue()
    {
        this.elements = new T[DefaultCapacity];
    }
    public CircularQueue(int initialCapacity)
    {

        this.elements = new T[initialCapacity];
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.endIndex] = element;
        this.endIndex = (this.endIndex + 1) % this.elements.Length;
        this.Count++;
    }

    private void Grow()
    {
        T[] newElements = new T[this.elements.Length * 2];

        this.CopyAllElementsTo(newElements);

        this.elements = newElements;
        this.startIndex = 0;
        this.endIndex = this.Count;
    }

    private void CopyAllElementsTo(T[] resultArr)
    {
        int sourceIndex = this.startIndex;
        int destinationIndex = 0;

        for (int i = 0; i < this.Count; i++)
        {
            resultArr[destinationIndex] = this.elements[sourceIndex];
            sourceIndex = (sourceIndex + 1) % this.elements.Length;
            destinationIndex++;
        }
    }

    private void Resize()
    {
        T[] copy = new T[this.elements.Length / 2];

        for (int i = 0; i < this.Count; i++)
        {
            copy[i] = this.elements[i];
        }
        this.elements = copy;

    }



    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Cannot remove from empty queue!");
        }

        var result = this.elements[this.startIndex];
        this.startIndex = (this.startIndex + 1) % this.elements.Length;

        this.Count--;

        return result;
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
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
