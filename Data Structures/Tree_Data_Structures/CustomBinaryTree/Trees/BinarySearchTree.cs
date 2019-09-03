using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    public Node root;
    private Node current;

    private BinarySearchTree(Node node)
    {
        this.root = node;
    }

    public Node Insert(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);

        }
        int compare = node.Value.CompareTo(value);

        if (compare > 0)
        {
            node.Left = this.Insert(node.Left, value);
        }
        else if (compare < 0)
        {
            node.Right = this.Insert(node.Right, value);
        }

        return node;
    }

    public bool Contains(T value)
    {
        Node current = this.root;
        Node parrent = null;

        while (current != null)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                parrent = current;
                current = current.Left;
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                parrent = current;
                current = current.Right;
            }
            else
            {
                break;
            }
        }
        return current != null;
    }

    public void DeleteMin()
    {
        throw new NotImplementedException();
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(item);

            if (compare > 0)
            {
                current = current.Left;
            }
            else if (compare < 0)
            {
                current = current.Right;
            }
            else
            {
                return new BinarySearchTree<T>(current);
            }
        }
        return null;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        throw new NotImplementedException();
    }

    public void EachInOrder(Node node, Action<T> action)
    {
        if (this.root == null)
        {
            return;
        }

        this.EachInOrder(this.root.Left, action);
        action(this.root.Value);
        this.EachInOrder(this.root.Right, action);


    }
    public class Node
    {
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(T value)
        {
            this.Value = value;
        }
    }

}




public class Launcher
{
    public static void Main(string[] args)
    {

    }
}



