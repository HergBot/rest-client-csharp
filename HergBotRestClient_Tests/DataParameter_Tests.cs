using System;

using NUnit.Framework;

using HergBot.RestClient.Http;

namespace HergBot.RestClient_Tests
{
    public class DataParameter_Tests
    {
        private const string TEST_KEY = "test_key";

        private const string TEST_VALUE = "test_value";

        private DataParameter _parameter;

        [SetUp]
        public void SetUp()
        {
            _parameter = new DataParameter();
        }

        [Test]
        public void AddValue_WithData_AddsValue()
        {
            _parameter.AddValue(TEST_KEY, TEST_VALUE);
            string value = _parameter.GetValue(TEST_KEY);
            Assert.AreEqual(TEST_VALUE, value);
        }

        [Test]
        public void AddValue_WithDuplicateKey_ThrowsException()
        {
            _parameter.AddValue(TEST_KEY, TEST_VALUE);
            Assert.Throws<ArgumentException>(() =>
            {
                _parameter.AddValue(TEST_KEY, TEST_VALUE);
            });
        }

        [Test]
        public void AddValue_WithNullKey_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _parameter.AddValue(null, TEST_VALUE);
            });
        }

        [Test]
        public void GetValue_WithNoData_ReturnsNull()
        {
            string value = _parameter.GetValue(TEST_KEY);
            Assert.AreEqual(null, value);
        }

        [Test]
        public void GetValue_WithData_ReturnsValue()
        {
            _parameter.AddValue(TEST_KEY, TEST_VALUE);
            string value = _parameter.GetValue(TEST_KEY);
            Assert.AreEqual(TEST_VALUE, value);
        }

        [Test]
        public void GetValue_WithNullKey_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _parameter.GetValue(null);
            });
        }

        [Test]
        public void ClearValues_WithData_ClearsData()
        {
            _parameter.AddValue(TEST_KEY, TEST_VALUE);
            _parameter.ClearValues();
            string value = _parameter.GetValue(TEST_KEY);
            Assert.AreEqual(null, value);
        }
    }
}
