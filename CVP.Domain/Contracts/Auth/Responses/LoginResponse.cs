using System;
using System.Collections.Generic;
using System.Text;


namespace CVP.Domain.Contracts.Auth.Responses
{
    public class LoginResponse : ResponseBase
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
