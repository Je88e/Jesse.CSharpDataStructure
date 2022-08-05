using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue
{
    public static class ArrayQueueTest
    {
        public static void DoTest()
        {
            ArrayQueue<int> queue = new ArrayQueue<int>();
            queue.Enqueue(1);
            Console.WriteLine(queue.Count);

            Console.WriteLine(queue.Dequeue());

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine(i);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}