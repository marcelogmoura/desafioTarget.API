using System;

namespace desafioTarget.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}