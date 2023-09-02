using JackHenry.RedditTracker.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JackHenry.RedditTracker.Api.Test
{
    public class RedditControllerTest
    {
        private RedditController _redditController;
        private IConfiguration _configuration;
        
        public RedditControllerTest()
        {
            _redditController = new RedditController(_configuration);
        }
        
        [Fact]
        public void Test1()
        {
            var result = _redditController.RedditAuthorize();
            Assert.IsType<OkObjectResult>(result);
        }
    }
}