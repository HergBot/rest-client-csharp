using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Moq;
using NUnit.Framework;

using HergBot.RestClient.Http;

namespace HergBot.RestClient_Tests
{
    public class HttpRequest_Tests
    {
        private const string VALID_URL = "http://www.fake.url";

        private const string TEST_RESPONSE = "{\"response\": \"test\"}";

        private const string TEST_KEY = "test_key";

        private const string TEST_VALUE = "test_value";

        private const string REFUSED_ERROR = "Connection Refused";

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
        public void Send_PatchRequest_ThrowsNotImplemented()
        {
            Assert.ThrowsAsync<NotImplementedException>(async () => await _testRequest.Send(HttpVerb.PATCH));
        }

        [Test]
        public async Task Send_RefusedRequest_ReturnsError()
        {
            _mockHttpClient.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ThrowsAsync(new HttpRequestException(REFUSED_ERROR));
            HttpResponse response = await _testRequest.Send(HttpVerb.GET);
            Assert.IsFalse(response.Success);
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.Status);
            Assert.AreEqual(REFUSED_ERROR, response.Response);
        }

        [Test]
        public void Send_NullUrlRequest_ThrowsInvalidOperation()
        {
            IHttpClient client = new RestClient.Http.HttpClientHandler();
            HttpRequest request = new HttpRequest(client, null);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await request.Send(HttpVerb.GET));
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
