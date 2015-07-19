using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @abstract
{
  abstract class class1
    {
        public abstract void addData();

        public virtual void getData()
        {

            Console.Write("getdata abstarct");

        }


    }


    class class2 : class1
    {
        public override void addData()
        {
            Console.Write("derved add method");

        }

        public override void getData()
        {

            Console.Write("derved getdata abstarct");

        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            class2 ob1 = new class2();

          //  class1 ob2 = new class1();
            ob1.getData();
            ob1.addData();
            Console.Write("helo");
            Console.Read();
        }
    }
}
