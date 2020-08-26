using ApiEmployee.DataAccess;
using ApiEmployee.DataContrats;
using ApiEmployee.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiEmployee.Core
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            return _employeeRepository.FindByCondition(x => !x.IsBoss).ToList();
        }

        public IEnumerable<EmployeeViewModel> GetAllBoss()
        {
            return _employeeRepository.FindByCondition(x => x.IsBoss).ToList();
        }

        public long InsertEmployees(EmployeeViewModel employee)
        {
            var entity = _employeeRepository.Create(employee);
            return entity.IdEmployee;
        }

        public bool UpdateEmployees(EmployeeViewModel employee)
        {
            var result = _employeeRepository.Update(employee, "IdEmployee");
            return result == EntityState.Modified;
        }

        public bool DeleteEmployee(long id)
        {
            EmployeeViewModel product = _employeeRepository.FindByCondition(x => x.IdEmployee == id).FirstOrDefault();
            if (product != null)
            {
                var result = _employeeRepository.Delete(product);
                return result == EntityState.Deleted;
            }
            return false;
        }
    }
}
