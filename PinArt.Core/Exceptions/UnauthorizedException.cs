using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Core.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
        {

        }

        public UnauthorizedException(string message) : base(message)
        {

        }
    }
}
