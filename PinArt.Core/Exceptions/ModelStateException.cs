using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Core.Exceptions
{
    public class ModelStateException : Exception
    {
        public ModelStateException()
        {

        }

        public ModelStateException(string message) : base(message)
        {

        }

    }
}
