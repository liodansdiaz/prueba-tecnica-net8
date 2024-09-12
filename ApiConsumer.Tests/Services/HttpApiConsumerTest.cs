using System.Net;
using ApiConsumer.Services;
using Moq;
using Moq.Protected;
using Xunit;

namespace ApiConsumer.Tests.Services
{
    public class HttpApiConsumerTest
    {
        [Fact]
        public async Task ConsumeAsync_ValidUrl_PrintLinesToConsole()
        {
            //Arrange
            var handlerMock = new Mock<HttpMessageHandler>();

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            await writer.WriteAsync("Line1\nLine2\nLine3");
            await writer.FlushAsync();

            stream.Seek(0, SeekOrigin.Begin);

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StreamContent(stream)
                });

            var httpClient = new HttpClient(handlerMock.Object);
            var httpApiConsumer = new HttpApiConsumer(httpClient);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            await httpApiConsumer.ConsumeAsync("https://example.com");

            //Assert

            var output = stringWriter.ToString();

            Assert.Contains("Line1", output);
            Assert.Contains("Line2", output);
            Assert.Contains("Line3", output);

        }
    }
}
