using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JackHenry.RedditTracker.Common;
using Microsoft.Extensions.Configuration;

namespace JackHenry.RedditTracker.Core
{
    public static class ApiConfigurationModel
    {
        public static IConfiguration Configuration;

        public static RedditApiModel GetConfigurationData()
        {
            var redditApiModel = new RedditApiModel("", "");
            if (Configuration != null)
            {
                redditApiModel.ApiUrl = Configuration.GetSection("ApiBaseUrl")?.ToString();
            }

            return null;
        }
    }
}
