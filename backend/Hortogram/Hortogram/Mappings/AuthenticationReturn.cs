using System;

namespace Services
{
    public class AuthenticationReturn
    {
        public bool Status { get; set; }
        public string Token { get; set; }
        public Guid Id { get; set; }
    }
}
