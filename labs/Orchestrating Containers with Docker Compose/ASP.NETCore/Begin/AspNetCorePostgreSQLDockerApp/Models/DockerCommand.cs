using System;
using System.Collections.Generic;

namespace AspNetCorePostgreSQLDockerApp.Models {
  
  public class DockerCommand {
    public int Id { get; set; }
    public string Command { get; set; }
    public string Description { get; set; }
    public List<DockerCommandExample> Examples { get; set; }    
  }
  
}