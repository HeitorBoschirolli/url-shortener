using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using UrlShortenerBff;

namespace UrlShortenerBffTests;

[TestClass]
public class HandlerTest
{
    [TestMethod]
    public void ShouldReturnNotFoundAlways()
    {
        var request = Substitute.For<HttpRequest>();
        var logger = Substitute.For<ILogger>();
        var shortUrl = string.Empty;

        IActionResult response = Handler.GetLongUrlFromShortUrl(request, logger, shortUrl);

        Assert.IsTrue(response is NotFoundObjectResult);
        var responseAsObjectNotFound = response as NotFoundObjectResult;
        Assert.IsNotNull(responseAsObjectNotFound);
        Assert.AreEqual(responseAsObjectNotFound.Value, "No long URL found for the provided short URL ''");
    }
}