using System.Net;

namespace DomainModels.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message) => StatusCode = (int)HttpStatusCode.NotFound;
    }
}
