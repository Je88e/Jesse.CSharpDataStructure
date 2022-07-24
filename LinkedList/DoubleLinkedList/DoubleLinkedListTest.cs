using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedList.DoubleLinkedList
{
    public static class DoubleLinkedListTest
    {
        public static void DoTest()
        {
            DoubleLinkedList<int> linkedList = new DoubleLinkedList<int>();
            // Test1:顺序插入4个节点
            linkedList.Add(0);
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            Console.WriteLine("The nodes in the DoubleLinkedList:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            // Test2.1:在索引为2(即第3个节点)的位置之后插入单个节点
            linkedList.InsertAfter(2, 50);
            Console.WriteLine("After add 50:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test2.2:在索引为2(即第3个节点)的位置之前插入单个节点
            linkedList.InsertBefore(2, 40);
            Console.WriteLine("Before add 40:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            // Test3.1:移除索引为7(即最后一个节点)的位置的节点
            linkedList.Remove(7);
            Console.WriteLine("After remove an node in index of 7:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test3.2:移除索引为0(即第一个节点)的位置的节点的值
            linkedList.Remove(0);
            Console.WriteLine("After remove an node in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            // Test3.3:移除索引为2(即第3个节点)的位置的节点
            linkedList.Remove(2);
            Console.WriteLine("After remove an node in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            // Test4:修改索引为2(即第3个节点)的位置的节点的值
            linkedList[2] = 9;
            Console.WriteLine("After update the value of node in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.Write(linkedList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
        }
    }
}