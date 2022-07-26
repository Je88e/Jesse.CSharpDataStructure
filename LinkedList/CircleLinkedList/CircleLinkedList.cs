using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LinkedList.CircleLinkedList
{
    public class CNode<T>
    {
        public T Item { get; set; }
        public CNode<T> Prev { get; set; }
        public CNode<T> Next { get; set; }

        public CNode()
        {

        }

        public CNode(T Item)
        {
            this.Item = Item;
        }

        internal void Invaildate()
        {
            this.Item = default(T);
            this.Prev = null;
            this.Next = null;
        }
    }
    public class CircleLinkedList<T>
    {
        private int count { get; set; }
        private CNode<T> head { get; set; }
        private CNode<T> current { get; set; }

        public CircleLinkedList()
        {

        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public CNode<T> Current
        {
            get
            {
                return this.current;
            }
        }

        public bool IsEmpty()
        {
            return this.head is null;
        }
        private CNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            CNode<T> tempNode = this.head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        public void Add(T Item)
        {
            CNode<T> newNode = new CNode<T>(Item);
            if (this.head == null)
            {
                this.head = newNode;
                newNode.Next = newNode;
                newNode.Prev = newNode;
                this.current = newNode;
            }
            else
            {
                CNode<T> trailNode = this.head.Prev;
                newNode.Prev = trailNode;
                trailNode.Next = newNode;
                this.head.Prev = newNode;
                newNode.Next = head;
            }
            count++;
        }
        /// <summary>
        /// Remove Current Item
        /// </summary>
        /// <returns></returns>
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException("No Item In LinkedList");
            }
            CNode<T> removeNode = this.current;
            if (removeNode == removeNode.Next)
            {
                this.head = null;
            }
            else
            {
                if (removeNode == this.head)
                {
                    this.head = this.head.Next;
                }
                if (removeNode == this.current)
                {
                    this.current = this.current.Next;
                }
                removeNode.Prev.Next = removeNode.Next;
                removeNode.Next.Prev = removeNode.Prev;
            }
            removeNode.Invaildate();
            count--;
        }
        public void MoveNext()
        {
            this.current = this.current.Next;
        }

        public CNode<T> First
        {
            get
            {
                return this.head;
            }
        }
    }
}