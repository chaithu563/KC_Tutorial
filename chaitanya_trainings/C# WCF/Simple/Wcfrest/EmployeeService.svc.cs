using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Wcfrest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EmployeeService : IEmployeeService
    {

        List<Employee> EmployeeData = new List<Employee>();
       
      
        public List<Employee> GetAllEmployeeDetails()
        {
           
            return EmployeeData;
        }

        public Employee GetEmployee(int id)
        {
            IEnumerable<Employee> empList = EmployeeData.Where(x => x.EmpId == id);

            if (empList != null)
                return empList.First<Employee>();
            else
                return null;
        }


        public void AddEmployee(Employee newEmp)
        {
            EmployeeData.Add(newEmp);
        }


       
    }
}
