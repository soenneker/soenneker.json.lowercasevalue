[![](https://img.shields.io/nuget/v/soenneker.json.lowercasevalue.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.json.lowercasevalue/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.json.lowercasevalue/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.json.lowercasevalue/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.json.lowercasevalue.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.json.lowercasevalue/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.json.lowercasevalue/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.json.lowercasevalue/actions/workflows/codeql.yml)

# Soenneker.Json.LowercaseValue

A System.Text.Json converter attribute for forcing the (de)serialized value to lowercase.

## Install

```bash
dotnet add package Soenneker.Json.LowercaseValue
```

## Quick start

```csharp
using Soenneker.Json.LowercaseValue;

public sealed class Request
{
    [LowercaseValue]
    public string? Value { get; init; }
}
```

A System.Text.Json converter attribute for forcing the (de)serialized value to lowercase.

## What you get

- `LowercaseValueAttribute` — A System.Text.Json converter attribute for forcing the (de)serialized value to lowercase.
- `LowercaseValueJsonConverter` — A System.Text.Json converter attribute for forcing the (de)serialized value to lowercase.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `LowercaseValueJsonConverter.CanConvert(typeToConvert)` | Executes the can convert operation. | A value indicating whether the operation succeeded. |
| `LowercaseValueJsonConverter.Read(reader, typeToConvert, options)` | Executes the read operation. | The result of the operation. |
