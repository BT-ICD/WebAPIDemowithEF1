using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemowithEF1.Entities
{
    public class LearningDBContext: DbContext
    {
        public LearningDBContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDTO> Students_GetAllStudents { get; set; }
    }
}
