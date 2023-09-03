using JackHenry.RedditTracker.Common;
using JackHenry.RedditTracker.Helper.HttpHelper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Reddit;
using Reddit.Controllers;

namespace JackHenry.RedditTracker.Api.Controllers
{

    [ApiController]
    public class RedditController : ControllerBase
    {
        private readonly RedditApiModel redditApiModel;
        private readonly IConfiguration _configuration;
        private readonly string _redditAppId;
        private readonly string _refreshToken;
        private readonly string _accessToken;

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
            var r = new RedditClient("SgzkNQuIzBP30zPmA8nJGg");
            return Ok();

        }

        [HttpGet("RedditPostsWithMostUpVotes")]
        public ActionResult<List<Subreddit>> RedditPostsWithMostUpVotes()
        {
            return RedditHttpHelper.GetPostsWithMostUpVotes(_redditAppId, _refreshToken, _accessToken);
        }

        [HttpGet("RedditUsersWithMostPosts")]
        public ActionResult<List<Subreddit>> RedditUsersWithMostPosts()
        {
            return RedditHttpHelper.GetUsersWithMostPosts(_redditAppId, _refreshToken, _accessToken);
        }
        [HttpGet("Throw")]
        public IActionResult Throw() => throw new Exception("An error has been encountered.");


        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
            [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }


        [Route("/error")]
        public IActionResult HandleError() =>
            Problem();
    }
}
