using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{

    struct Employee1
    {
      public   int id;

      public  string name;
        public Employee1(int _id, string _name)
        {
            id = _id;
            name = _name;

        }

    }

    class Employee2
    {
       public int id;
       public string name;
        public Employee2(int _id, string _name)
        {
            id = _id;
            name = _name;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //struct
            Employee1 ob1 = new Employee1(1, "chaitanya");

            chnageValue1(ob1);

            Console.WriteLine(ob1.name);

            //class
            Employee2 ob2 = new Employee2(1, "chaitanya");

            chnageValue2(ob2);


            Console.WriteLine(ob1.name);
        }

        //class
        public static void chnageValue2(Employee2 emp)
        {
            emp.name="chnagedChaitanya2";
        }

        //strct
        public static void chnageValue1(Employee1 emp)
        {
            emp.name = "chnagedChaitanya1";
        }


    }
}
