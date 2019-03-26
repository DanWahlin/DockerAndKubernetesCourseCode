using System.Collections.Generic;
using System.Threading.Tasks;

using AspNetCorePostgreSQLDockerApp.Models;

namespace AspNetCorePostgreSQLDockerApp.Repository
{
    public interface IDockerCommandsRepository
    {     
        Task<List<DockerCommand>> GetDockerCommandsAsync();
        
        Task InsertDockerCommandAsync(DockerCommand command);
    }
}