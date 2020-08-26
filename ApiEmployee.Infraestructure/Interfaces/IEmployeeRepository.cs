using ApiEmployee.DataAccess.Interfaces;
using ApiEmployee.DataContrats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ApiEmployee.DataAccess
{
    public interface IEmployeeRepository : IRepositoryBase<EmployeeViewModel>
    {
        //IQueryable<EmployeeViewModel> GetAllEmployees();
       // IQueryable<EmployeeViewModel> GetAllBoss();
    }
}
