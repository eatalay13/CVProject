using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Data.Models.Auth
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
