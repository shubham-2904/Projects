namespace ServiceContracts
{
    public interface IServiceManager
    {
        ITaskService TaskService { get; }
        ITaskDetailService TaskDetailService { get; }
    }
}
