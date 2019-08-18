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

namespace HergBot.RestClient_Tests
{
    public class HttpRequest_Tests
    {
        private const string VALID_URL = "http://www.fake.url";

        private const string TEST_RESPONSE = "{\"response\": \"test\"}";

        private const string TEST_KEY = "test_key";

        private const string TEST_VALUE = "test_value";

        private Mock<IHttpClient> _mockHttpClient;

        private HttpRequest _testRequest;

        [SetUp]
        public void SetUp()
        {
            _mockHttpClient = new Mock<IHttpClient>();
            _testRequest = new HttpRequest(_mockHttpClient.Object, VALID_URL);
        }

        [Test]
        public async Task Send_GetRequest_ReturnsResponse()
        {
            MockResponse(HttpVerb.GET, HttpStatusCode.OK, TEST_RESPONSE);
            HttpResponse response = await _testRequest.Send(HttpVerb.GET);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.Status);
        }

        [Test]
        public async Task Send_GetQueryRequest_ReturnsReponse()
        {
            QueryParameter query = new QueryParameter();
            query.AddValue(TEST_KEY, TEST_VALUE);
            MockResponse(HttpVerb.GET, HttpStatusCode.OK, TEST_RESPONSE);
            HttpResponse response = await _testRequest.Send(HttpVerb.GET, query);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.Status);
        }

        [Test]
        public async Task Send_GetUidRequest_ReturnsReponse()
        {
            UniqueIdParameter uid = new UniqueIdParameter(TEST_VALUE);
            MockResponse(HttpVerb.GET, HttpStatusCode.OK, TEST_RESPONSE);
            HttpResponse response = await _testRequest.Send(HttpVerb.GET, uid);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.Status);
        }

        [Test]
        public async Task Send_PostRequest_ReturnsResponse()
        {
            JsonBodyParameter body = new JsonBodyParameter();
            body.AddValue(TEST_KEY, TEST_VALUE);
            MockResponse(HttpVerb.POST, HttpStatusCode.OK, TEST_RESPONSE);
            HttpResponse response = await _testRequest.Send(HttpVerb.POST, null, body);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.Status);
        }

        [Test]
        public async Task Send_PutRequest_ReturnsResponse()
        {
            JsonBodyParameter body = new JsonBodyParameter();
            UniqueIdParameter uid = new UniqueIdParameter(TEST_VALUE);
            body.AddValue(TEST_KEY, TEST_VALUE);
            MockResponse(HttpVerb.PUT, HttpStatusCode.OK, TEST_RESPONSE);
            HttpResponse response = await _testRequest.Send(HttpVerb.PUT, uid, body);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.Status);
        }

        [Test]
        public async Task Send_DeleteRequest_ReturnsResponse()
        {
            UniqueIdParameter uid = new UniqueIdParameter(TEST_VALUE);
            MockResponse(HttpVerb.DELETE, HttpStatusCode.OK, TEST_RESPONSE);
            HttpResponse response = await _testRequest.Send(HttpVerb.DELETE, uid);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.Status);
        }

        [Test]
        public async Task Send_PatchRequest_ReturnsResponse()
        {
            Assert.ThrowsAsync<NotImplementedException>(() => _testRequest.Send(HttpVerb.PATCH));
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
