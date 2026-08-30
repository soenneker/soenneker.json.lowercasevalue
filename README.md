[![](https://img.shields.io/nuget/v/soenneker.json.lowercasevalue.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.json.lowercasevalue/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.json.lowercasevalue/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.json.lowercasevalue/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.json.lowercasevalue/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.json.lowercasevalue/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.json.lowercasevalue.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.json.lowercasevalue/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.json.lowercasevalue/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.json.lowercasevalue/actions/workflows/codeql.yml)

# Soenneker.Json.LowercaseValue

Lowercases selected `System.Text.Json` string values during both serialization and deserialization.

## Install

```bash
dotnet add package Soenneker.Json.LowercaseValue
```

## Usage

```csharp
using Soenneker.Json.LowercaseValue;

public sealed class Request
{
    [LowercaseValue]
    public string? Region { get; init; }
}
```

```csharp
var request = new Request { Region = "US-EAST" };

string json = JsonSerializer.Serialize(request);
// {"Region":"us-east"}

Request? parsed = JsonSerializer.Deserialize<Request>(
    """{"Region":"EU-WEST"}""");
// parsed.Region == "eu-west"
```

Conversion uses invariant casing. It does not trim whitespace, normalize Unicode, or alter JSON property names. JSON `null` remains null; a non-string token for an attributed member throws `JsonException`.

The attribute can be placed on string properties and fields. Applying it to another type is unsupported.

You can also add `LowercaseValueJsonConverter` directly to `JsonSerializerOptions.Converters`, but that lowercases every string value handled by those options. Prefer the attribute when only specific fields have a lowercase wire contract.
