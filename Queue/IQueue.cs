using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queue
{
    public interface IQueue<T>
    {
        //FIFO First In First Out 
        void Enqueue(T item);
        T Dequeue();
        bool isEmpty();
        int Count { get; }

    }
}