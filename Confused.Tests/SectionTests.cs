using System.Linq;
using Confused.Tests.Files;
using Xunit;

namespace Confused.Tests
{
    public class SectionTests
    {
        private static readonly string Test1 = Load.ResourceFileContent("Test1.conf", "Files");

        [Fact]
        public void CountSections()
        {
            var data = Parse.String(Test1);
            Assert.Equal(3, data.Count);
        }

        [Fact]
        public void TestNames()
        {
            var data = Parse.String(Test1);
            string[] names = {"Options", "SSH", "FTP"};

            Assert.True(names.ToList().All(x => data.Keys.Contains(x)));
        }
    }
}