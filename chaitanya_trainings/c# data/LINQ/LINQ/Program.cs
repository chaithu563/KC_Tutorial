using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Data
    {
       public int a;
       public int b;

      public  Data(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           // IEnumerable<Data> ob = new List<Data>();
            List<Data> ob = new List<Data>();
            ob.Add(new Data(1,2));
            ob.Add(new Data(2, 2));
            ob.Add(new Data(3, 2));
            ob.Add(new Data(4, 2));

            //LINQ

            var max = ob.Max(x => x.a);

            Console.Write(max);
            Console.Read();

        }
    }
}
