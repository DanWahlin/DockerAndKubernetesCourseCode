using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithToMicroservices.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public Customer Customer { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}
