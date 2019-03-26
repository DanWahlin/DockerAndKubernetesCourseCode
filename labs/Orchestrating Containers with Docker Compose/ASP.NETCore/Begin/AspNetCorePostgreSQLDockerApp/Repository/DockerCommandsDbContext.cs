using Microsoft.EntityFrameworkCore;
using AspNetCorePostgreSQLDockerApp.Models;

namespace AspNetCorePostgreSQLDockerApp.Repository
{
    public class DockerCommandsDbContext : DbContext
    {
        public DbSet<DockerCommand> DockerCommands { get; set; }

        public DockerCommandsDbContext(DbContextOptions<DockerCommandsDbContext> options) : base(options) { }
    }
}