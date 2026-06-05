using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using Soenneker.Extensions.String;

namespace Soenneker.Json.LowercaseValue;

/// <summary>
/// A System.Text.Json converter attribute for forcing the (de)serialized value to lowercase
/// </summary>
public sealed class LowercaseValueJsonConverter : JsonConverter<object>
{
    // Static cached exception messages to reduce allocation cost for frequently thrown exceptions.
    private const string _cannotConvertError = $"{nameof(LowercaseValueJsonConverter)} cannot be applied to the specified type.";

    /// <summary>
    /// Executes the can convert operation.
    /// </summary>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <returns>A value indicating whether the operation succeeded.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(string);
    }

    /// <summary>
    /// Executes the read operation.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <param name="options">The options.</param>
    /// <returns>The result of the operation.</returns>
    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert != typeof(string))
            throw new InvalidOperationException(_cannotConvertError);

        return reader.GetString()?.ToLowerInvariantFast();
    }

    /// <summary>
    /// Executes the write operation.
    /// </summary>
    /// <param name="writer">The writer.</param>
    /// <param name="value">The value.</param>
    /// <param name="options">The options.</param>
    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        if (value is not string stringValue)
            throw new InvalidOperationException(_cannotConvertError);

        writer.WriteStringValue(stringValue.ToLowerInvariantFast());
    }
}