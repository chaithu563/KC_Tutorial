using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalParam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(addData(1, 2, 3));

            Console.Read();




        }

        static int addData(int a, int b, int c = 10)
        {
            return a + b + c;
        }
    }
}
