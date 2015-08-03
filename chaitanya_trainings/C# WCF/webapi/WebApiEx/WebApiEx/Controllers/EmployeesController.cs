using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WebApiEx.Models;
namespace WebApiEx.Controllers
{
    //http://bitoftech.net/2014/04/16/create-read-only-odata-endpoint-using-asp-net-web-api/


    public class EmployeesController : EntitySetController<Employee, int>
    {
        chaitanyaEntities ctx = new chaitanyaEntities();

        [Queryable(PageSize = 10)]
        public override IQueryable<Employee> Get()
        {
            return ctx.Employees.AsQueryable();
        }

        protected override Employee GetEntityByKey(int key)
        {
            return ctx.Employees.Find(key);
        }

    }
}
