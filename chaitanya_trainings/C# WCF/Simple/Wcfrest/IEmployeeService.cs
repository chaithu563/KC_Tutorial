using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Wcfrest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
       // [WebGet(UriTemplate = "Employee", ResponseFormat = WebMessageFormat.Json)]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Employee")]
        [OperationContract ]
        List<Employee> GetAllEmployeeDetails();

        [WebGet(UriTemplate = "Employee?id={id}")]
        [OperationContract]
        Employee GetEmployee(int Id);

        [WebInvoke(Method = "POST", UriTemplate = "EmployeePOST")]
        [OperationContract]
        void AddEmployee(Employee newEmp);

        //[WebInvoke(Method = "PUT", UriTemplate = "EmployeePUT")]
        //[OperationContract]
        //void UpdateEmployee(Employee newEmp);

        //[WebInvoke(Method = "DELETE", UriTemplate = "Employee/{empId}")]
        //[OperationContract]
        //void DeleteEmployee(string empId);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmpId { get; set; }
        [DataMember]
        public string Fname { get; set; }
        [DataMember]
        public string Lname { get; set; }
        [DataMember]
        public DateTime JoinDate { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public int Salary { get; set; }
        [DataMember]
        public string Designation { get; set; }
    }


}
