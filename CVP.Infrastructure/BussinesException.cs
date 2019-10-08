using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Infrastructure
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
