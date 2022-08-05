using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueNode<T>
    {
        public QueueNode<T> Next { get; set; }
        public T value { get; set; }
        public QueueNode()
        {

        }
        public QueueNode(T _value)
        {
            this.value = _value;
        }
    }
    public class LinkedListQueue<T> : IQueue<T>
    {
        private int size;
        private QueueNode<T> head;
        private QueueNode<T> tail;
        public int Count => this.size;
        public T Dequeue()
        {
            T result = head.value;
            this.head = head.Next;
            size--;
            
            if (size == 0)
            {
                this.tail = null;
                return default(T);
            }
            
            return result;
        }

        public void Enqueue(T item)
        {
            QueueNode<T> tailPrev = this.tail;
            tail = new QueueNode<T>(item);
            if (size == 0)
            {
                head = tail;
            }
            else
            {
                tailPrev.Next = tail;
            }

            size++;
        }

        public bool isEmpty()
        {
            return this.size == 0;
        }
    }
}