using Confused.Tests.Files;
using Xunit;

namespace Confused.Tests
{
    public class ConverterTests
    {
        private static readonly string Test1 = Load.ResourceFileContent("Test1.conf", "Files");

        [Fact]
        public void ArrayConvert()
        {
            var data = Parse.String(Test1);

            var stringArray = Parse.Array<string>(data["Options"]["StringArrayTest"]);

            Assert.Equal("Hello World!", stringArray[0]);
            Assert.Equal("Hey!", stringArray[1]);

            var intArray = Parse.Array<int>(data["Options"]["IntArrayTest"]);

            Assert.Equal(23, intArray[0]);
            Assert.Equal(234, intArray[1]);
            Assert.Equal(456456, intArray[2]);
        }

        [Fact]
        public void ValueConvert()
        {
            var data = Parse.String(Test1);
            Assert.Equal(22, Parse.Value<int>(data["SSH"]["Port"]));
        }
    }
}