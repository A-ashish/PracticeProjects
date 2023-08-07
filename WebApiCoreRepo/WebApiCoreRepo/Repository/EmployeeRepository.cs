using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreRepo.Model;

namespace WebApiCoreRepo.Repository
{
    public class EmployeeRepository : IEmployeeInterface
    {
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
