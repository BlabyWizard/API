using Universitate.Properties.Models;

namespace Universitate.Repositories
{
    public interface IStdRepository
    {
        Task<IEnumerable<Student>> Get();
        Task<Student> Get(int IdStudent);
        Task<Student> Create(Student student);
        Task Update(Student student);
        Task Delete(int IdStudent);

    }
}
