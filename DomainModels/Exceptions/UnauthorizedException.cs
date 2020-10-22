using System.Net;

namespace DomainModels.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(string message) : base(message) => StatusCode = (int)HttpStatusCode.Unauthorized;
    }
}
