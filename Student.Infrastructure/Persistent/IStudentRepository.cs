using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Student.Infrastructure.Persistent
{
    public interface IStudentRepository
    {
          Task<List<Students.Domain.Student>> GetAll();
          Task<Students.Domain.Student> FindById(int id);
          Task<Students.Domain.Student> Create(string firsName, string lastName, DateOnly Birthday, string RecordBook);
          Task<Students.Domain.Student> Update(int id, string firsName, string lastName, DateOnly Birthday, string RecordBook);
          Task Delete(int id);
    }
}
