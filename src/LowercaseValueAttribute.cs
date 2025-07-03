using System;
using System.Text.Json.Serialization;

namespace Soenneker.Json.LowercaseValue;

/// <summary>
/// A System.Text.Json converter attribute for forcing the (de)serialized value to lowercase
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class LowercaseValueAttribute : JsonConverterAttribute
{
    public LowercaseValueAttribute() : base(typeof(LowercaseValueJsonConverter))
    {
    }
}