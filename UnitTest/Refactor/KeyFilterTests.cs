using System.Collections.Generic;
using System.Reflection;
using Kata.Refactor.Before;
using Xunit;

namespace UnitTest.Refactor
{
    public class KeyFilterTests
    {
        private KeysFilter _keysFilter;
        private FakeSessionService _sessionService;

        public KeyFilterTests()
        {
            _keysFilter = new KeysFilter();
            _sessionService = new FakeSessionService();
            typeof(KeysFilter).InvokeMember("SessionService",
                BindingFlags.SetProperty | BindingFlags.NonPublic | BindingFlags.Instance, null, _keysFilter,
                new object[] {_sessionService});
        }

        [Fact]
        public void ShouldReturnEmptyListWhenMarksIsNull()
        {
            var result = _keysFilter.Filter(null, true);
            Assert.True(result.Count == 0);
        }

        [Fact]
        public void ShouldReturnEmptyListWhenMarksIsEmpty()
        {
            var result = _keysFilter.Filter(new List<string>(), true);
            Assert.True(result.Count == 0);
        }

        [Fact]
        public void ShouldGetGoldenKeysWhenTheyAreIncludedInSessionAndValid()
        {
            IList<string> sessionKeys = new List<string> {"GoldenKeyOne"};
            _sessionService.SessionKeys["GoldenKey"] = sessionKeys;
            var result = _keysFilter.Filter(sessionKeys, true);
            Assert.Equal(sessionKeys, result);
        }

        [Theory]
        [InlineData("GoldenKey", true)]
        [InlineData("SilverKey", false)]
        [InlineData("CopperKey", false)]
        public void ShouldGetFakeKeysWhenAreNotIncludedInSessionButValid(string sessionKey, bool isGoldenKey)
        {
            IList<string> marks = new List<string> {"eitherKeyFAKE"};
            var result = _keysFilter.Filter(marks, isGoldenKey);
            Assert.Equal(marks, result);
        }

        [Fact]
        public void ShouldFilterGoldenKeysWhenItIsNotIncludedInSessionButValid()
        {
            IList<string> sessionKeys = new List<string> {"GD01x00001"};
            IList<string> marks = new List<string> {"GD01x00001", "GD02x00001"};
            _sessionService.SessionKeys["GoldenKey"] = sessionKeys;
            var result = _keysFilter.Filter(marks, true);
            Assert.Equal(new List<string>() { "GD01x00001"}, result);
        }

        [Fact]
        public void ShouldNotFilterGoldenKeysWhenMarksAreValid()
        {
            IList<string> sessionKeys = new List<string> {"GD01x00001", "GD02x00001"};
            IList<string> marks = new List<string> {"GD01x00001", "GD02x00001"};
            _sessionService.SessionKeys["GoldenKey"] = sessionKeys;
            var result = _keysFilter.Filter(marks, true);
            Assert.Equal(marks, result);
        }

        [Fact]
        public void ShouldFilterGoldenKeysWhenHasInvalidMarks()
        {
            IList<string> sessionKeys = new List<string> {"GD01x00002", "GD02x00001"};
            IList<string> marks = new List<string> {"GD01x00002", "GD02x00001"};
            _sessionService.SessionKeys["GoldenKey"] = sessionKeys;
            var result = _keysFilter.Filter(marks, true);
            Assert.Equal(new List<string>() { "GD01x00002"}, result);
        }

        [Fact]
        public void ShouldFilterSilverOrCopperKeysWhenNotInSession()
        {
            IList<string> sessionSilverKeys = new List<string> {"SL01x00001"};
            IList<string> sessionCopperKeys = new List<string> {"CP01x00001"};
            IList<string> sessionGoldenKeys = new List<string> {"GD01x00001"};
            IList<string> marks = new List<string> {"GD01x00001", "CP01x00001", "SL01x00001", "CP01x00002"};
            _sessionService.SessionKeys["GoldenKey"] = sessionGoldenKeys;
            _sessionService.SessionKeys["SilverKey"] = sessionSilverKeys;
            _sessionService.SessionKeys["CopperKey"] = sessionCopperKeys;
            var result = _keysFilter.Filter(marks, false);
            Assert.Equal(new List<string>() { "CP01x00001", "SL01x00001"}, result);
        }
    }
}