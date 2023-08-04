using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace UrlShortenerBff
{
    public static class Handler
    {
        [FunctionName("get-long-url-from-short-url")]
        public static IActionResult GetLongUrlFromShortUrl(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "{shortUrl}")] HttpRequest req,
            ILogger log,
            string shortUrl)
        {
            log.LogInformation("get-long-url-from-short-url invoked");
            return new NotFoundObjectResult($"No long URL found for the provided short URL '{shortUrl}'");
        }
    }
}
