using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using AspNetCorePostgreSQLDockerApp.Models;

namespace AspNetCorePostgreSQLDockerApp.Repository
{
    public class DockerCommandsDbSeeder
    {
        readonly ILogger _logger;

        public DockerCommandsDbSeeder(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("DockerCommandsDbSeederLogger");
        }

        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            //Based on EF team's example at https://github.com/aspnet/MusicStore/blob/dev/samples/MusicStore/Models/SampleData.cs
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dockerDb = serviceScope.ServiceProvider.GetService<DockerCommandsDbContext>();
                var customersDb = serviceScope.ServiceProvider.GetService<CustomersDbContext>();

                if (await dockerDb.Database.EnsureCreatedAsync())
                {
                    if (!await dockerDb.DockerCommands.AnyAsync()) {
                      await InsertDockerSampleData(dockerDb);
                    }
                }
            }
        }

        public async Task InsertDockerSampleData(DockerCommandsDbContext db)
        {
            var commands = GetDockerCommands();
            db.DockerCommands.AddRange(commands);

            try
            {
              await db.SaveChangesAsync();
            }
            catch (Exception exp)
            {
              _logger.LogError($"Error in {nameof(DockerCommandsDbSeeder)}: " + exp.Message);
            }

        }

        private List<DockerCommand> GetDockerCommands()
        {
            var cmd1 = new DockerCommand {
                Command = "run",
                Description = "Runs a Docker container",
                Examples  = new List<DockerCommandExample> {
                    new DockerCommandExample {
                        Example = "docker run imageName",
                        Description = "Creates a running container from the image. Pulls it from Docker Hub if the image is not local"
                    },
                    new DockerCommandExample {
                        Example = "docker run -d -p 8080:3000 imageName",
                        Description = "Runs a container in 'daemon' mode with an external port of 8080 and a container port of 3000."
                    }
                }
            };

            var cmd2 = new DockerCommand {
                Command = "ps",
                Description = "Lists containers",
                Examples  = new List<DockerCommandExample> {
                    new DockerCommandExample {
                        Example = "docker ps",
                        Description = "Lists all running containers"
                    },
                    new DockerCommandExample {
                        Example = "docker ps -a",
                        Description = "Lists all containers (even if they are not running)"
                    }
                }
            };

            return new List<DockerCommand> { cmd1, cmd2 };
        }

    }
}