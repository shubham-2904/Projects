namespace Entities.Exceptions
{
    public sealed class TaskDetailNotFound : NotFoundException
    {
        public TaskDetailNotFound(long id) 
            : base($"The task detail with id: {id} doesn't exist in the database or may be deleted from the database")
        {
        }
    }
}
