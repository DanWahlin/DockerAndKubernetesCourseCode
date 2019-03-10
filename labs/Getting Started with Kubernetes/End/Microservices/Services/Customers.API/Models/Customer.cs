using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Customers.API.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }

        [Display(Name = "Zipcode")]
        public int Zip { get; set; }
        public List<Order> Orders { get; set; }
    }
}