using HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly List<Department> _department = new List<Department>();

        public DepartmentService()
        {
            _department.Add(new Department
            {
                Id = 1,
                Name = "HR",
                EmployeeCount = 16,
                Location = "SZ"
            });
            _department.Add(new Department
            {
                Id = 2,
                Name = "生产",
                EmployeeCount = 1116,
                Location = "SZ"
            });
            _department.Add(new Department
            {
                Id = 3,
                Name = "销售",
                EmployeeCount = 106,
                Location = "SZ"
            });
        }

        public Task Add(Department department)
        {
            department.Id = _department.Max(x=>x.Id) + 1;
            _department.Add(department);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(function: () => _department.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(function:()=>_department.FirstOrDefault(t=>t.Id == id));
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(function:()=> 
            {
                return new CompanySummary
                {
                    EmployeeCount = _department.Sum(x => x.EmployeeCount),
                    AverageDepartmentEmployeeCount = (int)_department.Average(x=>x.EmployeeCount)
                };
            });
        }
        //视频 03:49
    }
}
