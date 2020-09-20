using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hortogram.Mappings
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhotoURL { get; set; }
        public bool? Status { get; set; }
    }
}
