using Microsoft.EntityFrameworkCore;
using MiniApp.Data;
using MiniApp.Models;

namespace MiniApp.Repos
{
    public class StudentRepo : IStudentRepo
    {
        private readonly DatabaseContext _context;

        public StudentRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Student model)
        {
            await _context.Students.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _context.Students.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Student>> GetAllStudent()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _context.Students.Where(s => s.Id == id).FirstOrDefaultAsync();
            return student!;
        }

        public async Task<bool> Update(StudentDTO model)
        {
            var student = await _context.Students.Where(s => s.Id == model.Id).FirstOrDefaultAsync();
            if (student != null)
            {
                student.Name = model.Name;
                student.Class = model.Class;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
            
        }
    }
}
