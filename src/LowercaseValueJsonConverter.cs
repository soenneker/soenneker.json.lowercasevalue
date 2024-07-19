using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using Soenneker.Extensions.String;

namespace Soenneker.Json.LowercaseValue;

/// <summary>
/// A System.Text.Json converter attribute for forcing the (de)serialized value to lowercase
/// </summary>
public class LowercaseValueJsonConverter : JsonConverter<object>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(string);
    }

    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == typeof(string))
        {
            string? value = reader.GetString();
            return value?.ToLowerInvariantFast();
        }

        throw new InvalidOperationException($"LowercaseValueJsonConverter cannot be applied to {typeToConvert}.");
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        if (value is string stringValue)
        {
            string toLower = stringValue.ToLowerInvariantFast();

            writer.WriteStringValue(toLower);
        }
        else
        {
            throw new InvalidOperationException($"LowercaseValueJsonConverter cannot be applied to {value.GetType()}.");
        }
    }
}