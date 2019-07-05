using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HergBot.RestClient.Http;
using NUnit.Framework;

namespace HergBot.RestClient_Tests
{
    public class HttpResponse_Tests
    {
        private const string TEST_URL = "http://www.test.url";

        private const string TEST_RESPONSE = "{\"response\": \"test\"}";

        [Test]
        public void Response_MatchesExpected()
        {
            HttpResponse response = new HttpResponse(TEST_URL, HttpStatusCode.OK, TEST_RESPONSE, HttpVerb.GET);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(TEST_URL, response.RequestUrl);
            Assert.AreEqual(HttpStatusCode.OK, response.Status);
            Assert.AreEqual(TEST_RESPONSE, response.Response);
            Assert.AreEqual(HttpVerb.GET, response.Verb);
        }

        [Test]
        [TestCase(HttpStatusCode.Continue)]
        [TestCase(HttpStatusCode.SwitchingProtocols)]
        public void Response_StatusCodeIn100s_IsSuccessful(HttpStatusCode code)
        {
            HttpResponse response = new HttpResponse(TEST_URL, code, TEST_RESPONSE, HttpVerb.GET);
            Assert.IsTrue(response.Success);
        }

        [Test]
        [TestCase(HttpStatusCode.OK)]
        [TestCase(HttpStatusCode.Created)]
        [TestCase(HttpStatusCode.Accepted)]
        [TestCase(HttpStatusCode.NoContent)]
        public void Response_StatusCodeIn200s_IsSuccessful(HttpStatusCode code)
        {
            HttpResponse response = new HttpResponse(TEST_URL, code, TEST_RESPONSE, HttpVerb.GET);
            Assert.IsTrue(response.Success);
        }

        [Test]
        [TestCase(HttpStatusCode.MultipleChoices)]
        [TestCase(HttpStatusCode.MovedPermanently)]
        [TestCase(HttpStatusCode.Found)]
        [TestCase(HttpStatusCode.NotModified)]
        public void Response_StatusCodeIn300s_IsSuccessful(HttpStatusCode code)
        {
            HttpResponse response = new HttpResponse(TEST_URL, code, TEST_RESPONSE, HttpVerb.GET);
            Assert.IsTrue(response.Success);
        }

        [Test]
        [TestCase(HttpStatusCode.BadRequest)]
        [TestCase(HttpStatusCode.Unauthorized)]
        [TestCase(HttpStatusCode.Forbidden)]
        [TestCase(HttpStatusCode.NotFound)]
        [TestCase(HttpStatusCode.MethodNotAllowed)]
        public void Response_StatusCodeIn400s_IsNotSuccessful(HttpStatusCode code)
        {
            HttpResponse response = new HttpResponse(TEST_URL, code, TEST_RESPONSE, HttpVerb.GET);
            Assert.IsFalse(response.Success);
        }

        [Test]
        [TestCase(HttpStatusCode.InternalServerError)]
        [TestCase(HttpStatusCode.BadGateway)]
        [TestCase(HttpStatusCode.ServiceUnavailable)]
        [TestCase(HttpStatusCode.GatewayTimeout)]
        public void Response_StatusCodeIn500s_IsNotSuccessful(HttpStatusCode code)
        {
            HttpResponse response = new HttpResponse(TEST_URL, code, TEST_RESPONSE, HttpVerb.GET);
            Assert.IsFalse(response.Success);
        }
    }
}
