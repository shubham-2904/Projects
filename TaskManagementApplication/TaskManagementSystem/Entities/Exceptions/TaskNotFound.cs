namespace Entities.Exceptions
{
    public sealed class TaskNotFound : NotFoundException
    {
        public TaskNotFound(long id) 
            : base($"The task with id: {id} doesn't exist in the database or may be deleted from the database")
        { }
    }
}
