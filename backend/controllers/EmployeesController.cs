using FalveyInsuranceGroup.Backend.Models;
using FalveyInsuranceGroup.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace FalveyInsuranceGroup.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly FalveyInsuranceGroupContext _context;
        public EmployeesController(FalveyInsuranceGroupContext context)
        {
            _context = context;
        }

        // For getting all employees
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        // For getting a specific employee
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // For posting a new employee
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee newEmployee)
        {
            if (newEmployee == null)
                return BadRequest();

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.employee_id }, newEmployee);
        }

        // For updating an existing employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            employee.employee_id = updatedEmployee.employee_id;
            employee.name = updatedEmployee.name;
            employee.title = updatedEmployee.title;
            employee.email = updatedEmployee.email;
            employee.phone = updatedEmployee.phone;
            employee.status = updatedEmployee.status;
            employee.created_at = updatedEmployee.created_at;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // For patching an existing employee
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchEmployee(int id, JsonPatchDocument<Employee> patchDocument)
        {
            if (patchDocument == null)
                return BadRequest();

            // If {id} is not there, return "Not Found"
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            patchDocument.ApplyTo(employee, ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.SaveChangesAsync();
            return Ok(employee);

        }

        // For deleting an existing employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
