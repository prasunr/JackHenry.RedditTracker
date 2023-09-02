using System.Diagnostics;
using JackHenry.RedditTracker.Common;
using JackHenry.RedditTracker.Helper.HttpHelper;
using Microsoft.AspNetCore.Diagnostics;
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
