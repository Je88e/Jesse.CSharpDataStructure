using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stack
{
    /// <summary>
    /// 基于数组的栈实现
    /// </summary>
    public class ArrayStack<T> : IStack<T>
    {
        private T[] nodes;
        private int size;
        public ArrayStack(int capacity)
        {
            this.nodes = new T[capacity];
            this.size = 0;
        }
        public ArrayStack()
        {
            this.nodes = new T[4];
            this.size = 0;
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="node">入栈元素</param>
        public void Push(T node)
        {
            if (size == nodes.Length)
            {
                T[] _nodes = new T[(nodes.Length == 0) ? 4 : (nodes.Length * 2)];
                Array.Copy(nodes, 0, _nodes, 0, size);
                nodes = _nodes;
            }
            nodes[size] = node;
            size++;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (size == 0)
            {
                return default(T);
            }
            if (size == nodes.Length / 4)
            {
                T[] _nodes = new T[(nodes.Length == 0) ? 4 : (nodes.Length / 2)];
                Array.Copy(nodes, 0, _nodes, 0, size);
                nodes = _nodes;
            }
            T node = nodes[size - 1];
            size--;
            nodes[size] = default(T);

            return node;

        }

        /// <summary>
        /// 反转输出数组
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] array = new T[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = nodes[size - i - 1];
            }

            return array;
        }

        public bool isEmpty()
        {
            return nodes.Length == 0;
        }

        public int Count { get { return this.size; } }
    }
}