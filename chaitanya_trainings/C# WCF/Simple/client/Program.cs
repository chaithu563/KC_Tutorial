using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.ServiceReference1;
namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client ob = new Service1Client();
            Console.Write(ob.GetData(2));
            Console.Read();
        }
    }
}
