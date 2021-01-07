using Common.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Api.Extensions
{
    public static class HeaderDictionaryExtensions
    {
        private const string _authorization = "Authorization";
        private const string _device = "DeviceId";

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

        public static Guid? GetDeviceId(this IHeaderDictionary dictionary)
        {
            if (dictionary.ContainsKey(_device))
            {
                var deviceId = dictionary.First(x => x.Key == _device).Value;

                return new Guid(deviceId);
            }

            return null;
        }
    }
}
