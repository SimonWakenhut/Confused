using System.IO;
using Confused.Tests.Files;
using Xunit;

namespace Confused.Tests
{
    public class FileLoadingTests
    {
        private static readonly string Test1 = Load.ResourceFileContent("Test1.conf", "Files");

        [Fact]
        public void TestKeyValueNames()
        {
            File.WriteAllText("Test1.conf", Test1);

            var data = Parse.File("Test1.conf");

            Assert.Equal("Hello World!", data["Options"]["HelloMessage"]);
            Assert.Equal("Hello World!, Hey!", data["Options"]["StringArrayTest"]);
            Assert.Equal("23, 234 , 456456", data["Options"]["IntArrayTest"]);

            Assert.Equal("22", data["SSH"]["Port"]);
            Assert.Equal("Peter", data["SSH"]["UserName"]);

            Assert.Equal("21", data["FTP"]["Port"]);
            Assert.Equal("Peter", data["FTP"]["UserName"]);

            File.Delete("Test1.conf");
        }
    }
}