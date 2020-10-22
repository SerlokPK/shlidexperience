using System.Net;

namespace DomainModels.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(string message) : base(message) => StatusCode = (int)HttpStatusCode.Conflict;
    }
}
