using System.Collections.Generic;

namespace AspNetCorePostgreSQLDockerApp.Models {
  public class Customer
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public State State { get; set; }
    public int Zip { get; set; }
    public string Gender { get; set; }
    public int OrderCount { get; set; }
    public List<Order> Orders { get; set; }
  }
}