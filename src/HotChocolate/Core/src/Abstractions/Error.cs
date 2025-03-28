#if NET8_0
using HotChocolate.Execution;
#endif
using HotChocolate.Properties;

namespace HotChocolate;

/// <summary>
/// Represents a GraphQL execution error.
/// </summary>
public class Error : IError
{
    private const string _code = "code";

    /// <summary>
    /// Initializes a new instance of <see cref="Error"/>.
    /// </summary>
    public Error(
        string message,
        string? code = null,
        Path? path = null,
        IReadOnlyList<Location>? locations = null,
        IReadOnlyDictionary<string, object?>? extensions = null,
        Exception? exception = null)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentException(
                AbstractionResources.Error_WithMessage_Message_Cannot_Be_Empty,
                nameof(message));
        }

        Message = message;
        Code = code;
        Path = path;
        Locations = locations;
        Extensions = extensions;
        Exception = exception;

        if (code is not null)
        {
            if (Extensions is null)
            {
                Extensions = new OrderedDictionary<string, object?> { { _code, code }, };
            }
            else if (!Extensions.TryGetValue(_code, out var value) || !ReferenceEquals(value, code))
            {
                Extensions = new OrderedDictionary<string, object?>(Extensions) { { _code, code }, };
            }
        }
    }

    /// <inheritdoc />
    public string Message { get; }

    /// <inheritdoc />
    public string? Code { get; }

    /// <inheritdoc />
    public Path? Path { get; }

    /// <inheritdoc />
    public IReadOnlyList<Location>? Locations { get; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, object?>? Extensions { get; }

    /// <inheritdoc />
    public Exception? Exception { get; }

    /// <inheritdoc />
    public IError WithMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentException(
                AbstractionResources.Error_WithMessage_Message_Cannot_Be_Empty,
                nameof(message));
        }

        return new Error(message, Code, Path, Locations, Extensions, Exception);
    }

    /// <inheritdoc />
    public IError WithCode(string? code)
    {
        IReadOnlyDictionary<string, object?>? extensions;

        if (string.IsNullOrEmpty(code))
        {
            extensions = Extensions;

            if (Extensions?.ContainsKey(_code) == true)
            {
                var temp = new OrderedDictionary<string, object?>(Extensions);
                temp.Remove(_code);
                extensions = temp;
            }

            return new Error(Message, null, Path, Locations, extensions, Exception);
        }

        extensions = Extensions is null
            ? new OrderedDictionary<string, object?> { [_code] = code, }
            : new OrderedDictionary<string, object?>(Extensions) { [_code] = code, };
        return new Error(Message, code, Path, Locations, extensions, Exception);
    }

    /// <inheritdoc />
    public IError WithPath(Path path)
        => new Error(Message, Code, path, Locations, Extensions, Exception);

    /// <inheritdoc />
    public IError WithPath(IReadOnlyList<object> path)
        => WithPath(Path.FromList(path));

    /// <inheritdoc />
    public IError WithLocations(IReadOnlyList<Location> locations)
        => new Error(Message, Code, Path, locations, Extensions, Exception);

    /// <inheritdoc />
    public IError WithExtensions(IReadOnlyDictionary<string, object?>? extensions)
        => extensions is null
            ? new Error(Message, Code, Path, Locations, null, Exception)
            : new Error(Message, Code, Path, Locations, extensions, Exception);

    /// <inheritdoc />
    public IError SetExtension(string key, object? value)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException(
                AbstractionResources.Error_SetExtension_Key_Cannot_Be_Empty,
                nameof(key));
        }

        var extensions = Extensions is { }
            ? new OrderedDictionary<string, object?>(Extensions)
            : new OrderedDictionary<string, object?>();
        extensions[key] = value;
        return new Error(Message, Code, Path, Locations, extensions, Exception);
    }

    /// <inheritdoc />
    public IError RemoveExtension(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException(
                AbstractionResources.Error_SetExtension_Key_Cannot_Be_Empty,
                nameof(key));
        }

        if (Extensions is null || !Extensions.ContainsKey(key))
        {
            return this;
        }

        var extensions = new OrderedDictionary<string, object?>(Extensions);
        extensions.Remove(key);

        return extensions.Count == 0
            ? new Error(Message, Code, Path, Locations, null, Exception)
            : new Error(Message, Code, Path, Locations, extensions, Exception);
    }

    /// <inheritdoc />
    public IError WithException(Exception? exception)
        => exception is null
            ? new Error(Message, Code, Path, Locations, Extensions)
            : new Error(Message, Code, Path, Locations, Extensions, exception);
}
