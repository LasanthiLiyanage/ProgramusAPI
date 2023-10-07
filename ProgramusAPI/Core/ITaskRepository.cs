using ProgramusAPI.Models;

namespace ProgramusAPI.Core
{
    public interface ITaskRepository : IGenericRepository<Tasks>
    {       
        Task<Tasks?> GetByTasksId(int Id);
    }
}
