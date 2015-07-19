using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{

    interface IA
    {
        void add();
    }

    interface IB
    {

        void add();
    }

   public class A :IA
    {
        public void add()
        {
            Console.Write("add A: IA");
        }

    }

    class B : A
    {
        public void add()
        {
            Console.Write("add B: IA");
        }

    }

    class C : A,IA,IB 
    {
        public new void add()
        {
            Console.Write("add B: IA");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("diamnod prog");
            IA ob = new C();
            ob.add();
            Console.Read();

        }
    }
}
