using Microsoft.EntityFrameworkCore;
using Students.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Infrastructure.Persistent
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBContext context;

        public StudentRepository(StudentDBContext context)
        {
            this.context = context;
        }

        public async Task<Students.Domain.Student> Create(string firsName, string lastName, DateOnly Birthday, string RecordBook)
        {
            var student = new Students.Domain.Student
            {
                FirstName = firsName,
                LastName = lastName,
                Birthday = Birthday,   
               
            };
            this.context.Students.Add(student);
            await this.context.SaveChangesAsync();
            return student;
        }

        public async Task Delete(int id)
        {
            var student = await this.context.Students.FirstAsync(x => x.Id==id);
            this.context.Students.Remove(student);
            await this.context.SaveChangesAsync();
        }

        public Task<Students.Domain.Student> FindById(int id)
        {
            return this.context.Students.FirstOrDefaultAsync(x => x.Id==id);
        }

        public Task<List<Students.Domain.Student>> GetAll()
        {
            return this.context.Students.ToListAsync();
        }

        public async Task<Students.Domain.Student> Update(int id, string firsName, string lastName, DateOnly Birthday, string RecordBook)
        {
            var student = this.context.Students.First(x => x.Id==id);
            student.FirstName = firsName;
            student.LastName = lastName;    
            student.Birthday = Birthday;
            student.RecordBook = RecordBook;
            await this.context.SaveChangesAsync();
            return student;
        }

        
    }
}
