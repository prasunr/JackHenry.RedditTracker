using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using JackHenry.RedditTracker.Common;
using Microsoft.Extensions.Configuration;

namespace JackHenry.RedditTracker.Helper.HttpHelper
{
    public class RedditHttpHelper
    {
        public static HttpClient HttpApiClient { get; set; }
        public static void AddRequestHeaders()
        {
            HttpApiClient.DefaultRequestHeaders.Accept.Clear();
            HttpApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public static void SetupAuthorizeHttpClient(RedditApiModel redditApiModel, string AuthorizeUrlParams)
        {
            HttpApiClient = new HttpClient();
            HttpApiClient.BaseAddress = new Uri(redditApiModel.ApiUrl + redditApiModel.ApiVersion + AuthorizeUrlParams);
            AddRequestHeaders();
            HttpApiClient.GetAsync(HttpApiClient.BaseAddress);
        }

        public static void SetupAccessTokenHttpClient(RedditApiModel redditApiModel, string AuthorizeUrlParams)
        {
            HttpApiClient = new HttpClient();
            HttpApiClient.BaseAddress = new Uri(redditApiModel.ApiUrl + redditApiModel.ApiVersion + "/access_token");
            AddRequestHeaders();
            HttpApiClient.PostAsJsonAsync(HttpApiClient.BaseAddress, new object(){});
        }

    }
}
