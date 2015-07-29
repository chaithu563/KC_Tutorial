using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiEx.Models;
namespace WebApiEx.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Employee> Get()
        {
            chaitanyaEntities ob = new chaitanyaEntities();


            return ob.Employees;
        }

        // GET api/values/5
        public Employee Get(int id)
        {
            chaitanyaEntities ob = new chaitanyaEntities();


            return ob.Employees.Where(x=>x.id==id).Single();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}