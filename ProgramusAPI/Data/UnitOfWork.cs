using ProgramusAPI.Core;
using ProgramusAPI.Core.Repositories;

namespace ProgramusAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext _context;
       
        public ITaskRepository Tasks { get; private set; }

        public UnitOfWork( ApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var  _logger = loggerFactory.CreateLogger(categoryName:"logs");

            Tasks = new TaskRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
