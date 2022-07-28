using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stack
{
    public static class ArrayStackTest
    {
        public static void DoTest(){
            ArrayStack<int> stack = new ArrayStack<int>(10);

            Console.Write("Push:");

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int num = rand.Next(1, 10);
                stack.Push(num);
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            
            Console.WriteLine("ToArray:" + String.Join(' ',stack.ToArray()));

            Console.Write("Pop:");
            for (int i = 0; i < 10; i++)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
            }
            Console.WriteLine();
            
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < 15; i++)
            {
                int num = rand.Next(1, 15);
                stack.Push(num);
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            
            Console.WriteLine("ToArray:" + String.Join(' ',stack.ToArray()));
            
            Console.Write("Pop:");
            for (int i = 0; i < 15; i++)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
            }
            Console.WriteLine();
            
            Console.WriteLine("-------------------------------");
        }

    }
}