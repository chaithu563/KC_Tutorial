using System;
using System.Collections;
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

      public  Data(int a1, int b1)
        {
            this.a = a1;
            this.b = b1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           // IEnumerable<Data> ob = new List<Data>();
            List<Data> ob = new List<Data>();
            ob.Add(new Data(1, 2));
            ob.Add(new Data(2, 2));
            ob.Add(new Data(3, 2));
            ob.Add(new Data(4, 2));

            //LINQ

            var aitems = ob.Where(x => x.b==2);
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, };
          
       
            int maxnumber = arr.Max();

            //ArrayList



          //  Console.Write(max);
            Console.Read();

        }
    }
}
