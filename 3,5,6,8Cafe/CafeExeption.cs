using System;

namespace Cafe
{
    public class CafeException : Exception
    {
        public CafeException(string message) : base(message)
        {
        }
    }
}