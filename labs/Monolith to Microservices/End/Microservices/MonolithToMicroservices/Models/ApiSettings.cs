using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithToMicroservices.Models
{
    public class ApiSettings : IApiSettings
    {
        public string CustomersUri { get; set; }
        public string LookupUri { get; set; }
        public string CustomerOrdersUri { get; set; }
    }
}
