using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp7._20._22.DatabaseContext;
using TestApp7._20._22.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace TestApp7._20._22.Services
{
    public class EmployeeRepository : IEmployee
    {
        private readonly myAppDbContext context;
        private readonly IConfiguration configuration;
        private List<SqlParameter> sqlparams;
        private string connstr;
        public EmployeeRepository(myAppDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
            connstr = configuration.GetConnectionString("myAppCon");
        }

        public Employee AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(int Id)
        {
            var myemp = context.Employees.FirstOrDefault(e => e.Id == Id);
            context.Employees.Remove(myemp);
            context.SaveChanges();
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == Id);
        }

        public Employee GetEmployee(string lastname)
        {
            return context.Employees.FirstOrDefault(e => e.LastName.Contains(lastname));
        }

        public Employee GetEmployeeNE(int Id)
        {
            DataTable dt = new DataTable(); 

            using(SqlConnection conn = new SqlConnection(connstr))
            {
               
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Employees Where Id=@Id", connstr);
                sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("Id", Id));
                sqlDataAdapter.Fill(dt);
            }

            Employee myEmp = new Employee();
            myEmp.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            myEmp.FirstName = dt.Rows[0]["FirstName"].ToString();
            myEmp.LastName = dt.Rows[0]["LastName"].ToString();

            return myEmp;                        
         }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
            return employee;
        }
    }
}
