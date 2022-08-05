using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stack
{
    public class StackNode<T> 
    {
        public T Item { get; set; }
        public StackNode<T> Next { get; set; }
        public StackNode(T _Item)
        {
            this.Item = _Item;
        }
        public StackNode()
        {
        }
    }
    public class LinkedListStack<T> : IStack<T>
    {
        private StackNode<T> top;
        private int size;
        public LinkedListStack()
        {
            this.top = null;
            this.size = 0;
        }

        public bool isEmpty()
        {
            return this.size == 0;
        }
        
        public T Pop()
        { 
            StackNode<T> topNode = this.top;
            this.top = topNode.Next;
            size--;

            return topNode.Item;
        }

        public void Push(T item)
        {
            StackNode<T> newNode = new StackNode<T>(item);
            StackNode<T> topNode = this.top;
            newNode.Next = topNode;
            this.top = newNode;
            size++;
        }
        
        public int Count { get { return this.size; } }
    }
}