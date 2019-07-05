using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using HergBot.RestClient.Http;

namespace HergBotRestClient_Tests
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
        public void SetBearerToken_IsSet()
        {

        }
    }
}
