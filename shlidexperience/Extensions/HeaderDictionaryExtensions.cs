using Api.Constants;
using Common.Helpers;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Api.Extensions
{
    public static class HeaderDictionaryExtensions
    {
        public static int? GetUserId(this IHeaderDictionary dictionary)
        {
            var token = dictionary.First(x => x.Key == HeaderConstants.Authorization).Value;
            var id = JwtTokenHelper.GetIdClaim(token);

            if (!string.IsNullOrEmpty(id))
            {
                return int.Parse(id);
            }

            return null;
        }
    }
}
