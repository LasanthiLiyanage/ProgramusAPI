namespace ProgramusAPI.Core
{
    public interface IUnitOfWork
    {
        ITaskRepository Tasks { get; }
        Task CompleteAsync();
    }
}
