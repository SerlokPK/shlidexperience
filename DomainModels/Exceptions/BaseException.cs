using System;
using System.Net;

namespace DomainModels.Exceptions
{
    public abstract class BaseException : Exception
    {
        public int StatusCode { get; set; }

        public BaseException(string message) : base(message) => StatusCode = (int)HttpStatusCode.InternalServerError;
    }
}
