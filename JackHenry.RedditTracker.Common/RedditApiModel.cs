using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackHenry.RedditTracker.Common
{
    public class RedditApiModel
    {
        public RedditApiModel(string apiUrl, string apiVersion)
        {
            this.ApiUrl = apiUrl;
            this.ApiVersion = apiVersion;

        }
        public string ApiUrl { get; set; }
        public string ApiVersion { get; set; }
        public string AuthorizeUrlParams { get; set; }

    }
}
