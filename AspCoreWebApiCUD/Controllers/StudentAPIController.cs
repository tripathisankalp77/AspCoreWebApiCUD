//jenkins change whle  we change the code autimetically 
// hello change
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreWebApiCUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreWebApiCUD.Controllers
{
    [Route("api/[controller]")]// This attribute defines the route template for the controller. The [controller] token will be replaced with the name of the controller, which in this case is "StudentAPI". So, the route for this controller will be "api/StudentAPI".
    [ApiController] // This attribute indicates that this controller will handle API requests and provides automatic model validation and other API-specific features.
    public class StudentAPIController : ControllerBase
    {
        private readonly EmployeesDbContext context;

        public StudentAPIController(EmployeesDbContext context)// This is the constructor for the StudentAPIController class. It takes an EmployeesDbContext object as a parameter, which is used to interact with the database. The context is assigned to a private readonly field, allowing the controller to use it for database operations.
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var students = await context.Students.ToListAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var students = await context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);

        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (id == null)
            {
                return BadRequest();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
    }

}
