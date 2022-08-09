using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tree
{
    public static class BinaryTreeTest
    {
        public static void DoTest()
        {
            // 构造一颗二叉树，根节点为"A"
            BinaryTree<string> bTree = new BinaryTree<string>("A");
            TNode<string> rootNode = bTree.Root;
            // 向根节点"A"插入左孩子节点"B"和右孩子节点"C"
            bTree.InsertLeft(rootNode, "B");
            bTree.InsertRight(rootNode, "C");
            // 向节点"B"插入左孩子节点"D"和右孩子节点"E"
            TNode<string> nodeB = rootNode.lChild;
            bTree.InsertLeft(nodeB, "D");
            bTree.InsertRight(nodeB, "E");
            // 向节点"C"插入右孩子节点"F"
            TNode<string> nodeC = rootNode.rChild;
            bTree.InsertRight(nodeC, "F");
            // 计算二叉树目前的深度
            Console.WriteLine("The depth of the tree : {0}", bTree.GetDepth(bTree.Root));
            
            List<string> list = new List<string>();
            // 前序遍历
            Console.WriteLine("---------PreOrder---------");
            list.Clear();
            foreach (string value in bTree.PreOrderForWriteLine(list,bTree.Root))
            {
                Console.Write(value);
            }
            // 中序遍历
            Console.WriteLine();
            Console.WriteLine("---------MidOrder---------");
            list.Clear();
            foreach (string value in bTree.MidOrderForWriteLine(list,bTree.Root))
            {
                Console.Write(value);
            }
            // 后序遍历
            Console.WriteLine();
            Console.WriteLine("---------PostOrder---------");
            list.Clear();
            foreach (string value in bTree.PostOrderForWriteLine(list,bTree.Root))
            {
                Console.Write(value);
            }
            // 前序遍历（非递归）
            Console.WriteLine();
            Console.WriteLine("---------PreOrderNoRecurise---------");
            foreach (string value in bTree.PreOrderNoRecurise(bTree.Root))
            {
                Console.Write(value);
            }
            // 中序遍历（非递归）
            Console.WriteLine();
            Console.WriteLine("---------MidOrderNoRecurise---------"); 
            foreach (string value in bTree.MidOrderNoRecurise(bTree.Root))
            {
                Console.Write(value);
            }
            // 后序遍历（非递归）
            Console.WriteLine();
            Console.WriteLine("---------PostOrderNoRecurise---------"); 
            foreach (string value in bTree.PostOrderNoRecurise(bTree.Root))
            {
                Console.Write(value);
            }
            // 层次遍历
            Console.WriteLine();
            Console.WriteLine("---------LevelOrderNoRecurise---------"); 
            foreach (string value in bTree.LevelOrder(bTree.Root))
            {
                Console.Write(value);
            }
            Console.WriteLine();
        }
    }
}