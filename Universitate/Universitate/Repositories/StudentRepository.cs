using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Universitate.Properties.Models;

namespace Universitate.Repositories
{
    public class StudentRepository : IStdRepository
    {
        private readonly StudentContext _context;

        public StudentRepository(StudentContext context) 
        {
            _context = context;
        }

        public async Task<Student> Create(Student student)
        {
            _context.students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task Delete(int IdStudent)
        {
            var studentToDelete = await _context.students.FindAsync(IdStudent);
            _context.students.Remove(studentToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await _context.students.ToListAsync();
        }

        public async Task<Student> Get(int IdStudent)
        {
            return await _context.students.FindAsync(IdStudent);
        }

        public async Task Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
