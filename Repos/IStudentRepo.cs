using MiniApp.Models;

namespace MiniApp.Repos
{
    public interface IStudentRepo
    {
        public Task<Student> GetStudentById(int id);
        public Task<List<Student>> GetAllStudent();
        public Task<bool> Add(Student model);
        public Task<bool> Update(StudentDTO model);
        public Task<bool> Delete(int id);
    }
}
