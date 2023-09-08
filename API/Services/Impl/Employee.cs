using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace API.Services.Impl
{
    public class Employee : IEmployee
    {

        private readonly IConfiguration _configuration;
        public Employee(IConfiguration configuration)
        {

            _configuration = configuration;

        }

        //list of the details of each employee
        public List<API.Employee> GetEmployees()
        {

            DataTable employees = GetDtEmployees();

            return (from DataRow dr in employees.Rows
                    select new API.Employee()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Mobile = dr["Mobile"].ToString(),

                    }).ToList();
        }

        //configuring db details of employee
        private DataTable GetDtEmployees()
        {
            string constr = this._configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            SqlConnection con = new SqlConnection(constr);
            string query = "SELECT * FROM [Loyaltysample].[dbo].[Employees]";
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);

            sqlDataAdapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }
    }
}
