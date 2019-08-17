using NUnit.Framework;

using HergBot.RestClient.Http;

namespace HergBot.RestClient_Tests
{
    public class QueryParameter_Tests
    {
        private const string TEST_KEY = "test_key";

        private const string TEST_VALUE = "test_value";

        private QueryParameter _parameter;

        [SetUp]
        public void SetUp()
        {
            _parameter = new QueryParameter();
        }

        [Test]
        public void Format_WithNoData_ReturnsEmptyString()
        {
            Assert.AreEqual(string.Empty, _parameter.Format());
        }

        [Test]
        public void Format_WithOneValue_ReturnsQueryString()
        {
            _parameter.AddValue(TEST_KEY, TEST_VALUE);
            Assert.AreEqual($"?{TEST_KEY}={TEST_VALUE}", _parameter.Format());
        }

        [Test]
        public void Format_WithMultipleValues_ReturnsQueryString()
        {
            _parameter.AddValue("one", "ONE");
            _parameter.AddValue("two", "TWO");
            _parameter.AddValue("three", "THREE");
            Assert.AreEqual("?one=ONE&two=TWO&three=THREE", _parameter.Format());
        }
    }
}
