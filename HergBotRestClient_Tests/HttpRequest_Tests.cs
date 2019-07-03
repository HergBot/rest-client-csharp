using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HergBot.RestClient.Http;

using Moq;
using NUnit.Framework;

namespace HergBotRestClient_Tests
{
    public class HttpRequest_Tests
    {
        private const string VALID_URL = "http://www.fake.url";

        private const string VALID_AUTH_TOKEN = "1234567890";

        [Test]
        public async Task Test()
        {
            // Mock out the GetAsync method for the HttpClient
            Mock<HttpClient> httpClientMock = new Mock<HttpClient>();
            httpClientMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));
            HttpRequest test = new HttpRequest(VALID_AUTH_TOKEN, VALID_URL);
            HttpResponse response = await test.Send(HttpVerb.GET);
            Console.WriteLine(response);
        }

        private void Mock200()
        {
            Mock<HttpMessageHandler> mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler
                .Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
        }
    }
}
