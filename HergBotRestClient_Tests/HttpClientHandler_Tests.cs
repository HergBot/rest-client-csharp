using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using HergBot.RestClient.Http;

namespace HergBot.RestClient_Tests
{
    public class HttpClientHandler_Tests
    {
        private const string TEST_AUTH_TOKEN = "ihavethepower";

        private HttpClientHandler _client;

        [SetUp]
        public void SetUp()
        {
            _client = new HttpClientHandler();
        }

        [Test]
        public void GetBearerToken_WithToken_IsSet()
        {
            _client.SetBearerToken(TEST_AUTH_TOKEN);
            string token = _client.GetBearerToken();
            Assert.AreEqual(TEST_AUTH_TOKEN, token);
        }

        [Test]
        public void GetBearerToken_NoToken_IsNull()
        {
            string token = _client.GetBearerToken();
            Assert.IsNull(token);
        }
    }
}
