using Microsoft.EntityFrameworkCore;
using ProgramusAPI.Models;

namespace ProgramusAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }

    }
}
