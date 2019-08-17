using NUnit.Framework;

using HergBot.RestClient.Http;

namespace HergBot.RestClient_Tests
{
    public class JsonBodyParameter_Tests
    {
        private const string EMPTY_JSON_OBJECT = "{}";

        private const string TEST_KEY = "test_key";

        private const string TEST_VALUE = "test_value";

        private JsonBodyParameter _parameter;

        [SetUp]
        public void SetUp()
        {
            _parameter = new JsonBodyParameter();
        }

        [Test]
        public void Format_WithNoData_ReturnsEmptyJsonObject()
        {
            Assert.AreEqual(EMPTY_JSON_OBJECT, _parameter.Format());
        }

        [Test]
        public void Format_WithOneValue_ReturnsJsonString()
        {
            _parameter.AddValue(TEST_KEY, TEST_VALUE);
            Assert.AreEqual($"{{\"{TEST_KEY}\":\"{TEST_VALUE}\"}}", _parameter.Format());
        }

        [Test]
        public void Format_WithMultipleValues_ReturnsJsonString()
        {
            _parameter.AddValue("one", "ONE");
            _parameter.AddValue("two", "TWO");
            _parameter.AddValue("three", "THREE");
            Assert.AreEqual("{\"one\":\"ONE\",\"two\":\"TWO\",\"three\":\"THREE\"}", _parameter.Format());
        }
    }
}
