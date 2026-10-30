namespace MechanicShop.Domain.Common.Results;
/// <summary>
/// Represents an error that can occur during the execution of a command or query.
/// The Error record struct encapsulates information about the error, including its code, description, and type.
/// It provides static factory methods for creating instances of different error types, such as Failure, Unexpected
/// d, Validation, Conflict, NotFound, Unauthorized, and Forbidden. Each error type has a corresponding ErrorKind enumeration value.
/// </summary>
public readonly record struct Error
{
    private Error(string code, string description, ErrorKind type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    public string Code { get; }

    public string Description { get; }

    public ErrorKind Type { get; }

/// Static factory methods for creating instances of different error types.
/// <param name="code">The error code.</param>
/// <param name="description">The error description.</param>
/// <returns>An instance of the Error record struct representing the specified error type.</returns>
/// 
    public static Error Failure(string code = nameof(Failure), string description = "General failure.")
        => new(code, description, ErrorKind.Failure);

    public static Error Unexpected(string code = nameof(Unexpected), string description = "Unexpected error.")
        => new(code, description, ErrorKind.Unexpected);

    public static Error Validation(string code = nameof(Validation), string description = "Validation error")
        => new(code, description, ErrorKind.Validation);

    public static Error Conflict(string code = nameof(Conflict), string description = "Conflict error")
        => new(code, description, ErrorKind.Conflict);

    public static Error NotFound(string code = nameof(NotFound), string description = "Not found error")
        => new(code, description, ErrorKind.NotFound);

    public static Error Unauthorized(string code = nameof(Unauthorized), string description = "Unauthorized error")
        => new(code, description, ErrorKind.Unauthorized);

    public static Error Forbidden(string code = nameof(Forbidden), string description = "Forbidden error")
        => new(code, description, ErrorKind.Forbidden);

    public static Error Create(int type, string code, string description)
        => new(code, description, (ErrorKind)type);
}