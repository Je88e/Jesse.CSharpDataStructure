using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedList.DoubleLinkedList
{
    /// <summary>
    /// LinkedList<T>为.Net的双链表实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DNode<T>
    {
        public T item { get; set; }
        public DNode<T> Prev { get; set; }
        public DNode<T> Next { get; set; }
        public DNode()
        {

        }
        public DNode(T item)
        {
            this.item = item;
        }

    }
    public class DoubleLinkedList<T>
    {
        private int count { get; set; }
        private DNode<T> head { get; set; }

        public DoubleLinkedList()
        {
            this.count = 0;
            this.head = null;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.GetNodeByIndex(index).item;
            }
            set
            {
                this.GetNodeByIndex(index).item = value;
            }
        }

        /// <summary>
        /// 根据索引获取元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private DNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            DNode<T> tempNode = this.head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        /// <summary>
        /// 双链表添加元素
        /// </summary>
        public void Add(T value)
        {
            DNode<T> newNode = new(value);
            if (head == null)
            {
                this.head = newNode;
            }
            else
            {
                DNode<T> trailNode = this.GetNodeByIndex(count - 1);
                trailNode.Next = newNode;
                newNode.Prev = trailNode;
            }
            this.count++;
        }

        /// <summary>
        /// 指定位置前插入元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void InsertBefore(int index, T value)
        {
            DNode<T> newNode = new(value);
            if (index == 0)
            {
                if (head == null)
                {
                    this.head = newNode;
                }
                else
                {
                    this.head.Prev = newNode;
                    newNode.Next = this.head;
                    this.head = newNode;
                }
            }
            else
            {
                DNode<T> indexNode = this.GetNodeByIndex(index);

                newNode.Prev = indexNode.Prev;
                indexNode.Prev.Next = newNode;

                newNode.Next = indexNode;
                indexNode.Prev = newNode;
            }
            this.count++;
        }

        /// <summary>
        /// 指定位置后插入元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void InsertAfter(int index, T value)
        {
            DNode<T> newNode = new(value);
            if (index == 0 && this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                DNode<T> indexNode = this.GetNodeByIndex(index);

                if (indexNode.Next != null)
                {
                    newNode.Next = indexNode.Next;
                    indexNode.Next.Prev = newNode;
                }

                newNode.Prev = indexNode;
                indexNode.Next = newNode;
            }
            this.count++;
        }

        public void Remove(int index)
        {
            if (index == 0)
            {
                this.head = this.head.Next;
            }
            else
            {
                //DNode<T> removeNode = GetNodeByIndex(index);

                // if (removeNode.Prev != null)
                // {
                //     removeNode.Prev.Next = removeNode.Next;
                //     removeNode.Next.Prev = removeNode.Prev;
                // }

                // if (removeNode.Next != null)
                // {
                //     removeNode.Next.Prev = removeNode.Prev;
                //     removeNode.Prev.Next = removeNode.Next;
                // }

                //prevNode的Index至少为1,所以不为空 
                DNode<T> prevNode = this.GetNodeByIndex(index - 1);
                DNode<T> removeNode = prevNode.Next;
                if (removeNode == null)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围"); 
                }
                
                prevNode.Next = removeNode.Next;
                if (removeNode.Next != null)
                {
                    removeNode.Prev = prevNode;
                }

                removeNode = null;
            }
            count--;
        }
    }
}