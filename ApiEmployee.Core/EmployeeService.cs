using ApiEmployee.DataAccess;
using ApiEmployee.DataContrats;
using ApiEmployee.Services;
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
        public bool InsertEmployees(EmployeeViewModel employee)
        {
             _employeeRepository.Create(employee);
            return true;
        }
        public bool UpdateEmployees(EmployeeViewModel employee)
        {
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            return true;
        }
    }
}
