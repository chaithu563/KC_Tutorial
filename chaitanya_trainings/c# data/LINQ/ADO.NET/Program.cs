using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=CHAITANYA-PC\\SQLEXPRESS;database=chaitanya;integrated Security=true;";
           
    using(SqlConnection _con = new SqlConnection(connectionString))
    {
       string queryStatement = "SELECT TOP 5 * FROM dbo.Employee ORDER BY id";

       using(SqlCommand _cmd = new SqlCommand(queryStatement, _con))
       {
          DataTable customerTable = new DataTable("Top5Customers");

          SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

          _con.Open();
          _dap.Fill(customerTable);
          _con.Close();

       

       }
    }

        }
    }
}
