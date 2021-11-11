using employee_UEPFeedbackformWebAPI.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee_UEPFeedbackformWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UepFeedbackContext _context;

        public UsersController(UepFeedbackContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("EmployeeDetails")]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await _context.Employees.ToListAsync();
        }
        [HttpGet]
        [Route("GetEmployeeDetail/{id}")]
        public async Task<ActionResult<Employee>> Get(string id)
        {
            Employee employee = null;
            var Emp = await _context.Employees.ToListAsync();
            if (Emp != null)
            {
                var emp = Emp.First(a => a.EmpName == id);
                employee = await _context.Employees.FindAsync(emp.EmpId);

                if (employee == null) 
                {
                    return NotFound();
                }
            }

            return employee;
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
        }


    }
}
