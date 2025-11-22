using Repository;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementSystem.ContextFactory
{
    public class TaskManagerContextFactory
        : IDesignTimeDbContextFactory<TaskManagerContext>
    {
        public TaskManagerContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder<TaskManagerContext>? builder = new DbContextOptionsBuilder<TaskManagerContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    b => b.MigrationsAssembly("TaskManagementSystem"));

            return new TaskManagerContext(builder.Options);
        }
    }
}
