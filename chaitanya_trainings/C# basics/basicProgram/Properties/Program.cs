using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Employee
    {
        private int _id;

        public string _name;

        private int _salary;

        public int getSalary()
        {

            return _salary;
        }

        public void setId(int id)
        {
            if (id < 0)
            {
                throw new Exception("My system error");
            }
            _id = id;
        }

        public int getId()
        {
            return _id;
        }
        


    }


    class EmployeeProp
    {
        private int _id;
        private string _name;
        private int _salary;

        public int Id
        {
            set { this._id = value; }
            get { return this._id; }
           

        }

        public string Name
        {
            get { return this._name; }

            set { this._name = value; }
        }

        public int Salary
        {
            get { return this._salary; }
        }


        public EmployeeProp(int id, string name, int salary)
        {
            this._id = id;
            this._name = name;
            this._salary = salary;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            EmployeeProp ob = new EmployeeProp(1, "chaitanya", 1000);

            ob.Id = 10;
           // ob.Salary = 111000;

            ob.Name = "chanew name";

            Console.WriteLine(ob.Name);
            Console.WriteLine(ob.Salary);
            Console.Read();
           



        }
    }
}
