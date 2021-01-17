using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TensesTowerAPI.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string School { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
