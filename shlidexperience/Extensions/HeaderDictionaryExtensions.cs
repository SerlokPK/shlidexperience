using Common.Helpers;
using Microsoft.AspNetCore.Http;

namespace Api.Extensions
{
    public static class HeaderDictionaryExtensions
    {
        public static void AddTotalCount(this IHeaderDictionary source, int totalCount)
        {
            DependencyHelper.ThrowIfNull(source);

            source.Add("X-Total-Count", totalCount.ToString());
        }
    }
}
