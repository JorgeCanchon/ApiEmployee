using ApiEmployee.DataContrats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ApiEmployee.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetAll();
        IEnumerable<EmployeeViewModel> GetAllEmployees();
        IEnumerable<EmployeeViewModel> GetAllBoss();
        EmployeeViewModel InsertEmployees(EmployeeViewModel employee);
        bool UpdateEmployees(EmployeeViewModel employee);
        bool DeleteEmployee(long id);
    }
}
