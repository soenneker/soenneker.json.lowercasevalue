using System;
using System.Text.Json.Serialization;

namespace Soenneker.Json.LowercaseValue;

/// <summary>
/// Applies invariant-lowercase conversion to a string property or field during JSON reads and writes.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class LowercaseValueAttribute : JsonConverterAttribute
{
    /// <summary>
    /// Creates the converter attribute.
    /// </summary>
    public LowercaseValueAttribute() : base(typeof(LowercaseValueJsonConverter))
    {
    }
}
