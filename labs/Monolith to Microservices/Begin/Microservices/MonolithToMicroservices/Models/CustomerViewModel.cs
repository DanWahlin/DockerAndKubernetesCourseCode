using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithToMicroservices.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<State> States { get; set; }
    }
}
