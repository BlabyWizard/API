using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universitate.Properties.Models;
using Universitate.Repositories;

namespace Universitate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStdRepository _stdRepository;

        public StudentsController(IStdRepository stdRepository)
        {
            _stdRepository = stdRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _stdRepository.Get();
        }
        [HttpGet("{IdStudent}")]
        public async Task<ActionResult<Student>> GetStudents(int IdStudent)
        {
            return await _stdRepository.Get(IdStudent);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudents([FromBody] Student student)
        {
            var newStudent = await _stdRepository.Create(student);
            return CreatedAtAction(nameof(GetStudents), new { EmpId = newStudent.IdStudent }, newStudent);
        }
        [HttpPut]
        public async Task<ActionResult> PutStudents(int IdStudent, [FromBody] Student student)
        {
            if (IdStudent != student.IdStudent)
            {
                return BadRequest();
            }
            await _stdRepository.Update(student);
            return NoContent();
        }
        [HttpDelete("{IdStudent}")]
        public async Task<ActionResult> Delete(int IdStudent) 
        {
            var studentToDelete = await _stdRepository.Get(IdStudent);
            if(studentToDelete == null)
            {
                return NotFound();
            }

            await _stdRepository.Delete(studentToDelete.IdStudent);
            return NoContent();
        }
        
    }
}
