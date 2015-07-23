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

            //var result = from v in ob.Employees
            //             where v.salary>10000
            //             select
            //             new
            //             {
            //                 v.name 

            //             }
            //           ;


            //var update = ob.Employees.Where(x => x.salary == 10000).Single();

            //update.name = "changesname";

            //ob.SaveChanges();
            //var result = ob.Employees.Select(x => new { x.name,x.salary });


            ob.Employees.Add(new Employee { id = 4, name = "testadd", salary = 11000 });

            ob.SaveChanges();
            var result = ob.Employees.Select(x => new { x.name, x.salary });
            Console.Read();
            
        }
    }
}
