using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifier
{

   public class class1
    {
        public int a;
        protected int b;

        private int c;


    }

   public class class2 : class1
    {
       public class2()
       {
           this.b = 10;
           this.a = 10;
          
       }


    }

    public class Program 
    {
        public Program()
        {
            //this.a = 10;
            //this.b = 10;
        }
        static void Main(string[] args)
        {
            class1 ob1 = new class1();
           
       
            class2 ob2 = new class2();
          
            
            
        }
    }
}
