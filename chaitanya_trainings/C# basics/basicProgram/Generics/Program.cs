using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class A<T,T2,T3>
    {
        T a;
        T2 b;
        public T3 add(T3 v)
        {
            T3 val;
            val = v;
            return val;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            A<int,string, int> ob = new A<int,string, int>();


        }
    }
}
