using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.TestServiceReference;
using client.EmpServiceReference1;
namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Service1Client ob = new Service1Client();
            
            //CompositeType ct = new CompositeType();
            //ct.StringValue = "kcr";
            //ct.BoolValue = true;

            //ct = ob.GetDataUsingDataContract(ct);

            //Console.WriteLine(ct.StringValue);

            EmployeeServiceClient ob = new EmployeeServiceClient();
            Employee[] ob1=   ob.GetAllEmployeeDetails();

            Console.Read();
        }
    }
}
