using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {

            chaitanyaEntities ob = new chaitanyaEntities();

           // var result = ob.Employees.Where(x => x.salary > 10000).Select(x => x.name);

            var result = from v in ob.Employees
                         where v.salary>10000
                         select
                         new
                         {
                             v.name 

                         }
                       ;

            foreach (var item in result)
            {
                Console.WriteLine(item);

            }

            Console.Read();
            
        }
    }
}
