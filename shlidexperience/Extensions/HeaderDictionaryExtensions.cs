using Common.Helpers;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Api.Extensions
{
    public static class HeaderDictionaryExtensions
    {
        private const string _authorization = "Authorization";

        public static int? GetUserId(this IHeaderDictionary dictionary)
        {
            if (dictionary.ContainsKey(_authorization))
            {
                var token = dictionary.First(x => x.Key == _authorization).Value;
                var id = JwtTokenHelper.GetIdClaim(token);

                if (!string.IsNullOrEmpty(id))
                {
                    return int.Parse(id);
                }
            }

            return null;
        }
    }
}
