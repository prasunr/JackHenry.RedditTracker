using System.Diagnostics;
using JackHenry.RedditTracker.Common;
using JackHenry.RedditTracker.Helper.HttpHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reddit;

namespace JackHenry.RedditTracker.Api.Controllers
{
   
    [ApiController]
    public class RedditController : ControllerBase
    {
        private readonly RedditApiModel redditApiModel;
        private readonly IConfiguration _configuration;
        public RedditController(IConfiguration configuration)
        {
            _configuration = configuration;
            var apiUrl = _configuration.GetSection("ApiBaseUrl").Value??"";
            var apiVersion = _configuration.GetSection("ApiVersion").Value??"";
            redditApiModel = new RedditApiModel(apiUrl, apiVersion);
        }
        

        [HttpGet("RedditAuthorize")]
        public IActionResult RedditAuthorize()
        {
            var apiAuthorizeParams = _configuration.GetSection("AuthorizeUrlParams").Value ?? "";

            var r = new RedditClient("SgzkNQuIzBP30zPmA8nJGg");

            //var redditApiModel = _configuration.GetSection("RedditApi");
            //RedditHttpHelper.SetupAuthorizeHttpClient(redditApiModel, apiAuthorizeParams);
            // Debug.WriteLine("Redditapimodel : ", redditApiModel);
            return Ok();

        }
    }
}
