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

            var result = ob.Employees.Select(x => x.name);

            foreach(var item in result)
            {
                Console.Write(item);

            }

            Console.Read();
            
        }
    }
}
