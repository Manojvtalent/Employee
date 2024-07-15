


using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Dbcontext
{
    public class projectDBcontext:DbContext
    {
        public projectDBcontext(DbContextOptions<projectDBcontext> options) : base(options) { }
        
         public DbSet<employee> Employess { get; set; }
    }
}
