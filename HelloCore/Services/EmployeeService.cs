using HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public EmployeeService()
        {
            _employees.Add(new Employee { Id = 1, DepartmentId = 1, FirstName = "colin", LastName = "wang", Gender = Gender.男, Fired = false });
            _employees.Add(new Employee { Id = 2, DepartmentId = 2, FirstName = "colin2", LastName = "wang", Gender = Gender.男, Fired = false });
            _employees.Add(new Employee { Id = 3, DepartmentId = 3, FirstName = "colin3", LastName = "wang", Gender = Gender.男, Fired = false });
        }

        public Task Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(function:()=>
            {
                var employee = _employees.FirstOrDefault(t=>t.Id == id);
                if (employee != null)
                {
                    employee.Fired = true;
                    return employee;
                }
                return null;
            });
        }

        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            return Task.Run(function:()=>_employees.Where(t=>t.DepartmentId == departmentId).AsEnumerable());
        }
    }
}
