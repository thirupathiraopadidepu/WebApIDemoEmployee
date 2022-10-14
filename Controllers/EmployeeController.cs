using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApIDemoEmployee.Migrations;
using WebApIDemoEmployee.Moidel;



namespace Demo_Webapii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeClassesController : ControllerBase
    {
        private readonly EmpDbContext _context;



        public EmployeeClassesController(EmpDbContext context)
        {
            _context = context;
        }



        // GET: api/EmployeeClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeClasses()
        {
            return await _context.Employees.ToListAsync();
        }



        // GET: api/EmployeeClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeClass(int id)
        {
            var employeeClass = await _context.Employees.FindAsync(id);



            if (employeeClass == null)
            {
                return NotFound();
            }



            return employeeClass;
        }



        // PUT: api/EmployeeClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeClass(int id, Employee employeeClass)
        {
            if (id != employeeClass.Id)
            {
                return BadRequest();
            }



            _context.Entry(employeeClass).State = EntityState.Modified;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }



            return NoContent();
        }



        // POST: api/EmployeeClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployeeClass(Employee employeeClass)
        {
            _context.Employees.Add(employeeClass);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetEmployeeClass", new { id = employeeClass.Id }, employeeClass);
        }



        // DELETE: api/EmployeeClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeClass(int id)
        {
            var employeeClass = await _context.Employees.FindAsync(id);
            if (employeeClass == null)
            {
                return NotFound();
            }



            _context.Employees.Remove(employeeClass);
            await _context.SaveChangesAsync();



            return NoContent();
        }



        private bool EmployeeClassExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}