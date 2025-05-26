using AwesomeAssertions;
using Xunit;

namespace Soenneker.Json.LowercaseValue.Tests;

public class ConverterTests
{
    [Fact]
    public void Should_convert_with_systemtextjson()
    {
        var testClass = new TestClass { Test = "BLAH", Test1 = "BLAR", TestBool = true };

        string result = System.Text.Json.JsonSerializer.Serialize(testClass);
        result.Should().NotBeNull();
        result.Should().Contain("true");
        result.Should().Contain("BLAR");
        result.Should().Contain("blah");
    }
}