using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Infrastructure
{
    public class BussinesException : Exception
    {
        public BussinesException(string message) : base(message)
        {

        }
    }
}
