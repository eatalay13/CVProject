using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Domain.Contracts.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
