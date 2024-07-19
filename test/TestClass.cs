namespace Soenneker.Json.LowercaseValue.Tests;

public class TestClass
{
    [LowercaseValue]
    public string Test { get; set; }

    public string Test1 { get; set; }

    public bool TestBool { get; set; }
}