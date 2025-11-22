using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions options)
            : base(options)
        {
        }

        DbSet<Entities.Model.Task> Tasks { get; set; }
        DbSet<TaskDetail> TasksDetail { get; set; }
    }
}
