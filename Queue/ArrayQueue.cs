using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private T[] array;
        private int head;
        private int tail;
        private int size;
        public ArrayQueue()
        {
            this.array = new T[0];
            this.size = 0;
            this.head = 0;
            this.tail = 0;
        }
        public ArrayQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("队列容量不可小于0");
            }

            this.array = new T[capacity];
            this.size = 0;
            this.head = 0;
            this.tail = 0;
        }

        public int Count => this.size;

        public void Enqueue(T item)
        {
            if (this.size == this.array.Length)
            {
                SetCapacity(this.array.Length + 4);
            }
            array[tail] = item;
            tail = (tail + 1) % array.Length;
            size++;
        }

        public T Dequeue()
        {
            if (size == 0)
            {
                return default(T);
            }

            T item = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;

            if (this.size == (int)((double)array.Length * 0.9))
            {
                SetCapacity(this.size);
            }

            size--;
            return item;
        }

        public bool isEmpty()
        {
            return this.size == 0;
        }

        private void SetCapacity(int capacity)
        {
            T[] newArray = new T[capacity];
            if (size > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, newArray, 0, size);
                }
                else
                {
                    Array.Copy(array, head, newArray, 0, array.Length - head);
                    Array.Copy(array, 0, newArray, array.Length - head, tail);
                }
            }

            array = newArray;
            head = 0;
            tail = ((size != capacity) ? size : 0);
        }
    }
}