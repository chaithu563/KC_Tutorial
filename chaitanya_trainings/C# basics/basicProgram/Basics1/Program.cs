using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics1
{
    //sealed
    class A
    {
        public virtual void m1()
        {
            Console.WriteLine("base");
        }

    }

    class B : A
    {
        public override void m1()
        {
            Console.WriteLine("derived");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            A ob1;
            ob1 = new A();
            ob1.m1();
           // ob1 = new B();

            ob1.m1();
         
           
           
            Console.Read();
        }
    }
}
