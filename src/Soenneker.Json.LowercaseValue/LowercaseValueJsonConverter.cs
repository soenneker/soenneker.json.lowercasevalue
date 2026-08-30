using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using Soenneker.Extensions.String;

namespace Soenneker.Json.LowercaseValue;

/// <summary>
/// Converts JSON string values to invariant lowercase when reading and writing.
/// </summary>
public sealed class LowercaseValueJsonConverter : JsonConverter<object>
{
    // Static cached exception messages to reduce allocation cost for frequently thrown exceptions.
    private const string _cannotConvertError = $"{nameof(LowercaseValueJsonConverter)} cannot be applied to the specified type.";

    /// <summary>
    /// Determines whether the requested type is <see cref="string"/>.
    /// </summary>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <returns><see langword="true"/> for <see cref="string"/>; otherwise, <see langword="false"/>.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(string);
    }

    /// <summary>
    /// Reads a JSON string and converts it to invariant lowercase.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <param name="options">The options.</param>
    /// <returns>The result of the operation.</returns>
    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert != typeof(string))
            throw new InvalidOperationException(_cannotConvertError);

        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException($"Expected a JSON string but found {reader.TokenType}.");

        return reader.GetString()?.ToLowerInvariantFast();
    }

    /// <summary>
    /// Writes a string as an invariant-lowercase JSON string.
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
