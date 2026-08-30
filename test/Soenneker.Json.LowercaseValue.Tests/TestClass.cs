namespace Soenneker.Json.LowercaseValue.Tests;

public class TestClass
{
    [LowercaseValue]
    public string Test { get; set; } = null!;

    public string Test1 { get; set; } = null!;

    public bool TestBool { get; set; }
}
