using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEmployee.Core;
using ApiEmployee.DataAccess;
using ApiEmployee.DataContrats;
using ApiEmployee.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiEmployee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeRepository)
        {
            _employeeService = employeeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<EmployeeViewModel> employees = _employeeService.GetAllEmployees();
                if (employees.Any())
                    return Ok(employees);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("bosses")]
        public IActionResult GetBosses()
        {
            try
            {
                IEnumerable<EmployeeViewModel> employees = _employeeService.GetAllBoss();
                if (employees.Any())
                    return Ok(employees);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
