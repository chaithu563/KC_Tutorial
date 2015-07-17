using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{


    interface IPerson
    {

         void setSalary(int sal);

    }

    class ContractEmployee : IPerson
    {

        private int salary;

        public void setSalary(int sal)
        {
            this.salary = sal;

        }


    }

    class PermenanetEmployee : IPerson
    {
        private int salary;

        //public void setSalary(int sal)
        //{
        //    this.salary = sal;
        //}

    }

    class Program
    {
        static void Main(string[] args)
        {
            IPerson ob;

            ob = new ContractEmployee();
           // ob.salary = 100;

            ob.setSalary(1000);

            //Console.WriteLine(ob.salary);

            ob = new PermenanetEmployee();
        }
    }
}
