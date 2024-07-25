using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.Infrastructure.Extensions
{
    public static class IConfigurationEx
    {
        public static int? GetHostedServiceTimeInterval(this IConfiguration configuration, string hostedServiceName)
        {
            var configurationValue = configuration?.GetSection("HostedServiceTimeIntervals")[hostedServiceName];
            if (int.TryParse(configurationValue, out var serviceTimeInterval))
                return serviceTimeInterval;
            else return null;
        }
    }
}
