using Microsoft.EntityFrameworkCore;
using ProgramusAPI.Data;
using ProgramusAPI.Models;

namespace ProgramusAPI.Core.Repositories
{
    public class TaskRepository : GenericRepository<Tasks>, ITaskRepository
    {
        public TaskRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {
        }      
                
        public override async Task<IEnumerable<Tasks>> All()
        {            
            try
            {
                return await _context.Tasks.Where(x => x.Id < 100).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }        

        public async Task<Tasks?> GetByTasksId(int Id)
        {
            try
            {
                return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }           

        public override async Task<Tasks?> GetById(int id)
        {
            return await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
