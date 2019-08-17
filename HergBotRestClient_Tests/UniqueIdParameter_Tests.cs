using System;

using NUnit.Framework;

using HergBot.RestClient.Http;

namespace HergBot.RestClient_Tests
{
    class UniqueIdParameter_Tests
    {
        private const string TEST_VALUE = "test_value";

        private UniqueIdParameter _parameter;

        [Test]
        public void Format_WithValue_ReturnsUidString()
        {
            _parameter = new UniqueIdParameter(TEST_VALUE);
            Assert.AreEqual($"/{TEST_VALUE}", _parameter.Format());
        }

        [Test]
        public void Format_WithNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _parameter = new UniqueIdParameter(null);
            });
        }

        [Test]
        public void Format_WithEmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _parameter = new UniqueIdParameter(string.Empty);
            });
        }

        [Test]
        public void Format_WithWhiteSpace_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _parameter = new UniqueIdParameter("  ");
            });
        }
    }
}
