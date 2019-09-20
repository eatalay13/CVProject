using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Domain.Contracts
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = "Success";
    }
}
