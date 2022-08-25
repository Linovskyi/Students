using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Students.Domain
{
    public class StudentDBContext : DbContext

    {
        public DbSet<Student> Students { get; set; }
        public StudentDBContext( DbContextOptions<StudentDBContext> options)
             : base (options)
        {

        }
    }
}
