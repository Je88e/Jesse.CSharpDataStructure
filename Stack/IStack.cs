using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stack
{
    public interface IStack<T>
    {
        bool isEmpty();
        void Push(T item);
        T Pop();
        int Count { get; }
    }
}