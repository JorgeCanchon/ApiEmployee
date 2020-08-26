using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEmployee.Core;
using ApiEmployee.DataAccess;
using ApiEmployee.DataContrats;
using ApiEmployee.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult Post(EmployeeViewModel employee)
        {
            try
            {
                long result = _employeeService.InsertEmployees(employee);
                if (result > 0)
                    return StatusCode(201);
                return StatusCode(500);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _employeeService.UpdateEmployees(employee);
            if (!result)
                return StatusCode(500);
            return Ok();
        }

        [HttpDelete("{idemployee}")]
        public IActionResult Delete(long idemployee)
        {
            var result = _employeeService.DeleteEmployee(idemployee);
            if (!result)
                return StatusCode(500);
            return Ok();
        }

        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }
    }
}
