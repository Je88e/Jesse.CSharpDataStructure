using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tree
{
    public class TNode<T>
    {
        public T value { get; set; }
        public TNode<T> lChild { get; set; }
        public TNode<T> rChild { get; set; }
        public TNode() { }
        public TNode(T _value)
        {
            this.value = _value;
        }
        public TNode(T _value, TNode<T> _lChild, TNode<T> _rChild)
        {
            this.value = _value;
            this.lChild = _lChild;
            this.rChild = _rChild;
        }
    }
    public class BinaryTree<T>
    {
        private TNode<T> root;
        public TNode<T> Root
        {
            get
            {
                return this.root;
            }
        }
        public BinaryTree() { }
        public BinaryTree(T value)
        {
            this.root = new TNode<T>(value);
        }
        public bool isEmpty()
        {
            return this.root == null;
        }
        public void InsertLeft(TNode<T> node, T value)
        {
            //成为该节点的左孩子节点
            TNode<T> insertNode = new TNode<T>(value);
            node.lChild = insertNode.lChild;

            node.lChild = insertNode;
        }
        public void InsertRight(TNode<T> node, T value)
        {
            TNode<T> insertNode = new TNode<T>(value);
            node.rChild = insertNode.rChild;

            node.rChild = insertNode;
        }
        public void RemoveLeft(TNode<T> node)
        {
            if (node is null || node.lChild is null)
            {
                return;
            }
            node.lChild = null;
        }
        public void RemoveRight(TNode<T> node)
        {
            if (node is null || node.rChild is null)
            {
                return;
            }
            node.rChild = null;
        }
        public bool IsLeafNode(TNode<T> node)
        {
            if (node is null)
            {
                throw new ArgumentNullException("节点为空");
            }
            return node.lChild is null && node.rChild is null;
        }
        public int GetDepth(TNode<T> root)
        {
            if (root is null)
            {
                return 0;
            }

            int leftDepth = GetDepth(root.lChild);
            int rightDepth = GetDepth(root.rChild);

            return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1;
        }

        #region 递归遍历
        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> PreOrder(TNode<T> node)
        {
            if (!(node is null))
            {
                // 根->左->右
                yield return node.value;
                PreOrder(node.lChild);
                PreOrder(node.rChild);
            }
        }
        public IEnumerable<T> PreOrderForWriteLine(List<T> list,TNode<T> node)
        {
            if (!(node is null))
            {
                // 根->左->右
                list.Add(node.value);
                PreOrderForWriteLine(list,node.lChild);
                PreOrderForWriteLine(list,node.rChild);
            }
            return list;
        }
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        /// 递归无法使用迭代器，该写法无效，使用MidOrderForWriteLine
        public IEnumerable<T> MidOrder(TNode<T> node)
        {
            if (!(node is null))
            {
                // 左->根->右
                MidOrder(node.lChild);
                yield return node.value;
                MidOrder(node.rChild);
            }
        }
        public IEnumerable<T> MidOrderForWriteLine(List<T> list,TNode<T> node)
        {
            if (!(node is null))
            {
                // 左->根->右
                MidOrderForWriteLine(list,node.lChild);
                list.Add(node.value);
                MidOrderForWriteLine(list,node.rChild);
            }
            return list;
        }
        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> PostOrder(TNode<T> node)
        {
            if (!(node is null))
            {
                // 左->右->根
                PostOrder(node.lChild);
                PostOrder(node.rChild);
                yield return node.value;
            }
        }
        public IEnumerable<T> PostOrderForWriteLine(List<T> list,TNode<T> node)
        {
            if (!(node is null))
            {
                // 左->右->根
                PostOrderForWriteLine(list,node.lChild);
                PostOrderForWriteLine(list,node.rChild);
                list.Add(node.value);
            }
            return list;
        }
        #endregion

        #region 基本非递归遍历
        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> PreOrderNoRecurise(TNode<T> node)
        {
            if (node is null)
            {
                throw new ArgumentException("节点为空");
            }
            // 根->左->右
            Stack<TNode<T>> stack = new Stack<TNode<T>>();
            stack.Push(node);
            TNode<T> tempNode = null;

            while (stack.Count > 0)
            {
                // 1.遍历根节点
                tempNode = stack.Pop();
                yield return tempNode.value;
                // 2.右子树压栈
                if (tempNode.rChild != null)
                {
                    stack.Push(tempNode.rChild);
                }
                // 3.左子树压栈(目的：保证下一个出栈的是左子树的节点)
                if (tempNode.lChild != null)
                {
                    stack.Push(tempNode.lChild);
                }
            }
        }
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> MidOrderNoRecurise(TNode<T> node)
        {
            if (node is null)
            {
                throw new ArgumentException("节点为空");
            }
            // 左->根->右
            Stack<TNode<T>> stack = new Stack<TNode<T>>();
            TNode<T> tempNode = node;

            while (!(tempNode is null) || stack.Count > 0)
            {
                //1、一次将所有左子树节点压栈
                while (!(tempNode is null))
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.lChild;
                }
                //2、出栈遍历节点
                tempNode = stack.Pop();
                yield return tempNode.value;
                //3、左子树遍历结束则跳转到右子树
                tempNode = tempNode.rChild;
            }
        }
        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> PostOrderNoRecurise(TNode<T> node)
        {
            if (node == null)
            {
                throw new NullReferenceException("节点为空");
            }

            // 左->右->根
            Stack<TNode<T>> stackIn = new Stack<TNode<T>>();
            Stack<TNode<T>> stackOut = new Stack<TNode<T>>();
            TNode<T> currentNode = null;
            //根节点压栈
            stackIn.Push(node);
            while (stackIn.Count > 0)
            {
                currentNode = stackIn.Pop();
                stackOut.Push(currentNode);
                //左子树压栈
                if (!(currentNode.lChild is null))
                {
                    stackIn.Push(currentNode.lChild);
                }
                //右子树压栈
                if (!(currentNode.rChild is null))
                {
                    stackIn.Push(currentNode.rChild);
                }
            }

            while (stackOut.Count > 0)
            {
                TNode<T> outNode = stackOut.Pop();
                yield return outNode.value;
            }
        }
        /// <summary>
        /// 层次遍历（广度优先遍历）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IEnumerable<T> LevelOrder(TNode<T> node)
        {
            if (node == null)
            {
                throw new NullReferenceException("节点为空");
            }

            Queue<TNode<T>> queue = new Queue<TNode<T>>();
            queue.Enqueue(node);
            TNode<T> tempNode = null;
            //FIFO
            while (queue.Count > 0)
            {
                tempNode = queue.Dequeue();
                yield return tempNode.value;
                if (!(tempNode.lChild is null))
                {
                    queue.Enqueue(tempNode.lChild);
                }
                if (!(tempNode.rChild is null))
                {
                    queue.Enqueue(tempNode.rChild);
                }
            }
        }
        #endregion
    }
}