using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp7._20._22.Models;

namespace TestApp7._20._22.Services
{
    public interface IEmployee
    {
        Employee GetEmployee(int Id);
        Employee GetEmployeeNE(int Id);
        Employee GetEmployee(string lastname);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();
        void DeleteEmployee(int Id);
    }
}
