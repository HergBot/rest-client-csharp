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

        private const string TEST_RESPONSE = "{\"response\": \"test\"}";

        private Mock<IHttpClient> _mockHttpClient;

        private HttpRequest _testRequest;

        [SetUp]
        public void SetUp()
        {
            _mockHttpClient = new Mock<IHttpClient>();
            _testRequest = new HttpRequest(_mockHttpClient.Object, VALID_AUTH_TOKEN, VALID_URL);
        }

        [Test]
        public async Task Get_Empty_200()
        {
            MockResponse(HttpVerb.GET, HttpStatusCode.OK, TEST_RESPONSE);
            HttpResponse response = await _testRequest.Send(HttpVerb.GET);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.Status);
        }

        private void MockResponse(HttpVerb verb, HttpStatusCode status, string response)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(status);
            responseMessage.Content = new StringContent(response);

            switch(verb)
            {
                case HttpVerb.DELETE:
                    _mockHttpClient.Setup(x => x.DeleteAsync(It.IsAny<string>()))
                        .ReturnsAsync(responseMessage);
                    break;
                case HttpVerb.GET:
                    _mockHttpClient.Setup(x => x.GetAsync(It.IsAny<string>()))
                        .ReturnsAsync(responseMessage);
                    break;
                case HttpVerb.POST:
                    _mockHttpClient.Setup(x => x.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                        .ReturnsAsync(responseMessage);
                    break;
                case HttpVerb.PUT:
                    _mockHttpClient.Setup(x => x.PutAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                        .ReturnsAsync(responseMessage);
                    break;
                default:
                    throw new NotImplementedException($"HTTP Verb '{verb.ToString()}' not implemented");
            }
        }
    }
}
